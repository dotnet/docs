namespace SmartHome.Core;

// <ReadingUnion>
// A union declaration is shorthand for a struct that holds one of the listed
// case types. The 'string?' case makes the contents nullable.
public union Reading(double, bool, string?);
// </ReadingUnion>

public static class ReadingReporter
{
    // <ReadingConsume>
    public static string Render(Reading reading) => reading switch
    {
        // Each type pattern applies to the union's contents, not to the Reading value.
        double measure => $"{measure:F1}",
        bool isOn => isOn ? "on" : "off",
        string text => text,
        // The contents can be null because 'string?' is a nullable case type.
        null => "no reading",
    };
    // </ReadingConsume>
}
