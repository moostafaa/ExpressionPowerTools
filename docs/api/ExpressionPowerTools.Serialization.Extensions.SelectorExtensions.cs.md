﻿# SelectorExtensions Class

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Extensions](ExpressionPowerTools.Serialization.Extensions.n.md) > **SelectorExtensions**

Extensions for selecting [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) .

```csharp
public static class SelectorExtensions
```

Inheritance [Object](https://docs.microsoft.com/dotnet/api/system.object) → **SelectorExtensions**

## Constructors

| Ctor | Description |
| :-- | :-- |
| [static SelectorExtensions()](ExpressionPowerTools.Serialization.Extensions.SelectorExtensions.ctor.md#static-selectorextensions) | Initializes a new instance of the [SelectorExtensions](ExpressionPowerTools.Serialization.Extensions.SelectorExtensions.cs.md) class. |
## Methods

| Method | Description |
| :-- | :-- |
| [Void ByMemberInfo&lt;T>(MemberSelector&lt;T> memberSelector, T member)](ExpressionPowerTools.Serialization.Extensions.SelectorExtensions.ByMemberInfo.m.md) | Pass the [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) directly. |
| [Void ByNameForType&lt;T>(MemberSelector&lt;T> memberSelector, Type type, String memberName)](ExpressionPowerTools.Serialization.Extensions.SelectorExtensions.ByNameForType.m.md) | Pass the [MemberInfo](https://docs.microsoft.com/dotnet/api/system.reflection.memberinfo) using name on [Type](https://docs.microsoft.com/dotnet/api/system.type) . |
| [Void ByResolver&lt;T, TTarget>(MemberSelector&lt;T> memberSelector, Expression&lt;Func&lt;TTarget, Object>> resolver)](ExpressionPowerTools.Serialization.Extensions.SelectorExtensions.ByResolver.m.md) |  |

---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/8/2020 3:10:02 AM | (c) Copyright 2020 Jeremy Likness. | 0.8.6-alpha |