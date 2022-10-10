using System.Text;
using System.Text.RegularExpressions;

static partial class Program
{ 
    private static readonly Regex s_abcOrDefGeneratedRegex = AbcOrDefGeneratedRegex();

    [GeneratedRegex(
        pattern: "abc|def",
        options: RegexOptions.IgnoreCase | RegexOptions.Compiled,
        cultureName: "en-US")]
    private static partial Regex AbcOrDefGeneratedRegex();

    private static void EvaluateText(string text)
    {
        if (s_abcOrDefGeneratedRegex.IsMatch(text))
        {
            Console.WriteLine($"""
                ✅ "{text}" matches "{s_abcOrDefGeneratedRegex}" pattern.
                """);
        }
        else
        {
            Console.WriteLine($"""
                ❌ "{text}" doesn't match "{s_abcOrDefGeneratedRegex}" pattern.
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
    private static partial Regex Example();

    [GeneratedRegex(pattern: "[ab]*[bc]")]
    private static partial Regex AnotherExample();

    [GeneratedRegex(pattern: "Monday|Tuesday|Wednesday|Thursday|Friday|Saturday|Sunday")]
    private static partial Regex DaysOfWeek();

    [GeneratedRegex(pattern: "")]
    private static partial Regex Blank();
}
