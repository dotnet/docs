namespace RawStringLiteralsSample;

public static class Program
{
    public static void Main()
    {
        ShowSingleLine();
        ShowEscapeContrast();
        ShowMultiline();
        ShowIndentation();
        ShowMoreQuotes();
        ShowRawInterpolated();
        ShowDoubleDollarInterpolation();
    }

    private static void ShowSingleLine()
    {
        // <SingleLine>
        // A raw string literal starts and ends with at least three quotes.
        // Inside, " and \ are literal — no escaping required.
        string message = """She said "hi" and left.""";
        string regex   = """\d{3}-\d{4}""";

        Console.WriteLine(message);   // She said "hi" and left.
        Console.WriteLine(regex);     // \d{3}-\d{4}
        // </SingleLine>
    }

    private static void ShowEscapeContrast()
    {
        // <EscapeContrast>
        // Same JSON value, three ways:
        string regular  = "{ \"name\": \"Ada\", \"path\": \"C:\\\\src\" }";
        string verbatim = @"{ ""name"": ""Ada"", ""path"": ""C:\\src"" }";
        string raw      = """{ "name": "Ada", "path": "C:\\src" }""";

        Console.WriteLine(regular  == raw);   // True
        Console.WriteLine(verbatim == raw);   // True
        // </EscapeContrast>
    }

    private static void ShowMultiline()
    {
        // <Multiline>
        // The opening """ and closing """ each sit on their own line.
        // The content between them is the value, exactly as written.
        string sql = """
            SELECT id, name
            FROM customers
            WHERE active = 1
            """;

        Console.WriteLine(sql);
        // </Multiline>
    }

    private static void ShowIndentation()
    {
        // <Indentation>
        // The column of the closing """ sets a left margin.
        // Whitespace up to that column is stripped from every content line.
        string xml = """
                <order id="42">
                    <item>book</item>
                </order>
                """;

        // First content line begins at column 0 of the value:
        Console.WriteLine(xml);
        /* Output:
           <order id="42">
               <item>book</item>
           </order>
         */
        // </Indentation>
    }

    private static void ShowMoreQuotes()
    {
        // <MoreQuotes>
        // When the content itself contains """, use four (or more) quotes
        // for the delimiters. The delimiter count just has to exceed any
        // run of quotes in the content.
        string sample = """"
            The token """ marks a raw string literal.
            """";

        Console.WriteLine(sample);
        // </MoreQuotes>
    }

    private static void ShowRawInterpolated()
    {
        // <RawInterpolated>
        // A single $ before """ enables interpolation: single { and } mark a hole.
        // Inside a single-$ raw string, literal braces aren't allowed — use $$ when
        // the content also contains literal { or }.
        string name = "Ada";
        int    score = 95;

        string report = $"""
            Player:  {name}
            Score:   {score}
            Updated: {DateTime.UtcNow:yyyy-MM-dd}
            """;

        Console.WriteLine(report);
        // </RawInterpolated>
    }

    private static void ShowDoubleDollarInterpolation()
    {
        // <DoubleDollarInterpolation>
        // Each $ raises the brace count for an interpolation hole.
        // With $$, single { and } are literal; only {{ and }} mark a hole.
        // Useful when the content has lots of literal braces (JSON, CSS, code).
        string user = "alice";

        string template = $$"""
            {
                "filter": { "user": "{{user}}" },
                "limit":  10
            }
            """;

        Console.WriteLine(template);
        // </DoubleDollarInterpolation>
    }
}
