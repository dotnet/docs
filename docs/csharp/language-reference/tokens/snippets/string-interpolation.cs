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
        InterpolatedRawStringLiteral();
        Console.WriteLine();
        InterpolatedRawStringLiteralWithBraces();
        Console.WriteLine();
        CreateCultureSpecificResults();
        Console.WriteLine();
        CreateCultureSpecificResultsOld();
        Console.WriteLine();
        MultiLineExpression();
        Console.WriteLine();

        RawStrings.Examples();
        Console.WriteLine();
    }

    private static void CompareWithCompositeFormatting()
    {
        // <CompareWithCompositeFormatting>
        var name = "Mark";
        var date = DateTime.Now;

        // Composite formatting:
        Console.WriteLine("Hello, {0}! Today is {1}, it's {2:HH:mm} now.", name, date.DayOfWeek, date);
        // String interpolation:
        Console.WriteLine($"Hello, {name}! Today is {date.DayOfWeek}, it's {date:HH:mm} now.");
        // Both calls produce the same output that is similar to:
        // Hello, Mark! Today is Wednesday, it's 19:40 now.
        // </CompareWithCompositeFormatting>
    }

    private static void AlignAndSpecifyFormat()
    {
        // <AlignAndSpecifyFormat>
        Console.WriteLine($"|{"Left",-7}|{"Right",7}|");

        const int FieldWidthRightAligned = 20;
        Console.WriteLine($"{Math.PI,FieldWidthRightAligned} - default formatting of the pi number");
        Console.WriteLine($"{Math.PI,FieldWidthRightAligned:F3} - display only three decimal digits of the pi number");
        // Output is:
        // |Left   |  Right|
        //     3.14159265358979 - default formatting of the pi number
        //                3.142 - display only three decimal digits of the pi number
        // </AlignAndSpecifyFormat>
    }

    private static void DelimitInterpolatedExpression()
    {
        // <BraceAndConditional>
        string name = "Horace";
        int age = 34;
        Console.WriteLine($"He asked, \"Is your name {name}?\", but didn't wait for a reply :-{{");
        Console.WriteLine($"{name} is {age} year{(age == 1 ? "" : "s")} old.");
        // Output is:
        // He asked, "Is your name Horace?", but didn't wait for a reply :-{
        // Horace is 34 years old.
        // </BraceAndConditional>
    }

    private static void CreateCultureSpecificResults()
    {
        var currentCulture = System.Globalization.CultureInfo.CurrentCulture;
        
        // <CultureSpecific>
        double speedOfLight = 299792.458;

        System.Globalization.CultureInfo.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("nl-NL");
        string messageInCurrentCulture = $"The speed of light is {speedOfLight:N3} km/s.";

        var specificCulture = System.Globalization.CultureInfo.GetCultureInfo("en-IN");
        string messageInSpecificCulture = string.Create(
            specificCulture, $"The speed of light is {speedOfLight:N3} km/s.");

        string messageInInvariantCulture = string.Create(
            System.Globalization.CultureInfo.InvariantCulture, $"The speed of light is {speedOfLight:N3} km/s.");

        Console.WriteLine($"{System.Globalization.CultureInfo.CurrentCulture,-10} {messageInCurrentCulture}");
        Console.WriteLine($"{specificCulture,-10} {messageInSpecificCulture}");
        Console.WriteLine($"{"Invariant",-10} {messageInInvariantCulture}");
        // Output is:
        // nl-NL      The speed of light is 299.792,458 km/s.
        // en-IN      The speed of light is 2,99,792.458 km/s.
        // Invariant  The speed of light is 299,792.458 km/s.
        // </CultureSpecific>
        
        System.Globalization.CultureInfo.CurrentCulture = currentCulture;
    }

    private static void CreateCultureSpecificResultsOld()
    {
        // <CultureSpecificByFormattableString>
        double speedOfLight = 299792.458;
        FormattableString message = $"The speed of light is {speedOfLight:N3} km/s.";

        var specificCulture = System.Globalization.CultureInfo.GetCultureInfo("en-IN");
        string messageInSpecificCulture = message.ToString(specificCulture);
        Console.WriteLine(messageInSpecificCulture);
        // Output:
        // The speed of light is 2,99,792.458 km/s.

        string messageInInvariantCulture = FormattableString.Invariant(message);
        Console.WriteLine(messageInInvariantCulture);
        // Output is:
        // The speed of light is 299,792.458 km/s.
        // </CultureSpecificByFormattableString>
    }

    private static void MultiLineExpression()
    {
        int safetyScore = 42;

        // <MultiLineExpression>
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
        // </MultiLineExpression>
        Console.WriteLine(message);
    }

    private static void InterpolatedRawStringLiteral()
    {
        // <InterpolatedRawStringLiteral>
        int X = 2;
        int Y = 3;

        var pointMessage = $"""The point "{X}, {Y}" is {Math.Sqrt(X * X + Y * Y):F3} from the origin""";

        Console.WriteLine(pointMessage);
        // Output is:
        // The point "2, 3" is 3.606 from the origin
        // </InterpolatedRawStringLiteral>
    }
    
    private static void InterpolatedRawStringLiteralWithBraces()
    {
        // <InterpolatedRawStringLiteralWithBraces>
        int X = 2;
        int Y = 3;

        var pointMessage = $$"""{The point {{{X}}, {{Y}}} is {{Math.Sqrt(X * X + Y * Y):F3}} from the origin}""";
        Console.WriteLine(pointMessage);
        // Output is:
        // {The point {2, 3} is 3.606 from the origin}
        // </InterpolatedRawStringLiteralWithBraces>
    }
}
