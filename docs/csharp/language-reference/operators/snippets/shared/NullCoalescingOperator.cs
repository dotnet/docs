using System.Diagnostics.CodeAnalysis;

namespace operators;

public static class NullCoalescingOperator
{
    public static void Examples()
    {
        WithNullConditional();
        WithNullableTypes();
        NullCoalescingAssignment();
    }

    public record class Human(string FirstName, string LastName)
    {
        public string FirstName { get; set; } = FirstName;
    }
    public static void AddMessageAtIndex()
    {
        List<string> messages = new List<string>(10);
        Human person = new Human("First", "Last");
        // <NullForgivingAssignment>
        person?.FirstName = "Scott";
        messages?[5] = "five";
        // </NullForgivingAssignment>

        int index = 0;
        int[] values = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];

        // <ConditionalRHS>
        values?[2] = GenerateNextIndex();
        int GenerateNextIndex() => index++;
        // </ConditionalRHS>

        // <EquivalentIfStatement>
        if (values is not null)
        {
            values[2] = GenerateNextIndex();
        }
        // </EquivalentIfStatement>
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
        List<int>? numbers = null;
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
