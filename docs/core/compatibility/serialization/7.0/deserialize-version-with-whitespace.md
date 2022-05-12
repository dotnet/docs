---
title: "Breaking change: Deserialize Version with leading/trailing whitespace"
description: Learn about the .NET 7 breaking change for deserializing Version types with leading or trailing whitespace.
ms.date: 01/11/2022
---
# Deserialize Version type with leading or trailing whitespace

<xref:System.Text.Json.JsonSerializer> now throws an exception while deserializing <xref:System.Version> types that have leading or trailing whitespace.

## Previous behavior

Prior to .NET 7, deserializing <xref:System.Version> types that have leading or trailing whitespace was permitted.

## New behavior

Started in .NET 7, <xref:System.Text.Json.JsonSerializer> throws a <xref:System.FormatException> when deserializing <xref:System.Version> types that have leading or trailing whitespace.

## Version introduced

.NET 7 Preview 1

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

.NET has optimized the implementation of the underlying <xref:System.Version> converter. This resulted in the implementation being made to align with the behavior for other primitive types supported by <xref:System.Text.Json?displayProperty=fullName>, for example, <xref:System.DateTime> and <xref:System.Guid>, which also disallow leading and trailing spaces.

## Recommended action

To get the old behavior back, add a custom converter for the <xref:System.Version> type that permits whitespace:

```csharp
internal sealed class VersionConverter : JsonConverter<Version>
{
    public override Version Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? versionString = reader.GetString();
        if (Version.TryParse(versionString, out Version? result))
        {
            return result;
        }

        ThrowHelper.ThrowJsonException();
        return null;
    }

    public override void Write(Utf8JsonWriter writer, Version value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
```

## Affected APIs

- <xref:System.Text.Json.JsonSerializer.Deserialize%2A?displayProperty=fullName>
- <xref:System.Text.Json.JsonSerializer.DeserializeAsync%2A?displayProperty=fullName>
