// <Snippet1>
using System;
using System.Text;

class ASCIIEncodingExample {
    public static void Main() {
        ASCIIEncoding ascii = new ASCIIEncoding();
        String encodingName = ascii.EncodingName;
        Console.WriteLine("Encoding name: " + encodingName);
    }
}
// </Snippet1>
