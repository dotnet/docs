// <Snippet1>
using System;
using System.Text;

class UTF7EncodingExample {
    public static void Main() {
        // Unicode characters.
        Char[] chars = new Char[] {
            '\u0023', // #
            '\u0025', // %
            '\u03a0', // Pi
            '\u03a3'  // Sigma
        };

        UTF7Encoding utf7 = new UTF7Encoding();
        int byteCount = utf7.GetByteCount(chars, 1, 2);
        Console.WriteLine(
            "{0} bytes needed to encode characters.", byteCount
        );
    }
}
// </Snippet1>
