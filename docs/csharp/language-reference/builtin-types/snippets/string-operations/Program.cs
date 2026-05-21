using System.Text.RegularExpressions;

namespace StringOperations;

public static class Program
{
    public static void Main()
    {
        RegexPattern();
        Console.WriteLine();
        RegexValidate();
        Console.WriteLine();
        SpanSearch();
    }

    private static void RegexPattern()
    {
        // <regex-pattern>
        string[] sentences =
        [
            "Put the water over there.",
            "They're quite thirsty.",
            "Their water bottles broke."
        ];

        string pattern = @"the(ir)?\s";

        foreach (string s in sentences)
        {
            Console.Write($"{s,28}");

            if (Regex.IsMatch(s, pattern, RegexOptions.IgnoreCase))
            {
                Console.WriteLine($"  (match for '{pattern}' found)");
            }
            else
            {
                Console.WriteLine();
            }
        }
        // </regex-pattern>
    }

    private static void RegexValidate()
    {
        // <regex-validate>
        string[] numbers =
        [
            "123-555-0190",
            "444-234-22450",
            "690-555-0178",
            "146-893-232",
            "146-555-0122",
            "4007-555-0111",
            "407-555-0111",
            "407-2-5555",
            "407-555-8974",
            "407-2ab-5555",
            "690-555-8148",
            "146-893-232-"
        ];

        string pattern = """^\d{3}-\d{3}-\d{4}$""";

        foreach (string s in numbers)
        {
            Console.Write($"{s,14}");
            Console.WriteLine(Regex.IsMatch(s, pattern) ? " - valid" : " - invalid");
        }
        // </regex-validate>
    }

    private static void SpanSearch()
    {
        // <span-search>
        ReadOnlySpan<char> input = "key1=alpha;key2=beta;key3=gamma".AsSpan();
        ReadOnlySpan<char> needle = "key2=".AsSpan();

        int start = input.IndexOf(needle);
        if (start >= 0)
        {
            ReadOnlySpan<char> rest = input[(start + needle.Length)..];
            int end = rest.IndexOf(';');
            ReadOnlySpan<char> value = end >= 0 ? rest[..end] : rest;
            Console.WriteLine($"key2 = {value}");
        }
        // => key2 = beta
        // </span-search>
    }
}
