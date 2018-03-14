// <Snippet1>
using System;
using System.Text;

class EncoderExample {
    public static void Main() {
        Byte[] bytes;
        // Unicode characters.
        Char[] chars = new Char[] {
            '\u0023', // #
            '\u0025', // %
            '\u03a0', // Pi
            '\u03a3'  // Sigma
        };
        
        Encoder uniEncoder = Encoding.Unicode.GetEncoder();
        
        int byteCount = uniEncoder.GetByteCount(chars, 0, chars.Length, true);
        bytes = new Byte[byteCount];
        int bytesEncodedCount = uniEncoder.GetBytes(chars, 0, chars.Length, bytes, 0, true);
        
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

/* This code example produces the following output.

8 bytes used to encode characters.
Encoded bytes: [35][0][37][0][160][3][163][3]

*/
// </Snippet1>
