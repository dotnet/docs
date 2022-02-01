using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class SerializePolymorphic
    {
        public static void Run()
        {
            string jsonString;
            var weatherForecastDerived = WeatherForecastFactories.CreateWeatherForecastDerived();
            WeatherForecast weatherForecast = weatherForecastDerived;
            weatherForecast.DisplayPropertyValues();

            Console.WriteLine("Base class generic type - derived class properties omitted");
            // <SerializeDefault>
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            jsonString = JsonSerializer.Serialize<WeatherForecast>(weatherForecast, options);
            // </SerializeDefault>

            Console.WriteLine($"JSON output:\n{jsonString}\n");

            Console.WriteLine("Object generic type parameter - derived class properties included");
            // <SerializeObject>
            options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            jsonString = JsonSerializer.Serialize<object>(weatherForecast, options);
            // </SerializeObject>
            Console.WriteLine($"JSON output:\n{jsonString}\n");

            Console.WriteLine("GetType() type parameter - derived class properties included");
            // <SerializeGetType>
            options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            jsonString = JsonSerializer.Serialize(weatherForecast, weatherForecast.GetType(), options);
            // </SerializeGetType>
            Console.WriteLine($"JSON output:\n{jsonString}\n");

            Console.WriteLine("Extra properties on interface implementations included only for object properties");
            // <SerializeInterface>
            var forecasts = new Forecasts
            {
                Monday = new Forecast
                {
                    Date = DateTime.Parse("2020-01-06"),
                    TemperatureCelsius = 10,
                    Summary = "Cool",
                    WindSpeed = 8
                },
                Tuesday = new Forecast
                {
                    Date = DateTime.Parse("2020-01-07"),
                    TemperatureCelsius = 11,
                    Summary = "Rainy",
                    WindSpeed = 10
                }
            };

            options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            jsonString = JsonSerializer.Serialize(forecasts, options);
            // </SerializeInterface>
            Console.WriteLine($"{jsonString}\n");

            WeatherForecastWithPrevious weatherForecastWithPrevious =
                WeatherForecastFactories.CreateWeatherForecastWithPrevious();
            WeatherForecastWithPreviousAsObject weatherForecastWithPreviousAsObject =
                WeatherForecastFactories.CreateWeatherForecastWithPreviousAsObject();

            Console.WriteLine("Second level derived class properties included only for object properties");
            // <SerializeSecondLevel>
            options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            jsonString = JsonSerializer.Serialize(weatherForecastWithPreviousAsObject, options);
            // </SerializeSecondLevel>
            Console.WriteLine($"JSON output with WindSpeed:\n{jsonString}\n");
            jsonString = JsonSerializer.Serialize(
                weatherForecastWithPrevious,
                options);
            Console.WriteLine($"JSON output without WindSpeed:\n{jsonString}\n");
        }
    }
}
