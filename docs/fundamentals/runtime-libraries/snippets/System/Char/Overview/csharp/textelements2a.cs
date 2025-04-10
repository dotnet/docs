// <Snippet4>
using System;
using System.Globalization;

public class Example4
{
    public static void Main()
    {
        string result = String.Empty;
        for (int ctr = 0x10107; ctr <= 0x10110; ctr++)  // Range of Aegean numbers.
            result += Char.ConvertFromUtf32(ctr);

        StringInfo si = new StringInfo(result);
        Console.WriteLine($"The string contains {si.LengthInTextElements} characters.");
    }
}
// The example displays the following output:
//       The string contains 10 characters.
// </Snippet4>
