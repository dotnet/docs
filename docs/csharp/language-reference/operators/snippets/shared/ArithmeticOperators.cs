namespace operators;

public static class ArithmeticOperators
{
    public static void Examples()
    {
        Console.WriteLine("==== ++ and -- operators");
        Increment();
        Decrement();

        Console.WriteLine("==== Unary + and - operators");
        UnaryPlusAndMinus();

        Console.WriteLine("==== *, /, %, +, and - operators");
        Multiplication();
        IntegerDivision();
        IntegerAsFloatingPointDivision();
        FloatingPointDivision();
        IntegerRemainder();
        FloatingPointRemainder();
        Addition();
        Subtraction();

        Console.WriteLine("==== Precedence and associativity examples");
        PrecedenceAndAssociativity();

        Console.WriteLine("==== Compound assignment");
        CompoundAssignment();
        CompoundAssignmentWithCast();

        Console.WriteLine("==== Special cases");
        CheckedUnchecked();
        FloatingPointOverflow();
        RoundOffErrors();
    }

    private static void Increment()
    {
        // <SnippetPrefixIncrement>
        double a = 1.5;
        Console.WriteLine(a);   // output: 1.5
        Console.WriteLine(++a); // output: 2.5
        Console.WriteLine(a);   // output: 2.5
        // </SnippetPrefixIncrement>

        // <SnippetPostfixIncrement>
        int i = 3;
        Console.WriteLine(i);   // output: 3
        Console.WriteLine(i++); // output: 3
        Console.WriteLine(i);   // output: 4
        // </SnippetPostfixIncrement>
    }

    private static void Decrement()
    {
        // <SnippetPrefixDecrement>
        double a = 1.5;
        Console.WriteLine(a);   // output: 1.5
        Console.WriteLine(--a); // output: 0.5
        Console.WriteLine(a);   // output: 0.5
        // </SnippetPrefixDecrement>

        // <SnippetPostfixDecrement>
        int i = 3;
        Console.WriteLine(i);   // output: 3
        Console.WriteLine(i--); // output: 3
        Console.WriteLine(i);   // output: 2
        // </SnippetPostfixDecrement>
    }

    private static void UnaryPlusAndMinus()
    {
        // <SnippetUnaryPlusAndMinus>
        Console.WriteLine(+4);     // output: 4

        Console.WriteLine(-4);     // output: -4
        Console.WriteLine(-(-4));  // output: 4

        uint a = 5;
        var b = -a;
        Console.WriteLine(b);            // output: -5
        Console.WriteLine(b.GetType());  // output: System.Int64

        Console.WriteLine(-double.NaN);  // output: NaN
        // </SnippetUnaryPlusAndMinus>
    }

    private static void Multiplication()
    {
        // <SnippetMultiplication>
        Console.WriteLine(5 * 2);         // output: 10
        Console.WriteLine(0.5 * 2.5);     // output: 1.25
        Console.WriteLine(0.1m * 23.4m);  // output: 2.34
        // </SnippetMultiplication>
    }

    private static void IntegerDivision()
    {
        // <SnippetIntegerDivision>
        Console.WriteLine(13 / 5);    // output: 2
        Console.WriteLine(-13 / 5);   // output: -2
        Console.WriteLine(13 / -5);   // output: -2
        Console.WriteLine(-13 / -5);  // output: 2
        // </SnippetIntegerDivision>
    }

    private static void IntegerAsFloatingPointDivision()
    {
        // <SnippetIntegerAsFloatingPointDivision>
        Console.WriteLine(13 / 5.0);       // output: 2.6

        int a = 13;
        int b = 5;
        Console.WriteLine((double)a / b);  // output: 2.6
        // </SnippetIntegerAsFloatingPointDivision>
    }

    private static void FloatingPointDivision()
    {
        // <SnippetFloatingPointDivision>
        Console.WriteLine(16.8f / 4.1f);   // output: 4.097561
        Console.WriteLine(16.8d / 4.1d);   // output: 4.09756097560976
        Console.WriteLine(16.8m / 4.1m);   // output: 4.0975609756097560975609756098
        // </SnippetFloatingPointDivision>
    }

    private static void IntegerRemainder()
    {
        // <SnippetIntegerRemainder>
        Console.WriteLine(5 % 4);   // output: 1
        Console.WriteLine(5 % -4);  // output: 1
        Console.WriteLine(-5 % 4);  // output: -1
        Console.WriteLine(-5 % -4); // output: -1
        // </SnippetIntegerRemainder>
    }

    private static void FloatingPointRemainder()
    {
        // <SnippetFloatingPointRemainder>
        Console.WriteLine(-5.2f % 2.0f); // output: -1.2
        Console.WriteLine(5.9 % 3.1);    // output: 2.8
        Console.WriteLine(5.9m % 3.1m);  // output: 2.8
        // </SnippetFloatingPointRemainder>
    }

    private static void Addition()
    {
        // <SnippetAddition>
        Console.WriteLine(5 + 4);       // output: 9
        Console.WriteLine(5 + 4.3);     // output: 9.3
        Console.WriteLine(5.1m + 4.2m); // output: 9.3
        // </SnippetAddition>
    }

    private static void Subtraction()
    {
        // <SnippetSubtraction>
        Console.WriteLine(47 - 3);      // output: 44
        Console.WriteLine(5 - 4.3);     // output: 0.7
        Console.WriteLine(7.5m - 2.3m); // output: 5.2
        // </SnippetSubtraction>
    }

    private static void PrecedenceAndAssociativity()
    {
        // <SnippetPrecedenceAndAssociativity>
        Console.WriteLine(2 + 2 * 2);   // output: 6
        Console.WriteLine((2 + 2) * 2); // output: 8

        Console.WriteLine(9 / 5 / 2);   // output: 0
        Console.WriteLine(9 / (5 / 2)); // output: 4
        // </SnippetPrecedenceAndAssociativity>
    }

    private static void CompoundAssignment()
    {
        // <SnippetCompoundAssignment>
        int a = 5;
        a += 9;
        Console.WriteLine(a);  // output: 14

        a -= 4;
        Console.WriteLine(a);  // output: 10

        a *= 2;
        Console.WriteLine(a);  // output: 20

        a /= 4;
        Console.WriteLine(a);  // output: 5

        a %= 3;
        Console.WriteLine(a);  // output: 2
        // </SnippetCompoundAssignment>
    }

    private static void CompoundAssignmentWithCast()
    {
        // <SnippetCompoundAssignmentWithCast>
        byte a = 200;
        byte b = 100;

        var c = a + b;
        Console.WriteLine(c.GetType());  // output: System.Int32
        Console.WriteLine(c);  // output: 300

        a += b;
        Console.WriteLine(a);  // output: 44
        // </SnippetCompoundAssignmentWithCast>
    }

    private static void CheckedUnchecked()
    {
        // <SnippetCheckedUnchecked>
        int a = int.MaxValue;
        int b = 3;

        Console.WriteLine(unchecked(a + b));  // output: -2147483646
        try
        {
            int d = checked(a + b);
        }
        catch(OverflowException)
        {
            Console.WriteLine($"Overflow occurred when adding {a} to {b}.");
        }
        // </SnippetCheckedUnchecked>
    }

    // <CheckedOperator>
    public record struct Point(int X, int Y)
    {
        public static Point operator checked +(Point left, Point right)
        {
            checked
            {
                return new Point(left.X + right.X, left.Y + right.Y);
            }
        }
        
        public static Point operator +(Point left, Point right)
        {
            return new Point(left.X + right.X, left.Y + right.Y);
        }
    }
    // </CheckedOperator>

    private static void FloatingPointOverflow()
    {
        // <SnippetFloatingPointOverflow>
        double a = 1.0 / 0.0;
        Console.WriteLine(a);                    // output: Infinity
        Console.WriteLine(double.IsInfinity(a)); // output: True

        Console.WriteLine(double.MaxValue + double.MaxValue); // output: Infinity

        double b = 0.0 / 0.0;
        Console.WriteLine(b);                // output: NaN
        Console.WriteLine(double.IsNaN(b));  // output: True
        // </SnippetFloatingPointOverflow>
    }

    private static void RoundOffErrors()
    {
        // <SnippetRoundOffErrors>
        Console.WriteLine(.41f % .2f); // output: 0.00999999

        double a = 0.1;
        double b = 3 * a;
        Console.WriteLine(b == 0.3);   // output: False
        Console.WriteLine(b - 0.3);    // output: 5.55111512312578E-17

        decimal c = 1 / 3.0m;
        decimal d = 3 * c;
        Console.WriteLine(d == 1.0m);  // output: False
        Console.WriteLine(d);          // output: 0.9999999999999999999999999999
        // </SnippetRoundOffErrors>
    }
}
