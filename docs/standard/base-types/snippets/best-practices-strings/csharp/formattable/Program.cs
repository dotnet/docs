using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        Decimal value = 126.03m;
        FormattableString amount = $"The amount is {value:C}";
        Console.WriteLine(amount.ToString());
        Console.WriteLine(amount.ToString(new CultureInfo("fr-FR")));
        Console.WriteLine(FormattableString.Invariant(amount));
    }
}
// The example displays the following output:
//    The amount is $126.03
//    The amount is 126,03 €
//    The amount is ¤126.03
