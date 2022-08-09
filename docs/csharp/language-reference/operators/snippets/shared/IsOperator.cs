namespace operators;

public static class IsOperator
{
    public static void Examples()
    {
        DeclarationPattern();
        IsFirstFridayOfOctober(DateTime.Now);
        NullCheck(default(object));
        NonNullCheck(new object());
        ListPattern();
    }

    // <IntroExample>
    static bool IsFirstFridayOfOctober(DateTime date) =>
        date is { Month: 10, Day: <=7, DayOfWeek: DayOfWeek.Friday };
    // </IntroExample>

    private static void DeclarationPattern()
    {
        // <DeclarationPattern>
        int i = 34;
        object iBoxed = i;
        int? jNullable = 42;
        if (iBoxed is int a && jNullable is int b)
        {
            Console.WriteLine(a + b);  // output 76
        }
        // </DeclarationPattern>
    }

    private static void NullCheck(object input)
    {
        // <NullCheck>
        if (input is null)
        {
            return;
        }
        // </NullCheck>
    }

    private static void NonNullCheck(object result)
    {
        // <NonNullCheck>
        if (result is not null)
        {
            Console.WriteLine(result.ToString());
        }
        // </NonNullCheck>
    }

    private static void ListPattern()
    {
        // <ListPatterns>
        int[] empty = { };
        int[] one = { 1 };
        int[] odd = { 1, 3, 5 };
        int[] even = { 2, 4, 6 };
        int[] fib = { 1, 1, 2, 3, 5 };

        Console.WriteLine(odd is [1, _, 2, ..]);   // false
        Console.WriteLine(fib is [1, _, 2, ..]);   // true
        Console.WriteLine(fib is [_, 1, 2, 3, ..]);     // true
        Console.WriteLine(fib is [.., 1, 2, 3, _ ]);     // true
        Console.WriteLine(even is [2, _, 6]);     // true
        Console.WriteLine(even is [2, .., 6]);    // true
        Console.WriteLine(odd is [.., 3, 5]); // true
        Console.WriteLine(even is [.., 3, 5]); // false
        Console.WriteLine(fib is [.., 3, 5]); // true
        // </ListPatterns>

    }
}
