using System.Text;

namespace HowToStrings;

static public class Concatenate
{
    public static void Examples()
    {
        UsingAddWithConstantStrings();
        UsingAddWithVariables();
        UsingInterpolationWithVariables();
        UsingStringBuilder();
        UsingConcatAndJoin();
        UsingAggregate();
    }

    private static void UsingAddWithConstantStrings()
    {
        // <Snippet1>
        // Concatenation of literals is performed at compile time, not run time.
        string text = "Historically, the world of data and the world of objects " +
        "have not been well integrated. Programmers work in C# or Visual Basic " +
        "and also in SQL or XQuery. On the one side are concepts such as classes, " +
        "objects, fields, inheritance, and .NET Framework APIs. On the other side " +
        "are tables, columns, rows, nodes, and separate languages for dealing with " +
        "them. Data types often require translation between the two worlds; there are " +
        "different standard functions. Because the object world has no notion of query, a " +
        "query can only be represented as a string without compile-time type checking or " +
        "IntelliSense support in the IDE. Transferring data from SQL tables or XML trees to " +
        "objects in memory is often tedious and error-prone.";

        Console.WriteLine(text);
        // </Snippet1>
    }

    private static void UsingAddWithVariables()
    {
        // <Snippet2>
        string userName = "<Type your name here>";
        string dateString = DateTime.Today.ToShortDateString();

        // Use the + and += operators for one-time concatenations.
        string str = "Hello " + userName + ". Today is " + dateString + ".";
        Console.WriteLine(str);

        str += " How are you today?";
        Console.WriteLine(str);
        // </Snippet2>
    }
    private static void UsingInterpolationWithVariables()
    {
        // <Snippet3>
        string userName = "<Type your name here>";
        string date = DateTime.Today.ToShortDateString();

        // Use string interpolation to concatenate strings.
        string str = $"Hello {userName}. Today is {date}.";
        Console.WriteLine(str);

        str = $"{str} How are you today?";
        Console.WriteLine(str);
        // </Snippet3>
    }

    private static void UsingStringBuilder()
    {
        // <Snippet4>
        // Use StringBuilder for concatenation in tight loops.
        var sb = new StringBuilder();
        for (int i = 0; i < 20; i++)
        {
            sb.AppendLine(i.ToString());
        }
        Console.WriteLine(sb.ToString());
        // </Snippet4>
    }

    private static void UsingConcatAndJoin()
    {
        // <Snippet5>
        string[] words = ["The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog."];

        var unreadablePhrase = string.Concat(words);
        Console.WriteLine(unreadablePhrase);

        var readablePhrase = string.Join(" ", words);
        Console.WriteLine(readablePhrase);
        // </Snippet5>
    }

    private static void UsingAggregate()
    {
        // <Snippet6>
        string[] words = ["The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog."];

        var phrase = words.Aggregate((partialPhrase, word) =>$"{partialPhrase} {word}");
        Console.WriteLine(phrase);
        // </Snippet6>
    }
}
