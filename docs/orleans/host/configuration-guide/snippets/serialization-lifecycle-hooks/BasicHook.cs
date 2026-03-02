using Orleans;

namespace SerializationLifecycleHooks;

// <BasicHookType>
[GenerateSerializer]
[SerializationCallbacks(typeof(TemperatureReadingHooks))]
public class TemperatureReading
{
    [Id(0)]
    public double Celsius { get; set; }

    [Id(1)]
    public DateTime Timestamp { get; set; }

    [NonSerialized]
    private double _fahrenheit;

    public double Fahrenheit => _fahrenheit;

    internal void RecomputeFahrenheit()
    {
        _fahrenheit = Celsius * 9.0 / 5.0 + 32.0;
    }
}
// </BasicHookType>

// <BasicHookClass>
public class TemperatureReadingHooks
{
    public void OnDeserialized(TemperatureReading value)
    {
        // Recompute the cached Fahrenheit value after deserialization.
        value.RecomputeFahrenheit();
    }
}
// </BasicHookClass>
