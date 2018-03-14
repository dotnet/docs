// This sample demonstrates how to use each member of the StringBuilder class.
//<Snippet2>
using System;
using System.Text;

class Constructors
{
    static void Main(string[] args)
    {
        ConstructorWithNothing();
        ConstructorWithCapacity();
        ConstructorWithString();
        ConstructorWithCapacityAndMax();
        ConstructorWithSubstring();
        ConstructorWithStringAndMax();

        Console.WriteLine("This sample completed successfully; " +
            "press Enter to exit.");
        Console.ReadLine();
    }

    private static void ConstructorWithNothing()
    {
        // Initialize a new StringBuilder object.
        //<Snippet1>
        StringBuilder stringBuilder = new StringBuilder();
        //</Snippet1>
    }
    private static void ConstructorWithCapacity()
    {
        // Initialize a new StringBuilder object with the specified capacity.
        //<Snippet3>
        int capacity = 255;
        StringBuilder stringBuilder = new StringBuilder(capacity);
        //</Snippet3>
    }
    private static void ConstructorWithString()
    {
        // Initialize a new StringBuilder object with the specified string.
        //<Snippet4>
        string initialString = "Initial string.";
        StringBuilder stringBuilder = new StringBuilder(initialString);
        //</Snippet4>
    }
    private static void ConstructorWithCapacityAndMax()
    {
        // Initialize a new StringBuilder object with the specified capacity 
        // and maximum capacity.
        //<Snippet5>
        int capacity = 255;
        int maxCapacity = 1024;
        StringBuilder stringBuilder = 
            new StringBuilder(capacity, maxCapacity);
        //</Snippet5>
    }
    private static void ConstructorWithSubstring()
    {
        // Initialize a new StringBuilder object with the specified substring.
        //<Snippet6>
        string initialString = "Initial string for stringbuilder.";
        int startIndex = 0;
        int substringLength = 14;
        int capacity = 255;
        StringBuilder stringBuilder = new StringBuilder(initialString, 
            startIndex, substringLength, capacity);
        //</Snippet6>
    }
    private static void ConstructorWithStringAndMax()
    {
        // Initialize a new StringBuilder object with the specified string
        // and maximum capacity.
        //<Snippet7>
        string initialString = "Initial string. ";
        int capacity = 255;
        StringBuilder stringBuilder = 
            new StringBuilder(initialString, capacity);
        //</Snippet7>

        // Ensure that appending the specified string will not exceed the 
        // maximum capacity of the object.
        //<Snippet8>
        string phraseToAdd = "Sentence to be appended.";
        if ((stringBuilder.Length + phraseToAdd.Length) 
            <= stringBuilder.MaxCapacity)
        {
            stringBuilder.Append(phraseToAdd); 
        }
        //</Snippet8>

        // Retrieve the string value of the StringBuilder object.
        //<Snippet9>
        string builderResults = stringBuilder.ToString();
        //</Snippet9>

        // Retrieve the last 10 characters of the StringBuilder object.
        //<Snippet10>
        int sentenceLength = 10;
        int startPosition = stringBuilder.Length - sentenceLength;
        string endPhrase = stringBuilder.ToString(
            startPosition, sentenceLength);
        //</Snippet10>

        // Retrieve the last character of the StringBuilder object.
        //<Snippet11>
        int lastCharacterPosition = stringBuilder.Length-1;
        char lastCharacter = stringBuilder[lastCharacterPosition];
        //</Snippet11>
    }
}
//
// This sample produces the following output:
//
// This sample completed successfully; press Enter to exit.
//</Snippet2>