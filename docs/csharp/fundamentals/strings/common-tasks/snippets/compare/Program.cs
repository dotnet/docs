namespace CompareStrings;

public static class Program
{
    public static void Main()
    {
        EqualsDefault();
        Console.WriteLine();
        IgnoreCase();
        Console.WriteLine();
        ComparePicker();
        Console.WriteLine();
        SortCollection();
    }

    private static void EqualsDefault()
    {
        // <EqualsDefault>
        string root = @"C:\users";
        string root2 = @"C:\Users";

        // Equals and == default to ordinal, case-sensitive comparison.
        Console.WriteLine($"<{root}>.Equals(<{root2}>) = {root.Equals(root2)}");
        Console.WriteLine($"<{root}> == <{root2}> -> {root == root2}");
        // => <C:\users>.Equals(<C:\Users>) = False
        // => <C:\users> == <C:\Users> -> False
        // </EqualsDefault>
    }

    private static void IgnoreCase()
    {
        // <IgnoreCase>
        string root = @"C:\users";
        string root2 = @"C:\Users";

        bool equal = root.Equals(root2, StringComparison.OrdinalIgnoreCase);
        int order = string.Compare(root, root2, StringComparison.OrdinalIgnoreCase);

        Console.WriteLine($"OrdinalIgnoreCase equal? {equal}");
        Console.WriteLine($"OrdinalIgnoreCase Compare result: {order}");
        // => OrdinalIgnoreCase equal? True
        // => OrdinalIgnoreCase Compare result: 0
        // </IgnoreCase>
    }

    private static void ComparePicker()
    {
        // <ComparePicker>
        // Machine-defined text: paths, identifiers, protocol tokens.
        string path1 = "/api/users";
        string path2 = "/API/Users";
        Console.WriteLine($"Paths equal (Ordinal)?          {path1.Equals(path2, StringComparison.Ordinal)}");
        Console.WriteLine($"Paths equal (OrdinalIgnoreCase)? {path1.Equals(path2, StringComparison.OrdinalIgnoreCase)}");
        // => Paths equal (Ordinal)?          False
        // => Paths equal (OrdinalIgnoreCase)? True

        // User-visible text: prefer CurrentCulture(IgnoreCase) so case and
        // locale rules match what the user expects in the UI.
        string title = "Pride and Prejudice";
        string typed = "PRIDE";
        bool match = title.StartsWith(typed, StringComparison.CurrentCultureIgnoreCase);
        Console.WriteLine($"Title starts with '{typed}' (current culture, ignore case)? {match}");
        // => Title starts with 'PRIDE' (current culture, ignore case)? True
        // </ComparePicker>
    }

    private static void SortCollection()
    {
        // <SortCollection>
        string[] files =
        [
            @"c:\public\TextFile.TXT",
            @"c:\public\textfile.txt",
            @"c:\public\testfile2.txt",
            @"c:\public\Text.txt",
        ];

        // For file names, identifiers, and other machine-defined keys,
        // use StringComparer.Ordinal (or OrdinalIgnoreCase).
        Array.Sort(files, StringComparer.Ordinal);
        foreach (string file in files)
        {
            Console.WriteLine(file);
        }
        // => c:\public\Text.txt
        // => c:\public\TextFile.TXT
        // => c:\public\testfile2.txt
        // => c:\public\textfile.txt
        // </SortCollection>
    }
}
