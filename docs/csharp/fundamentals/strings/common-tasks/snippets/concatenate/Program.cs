using System.Text;

namespace ConcatenateStrings;

public static class Program
{
    public static void Main()
    {
        CombineLiterals();
        Console.WriteLine();
        UseOperators();
        Console.WriteLine();
        UseInterpolation();
        Console.WriteLine();
        UseConcatAndJoin();
        Console.WriteLine();
        UseStringBuilder();
    }

    private static void CombineLiterals()
    {
        // <Literals>
        // The compiler joins adjacent string literals at compile time,
        // so splitting a long literal across lines has no run-time cost.
        string message =
            "This is the first sentence of a longer message. " +
            "This is the second sentence. " +
            "This is the third and final sentence.";

        Console.WriteLine(message);
        // => This is the first sentence of a longer message. This is the second sentence. This is the third and final sentence.
        // </Literals>
    }

    private static void UseOperators()
    {
        // <Operators>
        string name = "Alex";
        string day = "Monday";

        // Use + to build a string from variables and literals.
        string greeting = "Hello " + name + ". Today is " + day + ".";
        Console.WriteLine(greeting);
        // => Hello Alex. Today is Monday.

        // Use += to append to an existing string.
        greeting += " How are you today?";
        Console.WriteLine(greeting);
        // => Hello Alex. Today is Monday. How are you today?
        // </Operators>
    }

    private static void UseInterpolation()
    {
        // <Interpolation>
        string name = "Alex";
        string day = "Monday";

        // String interpolation reads better than a chain of + operators.
        string greeting = $"Hello {name}. Today is {day}.";
        Console.WriteLine(greeting);
        // => Hello Alex. Today is Monday.
        // </Interpolation>
    }

    private static void UseConcatAndJoin()
    {
        // <ConcatJoin>
        string[] words = ["The", "quick", "brown", "fox"];

        // Concat joins the sequence with no separator.
        string runTogether = string.Concat(words);
        Console.WriteLine(runTogether);
        // => Thequickbrownfox

        // Join places a separator between each element.
        string sentence = string.Join(' ', words);
        Console.WriteLine(sentence);
        // => The quick brown fox
        // </ConcatJoin>
    }

    private static void UseStringBuilder()
    {
        // <StringBuilder>
        // StringBuilder builds a string in place, which suits loops
        // that append many pieces.
        var builder = new StringBuilder();
        for (int i = 1; i <= 3; i++)
        {
            builder.AppendLine($"Line {i}");
        }

        Console.Write(builder.ToString());
        // => Line 1
        // => Line 2
        // => Line 3
        // </StringBuilder>
    }
}
