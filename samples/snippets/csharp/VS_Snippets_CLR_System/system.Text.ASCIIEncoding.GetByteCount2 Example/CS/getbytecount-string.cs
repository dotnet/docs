// <Snippet1>
using System;
using System.Text;

class ASCIIEncodingExample {
    public static void Main() {
        String chars = "ASCII Encoding Example";

        ASCIIEncoding ascii = new ASCIIEncoding();
        int byteCount = ascii.GetByteCount(chars);
        Console.WriteLine(
            "{0} bytes needed to encode string.", byteCount
        );
    }
}
// </Snippet1>
