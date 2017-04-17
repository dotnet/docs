// <Snippet1>
using System;
using System.Text;

class UTF8EncodingExample {
    public static void Main() {
        Char[] chars;
        Byte[] bytes = new Byte[] {
             85,  84,  70,  56,  32,  69, 110,
             99, 111, 100, 105, 110, 103,  32,
             69, 120,  97, 109, 112, 108, 101
        };

        UTF8Encoding utf8 = new UTF8Encoding();

        int charCount = utf8.GetCharCount(bytes, 2, 13);
        chars = new Char[charCount];
        int charsDecodedCount = utf8.GetChars(bytes, 2, 13, chars, 0);

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
