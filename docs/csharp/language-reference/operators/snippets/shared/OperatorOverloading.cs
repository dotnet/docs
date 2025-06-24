public struct Fraction
{
    private int numerator;
    private int denominator;

    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.", nameof(denominator));
        }
        this.numerator = numerator;
        this.denominator = denominator;
    }

    public static Fraction operator +(Fraction operand) => operand;
    public static Fraction operator -(Fraction operand) => new Fraction(-operand.numerator, operand.denominator);

    public static Fraction operator +(Fraction left, Fraction right)
        => new Fraction(left.numerator * right.denominator + right.numerator * left.denominator, left.denominator * right.denominator);

    public static Fraction operator -(Fraction left, Fraction right)
        => left + (-right);

    public static Fraction operator *(Fraction left, Fraction right)
        => new Fraction(left.numerator * right.numerator, left.denominator * right.denominator);

    public static Fraction operator /(Fraction left, Fraction right)
    {
        if (right.numerator == 0)
        {
            throw new DivideByZeroException();
        }
        return new Fraction(left.numerator * right.denominator, left.denominator * right.numerator);
    }

    // Define increment and decrement to add 1/den, rather than 1/1.
    public static Fraction operator ++(Fraction operand)
        => new Fraction(operand.numerator++, operand.denominator);

    public static Fraction operator --(Fraction operand) =>
        new Fraction(operand.numerator--, operand.denominator);

    public override string ToString() => $"{numerator} / {denominator}";

    // New operators allowed in C# 14:
    public void operator +=(Fraction operand) =>
        (numerator, denominator ) =
        (
            numerator * operand.denominator + operand.numerator * denominator,
            denominator * operand.denominator
        );

    public void operator -=(Fraction operand) =>
        (numerator, denominator) =
        (
            numerator * operand.denominator - operand.numerator * denominator,
            denominator * operand.denominator
        );

    public void operator *=(Fraction operand) =>
        (numerator, denominator) =
        (
            numerator * operand.numerator,
            denominator * operand.denominator
        );

    public void operator /=(Fraction operand)
    {
        if (operand.numerator == 0)
        {
            throw new DivideByZeroException();
        }
        (numerator, denominator) =
        (
            numerator * operand.denominator,
            denominator * operand.numerator
        );
    }

    public void operator ++() => numerator++;

    public void operator --() => numerator--;
}

public static class OperatorOverloading
{
    public static void Main()
    {
        var a = new Fraction(5, 4);
        var b = new Fraction(1, 2);
        Console.WriteLine(-a);   // output: -5 / 4
        Console.WriteLine(a + b);  // output: 14 / 8
        Console.WriteLine(a - b);  // output: 6 / 8
        Console.WriteLine(a * b);  // output: 5 / 8
        Console.WriteLine(a / b);  // output: 10 / 4
    }
}
