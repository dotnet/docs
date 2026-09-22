static class PropertyPositionalPatterns
{
    public static void Run()
    {
        Console.WriteLine($"Hot and humid: {IsHotAndHumid(
            new WeatherReading(32, 75))}");
        Console.WriteLine($"Date: {DescribeDate(
            new DateTime(2026, 9, 19))}");
        Console.WriteLine($"Point: {ClassifyPoint(new GridPoint(0, 5))}");
        Console.WriteLine($"Crossing: {GetCrossingInstruction(
            PedestrianSignal.Walk, crossingIsClear: true)}");
    }

    // <PropertyPattern>
    static bool IsHotAndHumid(WeatherReading reading) =>
        reading is { TemperatureC: > 30, HumidityPercent: > 70 };

    sealed record WeatherReading(int TemperatureC, int HumidityPercent);
    // </PropertyPattern>

    // <NestedPropertyPattern>
    static string DescribeDate(object? value) =>
        value switch
        {
            DateTime { Date.DayOfWeek:
                DayOfWeek.Saturday or DayOfWeek.Sunday } => "Weekend date",
            DateTime => "Weekday date",
            null => "No date",
            _ => "Not a date"
        };
    // </NestedPropertyPattern>

    // <ObjectPropertyPattern>
    static string ClassifyPoint(GridPoint point) =>
        point switch
        {
            { X: 0, Y: 0 } => "Origin",
            { X: 0 } => "On the vertical axis",
            { Y: 0 } => "On the horizontal axis",
            _ => "Away from both axes"
        };

    readonly record struct GridPoint(int X, int Y);
    // </ObjectPropertyPattern>

    // <TuplePattern>
    static string GetCrossingInstruction(
        PedestrianSignal signal, bool crossingIsClear) =>
        (signal, crossingIsClear) switch
        {
            (PedestrianSignal.Walk, true) => "Cross now",
            (PedestrianSignal.Walk, false) => "Wait for the crossing to clear",
            _ => "Wait for the walk signal"
        };

    enum PedestrianSignal
    {
        Stop,
        Walk
    }
    // </TuplePattern>
}
