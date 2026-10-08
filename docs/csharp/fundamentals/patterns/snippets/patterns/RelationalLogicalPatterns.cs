static class RelationalLogicalPatterns
{
    public static void Run()
    {
        Console.WriteLine($"Temperature: {ClassifyTemperature(21)}");
        ShowExpressionAndPattern(-4, threshold: 0);
        Console.WriteLine(
            $"Weekend pattern: {IsWeekendPattern(DayOfWeek.Saturday)}; " +
            $"imperative: {IsWeekendImperative(DayOfWeek.Saturday)}");
        Console.WriteLine($"Accepted priority: {IsAcceptedPriority(9)}");
        Console.WriteLine(
            $"Heat warning: {GetHeatWarning(36, isOutdoors: true)}");
    }

    // <CombinedPatterns>
    static string ClassifyTemperature(int temperature) =>
        temperature switch
        {
            < 0 => "Below freezing",
            >= 18 and <= 24 => "Comfortable",
            (>= 0 and < 10) or > 30 => "Far outside the comfortable range",
            _ => "Cool or warm"
        };
    // </CombinedPatterns>

    // <ExpressionAndPattern>
    static void ShowExpressionAndPattern(int temperature, int threshold)
    {
        bool belowThreshold = temperature < threshold;
        bool belowFreezing = temperature is < 0;

        string description = temperature switch
        {
            < 0 => "Freezing",
            0 => "Freezing point",
            > 0 => "Above freezing"
        };

        Console.WriteLine(
            $"Below threshold: {belowThreshold}; " +
            $"below freezing: {belowFreezing}; {description}");
    }
    // </ExpressionAndPattern>

    // <PatternAndImperative>
    static bool IsWeekendPattern(DayOfWeek day) =>
        day is DayOfWeek.Saturday or DayOfWeek.Sunday;

    static bool IsWeekendImperative(DayOfWeek day) =>
        day == DayOfWeek.Saturday || day == DayOfWeek.Sunday;
    // </PatternAndImperative>

    // <ParenthesizedPattern>
    static bool IsAcceptedPriority(int priority) =>
        priority is (>= 1 and <= 3) or 9;
    // </ParenthesizedPattern>

    // <WhenGuard>
    static string GetHeatWarning(int temperature, bool isOutdoors) =>
        temperature switch
        {
            > 35 when isOutdoors => "High heat outdoors",
            > 35 => "High heat",
            _ => "No heat warning"
        };
    // </WhenGuard>
}
