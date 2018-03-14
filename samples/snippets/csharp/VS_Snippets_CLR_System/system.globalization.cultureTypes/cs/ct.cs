//<snippet1>
// This example demonstrates the CultureTypes enumeration 
// and the CultureInfo.CultureTypes property.

using System;
using System.Globalization;

class Sample
{
    public static void Main()
    {
        // Create a table of most culture types. 
        CultureTypes[] mostCultureTypes = new CultureTypes[] {
                        CultureTypes.NeutralCultures, 
                        CultureTypes.SpecificCultures, 
                        CultureTypes.InstalledWin32Cultures, 
                        CultureTypes.UserCustomCulture, 
                        CultureTypes.ReplacementCultures, 
                        CultureTypes.FrameworkCultures,
                        CultureTypes.WindowsOnlyCultures
                        };
        CultureInfo[] allCultures;
        CultureTypes combo;

        // Get and enumerate all cultures.
        allCultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
        foreach (CultureInfo ci in allCultures)
        {
            // Display the name of each culture.
            Console.WriteLine("Culture: {0}", ci.Name);

            // Get the culture types of each culture. 
            combo = ci.CultureTypes;

            // Display the name of each culture type flag that is set.
            Console.Write("  ");
            foreach (CultureTypes ct in mostCultureTypes)
                if (0 != (ct & combo))
                    Console.Write("{0} ", ct);
            Console.WriteLine();
        }
    }
}

/*
The following is a portion of the results produced by this code example.
.
.
.
Culture: tg
  NeutralCultures InstalledWin32Cultures 
Culture: ta
  NeutralCultures InstalledWin32Cultures FrameworkCultures 
Culture: te
  NeutralCultures InstalledWin32Cultures FrameworkCultures 
Culture: syr
  NeutralCultures InstalledWin32Cultures FrameworkCultures 
Culture: tg-Cyrl-TJ
  SpecificCultures InstalledWin32Cultures 
Culture: ta-IN
  SpecificCultures InstalledWin32Cultures FrameworkCultures 
Culture: te-IN
  SpecificCultures InstalledWin32Cultures FrameworkCultures 
Culture: syr-SY
  SpecificCultures InstalledWin32Cultures FrameworkCultures 
Culture: tg-Cyrl
  NeutralCultures InstalledWin32Cultures 
.
.
.
*/
//</snippet1>
