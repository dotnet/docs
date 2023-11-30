using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class Utf8ReaderFromBytes
    {
        public static void Run()
        {
            WeatherForecast weatherForecast = WeatherForecastFactories.CreateWeatherForecast();
            byte[] jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(
                weatherForecast,
                new JsonSerializerOptions { WriteIndented = true });

            // <Deserialize>
            var options = new JsonReaderOptions
            {
                AllowTrailingCommas = true,
                CommentHandling = JsonCommentHandling.Skip
            };
            var reader = new Utf8JsonReader(jsonUtf8Bytes, options);

            while (reader.Read())
            {
                Console.Write(reader.TokenType);

                switch (reader.TokenType)
                {
                    case JsonTokenType.PropertyName:
                    case JsonTokenType.String:
                        {
                            string? text = reader.GetString();
                            Console.Write(" ");
                            Console.Write(text);
                            break;
                        }

                    case JsonTokenType.Number:
                        {
                            int intValue = reader.GetInt32();
                            Console.Write(" ");
                            Console.Write(intValue);
                            break;
                        }

                        // Other token types elided for brevity
                }
                Console.WriteLine();
            }
            // </Deserialize>
        }
    }
}
