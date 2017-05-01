// <Snippet1>
using System;
using System.Text;

class ASCIIEncodingExample {
    public static void Main() {
        ASCIIEncoding ascii = new ASCIIEncoding();
        int byteCount = 8;
        int maxCharCount = ascii.GetMaxCharCount(byteCount);
        Console.WriteLine(
            "Maximum of {0} characters needed to decode {1} bytes.",
            maxCharCount,
            byteCount
        );
    }
}
// </Snippet1>
