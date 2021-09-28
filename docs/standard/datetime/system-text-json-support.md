---
title: DateTime and DateTimeOffset support in System.Text.Json
description: An overview of how DateTime and DateTimeOffset types are supported in the System.Text.Json library.
author: layomia
ms.author: laakinri
ms.date: 07/22/2019
helpviewer_keywords:
  - "JSON, Serializer, Utf8"
  - "JSON DateTime, JSON DateTimeOffset"
  - "DateTime, DateTimeOffset"
  - "JsonSerializer, Utf8JsonReader, Utf8JsonWriter, JsonElement, JsonDocument"
  - "JSON Serializer, JSON Reader, JSON Writer"
  - "Converter, JSON Converter, DateTime Converter"
  - "ISO, ISO 8601, ISO 8601-1:2019"
---
# DateTime and DateTimeOffset support in System.Text.Json

The System.Text.Json library parses and writes <xref:System.DateTime> and <xref:System.DateTimeOffset> values according to the ISO 8601-1:2019 extended profile.
[Converters](xref:System.Text.Json.Serialization.JsonConverter%601) provide custom support for serializing and deserializing with <xref:System.Text.Json.JsonSerializer>.
Custom support can also be implemented when using <xref:System.Text.Json.Utf8JsonReader> and <xref:System.Text.Json.Utf8JsonWriter>.

## Support for the ISO 8601-1:2019 format

The <xref:System.Text.Json.JsonSerializer>, <xref:System.Text.Json.Utf8JsonReader>, <xref:System.Text.Json.Utf8JsonWriter>,
and <xref:System.Text.Json.JsonElement> types parse and write <xref:System.DateTime> and <xref:System.DateTimeOffset>
text representations according to the extended profile of the ISO 8601-1:2019 format; for example, 2019-07-26T16:59:57-05:00.

<xref:System.DateTime> and <xref:System.DateTimeOffset> data can be serialized with <xref:System.Text.Json.JsonSerializer>:

:::code language="csharp" source="snippets/system-text-json-support/csharp/serializing-with-jsonserializer/Program.cs":::

They can also be deserialized with <xref:System.Text.Json.JsonSerializer>:

:::code language="csharp" source="snippets/system-text-json-support/csharp/deserializing-with-jsonserializer-valid/Program.cs":::

With default options, input <xref:System.DateTime> and <xref:System.DateTimeOffset> text representations must conform to the extended ISO 8601-1:2019 profile.
Attempting to deserialize representations that don't conform to the profile will cause <xref:System.Text.Json.JsonSerializer> to throw a <xref:System.Text.Json.JsonException>:

:::code language="csharp" source="snippets/system-text-json-support/csharp/deserializing-with-jsonserializer-error/Program.cs":::

The <xref:System.Text.Json.JsonDocument> provides structured access to the contents of a JSON payload, including <xref:System.DateTime>
and <xref:System.DateTimeOffset> representations. The example below shows how, when given a collection of temperatures, the average
temperature on Mondays can be calculated:

:::code language="csharp" source="snippets/system-text-json-support/csharp/computing-with-jsondocument-valid/Program.cs":::

Attempting to compute the average temperature given a payload with non-compliant <xref:System.DateTime> representations will cause <xref:System.Text.Json.JsonDocument>
to throw a <xref:System.FormatException>:

:::code language="csharp" source="snippets/system-text-json-support/csharp/computing-with-jsondocument-error/Program.cs":::

The lower level <xref:System.Text.Json.Utf8JsonWriter> writes <xref:System.DateTime> and <xref:System.DateTimeOffset> data:

:::code language="csharp" source="snippets/system-text-json-support/csharp/writing-with-utf8jsonwriter/Program.cs":::

<xref:System.Text.Json.Utf8JsonReader> parses <xref:System.DateTime> and <xref:System.DateTimeOffset> data:

:::code language="csharp" source="snippets/system-text-json-support/csharp/reading-with-utf8jsonreader-valid/Program.cs":::

Attempting to read non-compliant formats with <xref:System.Text.Json.Utf8JsonReader> will cause it to throw a <xref:System.FormatException>:

:::code language="csharp" source="snippets/system-text-json-support/csharp/reading-with-utf8jsonreader-error/Program.cs":::

## Custom support for <xref:System.DateTime> and <xref:System.DateTimeOffset>

### When using <xref:System.Text.Json.JsonSerializer>

If you want the serializer to perform custom parsing or formatting, you can implement
[custom converters](xref:System.Text.Json.Serialization.JsonConverter%601).
Here are a few examples:

#### Using `DateTime(Offset).Parse` and `DateTime(Offset).ToString`

If you can't determine the formats of your input <xref:System.DateTime> or <xref:System.DateTimeOffset> text representations, you can use the
`DateTime(Offset).Parse` method in your converter read logic. This allows you to use .NET's extensive support for parsing various
<xref:System.DateTime> and <xref:System.DateTimeOffset> text formats, including non-ISO 8601 strings and ISO 8601 formats that don't conform to
the extended ISO 8601-1:2019 profile. This approach is significantly less performant than using the serializer's native implementation.

For serializing, you can use the `DateTime(Offset).ToString` method in your converter write logic. This allows you to write <xref:System.DateTime>
and <xref:System.DateTimeOffset> values using any of the
[standard date and time formats](../base-types/standard-date-and-time-format-strings.md), and the
[custom date and time formats](../base-types/custom-date-and-time-format-strings.md).
This is also significantly less performant than using the serializer's native implementation.

:::code language="csharp" source="snippets/system-text-json-support/csharp/datetime-converter-examples/example1/Program.cs":::

> [!NOTE]
> When implementing <xref:System.Text.Json.Serialization.JsonConverter%601>, and `T` is <xref:System.DateTime>, the `typeToConvert` parameter will always be `typeof(DateTime)`.
The parameter is useful for handling polymorphic cases and when using generics to get `typeof(T)` in a performant way.

#### Using <xref:System.Buffers.Text.Utf8Parser> and <xref:System.Buffers.Text.Utf8Formatter>

You can use fast UTF-8-based parsing and formatting methods in your converter logic if your input <xref:System.DateTime> or <xref:System.DateTimeOffset>
text representations are compliant with one of the "R", "l", "O", or "G"
[standard date and time format strings](../base-types/standard-date-and-time-format-strings.md),
or you want to write according to one of these formats. This is much faster than using `DateTime(Offset).Parse` and `DateTime(Offset).ToString`.

This example shows a custom converter that serializes and deserializes <xref:System.DateTime> values according to
[the "R" standard format](../base-types/standard-date-and-time-format-strings.md#the-rfc1123-r-r-format-specifier):

:::code language="csharp" source="snippets/system-text-json-support/csharp/datetime-converter-examples/example2/Program.cs":::

> [!NOTE]
> The "R" standard format will always be 29 characters long.
>
> The "l" (lowercase "L") format is not documented with the other [standard date and time format strings](../base-types/standard-date-and-time-format-strings.md) because it is supported only by the `Utf8Parser` and `Utf8Formatter` types. The format is lowercase RFC 1123 (a lowercase version of the "R" format), for example: "thu, 25 jul 2019 06:36:07 gmt".

#### Using `DateTime(Offset).Parse` as a fallback to the serializer's native parsing

If you generally expect your input <xref:System.DateTime> or <xref:System.DateTimeOffset> data to conform to the extended ISO 8601-1:2019 profile,
you can use the serializer's native parsing logic. You can also implement a fallback mechanism just in case.
This example shows that, after failing to parse a <xref:System.DateTime> text representation using <xref:System.Text.Json.Utf8JsonReader.TryGetDateTime(System.DateTime@)>,
the converter successfully parses the data using <xref:System.DateTime.Parse(System.String)>.

:::code language="csharp" source="snippets/system-text-json-support/csharp/datetime-converter-examples/example3/Program.cs":::

#### Using Unix epoch date format

The following converters handle Unix epoch format with or without a time zone offset (values such as `/Date(1590863400000-0700)/` or `/Date(1590863400000)/`):

:::code language="csharp" source="../serialization/snippets/system-text-json-how-to-5-0/csharp/CustomConverterUnixEpochDate.cs" id="ConverterOnly":::

:::code language="csharp" source="../serialization/snippets/system-text-json-how-to-5-0/csharp/CustomConverterUnixEpochDateNoZone.cs" id="ConverterOnly":::

### When writing with <xref:System.Text.Json.Utf8JsonWriter>

If you want to write a custom <xref:System.DateTime> or <xref:System.DateTimeOffset> text representation with <xref:System.Text.Json.Utf8JsonWriter>,
you can format your custom representation to a <xref:System.String>, `ReadOnlySpan<Byte>`, `ReadOnlySpan<Char>`, or <xref:System.Text.Json.JsonEncodedText>,
then pass it to the corresponding <xref:System.Text.Json.Utf8JsonWriter.WriteStringValue%2A?displayProperty=nameWithType>
or <xref:System.Text.Json.Utf8JsonWriter.WriteString%2A?displayProperty=nameWithType> method.

The following example shows how a custom <xref:System.DateTime> format can be created with <xref:System.DateTime.ToString(System.String,System.IFormatProvider)>,
then written with the <xref:System.Text.Json.Utf8JsonWriter.WriteStringValue(System.String)> method:

:::code language="csharp" source="snippets/system-text-json-support/csharp/custom-writing-with-utf8jsonwriter/Program.cs":::

### When reading with <xref:System.Text.Json.Utf8JsonReader>

If you want to read a custom <xref:System.DateTime> or <xref:System.DateTimeOffset> text representation with <xref:System.Text.Json.Utf8JsonReader>,
you can get the value of the current JSON token as a <xref:System.String> using <xref:System.Text.Json.Utf8JsonReader.GetString>, then parse the value
using custom logic.

The following example shows how a custom <xref:System.DateTimeOffset> text representation can be retrieved using <xref:System.Text.Json.Utf8JsonReader.GetString>,
then parsed using <xref:System.DateTimeOffset.ParseExact(System.String,System.String,System.IFormatProvider)>:

:::code language="csharp" source="snippets/system-text-json-support/csharp/custom-reading-with-utf8jsonreader/Program.cs":::

## The extended ISO 8601-1:2019 profile in System.Text.Json

### Date and time components

The extended ISO 8601-1:2019 profile implemented in <xref:System.Text.Json> defines the following components for
date and time representations. These components are used to define various levels of granularity
supported when parsing and formatting <xref:System.DateTime> and <xref:System.DateTimeOffset> representations.

| Component       | Format                      | Description                                                                     |
|-----------------|-----------------------------|---------------------------------------------------------------------------------|
| Year            | "yyyy"                      | 0001-9999                                                                       |
| Month           | "MM"                        | 01-12                                                                           |
| Day             | "dd"                        | 01-28, 01-29, 01-30, 01-31 based on month/year                                  |
| Hour            | "HH"                        | 00-23                                                                           |
| Minute          | "mm"                        | 00-59                                                                           |
| Second          | "ss"                        | 00-59                                                                           |
| Second fraction | "FFFFFFF"                   | Minimum of one digit, maximum of 16 digits                                      |
| Time offset     | "K"                         | Either "Z" or "('+'/'-')HH':'mm"                                                |
| Partial time    | "HH':'mm':'ss[FFFFFFF]"     | Time without UTC offset information                                             |
| Full date       | "yyyy'-'MM'-'dd"            | Calendar date                                                                   |
| Full time       | "'Partial time'K"           | UTC of day or Local time of day with the time offset between local time and UTC |
| Date time       | "'Full date''T''Full time'" | Calendar date and time of day, e.g. 2019-07-26T16:59:57-05:00                   |

### Support for parsing

The following levels of granularity are defined for parsing:

1. 'Full date'
    1. "yyyy'-'MM'-'dd"

2. "'Full date''T''Hour'':''Minute'"
    1. "yyyy'-'MM'-'dd'T'HH':'mm"

3. "'Full date''T''Partial time'"
    1. "yyyy'-'MM'-'dd'T'HH':'mm':'ss"
    ([The Sortable ("s") Format Specifier](../base-types/standard-date-and-time-format-strings.md#the-sortable-s-format-specifier))
    2. "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'FFFFFFF"

4. "'Full date''T''Time hour'':''Minute''Time offset'"
    1. "yyyy'-'MM'-'dd'T'HH':'mmZ"
    2. "yyyy'-'MM'-'dd'T'HH':'mm('+'/'-')HH':'mm"

5. 'Date time'
    1. "yyyy'-'MM'-'dd'T'HH':'mm':'ssZ"
    2. "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'FFFFFFFZ"
    3. "yyyy'-'MM'-'dd'T'HH':'mm':'ss('+'/'-')HH':'mm"
    4. "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'FFFFFFF('+'/'-')HH':'mm"

    This level of granularity is compliant with [RFC 3339](https://tools.ietf.org/html/rfc3339#section-5.6), a widely adopted profile of ISO 8601 used for interchanging date and time information. However, there are a few restrictions in the System.Text.Json implementation.

    - RFC 3339 does not specify a maximum number of fractional-second digits, but specifies that at least one digit must follow the period, if a fractional-second section is present. The implementation in System.Text.Json allows up to 16 digits (to support interop with other programming languages and frameworks), but parses only the first seven. A <xref:System.Text.Json.JsonException> will be thrown if there are more than 16 fractional second digits when reading `DateTime` and `DateTimeOffset` instances.
    - RFC 3339 allows the "T" and "Z" characters to be "t" or "z" respectively, but allows applications to limit support to just the upper-case variants. The implementation in System.Text.Json requires them to be "T" and "Z". A <xref:System.Text.Json.JsonException> will be thrown if input payloads contain "t" or "z" when reading `DateTime` and `DateTimeOffset` instances.
    - RFC 3339 specifies that the date and time sections are separated by "T", but allows applications to separate them by a space (" ") instead. System.Text.Json requires date and time sections to be separated with "T". A <xref:System.Text.Json.JsonException> will be thrown if input payloads contain a space (" ") when reading `DateTime` and `DateTimeOffset` instances.

If there are decimal fractions for seconds, there must be at least one digit; `2019-07-26T00:00:00.` is not allowed.
While up to 16 fractional digits are allowed, only the first seven are parsed. Anything beyond that is considered a zero.
For example, `2019-07-26T00:00:00.1234567890` will be parsed as if it is `2019-07-26T00:00:00.1234567`.
This is to stay compatible with the <xref:System.DateTime> implementation, which is limited to this resolution.

Leap seconds are not supported.

### Support for formatting

The following levels of granularity are defined for formatting:

1. "'Full date''T''Partial time'"
    1. "yyyy'-'MM'-'dd'T'HH':'mm':'ss"
        ([The Sortable ("s") Format Specifier](../base-types/standard-date-and-time-format-strings.md#the-sortable-s-format-specifier))

        Used to format a <xref:System.DateTime> without fractional seconds and without offset information.

    2. "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'FFFFFFF"

        Used to format a <xref:System.DateTime> with fractional seconds but without offset information.

2. 'Date time'
    1. "yyyy'-'MM'-'dd'T'HH':'mm':'ssZ"

        Used to format a <xref:System.DateTime> without fractional seconds but with a UTC offset.

    2. "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'FFFFFFFZ"

        Used to format a <xref:System.DateTime> with fractional seconds and with a UTC offset.

    3. "yyyy'-'MM'-'dd'T'HH':'mm':'ss('+'/'-')HH':'mm"

        Used to format a <xref:System.DateTime> or <xref:System.DateTimeOffset> without fractional seconds but with a local offset.

    4. "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'FFFFFFF('+'/'-')HH':'mm"

        Used to format a <xref:System.DateTime> or <xref:System.DateTimeOffset> with fractional seconds and with a local offset.

    This level of granularity is compliant with [RFC 3339](https://tools.ietf.org/html/rfc3339#section-5.6).

If the [round-trip format](../base-types/standard-date-and-time-format-strings.md#the-round-trip-o-o-format-specifier) representation of a
<xref:System.DateTime> or <xref:System.DateTimeOffset> instance has trailing zeros in its fractional seconds, then <xref:System.Text.Json.JsonSerializer>
and <xref:System.Text.Json.Utf8JsonWriter> will format a representation of the instance without trailing zeros.
For example, a <xref:System.DateTime> instance whose [round-trip format](../base-types/standard-date-and-time-format-strings.md#the-round-trip-o-o-format-specifier)
representation is `2019-04-24T14:50:17.1010000Z`, will be formatted as `2019-04-24T14:50:17.101Z` by <xref:System.Text.Json.JsonSerializer>
and <xref:System.Text.Json.Utf8JsonWriter>.

If the [round-trip format](../base-types/standard-date-and-time-format-strings.md#the-round-trip-o-o-format-specifier) representation of a
<xref:System.DateTime> or <xref:System.DateTimeOffset> instance has all zeros in its fractional seconds, then <xref:System.Text.Json.JsonSerializer>
and <xref:System.Text.Json.Utf8JsonWriter> will format a representation of the instance without fractional seconds.
For example, a <xref:System.DateTime> instance whose [round-trip format](../base-types/standard-date-and-time-format-strings.md#the-round-trip-o-o-format-specifier)
representation is `2019-04-24T14:50:17.0000000+02:00`, will be formatted as `2019-04-24T14:50:17+02:00` by <xref:System.Text.Json.JsonSerializer>
and <xref:System.Text.Json.Utf8JsonWriter>.

Truncating zeros in fractional-second digits allows the smallest output needed to preserve information on a round trip to be written.

A maximum of 7 fractional-second digits are written. This aligns with the <xref:System.DateTime> implementation, which is limited to this resolution.
