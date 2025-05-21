---
title: "Breaking change: Default serialization format for TimeSpan"
description: Learn about the .NET 6 servicing release breaking change where the default serialization format for TimeSpan in source generators has changed.
ms.date: 01/11/2022
ms.topic: how-to
---
# Default serialization format for TimeSpan

<xref:System.Text.Json?displayProperty=fullName> added support for <xref:System.TimeSpan> in .NET 6 GA, however this change did not include support for source generators. In .NET 6 servicing release 6.0.2, <xref:System.Text.Json?displayProperty=fullName> includes support for source-generator serialization of <xref:System.TimeSpan> values. This support changes the default serialization format for <xref:System.TimeSpan> values in source generators.

## Previous behavior

In .NET 6 GA, source generators serialize <xref:System.TimeSpan> values by outputting all public properties of the type, which is the default serialization behavior for objects:

```json
{"days":2,"hours":0,"milliseconds":0,"minutes":0,"seconds":1,"ticks":1728010000000,"totalDays":2.0000115740740743,"totalHours":48.000277777777775,"totalMilliseconds":172801000,"totalMinutes":2880.016666666667,"totalSeconds":172801}
```

## New behavior

In servicing release .NET 6.0.2, source generators serialize <xref:System.TimeSpan> values in the following format, which is consistent with the reflection-based serializer format:

```json
"2.00:00:01"
```

## Version introduced

.NET 6.0.2 (servicing release)

## Type of breaking change

This change might affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

[System.Text.Json source generation](../../../../standard/serialization/system-text-json/source-generation.md) is a new feature, and its serialization behavior should be as consistent as possible with the reflection-based serializer. This change simplifies migration to source generators.

## Recommended action

It's unlikely for users to depend on the current <xref:System.TimeSpan> serialization format, as it redundantly outputs all public properties of the type (which is the default serialization behavior for objects), and it doesn't roundtrip.

If you do depend on the existing behavior, the recommended course of action is to [author a custom converter](../../../../standard/serialization/system-text-json/converters-how-to.md) that outputs the needed properties from <xref:System.TimeSpan>:

```csharp
public class TimeSpanConverter : JsonConverter<TimeSpan>
{
    public void WriteValue(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteNumber("days", value.Days);
        writer.WriteNumber("hours", value.Hours);
        /* insert any needed properties here */
        writer.WriteEndObject();
    }
}
```

## Affected APIs

- <xref:System.Text.Json.JsonSerializer.Serialize%2A?displayProperty=fullName>

## See also

- [How to use source generation in System.Text.Json](../../../../standard/serialization/system-text-json/source-generation.md)
