// <Snippet1>
using System;
using System.Text;

class UTF7EncodingExample {
    public static void Main() {
        Char[] chars;
        Byte[] bytes = new Byte[] {
            99, 43, 65, 119, 67, 103, 111, 65, 45
        };

        Decoder utf7Decoder = Encoding.UTF7.GetDecoder();

        int charCount = utf7Decoder.GetCharCount(bytes, 0, bytes.Length);
        chars = new Char[charCount];
        int charsDecodedCount = utf7Decoder.GetChars(bytes, 0, bytes.Length, chars, 0);

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
