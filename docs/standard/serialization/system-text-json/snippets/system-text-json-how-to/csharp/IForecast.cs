namespace SystemTextJsonSamples
{
    public interface IForecast
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string? Summary { get; set; }
    }

    public class Forecast : IForecast
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string? Summary { get; set; }
        public int WindSpeed { get; set; }
    }

    public class Forecasts
    {
        public IForecast? Monday { get; set; }
        public object? Tuesday { get; set; }
    }
}
