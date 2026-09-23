namespace Discards;

class Program
{
    static void Main()
    {
        ShowStatus();
        ShowForecast();
        CheckInput();
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
    static void CheckInput()
    {
        string text = "42";

        if (IsWholeNumber(text))
        {
            Console.WriteLine($"Accepted: {text}");
        }
        else
        {
            Console.WriteLine("Enter a whole number.");
        }

        static bool IsWholeNumber(string text) => int.TryParse(text, out _);
    }
    // </OutDiscard>

    // <LambdaDiscards>
    static void ShowLambdaDiscards()
    {
        EventHandler handler = (_, _) => Console.WriteLine("Timer tick");
        handler(null, EventArgs.Empty);
    }
    // </LambdaDiscards>
}
