static class BasicPatterns
{
    public static void Run()
    {
        PrintPrice(19.95m);
        Console.WriteLine(FormatSensorValue(21.5));
        Console.WriteLine(GetCommandMessage(Command.Start));
        Console.WriteLine(HasText("ready"));
        Console.WriteLine(DescribeAverage([88, 92, 95]));
    }

    // <DeclarationPattern>
    static void PrintPrice(object value)
    {
        if (value is decimal amount)
        {
            Console.WriteLine($"Price: {amount:C}");
        }
    }
    // </DeclarationPattern>

    // <DeclarationSwitch>
    static string FormatSensorValue(object reading) =>
        reading switch
        {
            int count => $"Count: {count}",
            double temperature => $"Temperature: {temperature:F1}°C",
            string message => $"Message: {message}",
            _ => "Unsupported reading"
        };
    // </DeclarationSwitch>

    enum Command
    {
        Start,
        Stop,
        Pause
    }

    // <ConstantPatterns>
    static string GetCommandMessage(Command command) =>
        command switch
        {
            Command.Start => "Starting",
            Command.Stop => "Stopping",
            Command.Pause => "Pausing",
            _ => "Unknown command"
        };
    // </ConstantPatterns>

    // <ConstantNullPattern>
    static bool HasText(string? text) => text is not null;
    // </ConstantNullPattern>

    // <VarPatternWhen>
    static string DescribeAverage(int[] scores) =>
        scores.Average() switch
        {
            var average when average >= 90 => $"Excellent: {average:F1}",
            var average when average >= 70 => $"Passing: {average:F1}",
            var average => $"Needs practice: {average:F1}"
        };
    // </VarPatternWhen>
}
