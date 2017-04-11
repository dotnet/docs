// <Snippet1>
using System;
using System.Text;

class ASCIIEncodingExample {
    public static void Main() {
        Byte[] bytes;
        String chars = "ASCII Encoding Example";
        
        ASCIIEncoding ascii = new ASCIIEncoding();
        
        int byteCount = ascii.GetByteCount(chars.ToCharArray(), 6, 8);
        bytes = new Byte[byteCount];
        int bytesEncodedCount = ascii.GetBytes(chars, 6, 8, bytes, 0);
        
        Console.WriteLine(
            "{0} bytes used to encode string.", bytesEncodedCount
        );

        Console.Write("Encoded bytes: ");
        foreach (Byte b in bytes) {
            Console.Write("[{0}]", b);
        }
        Console.WriteLine();
    }
}
// </Snippet1>
