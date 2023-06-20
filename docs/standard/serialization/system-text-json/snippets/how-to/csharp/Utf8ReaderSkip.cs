using System.Text.Json;

namespace RoundtripJsonElementAndNode
{
    public class WeatherForecast
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string? Summary { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            var weatherForecast = new WeatherForecast
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "Hot"
            };

            byte[] jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(weatherForecast);

            var reader = new Utf8JsonReader(jsonUtf8Bytes);

            int temp;
            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonTokenType.PropertyName:
                        {
                            if (reader.ValueTextEquals("TemperatureCelsius"))
                            {
                                reader.Skip();
                                temp = reader.GetInt32();

                                Console.WriteLine($"Temperature is {temp} degrees.");
                            }
                            continue;
                        }
                    default:
                        continue;
                }
            }
        }
    }
}
