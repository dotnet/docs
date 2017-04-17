// <Snippet1>
using System;
using System.Text;

class UnicodeEncodingExample {
    public static void Main() {
        UnicodeEncoding Unicode = new UnicodeEncoding();
        int charCount = 2;
        int maxByteCount = Unicode.GetMaxByteCount(charCount);
        Console.WriteLine(
            "Maximum of {0} bytes needed to encode {1} characters.",
            maxByteCount,
            charCount
        );
    }
}
// </Snippet1>
