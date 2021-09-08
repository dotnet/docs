// <All>
using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SerializeOnlyNoOptions
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }
    }

    // <JsonSourceGenerationOptionsGenmode>
    [JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Serialization)]
    [JsonSerializable(typeof(WeatherForecast))]
    internal partial class SerializeOnlyContext : JsonSerializerContext
    {
    }
    // </JsonSourceGenerationOptionsGenmode>
    
    // <JsonSerializableGenmode>
    [JsonSerializable(typeof(WeatherForecast), GenerationMode = JsonSourceGenerationMode.Serialization)]
    internal partial class SerializeOnlyWeatherForecastOnlyContext : JsonSerializerContext
    {
    }
    // </JsonSerializableGenmode>

     public class Program
    {
        public static void Main()
        {
            WeatherForecast weatherForecast = new()
                { Date = DateTime.Parse("2019-08-01"), TemperatureCelsius = 25, Summary = "Hot" };

            // Use a context that selects Serialization mode.
            // <SerializeOnlyContext> 
            using MemoryStream memoryStream1 = new();
            using Utf8JsonWriter writer1 = new(memoryStream1);
            SerializeOnlyContext.Default.WeatherForecast.Serialize(writer1, weatherForecast);
            writer1.Flush();
            // </SerializeOnlyContext> 
            Console.WriteLine(Encoding.UTF8.GetString(memoryStream1.ToArray()));
            // output:
            //{"Date":"2019-08-01T00:00:00","TemperatureCelsius":25,"Summary":"Hot"}

            // Use context that selects Serialization mode only for WeatherForecast.
            // <SerializeWFContext> 
            using MemoryStream memoryStream2 = new();
            using Utf8JsonWriter writer2 = new(memoryStream2);
            SerializeOnlyContext.Default.WeatherForecast.Serialize(writer2, weatherForecast);
            writer2.Flush();
            // </SerializeWFContext> 
            Console.WriteLine(Encoding.UTF8.GetString(memoryStream2.ToArray()));
            // output:
            //{"Date":"2019-08-01T00:00:00","TemperatureCelsius":25,"Summary":"Hot"}
        }
    }
}
// </All>
