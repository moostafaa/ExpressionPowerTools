﻿# UnarySerializer.Deserialize Method

[Index](../index.md) > [ExpressionPowerTools.Serialization](ExpressionPowerTools.Serialization.a.md) > [ExpressionPowerTools.Serialization.Serializers](ExpressionPowerTools.Serialization.Serializers.n.md) > [UnarySerializer](ExpressionPowerTools.Serialization.Serializers.UnarySerializer.cs.md) > **Deserialize**

Deserializes a [UnaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.unaryexpression) .

## Overloads

| Overload | Description |
| :-- | :-- |
| [Deserialize(JsonElement json, SerializationState state)](#deserializejsonelement-json-serializationstate-state) | Deserializes a [UnaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.unaryexpression) . |
## Deserialize(JsonElement json, SerializationState state)

Deserializes a [UnaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.unaryexpression) .

```csharp
public virtual UnaryExpression Deserialize(JsonElement json, SerializationState state)
```

### Return Type

 [UnaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.unaryexpression)  - The [UnaryExpression](https://docs.microsoft.com/dotnet/api/system.linq.expressions.unaryexpression) .

### Parameters

| Parameter | Type | Description |
| :-- | :-- | :-- |
| `json` | [JsonElement](https://docs.microsoft.com/dotnet/api/system.text.json.jsonelement) | The serialized fragment. |
| `state` | [SerializationState](ExpressionPowerTools.Serialization.Serializers.SerializationState.cs.md) | State, such as [JsonSerializerOptions](https://docs.microsoft.com/dotnet/api/system.text.json.jsonserializeroptions) , for the deserialization. |



---

| Generated | Copyright | Version |
| :-- | :-: | --: |
| 9/4/2020 7:10:41 PM | (c) Copyright 2020 Jeremy Likness. | 0.8.5-alpha |