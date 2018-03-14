// <Snippet1>
using System;
using System.Text;

class Example
{
    public static void Main()
    {
        UTF8Encoding utf8 = new UTF8Encoding();
        UTF8Encoding utf8ThrowException = new UTF8Encoding(false, true);

        // Create an array with two high surrogates in a row (\uD801, \uD802).
        Char[] chars = new Char[] {'a', 'b', 'c', '\uD801', '\uD802', 'd'};

        // The following method call will not throw an exception.
        Byte[] bytes = utf8.GetBytes(chars);
        ShowArray(bytes);
        Console.WriteLine();

        try {
            // The following method call will throw an exception.
            bytes = utf8ThrowException.GetBytes(chars);
            ShowArray(bytes);
        }
        catch (EncoderFallbackException e) {
            Console.WriteLine("{0} exception\nMessage:\n{1}",
                              e.GetType().Name, e.Message);
        }
    }

    public static void ShowArray(Array theArray) {
        foreach (Object o in theArray)
            Console.Write("{0:X2} ", o);

        Console.WriteLine();
    }
}
// The example displays the following output:
//    61 62 63 EF BF BD EF BF BD 64
//
//    EncoderFallbackException exception
//    Message:
//    Unable to translate Unicode character \uD801 at index 3 to specified code page.
// </Snippet1>
