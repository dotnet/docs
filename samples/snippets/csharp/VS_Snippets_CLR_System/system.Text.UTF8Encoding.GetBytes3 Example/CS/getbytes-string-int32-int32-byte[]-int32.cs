// <Snippet1>
using System;
using System.Text;

class UTF8EncodingExample {
    public static void Main() {
        Byte[] bytes;
        String chars = "UTF8 Encoding Example";
        
        UTF8Encoding utf8 = new UTF8Encoding();
        
        int byteCount = utf8.GetByteCount(chars.ToCharArray(), 0, 13);
        bytes = new Byte[byteCount];
        int bytesEncodedCount = utf8.GetBytes(chars, 0, 13, bytes, 0);
        
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
