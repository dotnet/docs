using System;
using System.Collections.Generic;

namespace NewCsharp9
{
    public class WeatherForecastOptions
    {

    }

    public class WeatherForecast
    {

    }

    public class WeatherStation
    {
        public string Location { get; init; }

        // <WeatherStationField>
        private List<WeatherObservation> _observations = new();
        // </WeatherStationField>

        // <ForecastSignature>
        public WeatherForecast ForecastFor(DateTime forecastDate, WeatherForecastOptions options)
        // </ForecastSignature>
        {
            // implementation elided
            return new();
        }
    }

    public class FitAndFinish
    {
        public static void Examples()
        {
            // <InitWeatherStation>
            WeatherStation station = new() { Location = "Seattle, WA" };
            // </InitWeatherStation>

            // <TargetTypeNewArgument>
            var forecast = station.ForecastFor(DateTime.Now.AddDays(2), new());
            // </TargetTypeNewArgument>
        }
    }
}
