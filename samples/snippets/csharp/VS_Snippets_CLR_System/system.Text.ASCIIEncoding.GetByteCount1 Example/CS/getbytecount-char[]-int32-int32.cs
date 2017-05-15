// <Snippet1>
using System;
using System.Text;

class ASCIIEncodingExample {
    public static void Main() {
        // Unicode characters.
        Char[] chars = new Char[] {
            '\u0023', // #
            '\u0025', // %
            '\u03a0', // Pi
            '\u03a3'  // Sigma
        };

        ASCIIEncoding ascii = new ASCIIEncoding();
        int byteCount = ascii.GetByteCount(chars, 1, 2);
        Console.WriteLine(
            "{0} bytes needed to encode characters.", byteCount
        );
    }
}
// </Snippet1>
