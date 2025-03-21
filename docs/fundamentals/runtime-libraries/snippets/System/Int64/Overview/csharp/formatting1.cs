using System;

public class Example1
{
    public static void Main()
    {
        CallToString();
        Console.WriteLine("-----");
        CallConvert();
    }

    private static void CallToString()
    {
        // <Snippet1>
        long[] numbers = { -1403, 0, 169, 1483104 };
        foreach (var number in numbers)
        {
            // Display value using default formatting.
            Console.Write("{0,-8}  -->   ", number.ToString());
            // Display value with 3 digits and leading zeros.
            Console.Write("{0,8:D3}", number);
            // Display value with 1 decimal digit.
            Console.Write("{0,13:N1}", number);
            // Display value as hexadecimal.
            Console.Write("{0,18:X2}", number);
            // Display value with eight hexadecimal digits.
            Console.WriteLine("{0,18:X8}", number);
        }
        // The example displays the following output:
        //    -1403     -->      -1403     -1,403.0  FFFFFFFFFFFFFA85  FFFFFFFFFFFFFA85
        //    0         -->        000          0.0                00          00000000
        //    169       -->        169        169.0                A9          000000A9
        //    1483104   -->    1483104  1,483,104.0            16A160          0016A160
        // </Snippet1>
    }

    private static void CallConvert()
    {
        // <Snippet2>
        long[] numbers = { -146, 11043, 2781913 };
        foreach (var number in numbers)
        {
            Console.WriteLine($"{number} (Base 10):");
            Console.WriteLine($"   Binary:  {Convert.ToString(number, 2)}");
            Console.WriteLine($"   Octal:   {Convert.ToString(number, 8)}");
            Console.WriteLine($"   Hex:     {Convert.ToString(number, 16)}{Environment.NewLine}");
        }
        // The example displays the following output:
        //    -146 (Base 10):
        //       Binary:  1111111111111111111111111111111111111111111111111111111101101110
        //       Octal:   1777777777777777777556
        //       Hex:     ffffffffffffff6e
        //
        //    11043 (Base 10):
        //       Binary:  10101100100011
        //       Octal:   25443
        //       Hex:     2b23
        //
        //    2781913 (Base 10):
        //       Binary:  1010100111001011011001
        //       Octal:   12471331
        //       Hex:     2a72d9
        // </Snippet2>
    }
}
