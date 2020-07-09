using System;
using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class RoundtripDictionaryTkeyEnumTValue
    {
        public static void Run()
        {
            string jsonString;

            WeatherForecastWithEnumDictionary weatherForecast = WeatherForecastFactories.CreateWeatherForecastWithEnumDictionary();

            // <SnippetRegister>
            var serializeOptions = new JsonSerializerOptions();
            serializeOptions.Converters.Add(new DictionaryTKeyEnumTValueConverter());
            // </SnippetRegister>
            serializeOptions.WriteIndented = true;
            jsonString = JsonSerializer.Serialize(weatherForecast, serializeOptions);
            Console.WriteLine($"JSON output:\n{jsonString}\n");

            // <SnippetDeserialize>
            var deserializeOptions = new JsonSerializerOptions();
            deserializeOptions.Converters.Add(new DictionaryTKeyEnumTValueConverter());
            weatherForecast = JsonSerializer.Deserialize<WeatherForecastWithEnumDictionary>(jsonString, deserializeOptions);
            // </SnippetDeserialize>
            weatherForecast.DisplayPropertyValues();
        }
    }
}
