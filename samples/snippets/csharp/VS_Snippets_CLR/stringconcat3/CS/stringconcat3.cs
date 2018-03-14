//<snippet1>
using System;

public class Example
{
    public static void Main()
    {
        // Make an array of strings. Note that we have included spaces.
        string [] s = { "hello ", "and ", "welcome ", "to ",
                        "this ", "demo! " };

        // Put all the strings together.
        Console.WriteLine(string.Concat(s));

        // Sort the strings, and put them together.
        Array.Sort(s);
        Console.WriteLine(string.Concat(s));
    }
}
// The example displays the following output:
//       hello and welcome to this demo!
//       and demo! hello this to welcome
// </snippet1>
  