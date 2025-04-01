// <Snippet3>
using System;

public class Example5
{
    public static void Main()
    {
        string result = String.Empty;
        for (int ctr = 0x10107; ctr <= 0x10110; ctr++)  // Range of Aegean numbers.
            result += Char.ConvertFromUtf32(ctr);

        Console.WriteLine($"The string contains {result.Length} characters.");
    }
}
// The example displays the following output:
//     The string contains 20 characters.
// </Snippet3>
