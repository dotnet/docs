//<snippet1>
using System;
using System.IO;

public class CharsFromStr
{
    public static void Main()
    {
        string str = "Some number of characters";
        char[] b = new char[str.Length];

        using (StringReader sr = new StringReader(str))
        {
            // Read 13 characters from the string into the array.
            sr.Read(b, 0, 13);
            Console.WriteLine(b);

            // Read the rest of the string starting at the current string position.
            // Put in the array starting at the 6th array member.
            sr.Read(b, 5, str.Length - 13);
            Console.WriteLine(b);
        }
    }
}
// The example has the following output:
//
// Some number o
// Some f characters
//</snippet1>
