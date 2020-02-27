// <snippet1>
using System;
using System.Globalization;

class Sample
{
    public static void Main()
    {
        // Get and enumerate all cultures.
        var allCultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
        foreach (var ci in allCultures)
        {
            // Display the name of each culture.
            Console.Write($"{ci.EnglishName} ({ci.Name}): ");
            // Indicate the culture type.
            if (ci.CultureTypes.HasFlag(CultureTypes.NeutralCultures))
               Console.Write(" NeutralCulture");
            if (ci.CultureTypes.HasFlag(CultureTypes.SpecificCultures))
               Console.Write(" SpecificCulture");
            Console.WriteLine();         
        }
    }
}
/*
The following is a portion of the output from this example.
      Tajik (tg):  NeutralCulture
      Tajik (Cyrillic) (tg-Cyrl):  NeutralCulture
      Tajik (Cyrillic, Tajikistan) (tg-Cyrl-TJ):  SpecificCulture
      Thai (th):  NeutralCulture
      Thai (Thailand) (th-TH):  SpecificCulture
      Tigrinya (ti):  NeutralCulture
      Tigrinya (Eritrea) (ti-ER):  SpecificCulture
      Tigrinya (Ethiopia) (ti-ET):  SpecificCulture
      Tigre (tig):  NeutralCulture
      Tigre (Eritrea) (tig-ER):  SpecificCulture
      Turkmen (tk):  NeutralCulture
      Turkmen (Turkmenistan) (tk-TM):  SpecificCulture
      Setswana (tn):  NeutralCulture
      Setswana (Botswana) (tn-BW):  SpecificCulture
      Setswana (South Africa) (tn-ZA):  SpecificCulture
*/
//</snippet1>
