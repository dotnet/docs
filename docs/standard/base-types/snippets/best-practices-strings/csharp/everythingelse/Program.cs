// See https://aka.ms/new-console-template for more information

using System.Globalization;

void FrameworkDiffs()
{
    //<framework_diffs>
    const string greeting = "Hel\0lo";
    Console.WriteLine($"{greeting.IndexOf("\0")}");

    // The snippet prints:
    //
    // '3' when running on .NET Framework and .NET Core 2.x - 3.x (Windows)
    // '0' when running on .NET 5 or later (Windows)
    // '0' when running on .NET Core 2.x - 3.x or .NET 5 (non-Windows)
    // '3' when running on .NET Core 2.x or .NET 5+ (in invariant mode)
    //</framework_diffs>
}

//<html_example>
//
// THIS SAMPLE CODE IS INCORRECT.
// DO NOT USE IT IN PRODUCTION.
//
bool ContainsHtmlSensitiveCharacters(string input)
{
    if (input.IndexOf("<") >= 0) { return true; }
    if (input.IndexOf("&") >= 0) { return true; }
    return false;
}
//</html_example>

//<indexof>
Console.WriteLine("resume".IndexOf('e', StringComparison.Ordinal)); // "resume": prints '1'
Console.WriteLine("r\u00E9sum\u00E9".IndexOf('e', StringComparison.Ordinal)); // "résumé": prints '-1'
Console.WriteLine("r\u00E9sume\u0301".IndexOf('e', StringComparison.Ordinal)); // "résumé": prints '5'
Console.WriteLine("re\u0301sum\u00E9".IndexOf('e', StringComparison.Ordinal)); // "résumé": prints '1'
Console.WriteLine("re\u0301sume\u0301".IndexOf('e', StringComparison.Ordinal)); // "résumé": prints '1'
Console.WriteLine("resume".IndexOf('e', StringComparison.OrdinalIgnoreCase)); // "resume": prints '1'
Console.WriteLine("r\u00E9sum\u00E9".IndexOf('e', StringComparison.OrdinalIgnoreCase)); // "résumé": prints '-1'
Console.WriteLine("r\u00E9sume\u0301".IndexOf('e', StringComparison.OrdinalIgnoreCase)); // "résumé": prints '5'
Console.WriteLine("re\u0301sum\u00E9".IndexOf('e', StringComparison.OrdinalIgnoreCase)); // "résumé": prints '1'
Console.WriteLine("re\u0301sume\u0301".IndexOf('e', StringComparison.OrdinalIgnoreCase)); // "résumé": prints '1'
//</indexof>

//<indexof_string>
Console.WriteLine("r\u00E9sum\u00E9".IndexOf("e")); // "résumé": prints '-1' (not found)
Console.WriteLine("r\u00E9sum\u00E9".IndexOf("\u00E9")); // "résumé": prints '1'
Console.WriteLine("\u00E9".IndexOf("e\u0301")); // prints '0'
//</indexof_string>

//<endz>
// Set thread culture to Hungarian
CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("hu-HU");
Console.WriteLine("endz".EndsWith("z")); // Prints 'False'

// Set thread culture to invariant culture
CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
Console.WriteLine("endz".EndsWith("z")); // Prints 'True'
//</endz>
