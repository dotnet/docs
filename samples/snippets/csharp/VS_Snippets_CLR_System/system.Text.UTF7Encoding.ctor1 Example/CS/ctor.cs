// <Snippet1>
using System;
using System.Text;

class UTF7EncodingExample {
    public static void Main() {
        UTF7Encoding utf7 = new UTF7Encoding();
        String encodingName = utf7.EncodingName;
        Console.WriteLine("Encoding name: " + encodingName);
    }
}
// </Snippet1>
