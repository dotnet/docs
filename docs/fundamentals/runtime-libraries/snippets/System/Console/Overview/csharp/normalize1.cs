// <Snippet5>
using System;
using System.IO;

public class Example1
{
    public static void Main()
    {
        char[] chars = { '\u0061', '\u0308' };

        string combining = new String(chars);
        Console.WriteLine(combining);

        combining = combining.Normalize();
        Console.WriteLine(combining);
    }
}
// The example displays the following output:
//       a"
//       ä
// </Snippet5>
