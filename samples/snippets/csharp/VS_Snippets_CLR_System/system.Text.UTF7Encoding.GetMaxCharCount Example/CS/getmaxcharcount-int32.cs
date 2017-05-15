// <Snippet1>
using System;
using System.Text;

class UTF7EncodingExample {
    public static void Main() {
        UTF7Encoding utf7 = new UTF7Encoding();
        int byteCount = 8;
        int maxCharCount = utf7.GetMaxCharCount(byteCount);
        Console.WriteLine(
            "Maximum of {0} characters needed to decode {1} bytes.",
            maxCharCount,
            byteCount
        );
    }
}
// </Snippet1>
