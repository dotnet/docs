using System.Text.Json.Serialization;

namespace SystemTextJsonSamples
{
    [JsonConverter(typeof(TemperatureConverter))]
    public struct Temperature
    {
        public Temperature(int degrees, bool celsius)
        {
            Degrees = degrees;
            IsCelsius = celsius;
        }

        public int Degrees { get; }
        public bool IsCelsius { get; }
        public bool IsFahrenheit => !IsCelsius;

        public override string ToString() =>
            $"{Degrees}{(IsCelsius ? "C" : "F")}";

        public static Temperature Parse(string input)
        {
            int degrees = int.Parse(input.Substring(0, input.Length - 1));
            bool celsius = input.Substring(input.Length - 1) == "C";

            return new Temperature(degrees, celsius);
        }
    }
}
