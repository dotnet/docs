// <Snippet1>
using System;
using System.Text;

class UnicodeEncodingExample {
    public static void Main() {
        UnicodeEncoding unicode = new UnicodeEncoding();
        String encodingName = unicode.EncodingName;
        Console.WriteLine("Encoding name: " + encodingName);
    }
}
// </Snippet1>
