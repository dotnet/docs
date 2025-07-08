// <Snippet1>
using System;
using System.Globalization;

public class Example1
{
    public static void Main()
    {
        Console.WriteLine($"The current UI culture: {CultureInfo.CurrentUICulture.Name}");

        CultureInfo.CurrentUICulture = CultureInfo.CreateSpecificCulture("fr-FR");
        Console.WriteLine($"The current UI culture: {CultureInfo.CurrentUICulture.Name}");
    }
}
// The example displays output like the following:
//       The current UI culture: en-US
//       The current UI culture: fr-FR
// </Snippet1>
