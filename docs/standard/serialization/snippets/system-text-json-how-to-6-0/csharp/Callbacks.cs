using System.Text.Json;
using System.Text.Json.Serialization;

namespace Callbacks
{
    public class WeatherForecast : 
        IJsonOnDeserializing, IJsonOnDeserialized, 
        IJsonOnSerializing, IJsonOnSerialized
    {
        public DateTime Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string? Summary { get; set; }

        void IJsonOnDeserializing.OnDeserializing() => Console.WriteLine("\nBegin deserializing");
        void IJsonOnDeserialized.OnDeserialized()
        {
            Validate();
            Console.WriteLine("Finished deserializing");
        }
        void IJsonOnSerializing.OnSerializing()
        {
            Console.WriteLine("Begin serializing");
            Validate();
        }
        void IJsonOnSerialized.OnSerialized() => Console.WriteLine("Finished serializing");

        private void Validate()
        {
            if (Summary is null)
            {
                Console.WriteLine("The 'Summary' property is 'null'.");
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            var weatherForecast = new WeatherForecast
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
            };

            string jsonString = JsonSerializer.Serialize(weatherForecast);
            Console.WriteLine(jsonString);

            weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(jsonString);
            Console.WriteLine($"Date={weatherForecast?.Date}");
            Console.WriteLine($"TemperatureCelsius={weatherForecast?.TemperatureCelsius}");
            Console.WriteLine($"Summary={weatherForecast?.Summary}");
        }
    }
}
// output:
//Begin serializing
//The 'Summary' property is 'null'.
//Finished serializing
//{"Date":"2019-08-01T00:00:00","TemperatureCelsius":25,"Summary":null}

//Begin deserializing
//The 'Summary' property is 'null'.
//Finished deserializing
//Date=8/1/2019 12:00:00 AM
//TemperatureCelsius = 25
//Summary=
