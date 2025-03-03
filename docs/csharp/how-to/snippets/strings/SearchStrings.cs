namespace HowToStrings;

public class SearchStrings
{
    public static void Examples()
    {
        SearchWithMethods();
        SearchByIndex();
        RegularExpressionsOne();
        RegularExpressionsValidation();
    }

    private static void SearchWithMethods()
    {
        // <Snippet1>
        string factMessage = "Extension methods have all the capabilities of regular static methods.";

        // Write the string and include the quotation marks.
        Console.WriteLine($"\"{factMessage}\"");

        // Simple comparisons are always case sensitive!
        bool containsSearchResult = factMessage.Contains("extension");
        // Raw string literals can work here because the output doesn't begin with "
        Console.WriteLine($"""Contains "extension"? {containsSearchResult}""");

        // For user input and strings that will be displayed to the end user,
        // use the StringComparison parameter on methods that have it to specify how to match strings.
        bool ignoreCaseSearchResult = factMessage.StartsWith("extension", System.StringComparison.CurrentCultureIgnoreCase);
        Console.WriteLine($"""Starts with "extension"? {ignoreCaseSearchResult} (ignoring case)""");

        bool endsWithSearchResult = factMessage.EndsWith(".", System.StringComparison.CurrentCultureIgnoreCase);
        Console.WriteLine($"Ends with '.'? {endsWithSearchResult}");
        // </Snippet1>
    }

    private static void SearchByIndex()
    {
        // <Snippet2>
        string factMessage = "Extension methods have all the capabilities of regular static methods.";

        // Write the string and include the quotation marks.
        Console.WriteLine($"\"{factMessage}\"");

        // This search returns the substring between two strings, so
        // the first index is moved to the character just after the first string.
        int first = factMessage.IndexOf("methods") + "methods".Length;
        int last = factMessage.LastIndexOf("methods");
        string str2 = factMessage.Substring(first, last - first);
        Console.WriteLine($"""Substring between "methods" and "methods": '{str2}'""");
        // </Snippet2>
    }

    private static void RegularExpressionsOne()
    {
        // <Snippet3>
        string[] sentences =
        [
            "Put the water over there.",
            "They're quite thirsty.",
            "Their water bottles broke."
        ];

        string sPattern = "the(ir)?\\s";

        foreach (string s in sentences)
        {
            Console.Write($"{s,24}");

            if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
                Console.WriteLine($"  (match for '{sPattern}' found)");
            }
            else
            {
                Console.WriteLine();
            }
        }
        // </Snippet3>
    }

    private static void RegularExpressionsValidation()
    {
        // <Snippet4>
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

        string sPattern = """^\d{3}-\d{3}-\d{4}$""";

        foreach (string s in numbers)
        {
            Console.Write($"{s,14}");

            if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern))
            {
                Console.WriteLine(" - valid");
            }
            else
            {
                Console.WriteLine(" - invalid");
            }
        }
        // </Snippet4>
    }
}
