// <Usings>
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
// </Usings>

namespace SystemTextJsonSamples
{
    public class SerializeCustomEncoding
    {
        public static void Run()
        {
            string jsonString;
            WeatherForecast weatherForecast = 
                WeatherForecastFactories.CreateWeatherForecastCyrillic();
            weatherForecast.DisplayPropertyValues();

            Console.WriteLine("Default serialization - non-ASCII escaped");
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            jsonString = JsonSerializer.Serialize(weatherForecast, options);
            Console.WriteLine(jsonString);
            Console.WriteLine();

            Console.WriteLine("Serialize language sets unescaped");
            // <LanguageSets>
            options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            jsonString = JsonSerializer.Serialize(weatherForecast, options);
            // </LanguageSets>
            Console.WriteLine(jsonString);
            Console.WriteLine();

            Console.WriteLine("Serialize selected unescaped characters");
            // <SelectedCharacters>
            var encoderSettings = new TextEncoderSettings();
            encoderSettings.AllowCharacters('\u0436', '\u0430');
            encoderSettings.AllowRange(UnicodeRanges.BasicLatin);
            options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(encoderSettings),
                WriteIndented = true
            };
            jsonString = JsonSerializer.Serialize(weatherForecast, options);
            // </SelectedCharacters>
            Console.WriteLine(jsonString);
            Console.WriteLine();

            Console.WriteLine("Serialize using unsafe relaxed encoder");
            // <UnsafeRelaxed>
            options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };
            jsonString = JsonSerializer.Serialize(weatherForecast, options);
            // </UnsafeRelaxed>
            Console.WriteLine(jsonString);
        }
    }
}
