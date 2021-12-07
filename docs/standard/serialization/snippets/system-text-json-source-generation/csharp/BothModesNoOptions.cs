// <All>
using System.Text.Json;
using System.Text.Json.Serialization;

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
    internal partial class SourceGenerationContext : JsonSerializerContext
    {
    }
    // </DefineContext>

    public class Program
    {
        public static void Main()
        {
            string jsonString =
 @"{
  ""Date"": ""2019-08-01T00:00:00"",
  ""TemperatureCelsius"": 25,
  ""Summary"": ""Hot""
}
";
            WeatherForecast? weatherForecast;

            // <DeserializeWithTypeInfo>
            weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(
                jsonString, SourceGenerationContext.Default.WeatherForecast);
            // </DeserializeWithTypeInfo>
            Console.WriteLine($"Date={weatherForecast?.Date}");
            // output:
            //Date=8/1/2019 12:00:00 AM

            // <DeserializeWithContext>
            weatherForecast = JsonSerializer.Deserialize(
                jsonString, typeof(WeatherForecast), SourceGenerationContext.Default)
                as WeatherForecast;
            // </DeserializeWithContext>
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

            // <SerializeWithContext>
            jsonString = JsonSerializer.Serialize(
                weatherForecast, typeof(WeatherForecast), SourceGenerationContext.Default);
            // </SerializeWithContext>
            Console.WriteLine(jsonString);
            // output:
            //{"Date":"2019-08-01T00:00:00","TemperatureCelsius":25,"Summary":"Hot"}
        }
    }
}
// </All>
