// <Snippet1>
using System;
using System.Text;

class UTF8EncodingExample {
    public static void Main() {
        UTF8Encoding utf8 = new UTF8Encoding();
        int byteCount = 8;
        int maxCharCount = utf8.GetMaxCharCount(byteCount);
        Console.WriteLine(
            "Maximum of {0} characters needed to decode {1} bytes.",
            maxCharCount,
            byteCount
        );
    }
}
// </Snippet1>
