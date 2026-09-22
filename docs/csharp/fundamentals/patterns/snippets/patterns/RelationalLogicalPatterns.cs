static class RelationalLogicalPatterns
{
    public static void Run()
    {
        ShowExpressionAndPattern(-4, threshold: 0);
        Console.WriteLine(
            $"Comfortable temperature: {IsComfortableTemperature(21)}");
        Console.WriteLine($"Weekend: {IsWeekend(DayOfWeek.Saturday)}");
        Console.WriteLine($"Active status: {IsActive(Status.Pending)}");
        Console.WriteLine($"Accepted priority: {IsAcceptedPriority(9)}");
        Console.WriteLine(
            $"Heat warning: {GetHeatWarning(36, isOutdoors: true)}");
    }

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

    // <AndPattern>
    static bool IsComfortableTemperature(int temperature) =>
        temperature is >= 18 and <= 24;
    // </AndPattern>

    // <OrNotPatterns>
    static bool IsWeekend(DayOfWeek day) =>
        day is DayOfWeek.Saturday or DayOfWeek.Sunday;

    static bool IsActive(Status status) =>
        status is not Status.Complete;

    enum Status
    {
        Pending,
        Running,
        Complete
    }
    // </OrNotPatterns>

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
