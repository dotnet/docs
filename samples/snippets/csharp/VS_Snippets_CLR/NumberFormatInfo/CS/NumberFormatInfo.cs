//Types:System.Globalization.NumberFormatInfo Vendor: Richter
//<snippet1>
using System;
using System.Globalization;
using System.Text;

public sealed class App 
{
    static void Main() 
    {
        StringBuilder sb = new StringBuilder();

        // Loop through all the specific cultures known to the CLR.
        foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.SpecificCultures)) 
        {
            // Only show the currency symbols for cultures that speak English.
            if (ci.TwoLetterISOLanguageName != "en") continue;
             
            //<snippet2>
            // Display the culture name and currency symbol.
            NumberFormatInfo nfi = ci.NumberFormat;
            sb.AppendFormat("The currency symbol for '{0}' is '{1}'",
                ci.DisplayName, nfi.CurrencySymbol);
            sb.AppendLine();
            //</snippet2>
        }
        Console.WriteLine(sb.ToString());
    }
}

// This code produces the following output.
//
// The currency symbol for 'English (United States)' is '$'
// The currency symbol for 'English (United Kingdom)' is '£'
// The currency symbol for 'English (Australia)' is '$'
// The currency symbol for 'English (Canada)' is '$'
// The currency symbol for 'English (New Zealand)' is '$'
// The currency symbol for 'English (Ireland)' is '?'
// The currency symbol for 'English (South Africa)' is 'R'
// The currency symbol for 'English (Jamaica)' is 'J$'
// The currency symbol for 'English (Caribbean)' is '$'
// The currency symbol for 'English (Belize)' is 'BZ$'
// The currency symbol for 'English (Trinidad and Tobago)' is 'TT$'
// The currency symbol for 'English (Zimbabwe)' is 'Z$'
// The currency symbol for 'English (Republic of the Philippines)' is 'Php'
//</snippet1>