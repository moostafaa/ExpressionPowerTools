﻿# ExpressionExtensions.AsConstantExpression Method

[Index](../index.md) > [ExpressionPowerTools.Core](ExpressionPowerTools.Core.a.md) > [ExpressionPowerTools.Core.Extensions](ExpressionPowerTools.Core.Extensions.n.md) > [ExpressionExtensions](ExpressionPowerTools.Core.Extensions.ExpressionExtensions.cs.md) > **AsConstantExpression**

Wraps an item as a [ConstantExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.constantexpression) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [AsConstantExpression(Object obj)](#asconstantexpressionobject-obj) | Wraps an item as a [ConstantExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.constantexpression) . |
## AsConstantExpression(Object obj)

Wraps an item as a [ConstantExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.constantexpression) .

```csharp
public static ConstantExpression AsConstantExpression(Object obj)
```

### Return Type

 [ConstantExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.constantexpression)  - The [ConstantExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.constantexpression) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `obj` | [Object](https://docs.microsoft.com/dotnet/api/system.object) | The object to wrap. |

### Exceptions

| Exception | Description |
| :-- | :-- |
| [ArgumentNullException](https://docs.microsoft.com/dotnet/api/system.argumentnullexception) | Thrown when object is null. |

## Examples

For example:

```csharp

var target = this.AsConstantExpression();
            
```


---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/4/2020 7:10:41 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.5-alpha |