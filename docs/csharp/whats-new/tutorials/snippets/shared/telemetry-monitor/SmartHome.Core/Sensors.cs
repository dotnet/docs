namespace SmartHome.Core;

// <ClosedSensor>
// A closed class restricts its direct subtypes to this assembly. A 'closed'
// class is implicitly abstract.
public closed record class Sensor;

// Seal the cases whose shape is final.
public sealed record class Temperature(double Celsius) : Sensor;
public sealed record class Humidity(double Percent) : Sensor;

// Leave a case unsealed as an "escape hatch" so other assemblies can specialize it.
public record class Contact(bool Open) : Sensor;
// </ClosedSensor>

public static class SensorReporter
{
    // <SensorExhaustive>
    public static string Describe(Sensor sensor) => sensor switch
    {
        Temperature temperature => $"{temperature.Celsius:F1}°C",
        Humidity humidity => $"{humidity.Percent:F0}% RH",
        Contact contact => contact.Open ? "open" : "closed",
        // No default arm is needed. Sensor is closed, so these cases are exhaustive.
    };
    // </SensorExhaustive>
}
