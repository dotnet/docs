// <Snippet1>
using System;
using System.Text;

class UTF8EncodingExample {
    public static void Main() {
        Char[] chars;
        Byte[] bytes = new Byte[] {
            99, 204, 128, 234, 130, 160
        };

        Decoder utf8Decoder = Encoding.UTF8.GetDecoder();

        int charCount = utf8Decoder.GetCharCount(bytes, 0, bytes.Length);
        chars = new Char[charCount];
        int charsDecodedCount = utf8Decoder.GetChars(bytes, 0, bytes.Length, chars, 0);

        Console.WriteLine(
            "{0} characters used to decode bytes.", charsDecodedCount
        );

        Console.Write("Decoded chars: ");
        foreach (Char c in chars) {
            Console.Write("[{0}]", c);
        }
        Console.WriteLine();
    }
}
// </Snippet1>
