using System;

namespace NewCsharp9
{
    // <DeclareWeatherObservation>
    public struct WeatherObservation
    {
        public DateTime RecordedAt { get; init; }
        public decimal TemperatureInCelsius { get; init; }
        public decimal PressureInMillibars { get; init; }

        public override string ToString() =>
            $"At {RecordedAt:h:mm tt} on {RecordedAt:M/d/yyyy}: " +
            $"Temp = {TemperatureInCelsius}, with {PressureInMillibars} pressure";
    }
    // </DeclareWeatherObservation>

    public static class WeatherExamples
    {
        public static void InitWeather()
        {
            // <UseWeatherObservation>
            var now = new WeatherObservation 
            { 
                RecordedAt = DateTime.Now, 
                TemperatureInCelsius = 20, 
                PressureInMillibars = 998.0m 
            };
            // </UseWeatherObservation>

            //now.TemperatureInCelsius = 12;
            Console.WriteLine(now);
        }
    }
}
