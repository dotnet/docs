[McpServerTool(Name = "get_city_weather")]
[Description("Describes random weather in the provided city.")]
public string GetCityWeather(
    [Description("Name of the city to return weather for")] string city)
{
    // Read the environment variable during tool execution.
    // Alternatively, this could be read during startup and passed via IOptions dependency injection
    var weather = Environment.GetEnvironmentVariable("WEATHER_CHOICES");
    if (string.IsNullOrWhitespace(weather))
    {
        weather = "balmy,rainy,stormy";
    }

    var weatherChoices = weather.Split(",");
    var selectedWeatherIndex =  Random.Shared.Next(0, weatherChoices.Length);

    return $"The weather in {city} is {weatherChoices[selectedWeatherIndex]}.";
}
