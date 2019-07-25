---
# required/recommended metadata

title: Datetime and DateTimeOffset Support in System.Text.Json
description: An overview of how Datetime and DateTimeOffset types are supported in the System.Text.Json library.
author: layomia
ms.author: laakinri
ms.date: 07/22/2019
ms.topic: [TOPIC TYPE]
ms.prod: [PRODUCT VALUE]
helpviewer_keywords:
  - "JSON DateTime JSON DateTimeOffset"
  - "Serializer, Utf8"
  - "JSON Reader, JSON Writer, times"

---
# Datetime and DateTimeOffset Support in System.Text.Json

The <xref:System.Text.Json.JsonSerializer>, <xref:System.Text.Json.Utf8JsonReader>, <xref:System.Text.Json.Utf8JsonWriter>, and <xref:System.Text.Json.JsonElement> parse and write <xref:System.DateTime> and <xref:System.DateTimeOffset> text representations according to an extended profile of the ISO 8601-1:2019 format.

## Date and Time Components

ISO 8601-1:2019 defines the following components for date and time text representations:

| Component         | Format                                                     | ISO 8601-1:2019 Spec | Description                                                                                                     |
|-------------------|------------------------------------------------------------|----------------------|-----------------------------------------------------------------------------------------------------------------|
| `date-fullyear`   | `YYYY`                                                     | 4.3.2                | 0001-9999                                                                                                       |
| `date-month`      | `MM`                                                       | 4.3.3                | 01-12                                                                                                           |
| `date-mday`       | `DD`                                                       | 4.3.4                | 01-28, 01-29, 01-30, 01-31 based on month/year                                                                  |
| `time-hour`       | `hh`                                                       | 4.3.8a               | 00-23                                                                                                           |
| `time-minute`     | `mm`                                                       | 4.3.9a               | 00-59                                                                                                           |
| `time-second`     | `ss`                                                       | 4.3.10a              | 00-58, 00-59, 00-60 based on leap second rules                                                                  |
| `time-secfrac`    | `s`                                                        | 5.3.14               | There must be one digit, but the max number of digits is implemenation defined                                  |
| `time-numoffset`  | `("+" / "-") time-hour ":" time-minute`                    |                      |                                                                                                                 |
| `time-offset`     | `"Z" / time-numoffset`                                     |                      |                                                                                                                 |
| `partial-time`    | `time-hour ":" time-minute ":" time-second [time-secfrac]` |                      |                                                                                                                 |
| `full-date`       | `date-fullyear "-" date-month "-" date-mday`               | 5.2.2.1b             | Extended calendar date                                                                                          |
| `full-time`       | `partial-time time-offset`                                 | 5.3.3 or 5.3.4.2     | 5.3.3 is "UTC of day" while 5.3.4.2 is "Local time of day with the time shift between local time scale and UTC" |
| `date-time`       | `full-date "T" full-time`                                  | 5.4.2.1              | Extended calendar date and time of day                                                                          |

## Extended ISO 8601-1:2019 Profile in <xref:System.Text.Json>

### Parsing

The extended ISO 8601 profile implemented in System.Text.Json uses these components to define the following levels of date-time granularity:

1. `full-date` (ISO 8601-1:2019 5.2.2.1)
	1. `YYYY-MM-DD`

```markdown
> [!NOTE]
> - 5.2.2.2 "Representations with reduced precision" allows for just YYYY[“-”]MM (a) and just YYYY (b), but we currently don't permit it.
```

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

### Formatting

The following levels of granularity are defined for formatting:

1. `full-date "T" partial-time`
	1. `YYYY-MM-DDThh:mm:ss` 

	Used to format a <xref:System.DateTime> or <xref:System.DateTimeOffset> without fractional seconds and of kind <xref:System.DateTimeKind.Unspecified>

	2. `YYYY-MM-DDThh:mm:ss.s`

	Used to format a <xref:System.DateTime> or <xref:System.DateTimeOffset> with fractional seconds and of kind <xref:System.DateTimeKind.Unspecified>

2. `date-time` (ISO 8601-1:2019 5.4.2.1)
	1. `YYYY-MM-DDThh:mm:ssZ`

	Used to format a <xref:System.DateTime> or <xref:System.DateTimeOffset> without fractional seconds and of kind <xref:System.DateTimeKind.Utc>

	2. `YYYY-MM-DDThh:mm:ss.sZ`

	Used to format a <xref:System.DateTime> or <xref:System.DateTimeOffset> with fractional seconds and of kind <xref:System.DateTimeKind.Utc>

	3. `YYYY-MM-DDThh:mm:ss("+" / "-")hh":"mm`

	Used to format a <xref:System.DateTime> or <xref:System.DateTimeOffset> without fractional seconds and of kind <xref:System.DateTimeKind.Local>

	4. `YYYY-MM-DDThh:mm:ss.s("+" / "-")hh":"mm`

	Used to format a <xref:System.DateTime> or <xref:System.DateTimeOffset> with fractional seconds and of kind <xref:System.DateTimeKind.Local>

## Custom support for date and times in `JsonSerializer`

If you want custom parsing or formatting at the serializer level, you can implement [custom converters](https://github.com/dotnet/corefx/issues/36639). Here are a few examples:

1. Using `DateTime(Offset).Parse` and `DateTime(Offset).ToString`.

This allows you to use .NET's most comprehensive effort at parsing various date-time formats including non-ISO 8601 strings and ISO 8601 formats that don't conform to the Extended ISO 8601-1:2019 profile.
This approach can be used if you can't determine the input date-time formats, but is significantly less performant than using the serializer's native implementation.

```C#
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace DateTimeConverterExamples
{
    public class DateTimeConverterExample1 : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
            {
                throw new JsonException();
            }

            return DateTime.Parse(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }

    class Program
    {
        private static void ParseDateTimeWithDefaultOptions_Example1()
        {
            var _ = JsonSerializer.Deserialize<DateTime>(@"""04-10-2008 6:30 AM"""); // Throws JsonException
        }

        private static void FormatDateTimeWithDefaultOptions()
        {
            Console.WriteLine(JsonSerializer.Serialize(DateTime.Parse("04-10-2008 6:30 AM -4"))); // "2008-04-10T06:30:00-04:00"
        }

        private static void ProcessDateTimeWithCustomConverter_Example1()
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new DateTimeConverterExample1());

            var testDateTimeStr = "04-10-2008 6:30 AM";
            var testDateTimeJson = @"""" + testDateTimeStr + @"""";

            var resultDateTime = JsonSerializer.Deserialize<DateTime>(testDateTimeJson, options);
            Console.WriteLine(resultDateTime); // 4/10/2008 6:30:00 AM

            var resultDateTimeJson = JsonSerializer.Serialize(DateTime.Parse(testDateTimeStr), options);
            Console.WriteLine(Regex.Unescape(resultDateTimeJson));  // "4/10/2008 6:30:00 AM"
        }

        static void Main(string[] args)
        {
            // Parsing non-compliant format as DateTime fails by default.
            try
            {
                ParseDateTimeWithDefaultOptions_Example1();
            }
            catch (JsonException e)
            {
                Console.WriteLine(e.Message); // The JSON value could not be converted to System.DateTime. Path: $ | LineNumber: 0 | BytePositionInLine: 20.
            }

            // Formatting with default options prints according to extended ISO 8601 profile.
            FormatDateTimeWithDefaultOptions();

            // Using converters gives you control over the serializers parsing and formatting.
            ProcessDateTimeWithCustomConverter_Example1();
        }
    }
}

// The example displays the following output:
// The JSON value could not be converted to System.DateTime. Path: $ | LineNumber: 0 | BytePositionInLine: 20.
// "2008-04-10T06:30:00-04:00"
// 4/10/2008 6:30:00 AM
// "4/10/2008 6:30:00 AM"
```

2. Using `UTF8Parser` and `UTF8Formatter`.

This allows you to use fast parsing and formatting methods for UTF-8 date-time data that is compliant with one of the [Standard Date and Time Format Strings](https://docs.microsoft.com/dotnet/standard/base-types/standard-date-and-time-format-strings).
This is much faster than Example 1 and should be used if the input data isn't compliant with the Extended ISO 8601-1:2019 profile but conforms to the "R", "l", "O", or "G" Standard Format Specifiers.

```C#
using System;
using System.Buffers;
using System.Buffers.Text;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DateTimeConverterExamples
{
    public class DateTimeConverterExample2 : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
            {
                throw new JsonException();
            }

            if (Utf8Parser.TryParse(reader.ValueSpan, out DateTime value, out _, 'R'))
            {
                reader.Read();
                return value;
            }

            throw new FormatException();
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            Span<byte> destination = new byte[29];

            bool result = Utf8Formatter.TryFormat(value, destination, out _, new StandardFormat('R'));
            Debug.Assert(result);

            writer.WriteStringValue(Encoding.UTF8.GetString(destination));
        }
    }

    class Program
    {
        private static void ParseDateTimeWithDefaultOptions_Example2()
        {
            var _ = JsonSerializer.Deserialize<DateTime>(@"""Thu, 25 Jul 2019 13:36:07 GMT"""); // Throws JsonException
        }

        private static void ProcessDateTimeWithCustomConverter_Example2()
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new DateTimeConverterExample2());

            var testDateTimeStr = "Thu, 25 Jul 2019 13:36:07 GMT";
            var testDateTimeJson = @"""" + testDateTimeStr + @"""";

            var resultDateTime = JsonSerializer.Deserialize<DateTime>(testDateTimeJson, options);
            Console.WriteLine(resultDateTime); // 7/25/2019 1:36:07 PM

            Console.WriteLine(JsonSerializer.Serialize(DateTime.Parse(testDateTimeStr), options)); // "Thu, 25 Jul 2019 09:36:07 GMT"
        }

        static void Main(string[] args)
        {
            // Parsing non-compliant format as DateTime fails by default.
            try
            {
                ParseDateTimeWithDefaultOptions_Example2();
            }
            catch (JsonException e)
            {
                Console.WriteLine(e.Message); // The JSON value could not be converted to System.DateTime. Path: $ | LineNumber: 0 | BytePositionInLine: 31.
            }

            // Using converters gives you control over the serializers parsing and formatting.
            ProcessDateTimeWithCustomConverter_Example2();
        }
    }
}

// The example displays the following output:
// The JSON value could not be converted to System.DateTime.Path: $ | LineNumber: 0 | BytePositionInLine: 31.
// 7/25/2019 1:36:07 PM
// "Thu, 25 Jul 2019 09:36:07 GMT"
```

3. Using `DateTime(Offset).Parse` as a fallback to the serializers native parsing.

This approach can be used if you generally expect the input date-time data to conform to the Extended ISO 8601-1:2019 profile, but want to have a fallback just in case.

```C#
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