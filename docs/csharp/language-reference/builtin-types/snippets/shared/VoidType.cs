namespace builtin_types;

public static class VoidType
{
    public static void Examples()
    {
        Display([1, 2, 9]);
    }

    // <SnippetVoidExample>
    public static void Display(IEnumerable<int> numbers)
    {
        if (numbers is null)
        {
            return;
        }

        Console.WriteLine(string.Join(" ", numbers));
    }
    // </SnippetVoidExample>
}
