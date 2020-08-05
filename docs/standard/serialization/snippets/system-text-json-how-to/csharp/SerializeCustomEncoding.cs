// <SnippetUsings>
using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
// </SnippetUsings>

namespace SystemTextJsonSamples
{
    public class SerializeCustomEncoding
    {
        public static void Run()
        {
            string jsonString;
            WeatherForecast weatherForecast = WeatherForecastFactories.CreateWeatherForecastCyrillic();
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
            // <SnippetLanguageSets>
            options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            jsonString = JsonSerializer.Serialize(weatherForecast, options);
            // </SnippetLanguageSets>
            Console.WriteLine(jsonString);
            Console.WriteLine();

            Console.WriteLine("Serialize selected unescaped characters");
            // <SnippetSelectedCharacters>
            var encoderSettings = new TextEncoderSettings();
            encoderSettings.AllowCharacters('\u0436', '\u0430');
            encoderSettings.AllowRange(UnicodeRanges.BasicLatin);
            options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(encoderSettings),
                WriteIndented = true
            };
            jsonString = JsonSerializer.Serialize(weatherForecast, options);
            // </SnippetSelectedCharacters>
            Console.WriteLine(jsonString);
            Console.WriteLine();

            Console.WriteLine("Serialize using unsafe relaxed encoder");
            // <SnippetUnsafeRelaxed>
            options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };
            jsonString = JsonSerializer.Serialize(weatherForecast, options);
            // </SnippetUnsafeRelaxed>
            Console.WriteLine(jsonString);
        }
    }
}
