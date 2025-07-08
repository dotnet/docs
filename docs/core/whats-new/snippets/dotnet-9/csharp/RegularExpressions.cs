using System;
using System.Text.RegularExpressions;

internal partial class RegularExpressions
{
    // <GeneratedRegexMethod>
    [GeneratedRegex(@"\b\w{5}\b")]
    private static partial Regex FiveCharWord();
    // </GeneratedRegexMethod>

    // <GeneratedRegexProperty>
    [GeneratedRegex(@"\b\w{5}\b")]
    private static partial Regex FiveCharWordProperty { get; }
    // </GeneratedRegexProperty>

    public static void RunIt()
    {
        // <RegexSplit>
        foreach (string s in Regex.Split("Hello, world! How are you?", "[aeiou]"))
        {
            Console.WriteLine($"Split: \"{s}\"");
        }

        // Output, split by all English vowels:
        // Split: "H"
        // Split: "ll"
        // Split: ", w"
        // Split: "rld! H"
        // Split: "w "
        // Split: "r"
        // Split: " y"
        // Split: ""
        // Split: "?"

        // </RegexSplit>

        // <EnumerateSplits>
        ReadOnlySpan<char> input = "Hello, world! How are you?";
        foreach (Range r in Regex.EnumerateSplits(input, "[aeiou]"))
        {
            Console.WriteLine($"Split: \"{input[r]}\"");
        }
        // </EnumerateSplits>
    }
}
