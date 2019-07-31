---
title: DateTime and DateTimeOffset support in System.Text.Json
description: An overview of how DateTime and DateTimeOffset types are supported in the System.Text.Json library.
ms.technology: dotnet-standard
author: layomia
ms.author: laakinri
ms.date: 07/22/2019
helpviewer_keywords:
  - "JSON DateTime"
  - "DateTimeOffset"
  - "Serializer, Utf8"
  - "JSON Reader, JSON Writer, times"
---
# DateTime and DateTimeOffset support in System.Text.Json

The <xref:System.Text.Json.JsonSerializer>, <xref:System.Text.Json.Utf8JsonReader>, <xref:System.Text.Json.Utf8JsonWriter>,
and <xref:System.Text.Json.JsonElement> parse and write <xref:System.DateTime> and <xref:System.DateTimeOffset>
text representations according to the extended profile of the ISO 8601-1:2019 format, e.g. 2019-07-26T16:59:57-05:00.

<xref:System.DateTime> and <xref:System.DateTimeOffset> data can be serialized with <xref:System.Text.Json.JsonSerializer>:

```csharp
Product p = new Product();
p.Name = "Banana";
p.ExpiryDate = new DateTime(2019, 7, 26);
string json = JsonSerializer.Serialize(p);

/// {"Name":"Banana","ExpiryDate":"2019-07-26T00:00:00"}
```

To deserialize:

```csharp
Product p = JsonSerializer.Deserialize<Product>(@"{""Name"":""Banana"",""ExpiryDate"":""2019-07-26T00:00:00""}");
Console.WriteLine(p.Name); // Banana
Console.WriteLine(p.ExpiryDate); // 7/26/2019 12:00:00 AM

// With default options, input DateTimes must conform to the native implementation of the ISO 8601-1:2019 profile.
try
{
	var _ = JsonSerializer.Deserialize<Product>(@"{""Name"":""Banana"",""ExpiryDate"":""26/07/2019""}");
}
catch (JsonException e)
{
	Console.WriteLine(e.Message);
	// The JSON value could not be converted to System.DateTime. Path: $.ExpiryDate | LineNumber: 0 | BytePositionInLine: 42.
}
```

The <xref:System.Text.Json.JsonDocument> provides structured access to the contents of a JSON payload, including <xref:System.DateTime>
and <xref:System.DateTimeOffset> representations. Given a collection of temperatures:

```json
[
    {
        "date": "2013-01-07T00:00:00Z",
        "temp": 23,
    },
    {
        "date": "2013-01-08T00:00:00Z",
        "temp": 28,
    },
    {
        "date": "2013-01-14T00:00:00Z",
        "temp": 8,
    },
]
```

The temperatures on Mondays can be averaged out:

```csharp
double ComputeAverageTemperatures(string json)
{
    var options = new JsonDocumentOptions
    {
        AllowTrailingCommas = true
    };

    using (JsonDocument document = JsonDocument.Parse(json, options))
    {
        int sumOfAllTemperatures = 0;
        int count = 0;

        foreach (JsonElement element in document.RootElement.EnumerateArray())
        {
            DateTimeOffset date = element.GetProperty("date").GetDateTimeOffset();

            if (date.DayOfWeek == DayOfWeek.Monday)
            {
                int temp = element.GetProperty("temp").GetInt32();
                sumOfAllTemperatures += temp;
                count++;
            }
        }

        var averageTemp = (double)sumOfAllTemperatures / count;
        return averageTemp;
    }
}
```

Given a payload with non-compliant <xref:System.DateTime> representations:

```json
[
    {
        "date": "2013/01/07 00:00:00Z",
        "temp": 23,
    },
    {
        "date": "2013/01/08 00:00:00Z",
        "temp": 28,
    },
    {
        "date": "2013/01/14 00:00:00Z",
        "temp": 8,
    },
]
```

Computing the average will fail:

```
var _ = ComputeAverageTemperatures(json);

// Unhandled exception. System.FormatException: One of the identified items was in an invalid format.
//    at System.Text.Json.JsonElement.GetDateTimeOffset()
```

The lower level <xref:System.Text.Json.Utf8JsonWriter> writes <xref:System.DateTime> and <xref:System.DateTimeOffset> data:

```csharp
var options = new JsonWriterOptions
{
    Indented = true
};

using (var stream = new MemoryStream())
{
    using (var writer = new Utf8JsonWriter(stream, options))
    {
        writer.WriteStartObject();
        writer.WriteString("date", DateTimeOffset.UtcNow);
        writer.WriteNumber("temp", 42);
        writer.WriteEndObject();
    }

    string json = Encoding.UTF8.GetString(stream.ToArray());
    Console.WriteLine(json);
}

// The example displays the following output:
// {
//     "date": "2019-07-26T00:00:00-05:00",
//     "temp": 42
// }
```

To read with <xref:System.Text.Json.Utf8JsonReader>:

```csharp
byte[] utf8Data = Encoding.UTF8.GetBytes(@"""2019-07-26T00:00:00""");

var json = new Utf8JsonReader(utf8Data);
while (json.Read())
{
    if (json.TokenType == JsonTokenType.String)
    {
        Console.WriteLine(json.TryGetDateTime(out DateTime datetime));
		// True
        
		Console.WriteLine(datetime);
		// 7/26/2019 12:00:00 AM
        
		Console.WriteLine(json.GetDateTime());
		// 7/26/2019 12:00:00 AM
    }
}
```

Reading non-compliant formats will fail:

```csharp
byte[] utf8Data = Encoding.UTF8.GetBytes(@"""2019/07/26 00:00:00""");

var json = new Utf8JsonReader(utf8Data);
while (json.Read())
{
    if (json.TokenType == JsonTokenType.String)
    {
        Console.WriteLine(json.TryGetDateTime(out DateTime datetime));
		// False
        
		Console.WriteLine(datetime);
		// 1/1/0001 12:00:00 AM
        
		var _ = json.GetDateTime();
		// Unhandled exception. System.FormatException: The JSON value is not in a supported DateTime format.
		//     at System.Text.Json.Utf8JsonReader.GetDateTime()
    }
}
```

## Custom support for <xref:System.DateTime> and <xref:System.DateTimeOffset> in `JsonSerializer`

If you want custom parsing or formatting at the serializer level, you can implement
[custom converters](https://docs.microsoft.com/dotnet/api/system.text.json.serialization.jsonconverter-1?view=netcore-3.0).
Here are a few examples:

### Using `DateTime(Offset).Parse` and `DateTime(Offset).ToString`

This allows you to use .NET's extensive support for parsing various <xref:System.DateTime> and <xref:System.DateTimeOffset> text formats,
including non-ISO 8601 strings and ISO 8601 formats that don't conform to the extended ISO 8601-1:2019 profile. This approach can be used
if you can't determine the input formats, but it is significantly less performant than using the serializer's native implementation.

[!code-csharp[example-showing-datetime-parse](~/samples/snippets/standard/datetime/json/datetime-converter-examples/example1/Program.cs)]

### Using <xref:System.Buffers.Text.Utf8Parser> and <xref:System.Buffers.Text.Utf8Formatter>

This allows you to use fast UTF-8-based parsing and formatting methods for <xref:System.DateTime> and <xref:System.DateTimeOffset> datathat is compliant
with one of the [Standard Date and Time Format Strings](https://docs.microsoft.com/dotnet/standard/base-types/standard-date-and-time-format-strings).
This is much faster than Example 1 and should be used if the input data isn't compliant with the extended ISO 8601-1:2019 profile but conforms to the
"R", "l", "O", or "G" standard format specifiers.

[!code-csharp[example-showing-utf8-parser-and-formatter](~/samples/snippets/standard/datetime/json/datetime-converter-examples/example2/Program.cs)]

### Using `DateTime(Offset).Parse` as a fallback to the serializers native parsing

This approach can be used if you generally expect the input <xref:System.DateTime> and <xref:System.DateTimeOffset> data to conform to the
extended ISO 8601-1:2019 profile, but want to have a fallback just in case.

[!code-csharp[example-showing-datetime-parse-as-fallback](~/samples/snippets/standard/datetime/json/datetime-converter-examples/example3/Program.cs)]

## Extended ISO 8601-1:2019 Profile in System.Text.Json

### Date and time components

The extended ISO 8601-1:2019 profile implemented in <xref:System.Text.Json> defines the following components for
date and time representations. These components are used to define various levels of date and time granularity
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
| Partial time    | "HH':'mm':'ss[FFFFFFF]"     |                                                                                 |
| Full date       | "yyyy'-'MM'-'dd"            |                                                                                 |
| Full time       | "'Partial time'K"           | UTC of day or Local time of day with the time offset between local time and UTC |
| Date time       | "'Full date''T''Full time'" | Extended calendar date and time of day                                          |

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

If there are decimal fractions for seconds, there must be at least one digit i.e. `2019-07-26T00:00:00.` is not allowed.
While up to 16 fractional digits are allowed, only the first seven are parsed. Anything beyond that is considered a zero.
For example, `2019-07-26T00:00:00.1234567890` will be parsed as if it is `2019-07-26T00:00:00.1234567`.
This is to stay compatible with the <xref:System.DateTime> implementation which is limited to this resolution.

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
