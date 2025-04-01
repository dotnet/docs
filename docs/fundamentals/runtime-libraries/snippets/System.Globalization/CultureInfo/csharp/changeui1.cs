// <Snippet4>
using System;
using System.Globalization;

public class ChangeUICultureEx
{
    public static void Main()
    {
        CultureInfo current = CultureInfo.CurrentUICulture;
        Console.WriteLine($"The current UI culture is {current.Name}");
        CultureInfo newUICulture;
        if (current.Name.Equals("sl-SI"))
            newUICulture = new CultureInfo("hr-HR");
        else
            newUICulture = new CultureInfo("sl-SI");

        CultureInfo.CurrentUICulture = newUICulture;
        Console.WriteLine($"The current UI culture is now {CultureInfo.CurrentUICulture.Name}");
    }
}
// The example displays output like the following:
//     The current UI culture is en-US
//     The current UI culture is now sl-SI
// </Snippet4>
