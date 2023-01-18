// <All>
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ObjectProperties;

// <WF>
public class WeatherForecast
{
    public object? Data { get; set; }
    public List<object>? DataList { get; set; }
}
// </WF>

// <JsonSerializable>
[JsonSerializable(typeof(WeatherForecast))]
[JsonSerializable(typeof(bool))]
[JsonSerializable(typeof(int))]
public partial class WeatherForecastContext : JsonSerializerContext
{
}
// </JsonSerializable>

public class Program
{
    public static void Main()
    {
        // <WFInit>
        WeatherForecast wf = new() { Data = true, DataList = new List<object> { true, 1 } };
        // </WFInit>
        string json = JsonSerializer.Serialize(wf, WeatherForecastContext.Default.WeatherForecast);
        Console.WriteLine(json);
    }
}
// </All>
