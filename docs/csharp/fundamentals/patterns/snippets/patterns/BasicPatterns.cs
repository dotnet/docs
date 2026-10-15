static class BasicPatterns
{
    public static void Run()
    {
        PrintPrice(19.95m);
        Console.WriteLine(FormatSensorValue(21.5));
        Console.WriteLine(GetCommandMessage(Command.Start));
        Console.WriteLine(HasText("ready"));
        Console.WriteLine(GetDeliveryMessage(new ExpressDelivery(800)));
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
    static string GetDeliveryMessage(object delivery) =>
        delivery switch
        {
            ExpressDelivery express
                when EstimateDays(express) is var days && days <= 2
                    => $"Arrives in {days} day{(days == 1 ? "" : "s")}",
            ExpressDelivery => "Express delivery for your location takes more than two days",
            _ => "Standard delivery"
        };

    static int EstimateDays(ExpressDelivery delivery) =>
        delivery.MilesAway <= 500 ? 1 :
        delivery.MilesAway <= 1_000 ? 2 : 3;

    record ExpressDelivery(int MilesAway);
    // </VarPatternWhen>
}
