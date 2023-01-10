namespace operators;

public static class ComparisonOperators
{
    public static void Examples()
    {
        Console.WriteLine("--- >");
        Greater();
        Console.WriteLine("--- <");
        Less();
        Console.WriteLine("--- >=");
        GreaterOrEqual();
        Console.WriteLine("--- <=");
        LessOrEqual();
    }

    private static void Greater()
    {
        // <SnippetGreater>
        Console.WriteLine(7.0 > 5.1);   // output: True
        Console.WriteLine(5.1 > 5.1);   // output: False
        Console.WriteLine(0.0 > 5.1);   // output: False

        Console.WriteLine(double.NaN > 5.1);   // output: False
        Console.WriteLine(double.NaN <= 5.1);  // output: False
        // </SnippetGreater>
    }

    private static void Less()
    {
        // <SnippetLess>
        Console.WriteLine(7.0 < 5.1);   // output: False
        Console.WriteLine(5.1 < 5.1);   // output: False
        Console.WriteLine(0.0 < 5.1);   // output: True

        Console.WriteLine(double.NaN < 5.1);   // output: False
        Console.WriteLine(double.NaN >= 5.1);  // output: False
        // </SnippetLess>
    }

    private static void GreaterOrEqual()
    {
        // <SnippetGreaterOrEqual>
        Console.WriteLine(7.0 >= 5.1);   // output: True
        Console.WriteLine(5.1 >= 5.1);   // output: True
        Console.WriteLine(0.0 >= 5.1);   // output: False

        Console.WriteLine(double.NaN < 5.1);   // output: False
        Console.WriteLine(double.NaN >= 5.1);  // output: False
        // </SnippetGreaterOrEqual>
    }

    private static void LessOrEqual()
    {
        // <SnippetLessOrEqual>
        Console.WriteLine(7.0 <= 5.1);   // output: False
        Console.WriteLine(5.1 <= 5.1);   // output: True
        Console.WriteLine(0.0 <= 5.1);   // output: True

        Console.WriteLine(double.NaN > 5.1);   // output: False
        Console.WriteLine(double.NaN <= 5.1);  // output: False
        // </SnippetLessOrEqual>
    }
}
