// <Snippet1>
using System;
using System.Text;

class ASCIIEncodingExample {
    public static void Main() {
        Byte[] bytes = new Byte[] {
             65,  83,  67,  73,  73,  32,  69,
            110,  99, 111, 100, 105, 110, 103,
             32,  69, 120,  97, 109, 112, 108, 101
        };

        ASCIIEncoding ascii = new ASCIIEncoding();
        int charCount = ascii.GetCharCount(bytes, 6, 8);
        Console.WriteLine(
            "{0} characters needed to decode bytes.", charCount
        );
    }
}
// </Snippet1>
