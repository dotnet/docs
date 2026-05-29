using System.Globalization;
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
        Console.WriteLine();
        FormatAndAggregate();
        Console.WriteLine();
        CultureDeepDive();
        Console.WriteLine();
        StringCreate();
    }

    private static void RegexPattern()
    {
        // <RegexPattern>
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
        // </RegexPattern>
    }

    private static void RegexValidate()
    {
        // <RegexValidate>
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
        // </RegexValidate>
    }

    private static void SpanSearch()
    {
        // <SpanSearch>
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
        // </SpanSearch>
    }

    private static void FormatAndAggregate()
    {
        // <format>
        string[] words = ["The", "quick", "brown", "fox"];

        // string.Format uses composite formatting: numbered placeholders that
        // reference the argument list. Reach for it when the same template
        // appears repeatedly with different arguments, such as log messages
        // or localized resources where the template lives in a resource file.
        string formatted = string.Format("[{0}] {1} {2} {3} {4}!", DateTime.Today.ToShortDateString(), words[0], words[1], words[2], words[3]);
        Console.WriteLine(formatted);

        // Enumerable.Aggregate reduces a sequence to a single string by
        // applying a lambda to each element in turn. It's the LINQ-friendly
        // option when the separator depends on element position or when you
        // want to fold extra logic into the accumulation. Each iteration
        // allocates a new string, so for plain "join with a separator"
        // workloads, string.Join is faster.
        string aggregated = words.Aggregate((acc, word) => $"{acc}-{word}");
        Console.WriteLine(aggregated);
        // => The-quick-brown-fox
        // </format>
    }

    private static void CultureDeepDive()
    {
        // <culture-deep>
        string esszet = "Sie tanzen auf der Straße.";
        string doubleS = "Sie tanzen auf der Strasse.";

        // Linguistic comparison folds 'ß' to "ss" in the invariant culture;
        // ordinal comparison sees two distinct code points.
        Console.WriteLine($"InvariantCulture equal? {string.Equals(esszet, doubleS, StringComparison.InvariantCulture)}");
        Console.WriteLine($"Ordinal equal?          {string.Equals(esszet, doubleS, StringComparison.Ordinal)}");

        // CompareInfo gives you the underlying linguistic engine and lets you
        // pass CompareOptions explicitly. This matches what StringComparison
        // uses internally but is the API to reach for when you need to mix
        // options like IgnoreSymbols or IgnoreKanaType.
        CompareInfo de = CultureInfo.GetCultureInfo("de-DE").CompareInfo;
        int order = de.Compare(esszet, doubleS, CompareOptions.None);
        Console.WriteLine($"de-DE CompareInfo result: {order}");

        // StringComparer plugs into Array.Sort, List<T>.Sort, Dictionary,
        // HashSet, and other collections that need an IComparer<string> or
        // IEqualityComparer<string>. Sort the same input with different
        // comparers to see the difference between linguistic and ordinal
        // order. The hyphen in "co-op" is weighted close to zero in the
        // current culture but sorts before the letters in ordinal order.
        string[] linguistic = ["cop", "co-op", "coop"];
        Array.Sort(linguistic, StringComparer.InvariantCulture);
        Console.WriteLine($"InvariantCulture order: {string.Join(", ", linguistic)}");

        string[] ordinal = ["cop", "co-op", "coop"];
        Array.Sort(ordinal, StringComparer.Ordinal);
        Console.WriteLine($"Ordinal order:          {string.Join(", ", ordinal)}");
        // </culture-deep>
    }

    private static void StringCreate()
    {
        // <string-create>
        // string.Create lets you fill a string's character buffer through a
        // callback, with no intermediate allocations. Pass the desired length
        // and the state value the callback needs; the runtime hands you a
        // Span<char> to write into. The result is a normal, immutable string.
        char[] body = ['a', 'b', 'c', 'd'];
        int length = body.Length + 2;

        string result = string.Create(length, body, static (destination, source) =>
        {
            destination[0] = '0';
            destination[1] = '1';
            source.CopyTo(destination[2..]);
        });

        Console.WriteLine(result);
        // => 01abcd
        // </string-create>
    }
}
