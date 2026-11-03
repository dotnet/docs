using System.Text;

namespace StringsOverviewSample;

public static class Program
{
    public static void Main()
    {
        ShowStringKeyword();
        ShowImmutability();
        ShowStringBuilder();
        ShowEscapes();
        ShowEscEscape();
        ShowVerbatim();
        ShowRaw();
        ShowInterpolated();
        ShowUtf8Literal();
        ShowIndexing();
        ShowEqualityIntro();
    }

    private static void ShowStringKeyword()
    {
        // <StringKeyword>
        // The 'string' keyword is an alias for System.String. The two are identical.
        string a = "hello";
        String b = "hello";

        Console.WriteLine(a == b);                // True
        Console.WriteLine(typeof(string) == typeof(String)); // True
        // </StringKeyword>
    }

    private static void ShowImmutability()
    {
        // <Immutability>
        string greeting = "hello";

        // ToUpper returns a *new* string. The original is unchanged.
        string shouted = greeting.ToUpperInvariant();

        Console.WriteLine(greeting);  // hello
        Console.WriteLine(shouted);   // HELLO
        // </Immutability>
    }

    private static void ShowStringBuilder()
    {
        // <StringBuilder>
        // For many sequential edits, StringBuilder avoids allocating a new string each time.
        var builder = new StringBuilder();
        for (int i = 1; i <= 3; i++)
        {
            builder.Append("item ").Append(i).Append(';');
        }
        string result = builder.ToString();
        Console.WriteLine(result);    // item 1;item 2;item 3;
        // </StringBuilder>
    }

    private static void ShowEscapes()
    {
        // <Escapes>
        // Common escape sequences inside a regular string literal.
        string tabbed   = "name:\tAda";          // \t  tab
        string twoLines = "line 1\nline 2";      // \n  newline
        string quoted   = "She said \"hi\".";    // \"  literal quote
        string path     = "C:\\src\\app";        // \\  literal backslash

        Console.WriteLine(tabbed);
        Console.WriteLine(twoLines);
        Console.WriteLine(quoted);
        Console.WriteLine(path);
        // </Escapes>
    }

    private static void ShowEscEscape()
    {
        // <EscEscape>
        // Beginning in C# 13, \e represents the ESC control character (U+001B).
        // It's used to start ANSI terminal escape sequences.
        string esc = "\e[31mError\e[0m: file missing";

        Console.WriteLine(esc);                  // ESC[31mError ESC[0m: file missing
        Console.WriteLine((int)'\e');          // 27
        // </EscEscape>
    }

    private static void ShowVerbatim()
    {
        // <Verbatim>
        // A verbatim string literal (@) treats backslashes literally.
        // Useful for Windows paths and regular expressions.
        string winPath = @"C:\src\app\readme.md";
        string pattern = @"\d{3}-\d{4}";

        Console.WriteLine(winPath);
        Console.WriteLine(pattern);
        // </Verbatim>
    }

    private static void ShowRaw()
    {
        // <Raw>
        // Raw string literals use three or more quotes and need no escaping.
        // The source looks like the output, which is ideal for inline JSON, SQL, XML, and the like.
        string json = """
            {
                "name": "Ada",
                "roles": ["admin", "editor"]
            }
            """;

        string sql = """
            SELECT Id, Name
            FROM   Users
            WHERE  Name = 'O''Brien'
            """;

        Console.WriteLine(json);
        Console.WriteLine(sql);
        // </Raw>
    }

    private static void ShowInterpolated()
    {
        // <Interpolated>
        // The $ prefix evaluates expressions inside { } and inserts their values.
        string name = "Ada";
        int score = 92;

        string greeting = $"Hello, {name}! Your score is {score}.";
        // Format specifiers and alignment work inside the holes.
        string formatted = $"pi = {Math.PI:F3}, padded = |{name,10}|";

        // Combine $ and """ for richly formatted multiline output.
        string report = $"""
            Report for {name}
            -----------------
            Score : {score}
            Grade : {(score >= 90 ? "A" : "B")}
            """;

        Console.WriteLine(greeting);
        Console.WriteLine(formatted);
        Console.WriteLine(report);
        // </Interpolated>
    }

    private static void ShowUtf8Literal()
    {
        // <Utf8Literal>
        // Suffix u8 produces a ReadOnlySpan<byte> of the string's UTF-8 bytes.
        // Common in HTTP, network protocols, and other byte-oriented APIs.
        ReadOnlySpan<byte> verb = "POST"u8;
        ReadOnlySpan<byte> body = """{"status":"ok"}"""u8;

        Console.WriteLine(verb.Length);          // 4
        Console.WriteLine(body.Length);          // 15
        // </Utf8Literal>
    }

    private static void ShowIndexing()
    {
        // <Indexing>
        // A string is a sequence of UTF-16 code units. s[i] returns one char.
        string word = "café";

        Console.WriteLine(word.Length);          // 4
        Console.WriteLine(word[0]);              // c

        foreach (char c in word)
        {
            Console.Write($"{c} ");              // c a f é
        }
        Console.WriteLine();
        // </Indexing>
    }

    private static void ShowEqualityIntro()
    {
        // <EqualityIntro>
        // String equality compares character sequences, not references.
        string left  = "hello";
        string right = string.Concat("hel", "lo");

        Console.WriteLine(left == right);                                      // True
        Console.WriteLine(left.Equals(right, StringComparison.Ordinal));       // True
        // </EqualityIntro>
    }
}
