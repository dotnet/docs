using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace CustomConverterUnixEpochDate
{
    class Program
    {
        public static void Main()
        {
            var forecast = new Forecast() { Date = DateTimeOffset.Now, TemperatureCelsius = 19, Summary = "warm" };

            var options = new JsonSerializerOptions();
            options.Converters.Add(new UnixEpochDateTimeOffsetConverter());
            options.WriteIndented = true;

            string json = JsonSerializer.Serialize(forecast, options);
            Console.WriteLine(json);

            var forecastDeserialized = JsonSerializer.Deserialize<Forecast>(json, options);
            Console.WriteLine($"Deserialized date = {forecastDeserialized.Date}");
        }
    }

    public class Forecast
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }
    }

    // <ConverterOnly>
    sealed class UnixEpochDateTimeOffsetConverter : JsonConverter<DateTimeOffset>
    {
        static readonly DateTimeOffset s_epoch = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
        static readonly Regex s_regex = new Regex("^/Date\\(([+-]*\\d+)([+-])(\\d{2})(\\d{2})\\)/$", RegexOptions.CultureInvariant);

        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {

            string formatted = reader.GetString();
            Match match = s_regex.Match(formatted);

            if (
                    !match.Success
                    || !long.TryParse(match.Groups[1].Value, System.Globalization.NumberStyles.Integer, CultureInfo.InvariantCulture, out long unixTime)
                    || !int.TryParse(match.Groups[3].Value, System.Globalization.NumberStyles.Integer, CultureInfo.InvariantCulture, out int hours)
                    || !int.TryParse(match.Groups[4].Value, System.Globalization.NumberStyles.Integer, CultureInfo.InvariantCulture, out int minutes))
            {
                throw new JsonException();
            }

            int sign = match.Groups[2].Value[0] == '+' ? 1 : -1;
            TimeSpan utcOffset = new TimeSpan(hours * sign, minutes * sign, 0);

            return s_epoch.AddMilliseconds(unixTime).ToOffset(utcOffset);
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
            long unixTime = Convert.ToInt64((value - s_epoch).TotalMilliseconds);
            TimeSpan utcOffset = value.Offset;

            string formatted = FormattableString.Invariant($"/Date({unixTime}{(utcOffset >= TimeSpan.Zero ? "+" : "-")}{utcOffset:hhmm})/");
            writer.WriteStringValue(formatted);
        }
    }
    // </ConverterOnly>
}
