// <Snippet1>
using System;
using System.Text;

class UnicodeEncodingExample {
    public static void Main() {
        Byte[] bytes;
        String chars = "Unicode Encoding Example";
        
        UnicodeEncoding Unicode = new UnicodeEncoding();
        
        int byteCount = Unicode.GetByteCount(chars.ToCharArray(), 8, 8);
        bytes = new Byte[byteCount];
        int bytesEncodedCount = Unicode.GetBytes(chars, 8, 8, bytes, 0);
        
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
