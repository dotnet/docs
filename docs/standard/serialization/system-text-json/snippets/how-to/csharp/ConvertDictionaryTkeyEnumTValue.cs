using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class ConvertDictionaryTkeyEnumTValue
    {
        public static void Run()
        {
            string jsonString;

            var weatherForecast = WeatherForecastFactories.CreateWeatherForecastWithEnumDictionary();

            // <Register>
            var serializeOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters =
                {
                    new DictionaryTKeyEnumTValueConverter()
                }
            };
            // </Register>
            jsonString = JsonSerializer.Serialize(weatherForecast, serializeOptions);
            Console.WriteLine($"JSON output:\n{jsonString}\n");

            // <Deserialize>
            var deserializeOptions = new JsonSerializerOptions();
            deserializeOptions.Converters.Add(new DictionaryTKeyEnumTValueConverter());
            weatherForecast = JsonSerializer.Deserialize<WeatherForecastWithEnumDictionary>(
                jsonString,
                deserializeOptions
                );
            // </Deserialize>
            weatherForecast!.DisplayPropertyValues();
        }
    }
}
