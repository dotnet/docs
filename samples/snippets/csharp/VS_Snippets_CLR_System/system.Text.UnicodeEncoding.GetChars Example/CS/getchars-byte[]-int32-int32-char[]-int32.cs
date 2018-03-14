// <Snippet1>
using System;
using System.Text;

class UnicodeEncodingExample {
    public static void Main() {
        Char[] chars;
        Byte[] bytes = new Byte[] {
            85, 0, 110, 0, 105, 0, 99, 0, 111, 0, 100, 0, 101, 0
        };

        UnicodeEncoding Unicode = new UnicodeEncoding();

        int charCount = Unicode.GetCharCount(bytes, 2, 8);
        chars = new Char[charCount];
        int charsDecodedCount = Unicode.GetChars(bytes, 2, 8, chars, 0);

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
