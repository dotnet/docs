 // <Snippet1>
using System;
using System.Text;

public class Example
{
    public static void Main()
    {
        // The encoding.
        var enc = new UTF32Encoding();
        
        // Create a string.
        String s = "This string contains two characters " +
                   "with codes outside the ASCII code range: " +
                   "Pi (\u03A0) and Sigma (\u03A3).";
        Console.WriteLine("Original string:");
        Console.WriteLine("   {0}", s);
        
        // Encode the string.
        Byte[] encodedBytes = enc.GetBytes(s);
        Console.WriteLine();
        Console.WriteLine("Encoded bytes:");
        for (int ctr = 0; ctr < encodedBytes.Length; ctr++) {
            Console.Write("[{0:X2}]{1}", encodedBytes[ctr],
                                         (ctr + 1) % 4 == 0 ? " " : "" );
            if ((ctr + 1) % 16 == 0) Console.WriteLine();
        }
        Console.WriteLine();
        
        // Decode bytes back to string.
        // Notice Pi and Sigma characters are still present.
        String decodedString = enc.GetString(encodedBytes);
        Console.WriteLine();
        Console.WriteLine("Decoded string:");
        Console.WriteLine("   {0}", decodedString);
    }
}
// The example displays the following output:
//    Original string:
//       This string contains two characters with codes outside the ASCII code range:
//    Pi (π) and Sigma (Σ).
//
//    Encoded bytes:
//    [54][00][00][00] [68][00][00][00] [69][00][00][00] [73][00][00][00]
//    [20][00][00][00] [73][00][00][00] [74][00][00][00] [72][00][00][00]
//    [69][00][00][00] [6E][00][00][00] [67][00][00][00] [20][00][00][00]
//    [63][00][00][00] [6F][00][00][00] [6E][00][00][00] [74][00][00][00]
//    [61][00][00][00] [69][00][00][00] [6E][00][00][00] [73][00][00][00]
//    [20][00][00][00] [74][00][00][00] [77][00][00][00] [6F][00][00][00]
//    [20][00][00][00] [63][00][00][00] [68][00][00][00] [61][00][00][00]
//    [72][00][00][00] [61][00][00][00] [63][00][00][00] [74][00][00][00]
//    [65][00][00][00] [72][00][00][00] [73][00][00][00] [20][00][00][00]
//    [77][00][00][00] [69][00][00][00] [74][00][00][00] [68][00][00][00]
//    [20][00][00][00] [63][00][00][00] [6F][00][00][00] [64][00][00][00]
//    [65][00][00][00] [73][00][00][00] [20][00][00][00] [6F][00][00][00]
//    [75][00][00][00] [74][00][00][00] [73][00][00][00] [69][00][00][00]
//    [64][00][00][00] [65][00][00][00] [20][00][00][00] [74][00][00][00]
//    [68][00][00][00] [65][00][00][00] [20][00][00][00] [41][00][00][00]
//    [53][00][00][00] [43][00][00][00] [49][00][00][00] [49][00][00][00]
//    [20][00][00][00] [63][00][00][00] [6F][00][00][00] [64][00][00][00]
//    [65][00][00][00] [20][00][00][00] [72][00][00][00] [61][00][00][00]
//    [6E][00][00][00] [67][00][00][00] [65][00][00][00] [3A][00][00][00]
//    [20][00][00][00] [50][00][00][00] [69][00][00][00] [20][00][00][00]
//    [28][00][00][00] [A0][03][00][00] [29][00][00][00] [20][00][00][00]
//    [61][00][00][00] [6E][00][00][00] [64][00][00][00] [20][00][00][00]
//    [53][00][00][00] [69][00][00][00] [67][00][00][00] [6D][00][00][00]
//    [61][00][00][00] [20][00][00][00] [28][00][00][00] [A3][03][00][00]
//    [29][00][00][00] [2E][00][00][00]
//
//    Decoded string:
//       This string contains two characters with codes outside the ASCII code range:
//    Pi (π) and Sigma (Σ).
// </Snippet1>
