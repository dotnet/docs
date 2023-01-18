namespace operators;

public static class NullCoalescingOperator
{
    public static void Examples()
    {
        WithNullConditional();
        WithNullableTypes();
        NullCoalescingAssignment();
    }

    private static void WithNullConditional()
    {
        // <SnippetWithNullConditional>
        double SumNumbers(List<double[]> setsOfNumbers, int indexOfSetToSum)
        {
            return setsOfNumbers?[indexOfSetToSum]?.Sum() ?? double.NaN;
        }

        var sum = SumNumbers(null, 0);
        Console.WriteLine(sum);  // output: NaN
        // </SnippetWithNullConditional>
    }

    private static void WithNullableTypes()
    {
        // <SnippetWithNullableTypes>
        int? a = null;
        int b = a ?? -1;
        Console.WriteLine(b);  // output: -1
        // </SnippetWithNullableTypes>
    }

    private class Person
    {
        string name;

        // <SnippetWithThrowExpression>
        public string Name
        {
            get => name;
            set => name = value ?? throw new ArgumentNullException(nameof(value), "Name cannot be null");
        }
        // </SnippetWithThrowExpression>
    }

    // <SnippetUnconstrainedType>
    private static void Display<T>(T a, T backup)
    {
        Console.WriteLine(a ?? backup);
    }
    // </SnippetUnconstrainedType>

    private static void NullCoalescingAssignment()
    {
        // <SnippetAssignment>
        List<int> numbers = null;
        int? a = null;

        Console.WriteLine((numbers is null)); // expected: true
        // if numbers is null, initialize it. Then, add 5 to numbers
        (numbers ??= new List<int>()).Add(5);
        Console.WriteLine(string.Join(" ", numbers));  // output: 5
        Console.WriteLine((numbers is null)); // expected: false        

        
        Console.WriteLine((a is null)); // expected: true
        Console.WriteLine((a ?? 3)); // expected: 3 since a is still null 
        // if a is null then assign 0 to a and add a to the list
        numbers.Add(a ??= 0);
        Console.WriteLine((a is null)); // expected: false        
        Console.WriteLine(string.Join(" ", numbers));  // output: 5 0
        Console.WriteLine(a);  // output: 0	        
        // </SnippetAssignment>
    }
}
