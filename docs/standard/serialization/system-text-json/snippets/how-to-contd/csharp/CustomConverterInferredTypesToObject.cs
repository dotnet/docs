using System.Text.Json;
using System.Text.Json.Serialization;

namespace CustomConverterInferredTypesToObject
{
    public class ObjectToInferredTypesConverter : JsonConverter<object>
    {
        public override object Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) => reader.TokenType switch
            {
                JsonTokenType.True => true,
                JsonTokenType.False => false,
                JsonTokenType.Number when reader.TryGetInt64(out long l) => l,
                JsonTokenType.Number => reader.GetDouble(),
                JsonTokenType.String when reader.TryGetDateTime(out DateTime datetime) => datetime,
                JsonTokenType.String => reader.GetString()!,
                _ => JsonDocument.ParseValue(ref reader).RootElement.Clone()
            };

        public override void Write(
            Utf8JsonWriter writer,
            object objectToWrite,
            JsonSerializerOptions options)
        {
            if (objectToWrite.GetType() == typeof(object))
            {
                writer.WriteStartObject();
                writer.WriteEndObject();
                return;
            }

            JsonSerializer.Serialize(writer, objectToWrite, objectToWrite.GetType(), options);
        }
    }

    public class WeatherForecast
    {
        public object? Date { get; set; }
        public object? TemperatureCelsius { get; set; }
        public object? Summary { get; set; }
    }

    public class Program
    {
        public static void Run()
        {
            string jsonString = """
                {
                  "Date": "2019-08-01T00:00:00-07:00",
                  "TemperatureCelsius": 25,
                  "Summary": "Hot"
                }
                """;

            WeatherForecast weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(jsonString)!;
            Console.WriteLine($"Type of Date property   no converter = {weatherForecast.Date!.GetType()}");

            var options = new JsonSerializerOptions();
            options.WriteIndented = true;
            options.Converters.Add(new ObjectToInferredTypesConverter());
            weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(jsonString, options)!;
            Console.WriteLine($"Type of Date property with converter = {weatherForecast.Date!.GetType()}");

            Console.WriteLine(JsonSerializer.Serialize(weatherForecast, options));
        }
    }
}

// Produces output like the following example:
//
//Type of Date property   no converter = System.Text.Json.JsonElement
//Type of Date property with converter = System.DateTime
//{
//  "Date": "2019-08-01T00:00:00-07:00",
//  "TemperatureCelsius": 25,
//  "Summary": "Hot"
//}
