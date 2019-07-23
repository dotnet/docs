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

ISO 8601 defines the following components for date and time text representations:

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

The extended ISO 8601 profile implemented in System.Text.Json uses these components to define ten levels of date-time granularity:

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

5. `date-time` (5.4.2.1)
	1. `YYYY-MM-DDThh:mm:ssZ`
	2. `YYYY-MM-DDThh:mm:ss.sZ`
	3. `YYYY-MM-DDThh:mm:ss("+" / "-")hh":"mm`
	4. `YYYY-MM-DDThh:mm:ss.s("+" / "-")hh":"mm`

### Formatting

For formatting, four levels of granularity are defined using the ISO 8601-1:2019:

1. `full-date "T" partial-time`
	1. `YYYY-MM-DDThh:mm:ss` 
	Used to format a <xref:System.DateTime> or <xref:System.DateTimeOffset> without fractional seconds and of kind <xref:System.DateTimeKind.Unspecified>

	2. `YYYY-MM-DDThh:mm:ss.s`
	Used to format a <xref:System.DateTime> or <xref:System.DateTimeOffset> with fractional seconds and of kind <xref:System.DateTimeKind.Unspecified>

2. `date-time (5.4.2.1)`
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

1. Using `DateTime(Offset).Parse` and `DateTime(Offset).ToString`. This allows you to use .NET's most comprehensive effort at parsing various date-time formats.
This is significantly less performant than using the serializer's native parsing implementation.

```C#
using System.Text.Json.Serialization;

namespace Example1
{
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
            {
                throw new JsonException();
            }

            reader.Read();
            return DateTime.Parse(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }

    public class DateTimeOffsetConverter : JsonConverter<DateTimeOffset>
    {
        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
            {
                throw new JsonException();
            }

            reader.Read();
            return DateTimeOffset.Parse(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
```

2. Using `UTF8Parser` and `UTF8Formatter`. This allows you to use fast parsing and formatting methods for Ut8 date-time data that is compliant with one of the [Standard Date and Time Format Strings](https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings).
This is much faster than Example 1.

```C#
using System.Buffers;
using System.Buffers.Text;
using System.Text.Json.Serialization;

namespace Example2
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
            {
                throw new JsonException();
            }

            reader.Read();

            if (Utf8Parser.TryParse(reader.ValueSpan, out DateTime value,  out _, 'O'))
            {
                reader.Read();
                return value;
            }

            throw new FormatException();
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            Span<byte> destination = new byte[35];

            bool result = Utf8Formatter.TryFormat(value, destination, out _, new StandardFormat('O'));
            Debug.Assert(result);

            writer.WriteStringValue(Encoding.UTF8.GetString(destination));
        }
    }

    public class DateTimeOffsetConverter : JsonConverter<DateTimeOffset>
    {
        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
            {
                throw new JsonException();
            }

            reader.Read();

            if (Utf8Parser.TryParse(reader.ValueSpan, out DateTimeOffset value, out _, 'O'))
            {
                reader.Read();
                return value;
            }

            throw new FormatException();
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
            Span<byte> destination = new byte[35];

            bool result = Utf8Formatter.TryFormat(value, destination, out _, new StandardFormat('O'));
            Debug.Assert(result);

            writer.WriteStringValue(Encoding.UTF8.GetString(destination));
        }
    }
}
```