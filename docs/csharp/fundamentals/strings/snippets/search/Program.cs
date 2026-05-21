namespace SearchStrings;

public static class Program
{
    public static void Main()
    {
        Contains();
        Console.WriteLine();
        ContainsChar();
        Console.WriteLine();
        IndexOfExample();
    }

    private static void Contains()
    {
        // <contains>
        string factMessage = "Extension methods have all the capabilities of regular static methods.";

        // Write the string and include the quotation marks.
        Console.WriteLine($"\"{factMessage}\"");

        // Default comparisons are case sensitive.
        bool containsSearchResult = factMessage.Contains("extension");
        Console.WriteLine($"""Contains "extension"? {containsSearchResult}""");

        // For user-facing searches, pass a StringComparison value to control case and culture.
        bool ignoreCaseSearchResult = factMessage.StartsWith("extension", StringComparison.CurrentCultureIgnoreCase);
        Console.WriteLine($"""Starts with "extension"? {ignoreCaseSearchResult} (ignoring case)""");

        bool endsWithSearchResult = factMessage.EndsWith(".", StringComparison.Ordinal);
        Console.WriteLine($"Ends with '.'? {endsWithSearchResult}");
        // => "Extension methods have all the capabilities of regular static methods."
        // => Contains "extension"? False
        // => Starts with "extension"? True (ignoring case)
        // => Ends with '.'? True
        // </contains>
    }

    private static void ContainsChar()
    {
        // <contains-char>
        string path = "/usr/local/bin";
        bool hasSlash = path.Contains('/');
        Console.WriteLine($"Path contains '/': {hasSlash}");
        // => Path contains '/': True
        // </contains-char>
    }

    private static void IndexOfExample()
    {
        // <index-of>
        string factMessage = "Extension methods have all the capabilities of regular static methods.";

        Console.WriteLine($"\"{factMessage}\"");

        // Extract the text between the first and last occurrence of "methods".
        int first = factMessage.IndexOf("methods") + "methods".Length;
        int last = factMessage.LastIndexOf("methods");
        string between = factMessage.Substring(first, last - first);
        Console.WriteLine($"""Substring between "methods" and "methods": '{between}'""");
        // => "Extension methods have all the capabilities of regular static methods."
        // => Substring between "methods" and "methods": ' have all the capabilities of regular static '
        // </index-of>
    }
}
