// <All>
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace BothModesNoOptions
{
    // <WF>
    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string? Summary { get; set; }
    }
    // </WF>

    // <DefineContext>
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(WeatherForecast))]
    internal partial class SourceGenerationContext : JsonSerializerContext { }
    // </DefineContext>

    public class Program
    {
        public static void Main()
        {
            string jsonString = """
                {
                    "Date": "2019-08-01T00:00:00",
                    "TemperatureCelsius": 25,
                    "Summary": "Hot"
                }
                """;
            WeatherForecast? weatherForecast;

            // <DeserializeWithTypeInfo>
            weatherForecast = JsonSerializer.Deserialize(
                jsonString, SourceGenerationContext.Default.WeatherForecast);
            // </DeserializeWithTypeInfo>
            Console.WriteLine($"Date={weatherForecast?.Date}");
            // output:
            //Date=8/1/2019 12:00:00 AM

            // <DeserializeWithTypeInfoFromOptions>
            var sourceGenOptions = new JsonSerializerOptions
            {
                TypeInfoResolver = SourceGenerationContext.Default
            };
            weatherForecast = JsonSerializer.Deserialize(
                jsonString,
                (JsonTypeInfo<WeatherForecast>)sourceGenOptions.GetTypeInfo(typeof(WeatherForecast))!);
            // </DeserializeWithTypeInfoFromOptions>
            Console.WriteLine($"Date={weatherForecast?.Date}");
            // output:
            //Date=8/1/2019 12:00:00 AM

            // <SerializeWithTypeInfo>
            jsonString = JsonSerializer.Serialize(
                weatherForecast!, SourceGenerationContext.Default.WeatherForecast);
            // </SerializeWithTypeInfo>
            Console.WriteLine(jsonString);
            // output:
            //{"Date":"2019-08-01T00:00:00","TemperatureCelsius":25,"Summary":"Hot"}

            // <SerializeWithTypeInfoFromOptions>
            jsonString = JsonSerializer.Serialize(
                weatherForecast!,
                (JsonTypeInfo<WeatherForecast>)sourceGenOptions.GetTypeInfo(typeof(WeatherForecast))!);
            // </SerializeWithTypeInfoFromOptions>
            Console.WriteLine(jsonString);
            // output:
            //{"Date":"2019-08-01T00:00:00","TemperatureCelsius":25,"Summary":"Hot"}
        }
    }
}
// </All>
