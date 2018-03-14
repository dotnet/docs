// <Snippet1>
using System;
using System.Text;

class UTF8EncodingExample {
    public static void Main() {
        Byte[] bytes;
        // Unicode characters.
        Char[] chars = new Char[] {
            '\u0023', // #
            '\u0025', // %
            '\u03a0', // Pi
            '\u03a3'  // Sigma
        };
        
        UTF8Encoding utf8 = new UTF8Encoding();
        
        int byteCount = utf8.GetByteCount(chars, 1, 2);
        bytes = new Byte[byteCount];
        int bytesEncodedCount = utf8.GetBytes(chars, 1, 2, bytes, 0);
        
        Console.WriteLine(
            "{0} bytes used to encode characters.", bytesEncodedCount
        );

        Console.Write("Encoded bytes: ");
        foreach (Byte b in bytes) {
            Console.Write("[{0}]", b);
        }
        Console.WriteLine();
    }
}
// </Snippet1>
