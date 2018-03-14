// <Snippet1>
using System;
using System.Text;

class UTF7EncodingExample {
    public static void Main() {
        UTF7Encoding utf7 = new UTF7Encoding();
        int charCount = 2;
        int maxByteCount = utf7.GetMaxByteCount(charCount);
        Console.WriteLine(
            "Maximum of {0} bytes needed to encode {1} characters.",
            maxByteCount,
            charCount
        );
    }
}
// </Snippet1>
