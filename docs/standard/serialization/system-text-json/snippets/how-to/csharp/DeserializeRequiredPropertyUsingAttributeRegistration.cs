using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class DeserializeRequiredPropertyUsingAttributeRegistration
    {
        public static void Run()
        {
            string jsonString;
            var wf = WeatherForecastFactories.CreateWeatherForecastAttrReg();

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            jsonString = JsonSerializer.Serialize(wf, options);
            Console.WriteLine($"JSON with Date:\n{jsonString}\n");

            wf = JsonSerializer.Deserialize<WeatherForecastWithRequiredPropertyConverterAttribute>(
                jsonString, options)!;
            wf.DisplayPropertyValues();

            jsonString = @"{""TemperatureCelsius"": 25,""Summary"":""Hot""}";
            Console.WriteLine($"JSON without Date:\n{jsonString}\n");

            Console.WriteLine("Deserialize with converter");
            try
            {
                wf = JsonSerializer.Deserialize<WeatherForecastWithRequiredPropertyConverterAttribute>(
                    jsonString, options)!;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}\n");
            }
            // wf object is unchanged if exception is thrown.
            wf.DisplayPropertyValues();
        }
    }
}
