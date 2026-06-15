---
title: "Breaking change: CborReader and CborWriter enforce a default maximum nesting depth"
description: "Learn about the breaking change in .NET 11 where CborReader and CborWriter enforce a maximum nesting depth by default, throwing exceptions when the limit is exceeded."
ms.date: 06/12/2026
ai-usage: ai-assisted
---

# CborReader and CborWriter enforce a default maximum nesting depth

Starting in .NET 11, <xref:System.Formats.Cbor.CborReader> and <xref:System.Formats.Cbor.CborWriter> enforce a maximum nesting depth by default. Reading or writing CBOR data that exceeds the configured maximum depth throws an exception.

## Version introduced

.NET 11 Preview 5

## Previous behavior

Previously, `CborReader` and `CborWriter` had no maximum nesting depth limit. Reading or writing arbitrarily nested CBOR data structures succeeded without restriction.

```csharp
// Deeply nested CBOR data (100 levels of nested arrays)
var reader = new CborReader(deeplyNestedBuffer);

for (int i = 0; i < 100; i++)
{
    reader.ReadStartArray(); // Succeeded at any depth
}
```

```csharp
var writer = new CborWriter();

for (int i = 0; i < 2000; i++)
{
    writer.WriteStartArray(1); // Succeeded at any depth
}
```

## New behavior

Starting in .NET 11, `CborReader` throws <xref:System.Formats.Cbor.CborContentException> when reading a container (array, map, or indefinite-length string) that would exceed the maximum allowed depth (default: 64). `CborWriter` throws <xref:System.InvalidOperationException> when writing a container that would exceed the maximum allowed depth (default: 1000).

```csharp
// Throws CborContentException when nesting depth exceeds 64
var reader = new CborReader(deeplyNestedBuffer);

for (int i = 0; i < 65; i++)
{
    reader.ReadStartArray(); // Throws CborContentException on the 65th call
}
```

```csharp
// Throws InvalidOperationException when nesting depth exceeds 1000
var writer = new CborWriter();

for (int i = 0; i < 1001; i++)
{
    writer.WriteStartArray(1); // Throws InvalidOperationException on the 1001st call
}
```

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change limits the nesting depth to prevent excessive memory consumption and execution time. When you skip over a deeply nested array or map, the system must process every element in the structure, which can use a surprising amount of memory. This change is also consistent with the behavior of <xref:System.Text.Json.Utf8JsonReader> and <xref:System.Text.Json.Utf8JsonWriter>.

## Recommended action

If your application processes CBOR data nested more deeply than the defaults allow (64 levels for reading, 1000 levels for writing), use the new options types to specify a larger limit:

```csharp
// For reading CBOR data nested more than 64 levels deep
var options = new CborReaderOptions { MaxDepth = 256 };
var reader = new CborReader(data, options);
```

```csharp
// For writing CBOR data nested more than 1000 levels deep
var writerOptions = new CborWriterOptions { MaxDepth = 2000 };
var writer = new CborWriter(writerOptions);
```

> [!NOTE]
> Unlike `Utf8JsonReader`/`Utf8JsonWriter`, setting `MaxDepth = 0` in CBOR means *no nesting is allowed* (not "use the runtime default"). To use the runtime default, set `MaxDepth = -1` or omit the property when constructing `CborReaderOptions`/`CborWriterOptions`.

You cannot use an AppContext switch to restore the previous unlimited-depth behavior.

## Affected APIs

- <xref:System.Formats.Cbor.CborReader.ReadStartArray?displayProperty=fullName>
- <xref:System.Formats.Cbor.CborReader.ReadStartMap?displayProperty=fullName>
- <xref:System.Formats.Cbor.CborReader.ReadStartIndefiniteLengthByteString?displayProperty=fullName>
- <xref:System.Formats.Cbor.CborReader.ReadStartIndefiniteLengthTextString?displayProperty=fullName>
- <xref:System.Formats.Cbor.CborWriter.WriteStartArray(System.Int32)?displayProperty=fullName>
- <xref:System.Formats.Cbor.CborWriter.WriteStartIndefiniteLengthArray?displayProperty=fullName>
- <xref:System.Formats.Cbor.CborWriter.WriteStartMap(System.Nullable{System.Int32})?displayProperty=fullName>
- <xref:System.Formats.Cbor.CborWriter.WriteStartIndefiniteLengthMap?displayProperty=fullName>
