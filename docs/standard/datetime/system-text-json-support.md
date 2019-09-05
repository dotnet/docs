---
title: DateTime and DateTimeOffset support in System.Text.Json
description: An overview of how DateTime and DateTimeOffset types are supported in the System.Text.Json library.
ms.technology: dotnet-standard
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

The System.Text.Json library parses and writes <xref:System.DateTime> and <xref:System.DateTimeOffset> values according to the ISO 8601:-2019 extended profile.
[Converters](https://docs.microsoft.com/dotnet/api/system.text.json.serialization.jsonconverter-1?view=netcore-3.0) provide custom support for serializing and deserializing with <xref:System.Text.Json.JsonSerializer>.
Custom support can also be implemented when using <xref:System.Text.Json.Utf8JsonReader> and <xref:System.Text.Json.Utf8JsonWriter>.

## Support for the ISO 8601-1:2019 format

The <xref:System.Text.Json.JsonSerializer>, <xref:System.Text.Json.Utf8JsonReader>, <xref:System.Text.Json.Utf8JsonWriter>,
and <xref:System.Text.Json.JsonElement> types parse and write <xref:System.DateTime> and <xref:System.DateTimeOffset>
text representations according to the extended profile of the ISO 8601-1:2019 format; for example, 2019-07-26T16:59:57-05:00.

<xref:System.DateTime> and <xref:System.DateTimeOffset> data can be serialized with <xref:System.Text.Json.JsonSerializer>:

[!code-csharp[example-serializing-with-jsonserializer](~/samples/snippets/standard/datetime/json/serializing-with-jsonserializer.cs)]

They can also be deserialized with <xref:System.Text.Json.JsonSerializer>:

[!code-csharp[example-deserializing-with-jsonserializer-valid](~/samples/snippets/standard/datetime/json/deserializing-with-jsonserializer-valid.cs)]

With default options, input <xref:System.DateTime> and <xref:System.DateTimeOffset> text representations must conform to the extended ISO 8601-1:2019 profile.
Attempting to deserialize representations that don't conform to the profile will cause <xref:System.Text.Json.JsonSerializer> to throw a <xref:System.Text.Json.JsonException>:

[!code-csharp[example-deserializing-with-jsonserializer-error](~/samples/snippets/standard/datetime/json/deserializing-with-jsonserializer-error.cs)]

The <xref:System.Text.Json.JsonDocument> provides structured access to the contents of a JSON payload, including <xref:System.DateTime>
and <xref:System.DateTimeOffset> representations. The example below shows how, when given a collection of temperatures, the average
temperature on Mondays can be calculated:

[!code-csharp[example-computing-with-jsondocument-valid](~/samples/snippets/standard/datetime/json/computing-with-jsondocument-valid.cs)]

Attempting to compute the average temperature given a payload with non-compliant <xref:System.DateTime> representations will cause <xref:System.Text.Json.JsonDocument>
to throw a <xref:System.FormatException>:

[!code-csharp[example-computing-with-jsondocument-error](~/samples/snippets/standard/datetime/json/computing-with-jsondocument-error.cs)]

The lower level <xref:System.Text.Json.Utf8JsonWriter> writes <xref:System.DateTime> and <xref:System.DateTimeOffset> data:

[!code-csharp[example-writing-with-utf8jsonwriter](~/samples/snippets/standard/datetime/json/writing-with-utf8jsonwriter.cs)]

<xref:System.Text.Json.Utf8JsonReader> parses <xref:System.DateTime> and <xref:System.DateTimeOffset> data:

[!code-csharp[example-reading-with-utf8jsonreader-valid](~/samples/snippets/standard/datetime/json/reading-with-utf8jsonreader-valid.cs)]

Attempting to read non-compliant formats with <xref:System.Text.Json.Utf8JsonReader> will cause it to throw a <xref:System.FormatException>:

[!code-csharp[example-reading-with-utf8jsonreader-error](~/samples/snippets/standard/datetime/json/reading-with-utf8jsonreader-error.cs)]

## Custom support for <xref:System.DateTime> and <xref:System.DateTimeOffset>

### When using <xref:System.Text.Json.JsonSerializer>

If you want the serializer to perform custom parsing or formatting, you can implement
[custom converters](https://docs.microsoft.com/dotnet/api/system.text.json.serialization.jsonconverter-1?view=netcore-3.0).
Here are a few examples:

#### Using `DateTime(Offset).Parse` and `DateTime(Offset).ToString`

If you can't determine the formats of your input <xref:System.DateTime> or <xref:System.DateTimeOffset> text representations, you can use the
`DateTime(Offset).Parse` method in your converter read logic. This allows you to use .NET's extensive support for parsing various
<xref:System.DateTime> and <xref:System.DateTimeOffset> text formats, including non-ISO 8601 strings and ISO 8601 formats that don't conform to
the extended ISO 8601-1:2019 profile. This approach is significantly less performant than using the serializer's native implementation.

For serializing, you can use the `DateTime(Offset).ToString` method in your converter write logic. This allows you to write <xref:System.DateTime>
and <xref:System.DateTimeOffset> values using any of the
[standard date and time formats](https://docs.microsoft.com/dotnet/standard/base-types/standard-date-and-time-format-strings), and the
[custom date and time formats](https://docs.microsoft.com/dotnet/standard/base-types/custom-date-and-time-format-strings).
This is also significantly less performant than using the serializer's native implementation.

[!code-csharp[example-showing-datetime-parse](~/samples/snippets/standard/datetime/json/datetime-converter-examples/example1/Program.cs)]

> [!NOTE]
> When implementing <xref:System.Text.Json.Serialization.JsonConverter%601>, and `T` is <xref:System.DateTime>, the `typeToConvert` parameter will always be `typeof(DateTime)`.
The parameter is useful for handling polymorphic cases and when using generics to get `typeof(T)` in a performant way.

#### Using <xref:System.Buffers.Text.Utf8Parser> and <xref:System.Buffers.Text.Utf8Formatter>

You can use fast UTF-8-based parsing and formatting methods in your converter logic if your input <xref:System.DateTime> or <xref:System.DateTimeOffset>
text representations are compliant with one of the "R", "l", "O", or "G"
[standard date and time format strings](https://docs.microsoft.com/dotnet/standard/base-types/standard-date-and-time-format-strings),
or you want to write according to one of these formats. This is much faster than using `DateTime(Offset).Parse` and `DateTime(Offset).ToString`.

This example shows a custom converter that serializes and deserializes <xref:System.DateTime> values according to
[the "R" standard format](https://docs.microsoft.com/dotnet/standard/base-types/standard-date-and-time-format-strings#the-rfc1123-r-r-format-specifier):

[!code-csharp[example-showing-utf8-parser-and-formatter](~/samples/snippets/standard/datetime/json/datetime-converter-examples/example2/Program.cs)]

> [!NOTE]
> The "R" standard format will always be 29 characters long.

#### Using `DateTime(Offset).Parse` as a fallback to the serializer's native parsing

If you generally expect your input <xref:System.DateTime> or <xref:System.DateTimeOffset> data to conform to the extended ISO 8601-1:2019 profile,
you can use the serializer's native parsing logic. You can also implement a fallback mechanism just in case.
This example shows that, after failing to parse a <xref:System.DateTime> text representation using <xref:System.Text.Json.Utf8JsonReader.TryGetDateTime(System.DateTime@)>,
the converter successfully parses the data using <xref:System.DateTime.Parse(System.String)>.

[!code-csharp[example-showing-datetime-parse-as-fallback](~/samples/snippets/standard/datetime/json/datetime-converter-examples/example3/Program.cs)]

### When writing with <xref:System.Text.Json.Utf8JsonWriter>

If you want to write a custom <xref:System.DateTime> or <xref:System.DateTimeOffset> text representation with <xref:System.Text.Json.Utf8JsonWriter>,
you can format your custom representation to a <xref:System.String>, `ReadOnlySpan<Byte>`, `ReadOnlySpan<Char>`, or <xref:System.Text.Json.JsonEncodedText>,
then pass it to the corresponding <xref:System.Text.Json.Utf8JsonWriter.WriteStringValue> method.

The following example shows how a custom <xref:System.DateTime> format can be created with <xref:System.DateTime.ToString(System.String,System.IFormatProvider)>,
then written with the <xref:System.Text.Json.Utf8JsonWriter.WriteStringValue(System.String)> method:

[!code-csharp[example-custom-writing-with-utf8jsonwriter](~/samples/snippets/standard/datetime/json/custom-writing-with-utf8jsonwriter.cs)]

### When reading with <xref:System.Text.Json.Utf8JsonReader>

If you want to read a custom <xref:System.DateTime> or <xref:System.DateTimeOffset> text representation with <xref:System.Text.Json.Utf8JsonReader>,
you can get the value of the current JSON token as a <xref:System.String> using <xref:System.Text.Json.Utf8JsonReader.GetString>, then parse the value
using custom logic.

The following example shows how a custom <xref:System.DateTimeOffset> text representation can be retrieved using <xref:System.Text.Json.Utf8JsonReader.GetString>,
then parsed using <xref:System.DateTimeOffset.ParseExact(System.String, System.String, System.Globalization.IFormatProvider)>:

[!code-csharp[example-custom-reading-with-utf8jsonreader](~/samples/snippets/standard/datetime/json/custom-reading-with-utf8jsonreader.cs)]

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
	([The Sortable ("s") Format Specifier](https://docs.microsoft.com/dotnet/standard/base-types/standard-date-and-time-format-strings#the-sortable-s-format-specifier))
	2. "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'FFFFFFF"

4. "'Full date''T''Time hour'':''Minute''Time offset'"
	1. "yyyy'-'MM'-'dd'T'HH':'mmZ"
	2. "yyyy'-'MM'-'dd'T'HH':'mm('+'/'-')HH':'mm"

5. 'Date time'
	1. "yyyy'-'MM'-'dd'T'HH':'mm':'ssZ"
	2. "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'FFFFFFFZ"
	3. "yyyy'-'MM'-'dd'T'HH':'mm':'ss('+'/'-')HH':'mm"
	4. "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'FFFFFFF('+'/'-')HH':'mm"

If there are decimal fractions for seconds, there must be at least one digit; `2019-07-26T00:00:00.` is not allowed.
While up to 16 fractional digits are allowed, only the first seven are parsed. Anything beyond that is considered a zero.
For example, `2019-07-26T00:00:00.1234567890` will be parsed as if it is `2019-07-26T00:00:00.1234567`.
This is to stay compatible with the <xref:System.DateTime> implementation, which is limited to this resolution.

Leap seconds are not supported.

### Support for formatting

The following levels of granularity are defined for formatting:

1. "'Full date''T''Partial time'"
	1. "yyyy'-'MM'-'dd'T'HH':'mm':'ss"
		([The Sortable ("s") Format Specifier](https://docs.microsoft.com/dotnet/standard/base-types/standard-date-and-time-format-strings#the-sortable-s-format-specifier))

		Used to format a <xref:System.DateTime> without fractional seconds and without offset information.

	2. "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'FFFFFFF"

		Used to format a <xref:System.DateTime> with fractional seconds but without offset information.

2. 'Date time'
	1. "yyyy'-'MM'-'dd'T'HH':'mm':'ssZ"

		Used to format a <xref:System.DateTime> or <xref:System.DateTimeOffset> without fractional seconds but with a UTC offset.

	2. "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'FFFFFFFZ"

		Used to format a <xref:System.DateTime> or <xref:System.DateTimeOffset> with fractional seconds and with a UTC offset.

	3. "yyyy'-'MM'-'dd'T'HH':'mm':'ss('+'/'-')HH':'mm"

		Used to format a <xref:System.DateTime> or <xref:System.DateTimeOffset> without fractional seconds but with a local offset.

	4. "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'FFFFFFF('+'/'-')HH':'mm"

		Used to format a <xref:System.DateTime> or <xref:System.DateTimeOffset> with fractional seconds and with a local offset.

If present, a maximum of 7 fractional digits are written. This aligns with the <xref:System.DateTime> implementation, which is limited to this resolution.