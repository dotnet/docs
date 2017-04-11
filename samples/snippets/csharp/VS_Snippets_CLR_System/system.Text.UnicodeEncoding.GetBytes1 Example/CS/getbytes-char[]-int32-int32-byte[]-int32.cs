// <Snippet1>
using System;
using System.Text;

class UnicodeEncodingExample {
    public static void Main() {
        Byte[] bytes;
        // Unicode characters.
        Char[] chars = new Char[] {
            '\u0023', // #
            '\u0025', // %
            '\u03a0', // Pi
            '\u03a3'  // Sigma
        };
        
        UnicodeEncoding Unicode = new UnicodeEncoding();
        
        int byteCount = Unicode.GetByteCount(chars, 1, 2);
        bytes = new Byte[byteCount];
        int bytesEncodedCount = Unicode.GetBytes(chars, 1, 2, bytes, 0);
        
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
