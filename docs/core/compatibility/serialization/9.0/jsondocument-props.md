---
title: "Breaking change: Nullable JsonDocument properties deserialize to JsonValueKind.Null"
description: Learn about the breaking change in serialization in .NET 9 where nullable JsonDocument values deserialize to JsonValueKind.Null instead of null.
ms.date: 12/5/2024
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/43869
---

# Nullable JsonDocument properties deserialize to JsonValueKind.Null

Starting with .NET 9, deserializing `null` JSON values into <xref:System.Text.Json.JsonDocument> results in non-null documents of type <xref:System.Text.Json.JsonValueKind.Null?displayProperty=nameWithType>.

```csharp
using System.Text.Json;

var doc = JsonSerializer.Deserialize<JsonDocument>("null");

// Returns true in .NET 8 and false in .NET 9.
Console.WriteLine(doc is null);

// Returns false in .NET 8 and true in .NET 9.
Console.WriteLine(doc is { RootElement.ValueKind: JsonValueKind.Null });
```

## Version introduced

.NET 9

## Previous behavior

In .NET 8 and earlier versions, deserializing `null` JSON values into `JsonDocument` gives back `null` results.

```csharp
var doc = JsonSerializer.Deserialize<JsonDocument>("null");
Console.WriteLine(doc is null); // True.
```

## New behavior

Starting in .NET 9, deserializing `null` JSON values into `JsonDocument` gives back non-null instances of `JsonValueKind.Null`.

```csharp
var doc = JsonSerializer.Deserialize<JsonDocument>("null");
Console.WriteLine(doc is null); // False.
Console.WriteLine(doc is { RootElement.ValueKind: JsonValueKind.Null }); // True.
```

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change addresses an inconsistency between root-level JSON nulls and nested nulls in a document. It also makes it consistent with the behavior of the <xref:System.Text.Json.JsonDocument.Parse*?displayProperty=nameWithType> methods. The behavior of returning `null` was considered a bug and updated for alignment with the expected result.

## Recommended action

Update code that consumes deserialized objects containing `JsonDocument` types to expect `JsonValueKind.Null` instead of `null`.

## Affected APIs

* <xref:System.Text.Json.JsonSerializer.Deserialize*?displayProperty=fullName>
* <xref:System.Text.Json.JsonDocument?displayProperty=fullName>
