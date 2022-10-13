using System.Text;
using System.Text.RegularExpressions;

static partial class Program
{
    [GeneratedRegex(
        pattern: "abc|def",
        options: RegexOptions.IgnoreCase | RegexOptions.Compiled,
        cultureName: "en-US")]
    private static partial Regex AbcOrDefGeneratedRegex();

    private static void EvaluateText(string text)
    {
        if (AbcOrDefGeneratedRegex().IsMatch(text))
        {
            Console.WriteLine($"""
                ✅ "{text}" matches "{AbcOrDefGeneratedRegex()}" pattern.
                """);
        }
        else
        {
            Console.WriteLine($"""
                ❌ "{text}" doesn't match "{AbcOrDefGeneratedRegex()}" pattern.
                """);
        }
    }

    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        new List<string> { "Incubus", "Deftones", "Tool" }.ForEach(EvaluateText);

        // Sample output:
        //   ❌ "Incubus" doesn't match "abc|def" pattern.
        //   ✅ "Deftones" matches "abc|def" pattern.
        //   ❌ "Tool" doesn't match "abc|def" pattern.

        var abcOrDefRegex = new Regex(pattern: "abc|def", options: RegexOptions.IgnoreCase);
    }
}

static file partial class Program
{
    [GeneratedRegex(pattern: @"(a|bc)d")]
    private static partial Regex ExampleRegex();

    [GeneratedRegex(pattern: "[ab]*[bc]")]
    private static partial Regex AnotherExampleRegex();

    [GeneratedRegex(pattern: "Monday|Tuesday|Wednesday|Thursday|Friday|Saturday|Sunday")]
    private static partial Regex DaysOfWeekRegex();

    [GeneratedRegex(pattern: "")]
    private static partial Regex BlankRegex();

    [GeneratedRegex(pattern: @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
    private static partial Regex EmailRegex();

    [GeneratedRegex(pattern: "(\\w)\\1")]
    private static partial Regex WordWithBacktrackingRegex();
}
