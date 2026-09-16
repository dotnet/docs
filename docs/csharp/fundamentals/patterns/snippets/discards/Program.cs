namespace Discards;

class Program
{
    static void Main()
    {
        ShowStatus();
        ShowForecast();
        ValidateNumber();
        ValidateLabel("ZX-42");
        ShowLambdaDiscards();
    }

    // <DiscardPattern>
    static void ShowStatus()
    {
        int statusCode = 503;
        string message = statusCode switch
        {
            200 => "Ready",
            404 => "Not found",
            _ => "Another status"
        };

        Console.WriteLine(message);
    }
    // </DiscardPattern>

    // <TupleDiscards>
    static void ShowForecast()
    {
        var (city, high, _, _) = GetForecast();
        Console.WriteLine($"{city}: high {high}°C");

        static (string City, int High, int Low, int RainChance) GetForecast() =>
            ("Portland", 18, 9, 40);
    }
    // </TupleDiscards>

    // <OutDiscard>
    static void ValidateNumber()
    {
        bool isNumber = int.TryParse("42", out _);
        Console.WriteLine($"The text is numeric: {isNumber}");
    }
    // </OutDiscard>

    // <DiscardAssignment>
    static void ValidateLabel(string? label)
    {
        _ = label ?? throw new ArgumentNullException(nameof(label));
        Console.WriteLine("Label accepted.");
    }
    // </DiscardAssignment>

    // <LambdaDiscards>
    static void ShowLambdaDiscards()
    {
        EventHandler handler = (_, _) => Console.WriteLine("Timer tick");
        handler(null, EventArgs.Empty);
    }
    // </LambdaDiscards>
}
