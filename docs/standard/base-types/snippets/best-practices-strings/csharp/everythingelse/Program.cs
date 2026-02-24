// See https://aka.ms/new-console-template for more information

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
