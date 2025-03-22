// <Snippet5>
using System;
using System.Globalization;

public class GetCulturesEx
{
    public static void Main()
    {
        // Get all custom cultures.
        CultureInfo[] custom = CultureInfo.GetCultures(CultureTypes.UserCustomCulture);
        if (custom.Length == 0)
        {
            Console.WriteLine("There are no user-defined custom cultures.");
        }
        else
        {
            Console.WriteLine("Custom cultures:");
            foreach (var culture in custom)
                Console.WriteLine($"   {culture.Name} -- {culture.DisplayName}");
        }
        Console.WriteLine();

        // Get all replacement cultures.
        CultureInfo[] replacements = CultureInfo.GetCultures(CultureTypes.ReplacementCultures);
        if (replacements.Length == 0)
        {
            Console.WriteLine("There are no replacement cultures.");
        }
        else
        {
            Console.WriteLine("Replacement cultures:");
            foreach (var culture in replacements)
                Console.WriteLine($"   {culture.Name} -- {culture.DisplayName}");
        }
        Console.WriteLine();
    }
}
// The example displays output like the following:
//     Custom cultures:
//        x-en-US-sample -- English (United States)
//        fj-FJ -- Boumaa Fijian (Viti)
//
//     There are no replacement cultures.
// </Snippet5>
