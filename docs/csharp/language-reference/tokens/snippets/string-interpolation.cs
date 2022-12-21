using System;

public class StringInterpolation
{
    public static void Main()
    {
        CompareWithCompositeFormatting();
        Console.WriteLine();
        AlignAndSpecifyFormat();
        Console.WriteLine();
        DelimitInterpolatedExpression();
        Console.WriteLine();
        CreateCultureSpecificResults();
        Console.WriteLine();
        MultiLineExpression();
        Console.WriteLine();
        RawStrings.Examples();
        Console.WriteLine();
    }

    private static void CompareWithCompositeFormatting()
    {
        // <Snippet1>
        string name = "Mark";
        var date = DateTime.Now;

        // Composite formatting:
        Console.WriteLine("Hello, {0}! Today is {1}, it's {2:HH:mm} now.", name, date.DayOfWeek, date);
        // String interpolation:
        Console.WriteLine($"Hello, {name}! Today is {date.DayOfWeek}, it's {date:HH:mm} now.");
        // Both calls produce the same output that is similar to:
        // Hello, Mark! Today is Wednesday, it's 19:40 now.
        // </Snippet1>
    }

    private static void AlignAndSpecifyFormat()
    {
        // <Snippet2>
        Console.WriteLine($"|{"Left",-7}|{"Right",7}|");

        const int FieldWidthRightAligned = 20;
        Console.WriteLine($"{Math.PI,FieldWidthRightAligned} - default formatting of the pi number");
        Console.WriteLine($"{Math.PI,FieldWidthRightAligned:F3} - display only three decimal digits of the pi number");
        // Expected output is:
        // |Left   |  Right|
        //     3.14159265358979 - default formatting of the pi number
        //                3.142 - display only three decimal digits of the pi number
        // </Snippet2>
    }

    private static void DelimitInterpolatedExpression()
    {
        // <Snippet3>
        string name = "Horace";
        int age = 34;
        Console.WriteLine($"He asked, \"Is your name {name}?\", but didn't wait for a reply :-{{");
        Console.WriteLine($"{name} is {age} year{(age == 1 ? "" : "s")} old.");
        // Expected output is:
        // He asked, "Is your name Horace?", but didn't wait for a reply :-{
        // Horace is 34 years old.
        // </Snippet3>
    }

    private static void CreateCultureSpecificResults()
    {
        // <Snippet4>
        double speedOfLight = 299792.458;
        FormattableString message = $"The speed of light is {speedOfLight:N3} km/s.";

        System.Globalization.CultureInfo.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("nl-NL");
        string messageInCurrentCulture = message.ToString();

        var specificCulture = System.Globalization.CultureInfo.GetCultureInfo("en-IN");
        string messageInSpecificCulture = message.ToString(specificCulture);

        string messageInInvariantCulture = FormattableString.Invariant(message);

        Console.WriteLine($"{System.Globalization.CultureInfo.CurrentCulture,-10} {messageInCurrentCulture}");
        Console.WriteLine($"{specificCulture,-10} {messageInSpecificCulture}");
        Console.WriteLine($"{"Invariant",-10} {messageInInvariantCulture}");
        // Expected output is:
        // nl-NL      The speed of light is 299.792,458 km/s.
        // en-IN      The speed of light is 2,99,792.458 km/s.
        // Invariant  The speed of light is 299,792.458 km/s.
        // </Snippet4>
    }

    private static void MultiLineExpression()
    {
        int safetyScore = 42;

        // <Newlines>
        string message = $"The usage policy for {safetyScore} is {
            safetyScore switch
            {
                > 90 => "Unlimited usage",
                > 80 => "General usage, with daily safety check",
                > 70 => "Issues must be addressed within 1 week",
                > 50 => "Issues must be addressed within 1 day",
                _ => "Issues must be addressed before continued use",
            }
            }";
        // </Newlines>
        Console.WriteLine(message);
    }

    private static void InterpolatedRawLiteralStrings()
    {
        // <RawInterpolatedLiteralString>
        int X = 2;
        int Y = 3;

        var pointMessage = $"""The point "{X}, {Y}" is {Math.Sqrt(X * X + Y * Y)} from the origin""";

        Console.WriteLine(pointMessage);
        // output:  The point "2, 3" is 3.605551275463989 from the origin.
        // </RawInterpolatedLiteralString>

    }
    private static void InterpolatedRawLiteralStringsWithBraces()
    {
        // <RawInterpolatedLiteralStringWithBraces>
        int X = 2;
        int Y = 3;

        var pointMessage = $$"""The point {{{X}}, {{Y}}} is {{Math.Sqrt(X * X + Y * Y)}} from the origin""";
        Console.WriteLine(pointMessage);
        // output:  The point {2, 3} is 3.605551275463989 from the origin.
        // </RawInterpolatedLiteralStringWithBraces>
    }
}
