namespace operators;

public static class AdditionOperator
{
    public static void Examples()
    {
        NumericAddition();
        StringConcatenation();
        AddDelegates();
        AddAndAssign();
    }

    private static void NumericAddition()
    {
        // <SnippetAddNumerics>
        Console.WriteLine(5 + 4);       // output: 9
        Console.WriteLine(5 + 4.3);     // output: 9.3
        Console.WriteLine(5.1m + 4.2m); // output: 9.3
        // </SnippetAddNumerics>
    }

    private static void StringConcatenation()
    {
        // <SnippetAddStrings>
        Console.WriteLine("Forgot" + "white space");
        Console.WriteLine("Probably the oldest constant: " + Math.PI);
        Console.WriteLine(null + "Nothing to add.");
        // Output:
        // Forgotwhite space
        // Probably the oldest constant: 3.14159265358979
        // Nothing to add.
        // </SnippetAddStrings>

        // <SnippetUseStringInterpolation>
        Console.WriteLine($"Probably the oldest constant: {Math.PI:F2}");
        // Output:
        // Probably the oldest constant: 3.14
        // </SnippetUseStringInterpolation>
    }

    private static void AddDelegates()
    {
        // <SnippetAddDelegates>
        Action a = () => Console.Write("a");
        Action b = () => Console.Write("b");
        Action ab = a + b;
        ab();  // output: ab
        // </SnippetAddDelegates>
        Console.WriteLine();
    }

    private static void AddAndAssign()
    {
        // <SnippetAddAndAssign>
        int i = 5;
        i += 9;
        Console.WriteLine(i);
        // Output: 14

        string story = "Start. ";
        story += "End.";
        Console.WriteLine(story);
        // Output: Start. End.

        Action printer = () => Console.Write("a");
        printer();  // output: a

        Console.WriteLine();
        printer += () => Console.Write("b");
        printer();  // output: ab
        // </SnippetAddAndAssign>
        Console.WriteLine();
    }
}
