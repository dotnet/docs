using System;

namespace WeatherMicroservice
{
    public class WeatherReport
    {
        private static readonly string[] PossibleConditions = new string[]
        {
            "Sunny",
            "Mostly Sunny",
            "Partly Sunny",
            "Partly Cloudy",
            "Mostly Cloudy",
            "Rain"
        };

        public WeatherReport(double latitude, double longitude, int daysInFuture)
        {
            var generator = new Random((int)(latitude + longitude) + daysInFuture);

            HiTemperature = generator.Next(40, 100);
            LoTemperature = generator.Next(0, HiTemperature);
            AverageWindSpeed = generator.Next(0, 45);
            Conditions = PossibleConditions[generator.Next(0, PossibleConditions.Length - 1)];
        }

        public int HiTemperature { get; }
        public int LoTemperature { get; }
        public int AverageWindSpeed { get; }
        public string Conditions { get; }
    }
}
