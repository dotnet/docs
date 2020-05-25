using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace DateTimeConverterExamples
{
    public class DateTimeConverterUsingDateTimeParseAsFallback : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert == typeof(DateTime));

            if (!reader.TryGetDateTime(out DateTime value))
            {
                value = DateTime.Parse(reader.GetString());
            }

            return value;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("dd/MM/yyyy"));
        }
    }

    class Program
    {
        private static void ParseDateTimeWithDefaultOptions()
        {
            DateTime _ = JsonSerializer.Deserialize<DateTime>(@"""2019-07-16 16:45:27.4937872+00:00""");
        }

        private static void ProcessDateTimeWithCustomConverter()
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Converters.Add(new DateTimeConverterUsingDateTimeParseAsFallback());

            string testDateTimeStr = "2019-07-16 16:45:27.4937872+00:00";
            string testDateTimeJson = @"""" + testDateTimeStr + @"""";

            DateTime resultDateTime = JsonSerializer.Deserialize<DateTime>(testDateTimeJson, options);
            Console.WriteLine(resultDateTime);

            string resultDateTimeJson = JsonSerializer.Serialize(DateTime.Parse(testDateTimeStr), options);
            Console.WriteLine(Regex.Unescape(resultDateTimeJson));
        }

        static void Main(string[] args)
        {
            // Parsing non-compliant format as DateTime fails by default.
            try
            {
                ParseDateTimeWithDefaultOptions();
            }
            catch (JsonException e)
            {
                Console.WriteLine(e.Message);
            }

            // Using converters gives you control over the serializers parsing and formatting.
            ProcessDateTimeWithCustomConverter();
        }
    }
}

// The example displays output similar to the following:
// The JSON value could not be converted to System.DateTime.Path: $ | LineNumber: 0 | BytePositionInLine: 35.
// 7/16/2019 4:45:27 PM
// "16/07/2019"
