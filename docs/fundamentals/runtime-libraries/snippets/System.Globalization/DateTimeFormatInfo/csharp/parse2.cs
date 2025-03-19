// <Snippet16>
using System;
using System.Globalization;

public class ParseEx2
{
    public static void Main()
    {
        string inputDate = "14/05/10";

        CultureInfo[] cultures = { CultureInfo.GetCultureInfo("en-US"),
                                 CultureInfo.CreateSpecificCulture("en-US") };

        foreach (var culture in cultures)
        {
            try
            {
                Console.WriteLine($"{culture.Name} culture reflects user overrides: {culture.UseUserOverride}");
                DateTime occasion = DateTime.Parse(inputDate, culture);
                Console.WriteLine("'{0}' --> {1}", inputDate,
                                  occasion.ToString("D", CultureInfo.InvariantCulture));
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{inputDate}'");
            }
            Console.WriteLine();
        }
    }
}
// The example displays the following output:
//       en-US culture reflects user overrides: False
//       Unable to parse '14/05/10'
//
//       en-US culture reflects user overrides: True
//       '14/05/10' --> Saturday, 10 May 2014
// </Snippet16>
