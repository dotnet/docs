// <Snippet1>
using System;
using System.Text;

class EncoderExample {
    public static void Main() {
        // An Encoder is obtained from an Encoding.
        UnicodeEncoding uni = new UnicodeEncoding();
        Encoder enc1 = uni.GetEncoder();

        // A more direct technique.
        Encoder enc2 = Encoding.Unicode.GetEncoder();

        // enc1 and enc2 seem to be the same.
        Console.WriteLine(enc1.ToString());
        Console.WriteLine(enc2.ToString());

        // Note that their hash codes differ.
        Console.WriteLine(enc1.GetHashCode());
        Console.WriteLine(enc2.GetHashCode());
    }
}

/* This code example produces the following output.

System.Text.EncoderNLS
System.Text.EncoderNLS
58225482
54267293

*/
// </Snippet1>
