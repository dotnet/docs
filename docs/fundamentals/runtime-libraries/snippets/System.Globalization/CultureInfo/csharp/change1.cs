// <Snippet3>
using System;
using System.Globalization;

public class ChangeEx1
{
    public static void Main()
    {
        CultureInfo current = CultureInfo.CurrentCulture;
        Console.WriteLine($"The current culture is {current.Name}");
        CultureInfo newCulture;
        if (current.Name.Equals("fr-FR"))
            newCulture = new CultureInfo("fr-LU");
        else
            newCulture = new CultureInfo("fr-FR");

        CultureInfo.CurrentCulture = newCulture;
        Console.WriteLine($"The current culture is now {CultureInfo.CurrentCulture.Name}");
    }
}
// The example displays output like the following:
//     The current culture is en-US
//     The current culture is now fr-FR
// </Snippet3>
