﻿// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq.Expressions;
using ExpressionPowerTools.Core.Contract;
using ExpressionPowerTools.Core.Signatures;

namespace ExpressionPowerTools.Core.Extensions
{
    /// <summary>
    /// Extension methods for fluent API over expressions.
    /// </summary>
    public static class ExpressionExtensions
    {
        /// <summary>
        /// Extracts the name of the target of an expression.
        /// </summary>
        /// <example>
        /// For example:
        /// <code lang="csharp">
        /// Expression{Func{string}} expr = () => foo;
        /// expr.MemberName(); // "foo"
        /// </code>
        /// </example>
        /// <typeparam name="T">The type of the target.</typeparam>
        /// <param name="expr">An expression that results in a parameter.</param>
        /// <returns>The name of the target.</returns>
        public static string MemberName<T>(
            this Expression<Func<T>> expr) =>
            ((MemberExpression)expr.Body).Member.Name;

        /// <summary>
        /// Provides a way to enumerate an expression tree.
        /// </summary>
        /// <example>
        /// For example:
        /// <code lang="csharp">
        /// var expr = Expression.Constant(this);
        /// var target = expr.AsEnumerable();
        /// </code>
        /// </example>
        /// <param name="expression">The <see cref="Expression"/> to recurse.</param>
        /// <exception cref="ArgumentNullException">Thrown when expression is null.</exception>
        /// <returns>The <see cref="IExpressionEnumerator"/> instance.</returns>
        public static IExpressionEnumerator AsEnumerable(
            this Expression expression)
        {
            Ensure.NotNull(() => expression);
            return new ExpressionEnumerator(expression);
        }

        /// <summary>
        /// Wraps an item as a <see cref="ConstantExpression"/>.
        /// </summary>
        /// <example>
        /// For example:
        /// <code lang="csharp">
        /// var target = this.AsConstantExpression();
        /// </code>
        /// </example>
        /// <param name="obj">The object to wrap.</param>
        /// <exception cref="ArgumentNullException">Thrown when object is null.</exception>
        /// <returns>The <see cref="ConstantExpression"/>.</returns>
        public static ConstantExpression AsConstantExpression(
            this object obj)
        {
            Ensure.NotNull(() => obj);
            return Expression.Constant(obj);
        }

        /// <summary>
        /// Creates a <see cref="ParameterExpression" /> based on the
        /// type of the object.
        /// </summary>
        /// <example>
        /// For example:
        /// <code lang="csharp">
        /// var target = this.AsParameterExpression();
        /// // target.Type == this.GetType()
        /// </code>
        /// </example>
        /// <param name="obj">The object to inspect.</param>
        /// <exception cref="ArgumentNullException">Thrown when object is null.</exception>
        /// <returns>The <see cref="ParameterExpression"/>.</returns>
        public static ParameterExpression AsParameterExpression(
            this object obj)
        {
            Ensure.NotNull(() => obj);
            return Expression.Parameter(obj.GetType());
        }

        /// <summary>
        /// Creates a <see cref="ParameterExpression"/> based on the
        /// <see cref="Type"/>.
        /// </summary>
        /// <example>
        /// For example:
        /// <code lang="csharp">
        /// var target = GetType().AsParameterExpression();
        /// // target.Type == GetType()
        /// </code>
        /// </example>
        /// <param name="type">The <see cref="Type"/> to use.</param>
        /// <exception cref="ArgumentNullException">Thrown when type is null.</exception>
        /// <returns>The <see cref="ParameterExpression"/>.</returns>
        public static ParameterExpression AsParameterExpression(
            this Type type)
        {
            Ensure.NotNull(() => type);
            return Expression.Parameter(type);
        }

        /// <summary>
        /// Extracts the parameter from a member expression.
        /// </summary>
        /// <example>
        /// For example:
        /// <code lang="csharp">
        /// var result = ExpressionExtensions
        ///     .CreateParameterExpression{Foo, string}(
        ///        foo => foo.Bar);
        /// // result.Type == typeof(string)
        /// // result.Name == "Bar";
        /// </code>
        /// </example>
        /// <typeparam name="T">The parent type.</typeparam>
        /// <typeparam name="TValue">The member type.</typeparam>
        /// <param name="value">An expression that evaluates to the member.</param>
        /// <returns>The <see cref="ParameterExpression"/>.</returns>
        public static ParameterExpression
            CreateParameterExpression<T, TValue>(
            Expression<Func<T, TValue>> value)
        {
            Ensure.NotNull(() => value);
            var lambda = value as LambdaExpression;
            var body = lambda.Body as MemberExpression;
            return Expression.Parameter(
                body.Type,
                body.Member.Name);
        }
    }
}
