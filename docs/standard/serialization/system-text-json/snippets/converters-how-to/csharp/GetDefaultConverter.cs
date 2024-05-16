using System.Text.Json;
using System.Text.Json.Serialization;

namespace GetDefaultConverter;

public class WeatherForecast
{
    public DateTime Date { get; set; }
    public int TemperatureC { get; set; }
    public string? Summary { get; set; }
}

// <Converter>
public class MyCustomConverter : JsonConverter<int>
{
    private readonly static JsonConverter<int> s_defaultConverter = 
        (JsonConverter<int>)JsonSerializerOptions.Default.GetConverter(typeof(int));

    // Custom serialization logic
    public override void Write(
        Utf8JsonWriter writer, int value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }

    // Fall back to default deserialization logic
    public override int Read(
        ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return s_defaultConverter.Read(ref reader, typeToConvert, options);
    }
}
// </Converter>

public class Program
{
    public static void Main()
    {
        var weatherForecast = new WeatherForecast
        {
            Date = DateTime.Parse("2019-08-01"),
            TemperatureC = 25,
            Summary = "Hot",
        };

        var options = new JsonSerializerOptions { WriteIndented = true };
        options.Converters.Add(new MyCustomConverter());

        string jsonString = JsonSerializer.Serialize(weatherForecast, options);
        Console.WriteLine(jsonString);

        weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(jsonString);
        Console.WriteLine(weatherForecast!.TemperatureC);
    }
}
