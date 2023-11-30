namespace builtin_types;

public static class CharType
{
    public static void Examples()
    {
        Literals();
    }

    private static void Literals()
    {
        // <SnippetLiterals>
        var chars = new[]
        {
            'j',
            '\u006A',
            '\x006A',
            (char)106,
        };
        Console.WriteLine(string.Join(" ", chars));  // output: j j j j
        // </SnippetLiterals>
    }
}
