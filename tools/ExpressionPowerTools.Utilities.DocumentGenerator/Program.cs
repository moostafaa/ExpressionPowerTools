﻿// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using ExpressionPowerTools.Core.Comparisons;
using ExpressionPowerTools.Serialization.EFCore.AspNetCore;
using ExpressionPowerTools.Serialization.EFCore.Http.Extensions;
using ExpressionPowerTools.Serialization.Serializers;
using ExpressionPowerTools.Utilities.DocumentGenerator.Hierarchy;
using ExpressionPowerTools.Utilities.DocumentGenerator.IO;
using ExpressionPowerTools.Utilities.DocumentGenerator.Parsers;

namespace ExpressionPowerTools.Utilities.DocumentGenerator
{
    /// <summary>
    /// Main documentatoin generation program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Types to reference for linked documentation.
        /// </summary>
        public static readonly Type[] ReferenceTypes = new[]
        {
            typeof(IHttpClientFactory),
        };

        /// <summary>
        /// Example types that map to the assemblies to document.
        /// </summary>
        private static readonly Type[] ExampleTypes = new[]
        {
            typeof(DefaultComparisonRules),
            typeof(BaseSerializer<,>),
            typeof(ExpressionPowerToolsEFCoreMiddleware),
            typeof(ClientExtensions),
            typeof(FileHelper),
        };

        /// <summary>
        /// Version informatoin file.
        /// </summary>
        private static readonly string VersionInfo = "../../../../../version.json";

        /// <summary>
        /// Root directory for documentation output.
        /// </summary>
        private static string rootDir = "../../../../../docs/api/";

        /// <summary>
        /// The main entry method.
        /// </summary>
        /// <param name="args">Optional arguments (not used).</param>
        private static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                rootDir = args[0];
            }

            try
            {
                Parse();
            }
            catch (Exception ex)
            {
                WriteError(ex.Message);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Write a success message using green.
        /// </summary>
        /// <param name="text">The text to write.</param>
        private static void WriteSuccess(string text) =>
            WriteColor(ConsoleColor.Green, text);

        /// <summary>
        /// Write a warning message using green.
        /// </summary>
        /// <param name="text">The text to write.</param>
        private static void WriteWarning(string text) =>
            WriteColor(ConsoleColor.Yellow, text);

        /// <summary>
        /// Write an error message using green.
        /// </summary>
        /// <param name="text">The text to write.</param>
        private static void WriteError(string text) =>
            WriteColor(ConsoleColor.Red, text);

        /// <summary>
        /// Writes text with the specified color.
        /// </summary>
        /// <param name="color">The text color.</param>
        /// <param name="text">The text to write.</param>
        private static void WriteColor(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Parse the files.
        /// </summary>
        private static void Parse()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var location = Directory.GetCurrentDirectory();
            var versionPath = Path.Combine(location, VersionInfo);
            Console.WriteLine($"Retrieving version info from {versionPath}...");
            var versionDoc = JsonDocument.Parse(File.ReadAllText(versionPath));
            string version = versionDoc.RootElement.GetProperty(nameof(version)).GetString();
            Console.WriteLine($"Docs version is {version}");
            var fileChecker = new FileHelper(location);
            var xmlParser = new XmlDocParser(fileChecker);
            var markdown = new DocsToMarkdownParser();
            var writer = new FileWriter(
                rootDir.StartsWith("..") ? Path.Combine(location, rootDir) : rootDir,
                version);
            Console.WriteLine("Parsing assemblies (pass 1)...");
            var assemblies = new List<(DocAssembly doc, AssemblyParser parser)>();
            foreach (var type in ExampleTypes)
            {
                var parser = new AssemblyParser(type.Assembly);
                var doc = parser.Parse();
                assemblies.Add((doc, parser));
            }

            WriteSuccess($"Parsed {ExampleTypes.Length} assemblies. Starting pass 2...");

            int fileCount = 0;
            long elapsed = 0;

            bool deleted = false;

            foreach (var (doc, parser) in assemblies)
            {
                parser.Parse(doc);
                Console.WriteLine($"Checking {doc.Name}...");
                var docName = $"{doc.Name}.xml";
                Console.Write($"Documentation file: {docName} exists? ");
                if (fileChecker.FileExists(docName))
                {
                    WriteSuccess("YES");
                }
                else
                {
                    WriteWarning("NO");
                }

                Console.WriteLine("Parsing XML documents...");
                xmlParser.ParseComments(docName, doc);
                Console.WriteLine("Transforming to markdown...");
                var docFile = markdown.Parse(doc);
                if (deleted == false)
                {
                    Console.WriteLine("Purging existing docs....");
                    writer.Purge();
                    deleted = true;
                }

                Console.WriteLine("Writing documentation...");
                writer.Write(docFile);
                stopwatch.Stop();
                elapsed += stopwatch.ElapsedMilliseconds;
                fileCount += docFile.FileCount;
                WriteSuccess("Success.");
            }

            WriteSuccess($"Processed {TypeCache.Cache.TypeCount} types and generated {fileCount} files in {elapsed}ms.");
        }
    }
}
