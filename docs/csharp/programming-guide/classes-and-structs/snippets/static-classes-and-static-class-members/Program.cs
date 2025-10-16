//<Snippet1>
public static class TemperatureConverter
{
    public static double CelsiusToFahrenheit(string temperatureCelsius) =>
        double.Parse(temperatureCelsius) * 9 / 5 + 32;

    public static double FahrenheitToCelsius(string temperatureFahrenheit) =>
        (double.Parse(temperatureFahrenheit) - 32) * 5 / 9;
}

class TestTemperatureConverter
{
    static void Main()
    {
        Console.WriteLine("Please select the convertor direction");
        Console.WriteLine("1. From Celsius to Fahrenheit.");
        Console.WriteLine("2. From Fahrenheit to Celsius.");
        Console.Write(":");

        string? selection = Console.ReadLine();

        switch (selection)
        {
            case "1":
                Console.Write("Please enter the Celsius temperature: ");
                var f = TemperatureConverter.CelsiusToFahrenheit(Console.ReadLine() ?? "0");
                Console.WriteLine($"Temperature in Fahrenheit: {f:F2}");
                break;

            case "2":
                Console.Write("Please enter the Fahrenheit temperature: ");
                var c = TemperatureConverter.FahrenheitToCelsius(Console.ReadLine() ?? "0");
                Console.WriteLine($"Temperature in Celsius: {c:F2}");
                break;

            default:
                Console.WriteLine("Please select a convertor.");
                break;
        }

        // Keep the console window open in debug mode.
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}
/* Example Output:
    Please select the convertor direction
    1. From Celsius to Fahrenheit.
    2. From Fahrenheit to Celsius.
    :2
    Please enter the Fahrenheit temperature: 20
    Temperature in Celsius: -6.67
    Press any key to exit.
 */
//</Snippet1>

public delegate void EventType();

//<Snippet2>
public class Automobile
{
    public static int NumberOfWheels { get; } = 4;

    public static int SizeOfGasTank => 15;

    public static void Drive() { }

    public static event EventType? RunOutOfGas;

    // Other non-static fields and properties...
}
//</Snippet2>

class TestAutomobile
{
    void Test()
    {
        //<Snippet3>
        Automobile.Drive();
        var i = Automobile.NumberOfWheels;
        //</Snippet3>
    }
}
