// <SnippetUsingStatic>
using static System.Console;
// </SnippetUsingStatic>
using System.Linq;

public class Person
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    // <SnippetMiddleName>
    public string MiddleName { get; } = "";

    public Person(string first, string middle, string last)
    {
        FirstName = first;
        MiddleName = middle;
        LastName = last;
    }
    // </SnippetMiddleName>

    public Person(string first, string last)
    {
        FirstName = first;
        LastName = last;
    }

    // <SnippetStringInterpolation>
    public override string ToString() => $"{FirstName} {LastName}";
    public string AllCaps() => ToString().ToUpper();
    // </SnippetStringInterpolation>
}

public class Program
{
    public static void Main()
    {
        // <SnippetInterpolationMain>
        var p = new Person("Bill", "Wagner");
        WriteLine($"The name, in all caps: {p.AllCaps()}");
        WriteLine($"The name is: {p}");
        // </SnippetInterpolationMain>
        // <SnippetPhrases>
        var phrase = "the quick brown fox jumps over the lazy dog";
        var wordLength = from word in phrase.Split(' ') select word.Length;
        var average = wordLength.Average();
        WriteLine(average);
        // </SnippetPhrases>
    }
}
