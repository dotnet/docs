// <Snippet1>
using System;
using System.Text;

class UnicodeEncodingExample {
    public static void Main() {
        Char[] chars;
        Byte[] bytes = new Byte[] {
            85, 0, 110, 0, 105, 0, 99, 0, 111, 0, 100, 0, 101, 0
        };

        Decoder uniDecoder = Encoding.Unicode.GetDecoder();

        int charCount = uniDecoder.GetCharCount(bytes, 0, bytes.Length);
        chars = new Char[charCount];
        int charsDecodedCount = uniDecoder.GetChars(bytes, 0, bytes.Length, chars, 0);

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

/* This code example produces the following output.

7 characters used to decode bytes.
Decoded chars: [U][n][i][c][o][d][e]

*/
// </Snippet1>
