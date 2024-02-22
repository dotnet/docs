namespace StringExamples;

using System;

public class Declarations
{
    public static void DeclareStrings()
    {
        //<StringDeclarations>
        // Declare without initializing.
        string message1;

        // Initialize to null.
        string? message2 = null;

        // Initialize as an empty string.
        // Use the Empty constant instead of the literal "".
        string message3 = System.String.Empty;

        // Initialize with a regular string literal.
        string oldPath = "c:\\Program Files\\Microsoft Visual Studio 8.0";

        // Initialize with a verbatim string literal.
        string newPath = @"c:\Program Files\Microsoft Visual Studio 9.0";

        // Use System.String if you prefer.
        System.String greeting = "Hello World!";

        // In local variables (i.e. within a method body)
        // you can use implicit typing.
        var temp = "I'm still a strongly-typed System.String!";

        // Use a const string to prevent 'message4' from
        // being used to store another string value.
        const string message4 = "You can't get rid of me!";

        // Use the String constructor only when creating
        // a string from a char*, char[], or sbyte*. See
        // System.String documentation for details.
        char[] letters = { 'A', 'B', 'C' };
        string alphabet = new string(letters);
        //</StringDeclarations>
    }

    public static void Immutability()
    {
        //<StringImmutability>
        string s1 = "A string is more ";
        string s2 = "than the sum of its chars.";

        // Concatenate s1 and s2. This actually creates a new
        // string object and stores it in s1, releasing the
        // reference to the original object.
        s1 += s2;

        System.Console.WriteLine(s1);
        // Output: A string is more than the sum of its chars.
        //</StringImmutability>

        // <ModifyIsCopy>
        string str1 = "Hello ";
        string str2 = str1;
        str1 += "World";

        System.Console.WriteLine(str2);
        //Output: Hello
        //</ModifyIsCopy>

    }

}