using System;

namespace StringExamples;
public static class Interpolation
{
    public static void InterpolationExamples()
    {
        // <StringInterpolation>
        var jh = (firstName: "Jupiter", lastName: "Hammon", born: 1711, published: 1761);
        Console.WriteLine($"{jh.firstName} {jh.lastName} was an African American poet born in {jh.born}.");
        Console.WriteLine($"He was first published in {jh.published} at the age of {jh.published - jh.born}.");
        Console.WriteLine($"He'd be over {Math.Round((2018d - jh.born) / 100d) * 100d} years old today.");

        // Output:
        // Jupiter Hammon was an African American poet born in 1711.
        // He was first published in 1761 at the age of 50.
        // He'd be over 300 years old today.
        // </StringInterpolation>

        System.Console.WriteLine();

        // <StringFormat>
        var pw = (firstName: "Phillis", lastName: "Wheatley", born: 1753, published: 1773);
        Console.WriteLine($"{pw.firstName} {pw.lastName} was an African American poet born in {pw.born}.");
        Console.WriteLine($"She was first published in {pw.published} at the age of {pw.published - pw.born}.");
        Console.WriteLine($"She'd be over {Math.Round((2018d - pw.born) / 100d) * 100d} years old today.");

        // Output:
        // Phillis Wheatley was an African American poet born in 1753.
        // She was first published in 1773 at the age of 20.
        // She'd be over 300 years old today.
        // </StringFormat>
    }

    public static void RawInterpolationExamples()
    {
        // <InterpolationExample>
        int X = 2;
        int Y = 3;

        var pointMessage = $$"""The point {{{X}}, {{Y}}} is {{Math.Sqrt(X * X + Y * Y)}} from the origin.""";

        Console.WriteLine(pointMessage);
        // Output:
        // The point {2, 3} is 3.605551275463989 from the origin.
        // </InterpolationExample>

    }
}
