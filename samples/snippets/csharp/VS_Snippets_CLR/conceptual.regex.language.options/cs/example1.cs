using System;
using System.Text.RegularExpressions;

public class ShowOptionsExamples
{
    public static void Main()
    {
        ShowOptionsArgument();
        Console.WriteLine("-----");
        ShowInlineOptions();
        Console.WriteLine("-----");
        ShowGroupOptions();
    }

    private static void ShowOptionsArgument()
    {
        // <Snippet6>
        string pattern = @"d \w+ \s";
        string input = "Dogs are decidedly good pets.";
        RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace;

        foreach (Match match in Regex.Matches(input, pattern, options))
            Console.WriteLine($"'{match.Value}// found at index {match.Index}.");
        // The example displays the following output:
        //    'Dogs // found at index 0.
        //    'decidedly // found at index 9.
        // </Snippet6>
    }

    private static void ShowInlineOptions()
    {
        // <Snippet7>
        string pattern = @"(?ix) d \w+ \s";
        string input = "Dogs are decidedly good pets.";

        foreach (Match match in Regex.Matches(input, pattern))
            Console.WriteLine($"'{match.Value}// found at index {match.Index}.");
        // The example displays the following output:
        //    'Dogs // found at index 0.
        //    'decidedly // found at index 9.
        // </Snippet7>
    }

    private static void ShowGroupOptions()
    {
        // <Snippet8>
        string pattern = @"\b(?ix: d \w+)\s";
        string input = "Dogs are decidedly good pets.";

        foreach (Match match in Regex.Matches(input, pattern))
            Console.WriteLine($"'{match.Value}// found at index {match.Index}.");
        // The example displays the following output:
        //    'Dogs // found at index 0.
        //    'decidedly // found at index 9.
        // </Snippet8>
    }
}
