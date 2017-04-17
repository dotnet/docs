// <Snippet1>
using System;
using System.Text;

class UnicodeEncodingExample {
    public static void Main() {
        UnicodeEncoding Unicode = new UnicodeEncoding();
        int byteCount = 8;
        int maxCharCount = Unicode.GetMaxCharCount(byteCount);
        Console.WriteLine(
            "Maximum of {0} characters needed to decode {1} bytes.",
            maxCharCount,
            byteCount
        );
    }
}
// </Snippet1>
