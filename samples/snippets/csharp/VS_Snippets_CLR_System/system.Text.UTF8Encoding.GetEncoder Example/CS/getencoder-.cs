// <Snippet1>
using System;
using System.Text;

class UTF8EncodingExample {
    public static void Main() {
        Char[] chars = new Char[] {'a', 'b', 'c', '\u0300', '\ua0a0'};
        Byte[] bytes;

        Encoder utf8Encoder = Encoding.UTF8.GetEncoder();

        int byteCount = utf8Encoder.GetByteCount(chars, 2, 3, true);
        bytes = new Byte[byteCount];
        int bytesEncodedCount = utf8Encoder.GetBytes(chars, 2, 3, bytes, 0, true);

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

