// <Snippet1>
using System;
using System.Text;

class UnicodeEncodingExample {
    public static void Main() {
        Byte[] bytes = new Byte[] {
            85, 0, 110, 0, 105, 0, 99, 0, 111, 0, 100, 0, 101, 0
        };

        UnicodeEncoding Unicode = new UnicodeEncoding();
        int charCount = Unicode.GetCharCount(bytes, 2, 8);
        Console.WriteLine(
            "{0} characters needed to decode bytes.", charCount
        );
    }
}
// </Snippet1>
