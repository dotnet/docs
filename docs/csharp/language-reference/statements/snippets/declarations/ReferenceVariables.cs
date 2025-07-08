public static class ReferenceVariables
{
    public static void Examples()
    {
        AliasToLocalVariable();
        RefReassign();
        RefReadonly();
    }

    private static void AliasToLocalVariable()
    {
        // <AliasToLocalVariable>
        int a = 1;
        ref int aliasOfa = ref a;
        Console.WriteLine($"(a, aliasOfa) is ({a}, {aliasOfa})");  // output: (a, aliasOfa) is (1, 1)

        a = 2;
        Console.WriteLine($"(a, aliasOfa) is ({a}, {aliasOfa})");  // output: (a, aliasOfa) is (2, 2)

        aliasOfa = 3;
        Console.WriteLine($"(a, aliasOfa) is ({a}, {aliasOfa})");  // output: (a, aliasOfa) is (3, 3)
        // </AliasToLocalVariable>
    }

    private static void RefReassign()
    {
        // <RefReassign>
        void Display(int[] s) => Console.WriteLine(string.Join(" ", s));

        int[] xs = [0, 0, 0];
        Display(xs);

        ref int element = ref xs[0];
        element = 1;
        Display(xs);

        element = ref xs[^1];
        element = 3;
        Display(xs);
        // Output:
        // 0 0 0
        // 1 0 0
        // 1 0 3
        // </RefReassign>
    }

    private static void RefReadonly()
    {
        // <RefReadonly>
        int[] xs = [1, 2, 3];

        ref readonly int element = ref xs[0];
        // element = 100;  error CS0131: The left-hand side of an assignment must be a variable, property or indexer
        Console.WriteLine(element);  // output: 1

        element = ref xs[^1];
        Console.WriteLine(element);  // output: 3
        // </RefReadonly>
    }
}
