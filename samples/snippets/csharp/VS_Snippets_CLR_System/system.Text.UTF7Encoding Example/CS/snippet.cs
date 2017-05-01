// <Snippet1>
using System;
using System.Text;

class UTF7EncodingExample {
    public static void Main() {
        // Create a UTF-7 encoding.
        UTF7Encoding utf7 = new UTF7Encoding();
        
        // A Unicode string with two characters outside a 7-bit code range.
        String unicodeString =
            "This Unicode string contains two characters " +
            "with codes outside a 7-bit code range, " +
            "Pi (\u03a0) and Sigma (\u03a3).";
        Console.WriteLine("Original string:");
        Console.WriteLine(unicodeString);

        // Encode the string.
        Byte[] encodedBytes = utf7.GetBytes(unicodeString);
        Console.WriteLine();
        Console.WriteLine("Encoded bytes:");
        foreach (Byte b in encodedBytes) {
            Console.Write("[{0}]", b);
        }
        Console.WriteLine();
        
        // Decode bytes back to string.
        // Notice Pi and Sigma characters are still present.
        String decodedString = utf7.GetString(encodedBytes);
        Console.WriteLine();
        Console.WriteLine("Decoded bytes:");
        Console.WriteLine(decodedString);
    }
}
// </Snippet1>
