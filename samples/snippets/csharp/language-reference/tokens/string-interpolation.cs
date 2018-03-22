using System;
using System.Globalization;

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
        double price = 1000;
        FormattableString message = $"The cost of this item is {price:C}.";
        
        CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
        string messageInCurrentCulture = message.ToString();

        CultureInfo specificCulture = CultureInfo.GetCultureInfo("nl-NL");
        string messageInSpecificCulture = message.ToString(specificCulture);

        string messageInInvariantCulture = FormattableString.Invariant(message);

        const int CultureOutputAlignment = -10;
        Console.WriteLine($"{CultureInfo.CurrentCulture,CultureOutputAlignment} {messageInCurrentCulture}");
        Console.WriteLine($"{specificCulture,CultureOutputAlignment} {messageInSpecificCulture}");
        Console.WriteLine($"{"Invariant",CultureOutputAlignment} {messageInInvariantCulture}");
        // Expected output is:
        // en-US      The cost of this item is $1,000.00.
        // nl-NL      The cost of this item is € 1.000,00.
        // Invariant  The cost of this item is ¤1,000.00.
        // </Snippet4>
    }
}