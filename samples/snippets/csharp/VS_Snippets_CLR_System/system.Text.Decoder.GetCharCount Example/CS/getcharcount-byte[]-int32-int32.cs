// <Snippet1>
using System;
using System.Text;

class DecoderExample {
    public static void Main() {
        Byte[] bytes = new Byte[] {
            85, 0, 110, 0, 105, 0, 99, 0, 111, 0, 100, 0, 101, 0
        };

        Decoder uniDecoder = Encoding.Unicode.GetDecoder();
        int charCount = uniDecoder.GetCharCount(bytes, 0, bytes.Length);
        Console.WriteLine(
            "{0} characters needed to decode bytes.", charCount
        );
    }
}

/* This code example produces the following output.

7 characters needed to decode bytes.

*/
// </Snippet1>
