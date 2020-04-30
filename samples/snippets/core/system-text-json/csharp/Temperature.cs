using System.Text.Json.Serialization;

namespace SystemTextJsonSamples
{
    [JsonConverter(typeof(TemperatureConverter))]
    public struct Temperature
    {
        public Temperature(int degrees, bool celsius)
        {
            _degrees = degrees;
            _isCelsius = celsius;
        }
        private bool _isCelsius;
        private int _degrees;
        public int Degrees => _degrees;
        public bool IsCelsius => _isCelsius;
        public bool IsFahrenheit => !_isCelsius;
        public override string ToString() =>
            $"{_degrees.ToString()}{(_isCelsius ? "C" : "F")}";
        public static Temperature Parse(string input)
        {
            int degrees = int.Parse(input.Substring(0, input.Length - 1));
            bool celsius = (input.Substring(input.Length - 1) == "C");
            return new Temperature(degrees, celsius);
        }
    }
}
