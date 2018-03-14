// <Snippet1>
using System;
using System.Text;

class Example
{
    public static void Main()
    {
        // The default constructor does not provide a preamble.
        UTF8Encoding UTF8NoPreamble = new UTF8Encoding();
        UTF8Encoding UTF8WithPreamble = new UTF8Encoding(true);

        Byte[] preamble;

        preamble = UTF8NoPreamble.GetPreamble();
        Console.WriteLine("UTF8NoPreamble");
        Console.WriteLine(" preamble length: {0}", preamble.Length);
        Console.Write(" preamble: ");
        ShowArray(preamble);
        Console.WriteLine();
        
        preamble = UTF8WithPreamble.GetPreamble();
        Console.WriteLine("UTF8WithPreamble");
        Console.WriteLine(" preamble length: {0}", preamble.Length);
        Console.Write(" preamble: ");
        ShowArray(preamble);
    }

    public static void ShowArray(Byte[] bytes)
    {
        foreach (var b in bytes)
            Console.Write("{0:X2} ", b);

        Console.WriteLine();
    }
}
// The example displays the following output:
//    UTF8NoPreamble
//     preamble length: 0
//     preamble:
//
//    UTF8WithPreamble
//     preamble length: 3
//     preamble: EF BB BF
// </Snippet1>
