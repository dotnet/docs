using System.Text;

namespace ConcatenateStrings;

public static class Program
{
    public static void Main()
    {
        PlusOperator();
        Console.WriteLine();
        Interpolation();
        Console.WriteLine();
        UsingStringBuilder();
        Console.WriteLine();
        UsingJoin();
    }

    private static void PlusOperator()
    {
        // <PlusOperator>
        string userName = "Ada";
        string greeting = "Hello, " + userName + ".";
        Console.WriteLine(greeting);
        // => Hello, Ada.

        greeting += " Welcome back!";
        Console.WriteLine(greeting);
        // => Hello, Ada. Welcome back!
        // </PlusOperator>
    }

    private static void Interpolation()
    {
        // <Interpolation>
        string userName = "Ada";
        int unread = 3;
        string status = $"Hello, {userName}. You have {unread} unread messages.";
        Console.WriteLine(status);
        // => Hello, Ada. You have 3 unread messages.
        // </Interpolation>
    }

    private static void UsingStringBuilder()
    {
        // <StringBuilder>
        var builder = new StringBuilder();
        for (int i = 1; i <= 5; i++)
        {
            builder.AppendLine($"Line {i}");
        }
        Console.Write(builder.ToString());
        // => Line 1
        // => Line 2
        // => Line 3
        // => Line 4
        // => Line 5
        // </StringBuilder>
    }

    private static void UsingJoin()
    {
        // <Join>
        string[] words = ["The", "quick", "brown", "fox"];

        string sentence = string.Join(' ', words);
        Console.WriteLine(sentence);
        // => The quick brown fox

        string csv = string.Join(", ", words);
        Console.WriteLine(csv);
        // => The, quick, brown, fox
        // </Join>
    }
}
