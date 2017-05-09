// <Snippet1>
using System;
using System.Text;

class EncoderExample {
    public static void Main() {
        // A Decoder is obtained from an Encoding.
        UnicodeEncoding uni = new UnicodeEncoding();
        Decoder dec1 = uni.GetDecoder();

        // A more direct technique.
        Decoder dec2 = Encoding.Unicode.GetDecoder();

        // dec1 and dec2 seem to be the same.
        Console.WriteLine(dec1.ToString());
        Console.WriteLine(dec2.ToString());

        // Note that their hash codes differ.
        Console.WriteLine(dec1.GetHashCode());
        Console.WriteLine(dec2.GetHashCode());
    }
}

/* This code example produces the following output.

System.Text.UnicodeEncoding+Decoder
System.Text.UnicodeEncoding+Decoder
58225482
54267293

*/
// </Snippet1>
