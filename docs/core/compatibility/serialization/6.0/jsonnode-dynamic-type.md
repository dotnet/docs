---
title: "Breaking change: JsonNode no longer supports dynamic type"
description: Learn about the breaking change in .NET 6 where the C# `dynamic` type can no longer be used to get and set properties on `JsonNode`.
ms.date: 08/11/2021
---
# JsonNode no longer supports C# `dynamic` type

In earlier .NET 6 preview versions, you could use the C# [`dynamic` type](../../../../csharp/language-reference/builtin-types/reference-types.md#the-dynamic-type) to get and set properties on the <xref:System.Text.Json.Nodes.JsonNode> class. Starting in Preview 7, you can no longer use `dynamic` for `JsonNode` properties.

## Old behavior

In earlier .NET 6 preview versions, the `dynamic` type could be used to get and set properties on the <xref:System.Text.Json.Nodes.JsonNode> class. For example:

```csharp
dynamic obj = JsonNode.Parse("{\"A\":42}");
int i = (int)obj.A;
```

## New behavior

Starting in .NET 6 Preview 7, the property name must be specified as a string in the indexer, and you can't use the `dynamic` type for the return value. For example:

```csharp
JsonNode obj = JsonNode.Parse("{\"A\":42}");
int i = (int)obj["A"];
```

## Change category

This change affects [*binary compatibility*](../../categories.md#binary-compatibility).

## Version introduced

.NET 6 Preview 7 (breaks functionality introduced in .NET 6 Preview 4)

## Reason for change

As discussed in [dotnet/runtime#53195](https://github.com/dotnet/runtime/issues/53195), the `dynamic` feature in C# is considered somewhat stale. Adding a dependency to a new API, that is, <xref:System.Text.Json.Nodes.JsonNode> and its derived classes, is not a good practice.

## Recommended action

Use the string-based property name.

If `dynamic` is necessary, you can use the workaround mentioned at [dotnet/runtime#42097](https://github.com/dotnet/runtime/issues/42097). That workaround will be verified and updated as necessary for .NET 6.

## Affected APIs

When the return value is assigned to a variable of type [`dynamic`](../../../../csharp/language-reference/builtin-types/reference-types.md#the-dynamic-type), the following methods are affected:

- <xref:System.Text.Json.Nodes.JsonNode.Parse%2A?displayProperty=fullName>

When the return value is assigned to a variable of type [`dynamic`](../../../../csharp/language-reference/builtin-types/reference-types.md#the-dynamic-type), the type parameter is `dynamic` or `object`, and `JsonSerializerOptions.UnknownTypeHandling == UnknownTypeHandling.JsonNode`, the following methods are affected:

- <xref:System.Text.Json.JsonSerializer.Deserialize%60%601(System.ReadOnlySpan{System.Byte},System.Text.Json.Serialization.Metadata.JsonTypeInfo{%60%600})?displayProperty=fullName>
- <xref:System.Text.Json.JsonSerializer.Deserialize%60%601(System.ReadOnlySpan{System.Byte},System.Text.Json.JsonSerializerOptions)?displayProperty=fullName>
- <xref:System.Text.Json.JsonSerializer.Deserialize%60%601(System.ReadOnlySpan{System.Char},System.Text.Json.Serialization.Metadata.JsonTypeInfo{%60%600})?displayProperty=fullName>
- <xref:System.Text.Json.JsonSerializer.Deserialize%60%601(System.ReadOnlySpan{System.Char},System.Text.Json.JsonSerializerOptions)?displayProperty=fullName>
- <xref:System.Text.Json.JsonSerializer.Deserialize%60%601(System.String,System.Text.Json.JsonSerializerOptions)?displayProperty=fullName>
- <xref:System.Text.Json.JsonSerializer.Deserialize%60%601(System.String,System.Text.Json.Serialization.Metadata.JsonTypeInfo{%60%600})?displayProperty=fullName>
- <xref:System.Text.Json.JsonSerializer.Deserialize%60%601(System.Text.Json.Utf8JsonReader@,System.Text.Json.Serialization.Metadata.JsonTypeInfo{%60%600})?displayProperty=fullName>
- <xref:System.Text.Json.JsonSerializer.Deserialize%60%601(System.Text.Json.Utf8JsonReader@,System.Text.Json.JsonSerializerOptions)?displayProperty=fullName>
- <xref:System.Text.Json.JsonSerializer.Deserialize%60%601(System.IO.Stream,System.Text.Json.JsonSerializerOptions)?displayProperty=fullName>
- <xref:System.Text.Json.JsonSerializer.Deserialize%60%601(System.IO.Stream,System.Text.Json.Serialization.Metadata.JsonTypeInfo{%60%600})?displayProperty=fullName>
