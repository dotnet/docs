static class RelationalLogicalPatterns
{
    public static void Run()
    {
        ShowExpressionAndPattern(-4);
        Console.WriteLine(GetVentilationMode(21));
        Console.WriteLine(GetTimetable(ServiceDay.Saturday));
        Console.WriteLine(GetServiceAction(ServiceStatus.Limited));
        Console.WriteLine(GetPriorityAction(9));
        Console.WriteLine(GetShippingPrice(22, isHoliday: true));
    }

    // <ExpressionAndPattern>
    static void ShowExpressionAndPattern(int temperature)
    {
        bool freezeWarningFromExpression = temperature < 0;
        bool freezeWarningFromPattern = temperature is < 0;

        string description = temperature switch
        {
            < 0 => "Freezing",
            0 => "Freezing point",
            > 0 => "Above freezing"
        };

        string warning = freezeWarningFromPattern
            ? "Show freeze warning"
            : "No freeze warning";

        Console.WriteLine(
            $"Expression: {freezeWarningFromExpression}; " +
            $"pattern: {freezeWarningFromPattern}; {description}; {warning}");
    }
    // </ExpressionAndPattern>

    // <AndPattern>
    static string GetVentilationMode(int temperature) =>
        temperature is >= 18 and <= 24
            ? "Keep current airflow"
            : "Adjust airflow";
    // </AndPattern>

    // <OrNotPatterns>
    static string GetTimetable(ServiceDay day) =>
        day is ServiceDay.Saturday or ServiceDay.Sunday
            ? "Weekend timetable"
            : "Weekday timetable";

    static bool IsAvailable(ServiceStatus status) =>
        status is not ServiceStatus.Closed;

    static string GetServiceAction(ServiceStatus status) =>
        IsAvailable(status)
            ? "Offer trip planning"
            : "Show service unavailable";

    enum ServiceDay
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    enum ServiceStatus
    {
        Open,
        Limited,
        Closed
    }
    // </OrNotPatterns>

    // <ParenthesizedPattern>
    static bool IsAcceptedPriority(int priority) =>
        priority is (>= 1 and <= 3) or 9;

    static string GetPriorityAction(int priority) =>
        IsAcceptedPriority(priority)
            ? "Add request to queue"
            : "Reject unsupported priority";
    // </ParenthesizedPattern>

    // <WhenGuard>
    static decimal GetShippingPrice(decimal weightKg, bool isHoliday) =>
        weightKg switch
        {
            > 20 when isHoliday => 45.00m,
            > 20 => 35.00m,
            _ when isHoliday => 20.00m,
            _ => 15.00m
        };
    // </WhenGuard>
}
