namespace operators;

public static class DefaultOperator
{
    public static void Examples()
    {
        WithOperand();
        DefaultLiteral();
    }

    private static void WithOperand()
    {
        // <SnippetWithOperand>
        Console.WriteLine(default(int));  // output: 0
        Console.WriteLine(default(object) is null);  // output: True

        void DisplayDefaultOf<T>()
        {
            var val = default(T);
            Console.WriteLine($"Default value of {typeof(T)} is {(val == null ? "null" : val.ToString())}.");
        }

        DisplayDefaultOf<int?>();
        DisplayDefaultOf<System.Numerics.Complex>();
        DisplayDefaultOf<System.Collections.Generic.List<int>>();
        // Output:
        // Default value of System.Nullable`1[System.Int32] is null.
        // Default value of System.Numerics.Complex is (0, 0).
        // Default value of System.Collections.Generic.List`1[System.Int32] is null.
        // </SnippetWithOperand>
    }

    private static void DefaultLiteral()
    {
        // <SnippetDefaultLiteral>
        T[] InitializeArray<T>(int length, T initialValue = default)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "Array length must be nonnegative.");
            }

            var array = new T[length];
            for (var i = 0; i < length; i++)
            {
                array[i] = initialValue;
            }
            return array;
        }

        void Display<T>(T[] values) => Console.WriteLine($"[ {string.Join(", ", values)} ]");

        Display(InitializeArray<int>(3));  // output: [ 0, 0, 0 ]
        Display(InitializeArray<bool>(4, default));  // output: [ False, False, False, False ]

        System.Numerics.Complex fillValue = default;
        Display(InitializeArray(3, fillValue));  // output: [ (0, 0), (0, 0), (0, 0) ]
        // </SnippetDefaultLiteral>
    }
}
