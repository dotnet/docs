using System.Globalization;

namespace Interpolation;

public static class Program
{
    public static void Main()
    {
        General();
        Console.WriteLine();
        FormatString();
        Console.WriteLine();
        Alignment();
        Console.WriteLine();
        AlignmentAndFormat();
        Console.WriteLine();
        Escapes();
        Console.WriteLine();
        Conditional();
        Console.WriteLine();
        Newlines();
        Console.WriteLine();
        ConstantInterpolated();
        Console.WriteLine();
        Culture();
        Console.WriteLine();
        Invariant();
    }

    private static void General()
    {
        // <general>
        double a = 3;
        double b = 4;
        Console.WriteLine($"Area of the right triangle with legs of {a} and {b} is {0.5 * a * b}");
        Console.WriteLine($"Length of the hypotenuse of the right triangle with legs of {a} and {b} is {CalculateHypotenuse(a, b)}");
        double CalculateHypotenuse(double leg1, double leg2) => Math.Sqrt(leg1 * leg1 + leg2 * leg2);
        // => Area of the right triangle with legs of 3 and 4 is 6
        // => Length of the hypotenuse of the right triangle with legs of 3 and 4 is 5
        // </general>
    }

    private static void FormatString()
    {
        // <format-string>
        var date = new DateTime(1731, 11, 25);
        Console.WriteLine($"On {date:dddd, MMMM dd, yyyy} L. Euler introduced the letter e to denote {Math.E:F5}.");
        // => On Sunday, November 25, 1731 L. Euler introduced the letter e to denote 2.71828.
        // </format-string>
    }

    private static void Alignment()
    {
        // <alignment>
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
        // => Author and Title List
        // =>
        // => |Author                   |                         Title|
        // => |Doyle, Arthur Conan      |Hound of the Baskervilles, The|
        // => |London, Jack             |         Call of the Wild, The|
        // => |Shakespeare, William     |                  Tempest, The|
        // </alignment>
    }

    private static void AlignmentAndFormat()
    {
        // <alignment-and-format>
        const int NameAlignment = -9;
        const int ValueAlignment = 7;
        double a = 3;
        double b = 4;
        Console.WriteLine($"Three classical Pythagorean means of {a} and {b}:");
        Console.WriteLine($"|{"Arithmetic",NameAlignment}|{0.5 * (a + b),ValueAlignment:F3}|");
        Console.WriteLine($"|{"Geometric",NameAlignment}|{Math.Sqrt(a * b),ValueAlignment:F3}|");
        Console.WriteLine($"|{"Harmonic",NameAlignment}|{2 / (1 / a + 1 / b),ValueAlignment:F3}|");
        // => Three classical Pythagorean means of 3 and 4:
        // => |Arithmetic|  3.500|
        // => |Geometric|  3.464|
        // => |Harmonic |  3.429|
        // </alignment-and-format>
    }

    private static void Escapes()
    {
        // <escapes>
        int[] xs = [1, 2, 7, 9];
        int[] ys = [7, 9, 12];
        Console.WriteLine($"Find the intersection of the {{{string.Join(", ", xs)}}} and {{{string.Join(", ", ys)}}} sets.");
        // => Find the intersection of the {1, 2, 7, 9} and {7, 9, 12} sets.

        var userName = "Jane";
        var stringWithEscapes = $"C:\\Users\\{userName}\\Documents";
        var rawInterpolated = $"""C:\Users\{userName}\Documents""";
        Console.WriteLine(stringWithEscapes);
        Console.WriteLine(rawInterpolated);
        // => C:\Users\Jane\Documents
        // => C:\Users\Jane\Documents
        // </escapes>
    }

    private static void Conditional()
    {
        // <conditional>
        var rand = new Random(42);
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"Coin flip: {(rand.NextDouble() < 0.5 ? "heads" : "tails")}");
        }
        // </conditional>
    }

    private static void Newlines()
    {
        // <newlines>
        int[] numbers = [3, 1, 4, 1, 5, 9, 2, 6];
        Console.WriteLine($"""
            Total: {
                numbers.Sum()
                }, average: {numbers.Average():F2}.
            """);
        // => Total: 31, average: 3.88.
        // </newlines>
    }

    private static void ConstantInterpolated()
    {
        // <constant-interpolated>
        const string Audience = "world";
        const string Greeting = $"Hello, {Audience}!";
        Console.WriteLine(Greeting);
        // => Hello, world!
        // </constant-interpolated>
    }

    private static void Culture()
    {
        // <culture>
        CultureInfo[] cultures =
        [
            CultureInfo.GetCultureInfo("en-US"),
            CultureInfo.GetCultureInfo("en-GB"),
            CultureInfo.GetCultureInfo("nl-NL"),
            CultureInfo.InvariantCulture
        ];
        var date = new DateTime(2026, 5, 21, 12, 35, 31);
        var number = 31_415_926.536;
        foreach (var culture in cultures)
        {
            var cultureSpecificMessage = string.Create(culture, $"{date,23}{number,20:N3}");
            Console.WriteLine($"{culture.Name,-10}{cultureSpecificMessage}");
        }
        // Output is similar to:
        // => en-US       5/21/2026 12:35:31 PM      31,415,926.536
        // => en-GB         21/05/2026 12:35:31      31,415,926.536
        // => nl-NL         21-05-2026 12:35:31      31.415.926,536
        // =>               05/21/2026 12:35:31      31,415,926.536
        // </culture>
    }

    private static void Invariant()
    {
        // <invariant>
        var timestamp = new DateTime(2026, 5, 21, 15, 46, 24);
        string message = string.Create(CultureInfo.InvariantCulture, $"Date and time in invariant culture: {timestamp}");
        Console.WriteLine(message);
        // => Date and time in invariant culture: 05/21/2026 15:46:24
        // </invariant>
    }
}
