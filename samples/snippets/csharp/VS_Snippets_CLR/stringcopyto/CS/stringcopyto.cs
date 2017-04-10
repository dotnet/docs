// <Snippet1>
using System;

public class CopyToTest {
    public static void Main() {

        // Embed an array of characters in a string
        string strSource = "changed";
    char [] destination = { 'T', 'h', 'e', ' ', 'i', 'n', 'i', 't', 'i', 'a', 'l', ' ',
                'a', 'r', 'r', 'a', 'y' };

        // Print the char array
        Console.WriteLine( destination );

        // Embed the source string in the destination string
        strSource.CopyTo ( 0, destination, 4, strSource.Length );

        // Print the resulting array
        Console.WriteLine( destination );

        strSource = "A different string";

        // Embed only a section of the source string in the destination
        strSource.CopyTo ( 2, destination, 3, 9 );

        // Print the resulting array
        Console.WriteLine( destination );
    }
}
// The example displays the following output:
//       The initial array
//       The changed array
//       Thedifferentarray
// </Snippet1>
