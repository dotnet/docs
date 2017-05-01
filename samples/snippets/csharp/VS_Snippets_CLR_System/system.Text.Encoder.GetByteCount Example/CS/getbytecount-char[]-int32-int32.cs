// <Snippet1>
using System;
using System.Text;

class EncoderExample {
    public static void Main() {
        // Unicode characters.
        Char[] chars = new Char[] {
            '\u0023', // #
            '\u0025', // %
            '\u03a0', // Pi
            '\u03a3'  // Sigma
        };

        Encoder uniEncoder = Encoding.Unicode.GetEncoder();
        int byteCount = uniEncoder.GetByteCount(chars, 0, chars.Length, true);
        Console.WriteLine(
            "{0} bytes needed to encode characters.", byteCount
        );
    }
}

/* This example produces the following output.

8 bytes needed to encode characters.

*/
// </Snippet1>
