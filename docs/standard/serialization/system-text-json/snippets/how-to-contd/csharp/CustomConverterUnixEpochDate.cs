using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace CustomConverterUnixEpochDate
{
    class Program
    {
        public static void Main(DateTimeOffset date)
        {
            var forecast = new Forecast()
            {
                Date = date,
                TemperatureCelsius = 19,
                Summary = "warm"
            };

            var options = new JsonSerializerOptions();
            options.Converters.Add(new UnixEpochDateTimeOffsetConverter());
            //options.WriteIndented = true;

            string json = System.Text.Json.JsonSerializer.Serialize(forecast, options);
            Console.WriteLine($"System.Text.Json: {json}");

            Forecast forecastDeserialized = System.Text.Json.JsonSerializer.Deserialize<Forecast>(json, options)!;
            Console.WriteLine($"System.Text.Json deserialized date = {forecastDeserialized.Date}");
        }

        public static void Main2(DateTimeOffset date)
        {
            var forecast = new Forecast()
            {
                Date = date,
                TemperatureCelsius = 19,
                Summary = "warm"
            };

            var settings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
            };

            string json = JsonConvert.SerializeObject(forecast, settings);
            Console.WriteLine($"{Environment.NewLine}Newtonsoft: {json}");

            Forecast forecastDeserialized = JsonConvert.DeserializeObject<Forecast>(json, settings)!;
            Console.WriteLine($"Newtonsoft deserialized date = {forecastDeserialized.Date}");
        }
    }

    public class Forecast
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string? Summary { get; set; }
    }

    // <ConverterOnly>
    sealed class UnixEpochDateTimeOffsetConverter : System.Text.Json.Serialization.JsonConverter<DateTimeOffset>
    {
        static readonly DateTimeOffset s_epoch = new(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
        static readonly Regex s_regex = new(
            "^/Date\\(([+-]*\\d+)([+-])(\\d{2})(\\d{2})\\)/$",
            RegexOptions.CultureInvariant);

        public override DateTimeOffset Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            string formatted = reader.GetString()!;
            Match match = s_regex.Match(formatted);

            if (
                    !match.Success
                    || !long.TryParse(match.Groups[1].Value, NumberStyles.Integer, CultureInfo.InvariantCulture, out long unixTime)
                    || !int.TryParse(match.Groups[3].Value, NumberStyles.Integer, CultureInfo.InvariantCulture, out int hours)
                    || !int.TryParse(match.Groups[4].Value, NumberStyles.Integer, CultureInfo.InvariantCulture, out int minutes))
            {
                throw new System.Text.Json.JsonException();
            }

            int sign = match.Groups[2].Value[0] == '+' ? 1 : -1;
            TimeSpan utcOffset = new(hours * sign, minutes * sign, 0);

            return s_epoch.AddMilliseconds(unixTime).ToOffset(utcOffset);
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
            long unixTime = value.ToUnixTimeMilliseconds();

            TimeSpan utcOffset = value.Offset;

            string formatted = string.Create(
                CultureInfo.InvariantCulture,
                $"/Date({unixTime}{(utcOffset >= TimeSpan.Zero ? "+" : "-")}{utcOffset:hhmm})/");

            writer.WriteStringValue(formatted);
        }
    }
    // </ConverterOnly>
}
