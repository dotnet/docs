// <Snippet1>
using System;
using System.Text;

class UTF8EncodingExample {
    public static void Main() {
        UTF8Encoding utf8 = new UTF8Encoding();
        String encodingName = utf8.EncodingName;
        Console.WriteLine("Encoding name: " + encodingName);
    }
}
// </Snippet1>
