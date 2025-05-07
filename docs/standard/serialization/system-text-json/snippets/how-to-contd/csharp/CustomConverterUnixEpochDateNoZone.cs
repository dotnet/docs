using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace CustomConverterUnixEpochDateNoZone
{
    class Program
    {
        public static void Main(DateTime date)
        {
            var forecast = new Forecast()
            {
                Date = date,
                TemperatureCelsius = 19,
                Summary = "warm"
            };

            var options = new JsonSerializerOptions();
            options.Converters.Add(new UnixEpochDateTimeConverter());

            string json = System.Text.Json.JsonSerializer.Serialize(forecast, options);
            Console.WriteLine($"System.Text.Json: {json}");

            Forecast forecastDeserialized = System.Text.Json.JsonSerializer.Deserialize<Forecast>(json, options)!;
            Console.WriteLine($"System.Text.Json deserialized date = {forecastDeserialized.Date}");
        }

        public static void Main2(DateTime date)
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
        public DateTime Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string? Summary { get; set; }
    }

    // <ConverterOnly>
    sealed class UnixEpochDateTimeConverter : System.Text.Json.Serialization.JsonConverter<DateTime>
    {
        static readonly DateTime s_epoch = new(1970, 1, 1, 0, 0, 0);
        static readonly Regex s_regex = new("^/Date\\(([+-]*\\d+)\\)/$", RegexOptions.CultureInvariant);

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string formatted = reader.GetString()!;
            Match match = s_regex.Match(formatted);

            if (
                    !match.Success
                    || !long.TryParse(match.Groups[1].Value, System.Globalization.NumberStyles.Integer, CultureInfo.InvariantCulture, out long unixTime))
            {
                throw new System.Text.Json.JsonException();
            }

            return s_epoch.AddMilliseconds(unixTime);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            long unixTime = (value - s_epoch).Ticks / TimeSpan.TicksPerMillisecond;

            string formatted = string.Create(CultureInfo.InvariantCulture, $"/Date({unixTime})/");
            writer.WriteStringValue(formatted);
        }
    }
    // </ConverterOnly>
}
