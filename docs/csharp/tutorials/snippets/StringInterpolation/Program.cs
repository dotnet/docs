using System.Globalization;

namespace StringInterpolation;

class Program
{
    static void Main(string[] args)
    {
        StringInterpolationExample();
        Console.WriteLine();
        SpecifyFormatString();
        Console.WriteLine();
        SpecifyAlignmentAndFormat();
        Console.WriteLine();
        EscapeSequenceExample();
        Console.WriteLine();
        ConditionalOperatorExample();
        Console.WriteLine();
        CultureSensitiveExample();
        Console.WriteLine();
        CultureSensitiveExampleOld();
        Console.WriteLine();
        InvariantCultureExample();
        Console.WriteLine();
        InvariantCultureExampleOld();
        Console.WriteLine();
    }

    private static void StringInterpolationExample()
    {
        // <General>
        double a = 3;
        double b = 4;
        Console.WriteLine($"Area of the right triangle with legs of {a} and {b} is {0.5 * a * b}");
        Console.WriteLine($"Length of the hypotenuse of the right triangle with legs of {a} and {b} is {CalculateHypotenuse(a, b)}");
        double CalculateHypotenuse(double leg1, double leg2) => Math.Sqrt(leg1 * leg1 + leg2 * leg2);
        // Output:
        // Area of the right triangle with legs of 3 and 4 is 6
        // Length of the hypotenuse of the right triangle with legs of 3 and 4 is 5
        // </General>
    }

    private static void SpecifyFormatString()
    {
        // <FormatString>
        var date = new DateTime(1731, 11, 25);
        Console.WriteLine($"On {date:dddd, MMMM dd, yyyy} L. Euler introduced the letter e to denote {Math.E:F5}.");
        // Output:
        // On Sunday, November 25, 1731 L. Euler introduced the letter e to denote 2.71828.
        // </FormatString>
    }

    private static void SpecifyAlignment()
    {

        // <AlignmentString>
        var titles = new Dictionary<string, string>()
        {
            ["Doyle, Arthur Conan"] = "Hound of the Baskervilles, The",
            ["London, Jack"] = "Call of the Wild, The",
            ["Shakespeare, William"] = "Tempest, The"
        };

        Console.WriteLine("Author and Title List");
        Console.WriteLine();
        Console.WriteLine($"|{"Author",-25}|{"Title",30}|");
        foreach (var title in titles)
        {
            Console.WriteLine($"|{title.Key,-25}|{title.Value,30}|");
        }
        // Output:
        // Author and Title List
        // 
        // |Author                   |Title                          |
        // |Doyle, Arthur Conan      |Hound of the Baskervilles, The |
        // |London, Jack             |         Call of the Wild, The |
        // |Shakespeare, William     |                  Tempest, The |
        // </AlignmentString>
    }

    private static void SpecifyAlignmentAndFormat()
    {
        // <AlignmentAndFormatString>
        const int NameAlignment = -9;
        const int ValueAlignment = 7;
        double a = 3;
        double b = 4;
        Console.WriteLine($"Three classical Pythagorean means of {a} and {b}:");
        Console.WriteLine($"|{"Arithmetic",NameAlignment}|{0.5 * (a + b),ValueAlignment:F3}|");
        Console.WriteLine($"|{"Geometric",NameAlignment}|{Math.Sqrt(a * b),ValueAlignment:F3}|");
        Console.WriteLine($"|{"Harmonic",NameAlignment}|{2 / (1 / a + 1 / b),ValueAlignment:F3}|");
        // Output:
        // Three classical Pythagorean means of 3 and 4:
        // |Arithmetic|  3.500|
        // |Geometric|  3.464|
        // |Harmonic |  3.429|
        // </AlignmentAndFormatString>
    }

    private static void EscapeSequenceExample()
    {
        // <Escapes>
        var xs = new int[] { 1, 2, 7, 9 };
        var ys = new int[] { 7, 9, 12 };
        Console.WriteLine($"Find the intersection of the {{{string.Join(", ",xs)}}} and {{{string.Join(", ",ys)}}} sets.");
        // Output:
        // Find the intersection of the {1, 2, 7, 9} and {7, 9, 12} sets.

        var userName = "Jane";
        var stringWithEscapes = $"C:\\Users\\{userName}\\Documents";
        var verbatimInterpolated = $@"C:\Users\{userName}\Documents";
        Console.WriteLine(stringWithEscapes);
        Console.WriteLine(verbatimInterpolated);
        // Output:
        // C:\Users\Jane\Documents
        // C:\Users\Jane\Documents
        // </Escapes>
    }

    private static void ConditionalOperatorExample()
    {
        // <ConditionalOperator>
        var rand = new Random();
        for (int i = 0; i < 7; i++)
        {
            Console.WriteLine($"Coin flip: {(rand.NextDouble() < 0.5 ? "heads" : "tails")}");
        }
        // </ConditionalOperator>
    }

    private static void CultureSensitiveExample()
    {
        // <CultureSensitive>
        var cultures = new System.Globalization.CultureInfo[]
        {
            System.Globalization.CultureInfo.GetCultureInfo("en-US"),
            System.Globalization.CultureInfo.GetCultureInfo("en-GB"),
            System.Globalization.CultureInfo.GetCultureInfo("nl-NL"),
            System.Globalization.CultureInfo.InvariantCulture
        };
        var date = DateTime.Now;
        var number = 31_415_926.536;
        foreach (var culture in cultures)
        {
            var cultureSpecificMessage = string.Create(culture, $"{date,23}{number,20:N3}");
            Console.WriteLine($"{culture.Name,-10}{cultureSpecificMessage}");
        }
        // Output is similar to:
        // en-US       8/27/2023 12:35:31 PM      31,415,926.536
        // en-GB         27/08/2023 12:35:31      31,415,926.536
        // nl-NL         27-08-2023 12:35:31      31.415.926,536
        //               08/27/2023 12:35:31      31,415,926.536
        // </CultureSensitive>
    }

    private static void CultureSensitiveExampleOld()
    {
        // <CultureSensitiveOld>
        var cultures = new System.Globalization.CultureInfo[]
        {
            System.Globalization.CultureInfo.GetCultureInfo("en-US"),
            System.Globalization.CultureInfo.GetCultureInfo("en-GB"),
            System.Globalization.CultureInfo.GetCultureInfo("nl-NL"),
            System.Globalization.CultureInfo.InvariantCulture
        };
        var date = DateTime.Now;
        var number = 31_415_926.536;
        FormattableString message = $"{date,23}{number,20:N3}";
        foreach (var culture in cultures)
        {
            var cultureSpecificMessage = message.ToString(culture);
            Console.WriteLine($"{culture.Name,-10}{cultureSpecificMessage}");
        }
        // Output is similar to:
        // en-US       8/27/2023 12:35:31 PM      31,415,926.536
        // en-GB         27/08/2023 12:35:31      31,415,926.536
        // nl-NL         27-08-2023 12:35:31      31.415.926,536
        //               08/27/2023 12:35:31      31,415,926.536
        // </CultureSensitiveOld>
    }

    private static void InvariantCultureExample()
    {
        // <InvariantCulture>
        string message = string.Create(CultureInfo.InvariantCulture, $"Date and time in invariant culture: {DateTime.Now}");
        Console.WriteLine(message);
        // Output is similar to:
        // Date and time in invariant culture: 05/17/2018 15:46:24
        // </InvariantCulture>
    }

    private static void InvariantCultureExampleOld()
    {
        // <InvariantCultureOld>
        string message = FormattableString.Invariant($"Date and time in invariant culture: {DateTime.Now}");
        Console.WriteLine(message);
        // Output is similar to:
        // Date and time in invariant culture: 05/17/2018 15:46:24
        // </InvariantCultureOld>
    }
}
