﻿using System;
using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class RoundtripCamelCasePropertyNames
    {
        public static void Run()
        {
            string jsonString;
            WeatherForecastWithPropertyNameAttribute weatherForecast =
                WeatherForecastFactories.CreateWeatherForecastWithPropertyNameAttribute();
            weatherForecast.DisplayPropertyValues();

            // <Serialize>
            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            jsonString = JsonSerializer.Serialize(weatherForecast, serializeOptions);
            // </Serialize>
            Console.WriteLine($"JSON output:\n{jsonString}\n");

            // <Deserialize>
            var deserializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            weatherForecast =
                JsonSerializer.Deserialize<WeatherForecastWithPropertyNameAttribute>(
                    jsonString, deserializeOptions);
            // </Deserialize>
            weatherForecast.DisplayPropertyValues();
        }
    }
}
