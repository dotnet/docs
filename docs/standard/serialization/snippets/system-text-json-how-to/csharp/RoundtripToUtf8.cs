using System;
using System.Text;
using System.Text.Json;

namespace RoundtripToUtf8Bytes1
{
    public class Program
    {
        public class WeatherForecast
        {
            public DateTimeOffset Date { get; set; }
            public int TemperatureCelsius { get; set; }
            public string Summary { get; set; }
        }

        public static void Main()
        {
            var weatherForecast = new WeatherForecast
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "Hot"
            };

            // <Serialize>
            byte[] jsonUtf8Bytes =JsonSerializer.SerializeToUtf8Bytes(weatherForecast);
            // </Serialize>

            Console.WriteLine(Encoding.UTF8.GetString(jsonUtf8Bytes));
        }
    }
    // output:
    //{"Date":"2019-08-01T00:00:00-07:00","TemperatureCelsius":25,"Summary":"Hot"}
}

namespace RoundtripToUtf8Bytes2
{
    public class Program
    {
        public record WeatherForecast
        {
            public DateTimeOffset Date { get; set; }
            public int TemperatureCelsius { get; set; }
            public string Summary { get; set; }
        }

        public static void Main()
        {
            var weatherForecast = new WeatherForecast
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "Hot"
            };

            byte[] jsonUtf8Bytes =
                JsonSerializer.SerializeToUtf8Bytes(weatherForecast);

            // <Deserialize1>
            var readOnlySpan = new ReadOnlySpan<byte>(jsonUtf8Bytes);
            WeatherForecast deserializedWeatherForecast = 
                JsonSerializer.Deserialize<WeatherForecast>(readOnlySpan);
            // </Deserialize1>

            Console.WriteLine($"Date: {deserializedWeatherForecast.Date}");
            Console.WriteLine($"TemperatureCelsius: {deserializedWeatherForecast.TemperatureCelsius}");
            Console.WriteLine($"Summary: {deserializedWeatherForecast.Summary}");
        }
    }
    // output:
    //Date: 8/1/2019 12:00:00 AM -07:00
    //TemperatureCelsius: 25
    //Summary: Hot
}

namespace RoundtripToUtf8Bytes3
{
    public class Program
    {
        public record WeatherForecast
        {
            public DateTimeOffset Date { get; set; }
            public int TemperatureCelsius { get; set; }
            public string Summary { get; set; }
        }

        public static void Main()
        {
            var weatherForecast = new WeatherForecast
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "Hot"
            };

            byte[] jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(weatherForecast);

            // <Deserialize2>
            var utf8Reader = new Utf8JsonReader(jsonUtf8Bytes);
            WeatherForecast deserializedWeatherForecast = 
                JsonSerializer.Deserialize<WeatherForecast>(ref utf8Reader);
            // </Deserialize2>

            Console.WriteLine($"Date: {deserializedWeatherForecast.Date}");
            Console.WriteLine($"TemperatureCelsius: {deserializedWeatherForecast.TemperatureCelsius}");
            Console.WriteLine($"Summary: {deserializedWeatherForecast.Summary}");
        }
    }
    // output:
    //Date: 8/1/2019 12:00:00 AM -07:00
    //TemperatureCelsius: 25
    //Summary: Hot
}
