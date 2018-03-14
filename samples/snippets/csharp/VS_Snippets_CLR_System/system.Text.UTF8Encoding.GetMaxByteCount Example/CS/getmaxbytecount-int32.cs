// <Snippet1>
using System;
using System.Text;

class UTF8EncodingExample {
    public static void Main() {
        UTF8Encoding utf8 = new UTF8Encoding();
        int charCount = 2;
        int maxByteCount = utf8.GetMaxByteCount(charCount);
        Console.WriteLine(
            "Maximum of {0} bytes needed to encode {1} characters.",
            maxByteCount,
            charCount
        );
    }
}
// </Snippet1>
