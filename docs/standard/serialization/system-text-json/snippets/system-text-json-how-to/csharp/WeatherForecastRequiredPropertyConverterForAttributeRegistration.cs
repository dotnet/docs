using System.Text.Json;
using System.Text.Json.Serialization;

namespace SystemTextJsonSamples
{
    public class WeatherForecastRequiredPropertyConverterForAttributeRegistration :
        JsonConverter<WeatherForecastWithRequiredPropertyConverterAttribute>
    {
        public override WeatherForecastWithRequiredPropertyConverterAttribute Read(
            ref Utf8JsonReader reader,
            Type type,
            JsonSerializerOptions options)
        {
            // OK to pass in options when recursively calling Deserialize.
            WeatherForecastWithRequiredPropertyConverterAttribute forecast =
                JsonSerializer.Deserialize<WeatherForecastWithoutRequiredPropertyConverterAttribute>(
                    ref reader,
                    options)!;

            // Check for required fields set by values in JSON.
            return forecast!.Date == default
                ? throw new JsonException("Required property not received in the JSON")
                : forecast;
        }

        public override void Write(
            Utf8JsonWriter writer,
            WeatherForecastWithRequiredPropertyConverterAttribute forecast,
            JsonSerializerOptions options)
        {
            var weatherForecastWithoutConverterAttributeOnClass =
                new WeatherForecastWithoutRequiredPropertyConverterAttribute
                {
                    Date = forecast.Date,
                    TemperatureCelsius = forecast.TemperatureCelsius,
                    Summary = forecast.Summary
                };

            // OK to pass in options when recursively calling Serialize.
            JsonSerializer.Serialize(
                writer,
                weatherForecastWithoutConverterAttributeOnClass,
                options);
        }
    }
}
