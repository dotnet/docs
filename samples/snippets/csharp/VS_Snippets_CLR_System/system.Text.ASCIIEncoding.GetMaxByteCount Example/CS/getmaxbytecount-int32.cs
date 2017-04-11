// <Snippet1>
using System;
using System.Text;

class ASCIIEncodingExample {
    public static void Main() {
        ASCIIEncoding ascii = new ASCIIEncoding();
        int charCount = 2;
        int maxByteCount = ascii.GetMaxByteCount(charCount);
        Console.WriteLine(
            "Maximum of {0} bytes needed to encode {1} characters.",
            maxByteCount,
            charCount
        );
    }
}
// </Snippet1>
