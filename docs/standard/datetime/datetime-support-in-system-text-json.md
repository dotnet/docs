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

The <xref:System.Text.Json.JsonSerializer>, <xref:System.Text.Json.Utf8JsonReader>, <xref:System.Text.Json.Utf8JsonWriter>, and <xref:System.Text.Json.JsonElement> parse and write <xref:System.DateTime> and <xref:System.DateTimeOffset> text representations according to the extended profile of the ISO 8601-1:2019 format, e.g. 2019-07-26T16:59:57-05:00.

Date and time data can be serialized with <xref:System.Text.Json.JsonSerializer>:

```csharp
Product p = new Product();
p.Name = "Banana";
p.ExpiryDate = new DateTime(2019, 7, 26);
string json = JsonSerializer.Serialize(p);

/// {"Name":"Banana","ExpiryDate":"2019-07-26T00:00:00"}
```

To deserialize:

```csharp
Product p = JsonSerialize.Deserialize<Product>(@"{""Name"":""Banana"",""ExpiryDate"":""2019-07-26T00:00:00""}");
Console.WriteLine(p.Name) // Banana
Console.WriteLine(p.ExpiryDate) // 7/26/2019 12:00:00 AM
```

The <xref:System.Text.Json.JsonDocument> provides structured access to the contents of a JSON payload, including date and time values. Given a collection of temperatures:

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

The lower level <xref:System.Text.Json.Utf8JsonWriter> writes date and time data:

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

var json = new Utf8JsonReader(utf8Data, isFinalBlock: true, state: default);
while (json.Read())
{
    if (json.TokenType == JsonTokenType.String)
    {
        Console.WriteLine(json.TryGetDateTime(out DateTime datetime)); // True
        Console.WriteLine(datetime) // 7/26/2019 12:00:00 AM
        Console.WriteLine(json.GetDateTime()); // 7/26/2019 12:00:00 AM
    }
}
```
## Custom support for date and times in `JsonSerializer`

If you want custom parsing or formatting at the serializer level, you can implement [custom converters](https://github.com/dotnet/corefx/issues/36639). Here are a few examples:

### Using `DateTime(Offset).Parse` and `DateTime(Offset).ToString`.

This allows you to use .NET's extensive support for parsing various date and time formats, including non-ISO 8601 strings and ISO 8601 formats that don't conform to the Extended ISO 8601-1:2019 profile.
This approach can be used if you can't determine the input date and time formats, but it is significantly less performant than using the serializer's native implementation.

[!code-csharp[example-showing-datetime-parse](~/samples/snippets/standard/datetime/json/datetime-converter-examples/example1/Program.cs)]

### Using `UTF8Parser` and `UTF8Formatter`.

This allows you to use fast parsing and formatting methods for UTF-8 date and time data that is compliant with one of the [Standard Date and Time Format Strings](https://docs.microsoft.com/dotnet/standard/base-types/standard-date-and-time-format-strings).
This is much faster than Example 1 and should be used if the input data isn't compliant with the Extended ISO 8601-1:2019 profile but conforms to the "R", "l", "O", or "G" standard format specifiers.

[!code-csharp[example-showing-utf8-parser-and-formatter](~/samples/snippets/standard/datetime/json/datetime-converter-examples/example2/Program.cs)]

### Using `DateTime(Offset).Parse` as a fallback to the serializers native parsing.

This approach can be used if you generally expect the input date and time data to conform to the Extended ISO 8601-1:2019 profile, but want to have a fallback just in case.

```csharp
public class DateTimeConverterExample3 : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.String)
        {
            throw new JsonException();
        }

        ReadOnlySpan<byte> valueSpan = reader.ValueSpan;

        if (!reader.TryGetDateTime(out DateTime value))
        {
            value = DateTime.Parse(Encoding.UTF8.GetString(valueSpan));
        }

        return value;
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
```

## Extended ISO 8601-1:2019 Profile in System.Text.Json

### Date and time components

ISO 8601-1:2019 defines the following components for date and time representations:

| Component         | Format                                                     | ISO 8601-1:2019 spec | Description                                                                                                     |
|-------------------|------------------------------------------------------------|----------------------|-----------------------------------------------------------------------------------------------------------------|
| `date-fullyear`   | `YYYY`                                                     | 4.3.2                | 0001-9999                                                                                                       |
| `date-month`      | `MM`                                                       | 4.3.3                | 01-12                                                                                                           |
| `date-mday`       | `DD`                                                       | 4.3.4                | 01-28, 01-29, 01-30, 01-31 based on month/year                                                                  |
| `time-hour`       | `hh`                                                       | 4.3.8a               | 00-23                                                                                                           |
| `time-minute`     | `mm`                                                       | 4.3.9a               | 00-59                                                                                                           |
| `time-second`     | `ss`                                                       | 4.3.10a              | 00-58, 00-59, 00-60 based on leap second rules                                                                  |
| `time-secfrac`    | `s`                                                        | 5.3.14               | There must be one digit, but the max number of digits is implemenation-defined                                  |
| `time-numoffset`  | `("+" / "-") time-hour ":" time-minute`                    |                      |                                                                                                                 |
| `time-offset`     | `"Z" / time-numoffset`                                     |                      |                                                                                                                 |
| `partial-time`    | `time-hour ":" time-minute ":" time-second [time-secfrac]` |                      |                                                                                                                 |
| `full-date`       | `date-fullyear "-" date-month "-" date-mday`               | 5.2.2.1b             | Extended calendar date                                                                                          |
| `full-time`       | `partial-time time-offset`                                 | 5.3.3 or 5.3.4.2     | 5.3.3 is "UTC of day" while 5.3.4.2 is "Local time of day with the time shift between local time scale and UTC" |
| `date-time`       | `full-date "T" full-time`                                  | 5.4.2.1              | Extended calendar date and time of day                                                                          |

### Support for parsing

The extended ISO 8601 profile implemented in <xref:System.Text.Json> uses these components to define the following levels of date and time granularity:

1. `full-date` (ISO 8601-1:2019 5.2.2.1)
	1. `YYYY-MM-DD`

	ISO 8601-1:2019 5.2.2.2 "Representations with reduced precision" allows for just YYYY-MM (a) and just YYYY (b), but neither is supported.

2. `full-date "T" time-hour ":" time-minute`
	1. `YYYY-MM-DDThh:mm`

3. `full-date "T" partial-time`
	1. `YYYY-MM-DDThh:mm:ss`
	2. `YYYY-MM-DDThh:mm:ss.s`

4. `full-date "T" time-hour ":" time-minute time-offset`
	1. `YYYY-MM-DDThh:mmZ`
	2. `YYYY-MM-DDThh:mm("+" / "-")hh":"mm`

5. `date-time` (ISO 8601-1:2019 5.4.2.1)
	1. `YYYY-MM-DDThh:mm:ssZ`
	2. `YYYY-MM-DDThh:mm:ss.sZ`
	3. `YYYY-MM-DDThh:mm:ss("+" / "-")hh":"mm`
	4. `YYYY-MM-DDThh:mm:ss.s("+" / "-")hh":"mm`

Seconds can be omitted according to ISO 8601-1:2019 5.3.1.3a "Representations with reduced precision". ISO 8601-1:2019 5.3.1.3b allows just specifying the hour, but that representation is not supported.

ISO 8601-1:2019 5.3.14 allows decimal fractions for hours, minutes and seconds. Only second fractions are supported. Lower order components can't follow, i.e. you can have T23.3, but not T23.3:04.
There must be one digit, but the maximum number of digits is implementation defined. Up to 16 digits of fractional seconds are supported. While up to 16 fractional digits are allowed, only the first seven are parsed.
Anything beyond that is considered a zero. This is to stay compatible with the <xref:System.DateTime> implementation which is limited to this resolution.

Leap seconds are not supported.

### Support for formatting

The following levels of granularity are defined for formatting:

1. `full-date "T" partial-time`
	1. `YYYY-MM-DDThh:mm:ss` 

		Used to format a <xref:System.DateTime> without fractional seconds and without offset information.

	2. `YYYY-MM-DDThh:mm:ss.s`

		Used to format a <xref:System.DateTime> with fractional seconds but without offset information.

2. `date-time` (ISO 8601-1:2019 5.4.2.1)
	1. `YYYY-MM-DDThh:mm:ssZ`

		Used to format a <xref:System.DateTime> or <xref:System.DateTimeOffset> without fractional seconds but with a UTC offset.

	2. `YYYY-MM-DDThh:mm:ss.sZ`

		Used to format a <xref:System.DateTime> or <xref:System.DateTimeOffset> with fractional seconds and with a UTC offset.

	3. `YYYY-MM-DDThh:mm:ss("+" / "-")hh":"mm`

		Used to format a <xref:System.DateTime> or <xref:System.DateTimeOffset> without fractional seconds but with a local offset.

	4. `YYYY-MM-DDThh:mm:ss.s("+" / "-")hh":"mm`

		Used to format a <xref:System.DateTime> or <xref:System.DateTimeOffset> with fractional seconds and with a local offset.