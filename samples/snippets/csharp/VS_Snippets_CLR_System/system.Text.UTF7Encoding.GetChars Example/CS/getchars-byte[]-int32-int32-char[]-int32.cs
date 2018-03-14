// <Snippet1>
using System;
using System.Text;

class UTF7EncodingExample {
    public static void Main() {
        Char[] chars;
        Byte[] bytes = new Byte[] {
             85,  84,  70,  55,  32,  69, 110,
             99, 111, 100, 105, 110, 103,  32,
             69, 120,  97, 109, 112, 108, 101
        };

        UTF7Encoding utf7 = new UTF7Encoding();

        int charCount = utf7.GetCharCount(bytes, 2, 8);
        chars = new Char[charCount];
        int charsDecodedCount = utf7.GetChars(bytes, 2, 8, chars, 0);

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
