namespace builtin_types;

public static class BoolType
{
    public static void Examples()
    {
        Literals();
    }

    private static void Literals()
    {
        // <SnippetLiterals>
        bool check = true;
        Console.WriteLine(check ? "Checked" : "Not checked");  // output: Checked

        Console.WriteLine(false ? "Checked" : "Not checked");  // output: Not checked
        // </SnippetLiterals>
    }
}
