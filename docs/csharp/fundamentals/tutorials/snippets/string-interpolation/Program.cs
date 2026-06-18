using System.Globalization;

namespace StringInterpolationTutorial;

public static class Program
{
    public static void Main()
    {
        Greeting();
        Console.WriteLine();
        FormatValues();
        Console.WriteLine();
        AlignColumns();
        Console.WriteLine();
        CultureSpecific();
    }

    private static void Greeting()
    {
        // <Greeting>
        string name = "Maria";
        int itemCount = 3;

        // Prefix a string literal with $ to interpolate expressions inside braces.
        Console.WriteLine($"Hello, {name}! You have {itemCount} items in your cart.");
        // => Hello, Maria! You have 3 items in your cart.
        // </Greeting>
    }

    private static void FormatValues()
    {
        // <Format>
        decimal subtotal = 23.5m;
        decimal taxRate = 0.08m;

        // Follow an expression with :format to apply a standard or custom format string.
        Console.WriteLine($"Subtotal: {subtotal:C}");
        Console.WriteLine($"Tax rate: {taxRate:P0}");
        Console.WriteLine($"Total:    {subtotal * (1 + taxRate):C}");
        // => Subtotal: $23.50
        // => Tax rate: 8%
        // => Total:    $25.38
        // </Format>
    }

    private static void AlignColumns()
    {
        // <Align>
        (string Name, int Quantity, decimal Price)[] orders =
        [
            ("Espresso", 2, 3.50m),
            ("Cappuccino", 1, 4.25m),
            ("Tea", 4, 2.00m),
        ];

        // Follow an expression with ,width to set a minimum field width.
        // A positive width right-aligns; a negative width left-aligns.
        foreach (var order in orders)
        {
            Console.WriteLine($"{order.Name,-12}{order.Quantity,3}{order.Price * order.Quantity,10:C}");
        }
        // => Espresso      2     $7.00
        // => Cappuccino    1     $4.25
        // => Tea           4     $8.00
        // </Align>
    }

    private static void CultureSpecific()
    {
        // <Culture>
        decimal total = 1234.56m;

        // An interpolated string uses the current culture by default.
        // Use string.Create with a culture to control the formatting explicitly.
        string germanReceipt = string.Create(
            new CultureInfo("de-DE"), $"Gesamt: {total:C}");
        string invariantLog = string.Create(
            CultureInfo.InvariantCulture, $"total={total:F2}");

        Console.WriteLine(germanReceipt);
        Console.WriteLine(invariantLog);
        // => Gesamt: 1.234,56 €
        // => total=1234.56
        // </Culture>
    }
}
