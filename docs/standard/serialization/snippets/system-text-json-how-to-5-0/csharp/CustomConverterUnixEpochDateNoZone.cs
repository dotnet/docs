using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace CustomConverterUnixEpochDateNoZone
{
    class Program
    {
        public static void Main()
        {
            var forecast = new Forecast() { Date = DateTime.Now, TemperatureCelsius = 19, Summary = "warm" };

            var options = new JsonSerializerOptions();
            options.Converters.Add(new UnixEpochDateTimeConverter());
            options.WriteIndented = true;

            string json = JsonSerializer.Serialize(forecast, options);
            Console.WriteLine(json);

            var forecastDeserialized = JsonSerializer.Deserialize<Forecast>(json, options);
            Console.WriteLine($"Deserialized date = {forecastDeserialized.Date}");
        }
    }

    public class Forecast
    {
        public DateTime Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }
    }

    // <ConverterOnly>
    sealed class UnixEpochDateTimeConverter : JsonConverter<DateTime>
    {
        static readonly DateTime s_epoch = new DateTime(1970, 1, 1, 0, 0, 0);
        static readonly Regex s_regex = new Regex("^/Date\\(([+-]*\\d+)\\)/$", RegexOptions.CultureInvariant);

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {

            string formatted = reader.GetString();
            Match match = s_regex.Match(formatted);

            if (
                    !match.Success
                    || !long.TryParse(match.Groups[1].Value, System.Globalization.NumberStyles.Integer, CultureInfo.InvariantCulture, out long unixTime))
            {
                throw new JsonException();
            }

            return s_epoch.AddMilliseconds(unixTime);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            long unixTime = Convert.ToInt64((value - s_epoch).TotalMilliseconds);

            string formatted = FormattableString.Invariant($"/Date({unixTime})/");
            writer.WriteStringValue(formatted);
        }
    }
    // </ConverterOnly>
}
