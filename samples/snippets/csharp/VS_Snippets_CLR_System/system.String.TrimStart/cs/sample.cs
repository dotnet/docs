using System;
using System.Collections.Generic;

public class TrimExample
{
    // <Snippet3>
    public static void Main()
    {
        string[] lines = {"using System;",
                       "",
                       "public class HelloWorld",
                       "{",
                       "   public static void Main()",
                       "   {",
                       "      // This code displays a simple greeting",
                       "      // to the console.",
                       "      Console.WriteLine(\"Hello, World.\");",
                       "   }",
                       "}"};
        Console.WriteLine("Before call to StripComments:");
        foreach (string line in lines)
            Console.WriteLine("   {0}", line);

        string[] strippedLines = StripComments(lines);
        Console.WriteLine("After call to StripComments:");
        foreach (string line in strippedLines)
            Console.WriteLine("   {0}", line);
    }
    // This code produces the following output to the console:
    //    Before call to StripComments:
    //       using System;
    //   
    //       public class HelloWorld
    //       {
    //           public static void Main()
    //           {
    //               // This code displays a simple greeting
    //               // to the console.
    //               Console.WriteLine("Hello, World.");
    //           }
    //       }  
    //    After call to StripComments:
    //       This code displays a simple greeting
    //       to the console.
    // </Snippet3>

    // <Snippet2>
    public static string[] StripComments(string[] lines)
    {
        List<string> lineList = new List<string>();
        foreach (string line in lines)
        {
            if (line.TrimStart(' ').StartsWith("//"))
                lineList.Add(line.TrimStart(' ', '/'));
        }
        return lineList.ToArray();
    }
    // </Snippet2>

    public static void Main(string[] args)
    {
        // <Snippet1>
        // TrimStart examples
        string lineWithLeadingSpaces = "   Hello World!";
        string lineWithLeadingSymbols = "$$$$Hello World!";
        string lineWithLeadingUnderscores = "_____Hello World!";
        string lineWithLeadingLetters = "xxxxHello World!";
        string lineAfterTrimStart = string.Empty;

        // Make it easy to print out and work with all of the examples
        string[] lines = { lineWithLeadingSpaces, lineWithLeadingSymbols, lineWithLeadingUnderscores, lineWithLeadingLetters };

        foreach (var line in lines)
        {
            Console.WriteLine($"This line has leading characters: {line}");
        }
        // Output:
        // This line has leading characters:    Hello World!
        // This line has leading characters: $$$$Hello World!
        // This line has leading characters: _____Hello World!
        // This line has leading characters: xxxxHello World!

        // A basic demonstration of TrimStart in action
        lineAfterTrimStart = lineWithLeadingSpaces.TrimStart(' ');
        Console.WriteLine($"This is the result after calling TrimStart: {lineAfterTrimStart}");
        // This is the result after calling TrimStart: Hello World!   

        // Since TrimStart accepts a character array of leading items to be removed as an argument,
        // it's possible to do things like trim multiple pieces of data that each have different 
        // leading characters,
        foreach (var lineToEdit in lines)
        {
            Console.WriteLine(lineToEdit.TrimStart(' ', '$', '_', 'x'));
        }
        // Result for each: Hello World!

        // or handle pieces of data that have multiple kinds of leading characters 
        var lineToBeTrimmed = "__###__ John Smith";
        lineAfterTrimStart = lineToBeTrimmed.TrimStart('_', '#', ' ');
        Console.WriteLine(lineAfterTrimStart);
        // Result: John Smith
        // </Snippet1>
    }
}
