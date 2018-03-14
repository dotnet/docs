// <Snippet1>
using System;
using System.Text;

class Example 
{
    public static void Main() 
    {
        // Define a string.
        String original = "ASCII Encoding Example";
        // Instantiate an ASCII encoding object.
        ASCIIEncoding ascii = new ASCIIEncoding();
        
        // Create an ASCII byte array.
        Byte[] bytes = ascii.GetBytes(original); 
        
        // Display encoded bytes.
        Console.Write("Encoded bytes (in hex):  ");
        foreach (var value in bytes)
           Console.Write("{0:X2} ", value);
        Console.WriteLine();

        // Decode the bytes and display the resulting Unicode string.
        String decoded = ascii.GetString(bytes);
        Console.WriteLine("Decoded string: '{0}'", decoded);
    }
}
// The example displays the following output:
//     Encoded bytes (in hex):  41 53 43 49 49 20 45 6E 63 6F 64 69 6E 67 20 45 78 61 6D 70 6C 65
//     Decoded string: 'ASCII Encoding Example'
// </Snippet1>
