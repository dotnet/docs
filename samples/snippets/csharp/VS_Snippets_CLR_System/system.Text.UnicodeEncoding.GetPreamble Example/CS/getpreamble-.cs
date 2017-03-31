// <Snippet1>
using System;
using System.Text;

class UnicodeEncodingExample {
    public static void Main() {
        Byte[] byteOrderMark;
        
        byteOrderMark = Encoding.Unicode.GetPreamble();
        Console.WriteLine("Default (little-endian) Unicode Preamble:");
        foreach (Byte b in byteOrderMark) {
            Console.Write("[{0}]", b);
        }
        Console.WriteLine("\n");

        UnicodeEncoding bigEndianUnicode = new UnicodeEncoding(true, true);
        byteOrderMark = bigEndianUnicode.GetPreamble();
        Console.WriteLine("Big-endian Unicode Preamble:");
        foreach (Byte b in byteOrderMark) {
            Console.Write("[{0}]", b);
        }
    }
}
// </Snippet1>
