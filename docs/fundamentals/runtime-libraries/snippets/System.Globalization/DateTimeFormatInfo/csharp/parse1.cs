// <Snippet15>
using System;
using System.Globalization;

public class ParseEx1
{
    public static void Main()
    {
        string[] dateStrings = { "08/18/2014", "01/02/2015" };
        string[] cultureNames = { "en-US", "en-GB", "fr-FR", "fi-FI" };

        foreach (var cultureName in cultureNames)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            Console.WriteLine($"Parsing strings using the {culture.Name} culture.");
            foreach (var dateStr in dateStrings)
            {
                try
                {
                    Console.WriteLine(String.Format(culture,
                                      "   '{0}' --> {1:D}", dateStr,
                                      DateTime.Parse(dateStr, culture)));
                }
                catch (FormatException)
                {
                    Console.WriteLine($"   Unable to parse '{dateStr}'");
                }
            }
        }
    }
}
// The example displays the following output:
//       Parsing strings using the en-US culture.
//          '08/18/2014' --> Monday, August 18, 2014
//          '01/02/2015' --> Friday, January 02, 2015
//       Parsing strings using the en-GB culture.
//          Unable to parse '08/18/2014'
//          '01/02/2015' --> 01 February 2015
//       Parsing strings using the fr-FR culture.
//          Unable to parse '08/18/2014'
//          '01/02/2015' --> dimanche 1 février 2015
//       Parsing strings using the fi-FI culture.
//          Unable to parse '08/18/2014'
//          '01/02/2015' --> 1. helmikuuta 2015
// </Snippet15>
