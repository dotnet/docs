// <Snippet17>
using System;
using System.Globalization;
using System.Text.Json;
using System.Threading;

public class Example2
{
    public static void Main2()
    {
        // Display the currency value.
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
        Decimal value = 16039.47m;
        Console.WriteLine($"Current Culture: {CultureInfo.CurrentCulture.DisplayName}");
        Console.WriteLine($"Currency Value: {value:C2}");

        // Serialize the currency data.
        CurrencyValue data = new()
        {
            Amount = value,
            CultureName = CultureInfo.CurrentCulture.Name
        };
        string serialized = JsonSerializer.Serialize(data);
        Console.WriteLine();

        // Change the current culture.
        CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
        Console.WriteLine($"Current Culture: {CultureInfo.CurrentCulture.DisplayName}");

        // Deserialize the data.
        CurrencyValue restoredData = JsonSerializer.Deserialize<CurrencyValue>(serialized);

        // Display the round-tripped value.
        CultureInfo culture = CultureInfo.CreateSpecificCulture(restoredData.CultureName);
        Console.WriteLine($"Currency Value: {restoredData.Amount.ToString("C2", culture)}");
    }
}

internal struct CurrencyValue
{
    public decimal Amount { get; set; }
    public string CultureName { get; set; }
}

// The example displays the following output:
//       Current Culture: English (United States)
//       Currency Value: $16,039.47
//
//       Current Culture: English (United Kingdom)
//       Currency Value: $16,039.47
// </Snippet17>
