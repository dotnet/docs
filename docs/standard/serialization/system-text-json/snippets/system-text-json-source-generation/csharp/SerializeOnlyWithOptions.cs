// <All>
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SerializeOnlyWithOptions
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string? Summary { get; set; }
    }

    // <JsonSourceGenerationOptions>
    [JsonSourceGenerationOptions(
        WriteIndented = true,
        PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
        GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(WeatherForecast))]
    internal partial class SerializationModeOptionsContext : JsonSerializerContext
    {
    }
    // </JsonSourceGenerationOptions>
    public class Program
    {
        public static void Main()
        {
            string jsonString;
            WeatherForecast weatherForecast = new()
                { Date = DateTime.Parse("2019-08-01"), TemperatureCelsius = 25, Summary = "Hot" };

            // Serialize using TypeInfo<TValue> provided by the context
            // and options specified by [JsonSourceGenerationOptions].
            // <SerializeWithTypeInfo>
            jsonString = JsonSerializer.Serialize(
                weatherForecast, SerializationModeOptionsContext.Default.WeatherForecast);
            // </SerializeWithTypeInfo>
            Console.WriteLine(jsonString);
            // output:
            //{
            //  "date": "2019-08-01T00:00:00",
            //  "temperatureCelsius": 0,
            //  "summary": "Hot"
            //}

            // Serialize using Default context
            // and options specified by [JsonSourceGenerationOptions].
            // <SerializeWithContext>
            jsonString = JsonSerializer.Serialize(
                weatherForecast, typeof(WeatherForecast), SerializationModeOptionsContext.Default);
            // </SerializeWithContext>
            Console.WriteLine(jsonString);
            // output:
            //{
            //  "date": "2019-08-01T00:00:00",
            //  "temperatureCelsius": 0,
            //  "summary": "Hot"
            //}
        }
    }
}
// </All>
