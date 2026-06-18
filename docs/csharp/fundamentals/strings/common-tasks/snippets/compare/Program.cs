namespace CompareStrings;

public static class Program
{
    public static void Main()
    {
        DefaultEquality();
        Console.WriteLine();
        IgnoreCase();
        Console.WriteLine();
        OrderStrings();
        Console.WriteLine();
        ConstantPattern();
    }

    private static void DefaultEquality()
    {
        // <DefaultEquality>
        string root = @"C:\users";
        string root2 = @"C:\Users";

        // Equals and == both perform a case-sensitive, ordinal comparison.
        Console.WriteLine(root.Equals(root2));
        // => False
        Console.WriteLine(root == root2);
        // => False

        // Pass a StringComparison value to state the intent explicitly.
        Console.WriteLine(root.Equals(root2, StringComparison.Ordinal));
        // => False
        // </DefaultEquality>
    }

    private static void IgnoreCase()
    {
        // <IgnoreCase>
        string root = @"C:\users";
        string root2 = @"C:\Users";

        // OrdinalIgnoreCase compares the binary values but ignores case.
        bool equalIgnoringCase = string.Equals(root, root2, StringComparison.OrdinalIgnoreCase);
        Console.WriteLine(equalIgnoringCase);
        // => True
        // </IgnoreCase>
    }

    private static void OrderStrings()
    {
        // <Order>
        string first = "Avocado";
        string second = "Banana";

        // Compare returns a negative number, zero, or a positive number
        // to indicate sort order. Specify the comparison type explicitly.
        int order = string.Compare(first, second, StringComparison.Ordinal);
        Console.WriteLine(order < 0
            ? $"'{first}' sorts before '{second}'."
            : $"'{first}' sorts at or after '{second}'.");
        // => 'Avocado' sorts before 'Banana'.
        // </Order>
    }

    private static void ConstantPattern()
    {
        // <ConstantPattern>
        string status = "Ready";

        // When the right operand is a constant, the is operator and a
        // constant pattern read as an alternative to ==.
        if (status is "Ready")
        {
            Console.WriteLine("The system is ready.");
        }
        // => The system is ready.
        // </ConstantPattern>
    }
}
