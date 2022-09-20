// <All>
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonSerializerOptionsExample
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string? Summary { get; set; }
    }

    // <DefineContext>
    [JsonSerializable(typeof(WeatherForecast))]
    internal partial class OptionsExampleContext : JsonSerializerContext
    {
    }
    // </DefineContext>

    public class Program
    {
        public static void Main()
        {
            string jsonString =
 @"{
  ""date"": ""2019-08-01T00:00:00"",
  ""temperatureCelsius"": 25,
  ""summary"": ""Hot""
}
";
            WeatherForecast? weatherForecast;

            // <Deserialize>
            weatherForecast = JsonSerializer.Deserialize(
                jsonString, 
                typeof(WeatherForecast), 
                new OptionsExampleContext(
                    new JsonSerializerOptions(JsonSerializerDefaults.Web)))
                    as WeatherForecast;
            // </Deserialize>
            Console.WriteLine($"Date={weatherForecast?.Date}");
            // output:
            //Date=8/1/2019 12:00:00 AM

            // <Serialize>
            jsonString = JsonSerializer.Serialize(
                weatherForecast,
                typeof(WeatherForecast),
                new OptionsExampleContext(
                    new JsonSerializerOptions(JsonSerializerDefaults.Web)));
            // </Serialize>
            Console.WriteLine(jsonString);
            // output:
            //{ "date":"2019-08-01T00:00:00","temperatureCelsius":25,"summary":"Hot"}
        }
    }
}
// </All>
