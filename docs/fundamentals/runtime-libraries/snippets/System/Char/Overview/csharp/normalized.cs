// <Snippet5>
using System;

public class Example2
{
    public static void Main()
    {
        string combining = "\u0061\u0308";
        ShowString(combining);

        string normalized = combining.Normalize();
        ShowString(normalized);
    }

    private static void ShowString(string s)
    {
        Console.Write("Length of string: {0} (", s.Length);
        for (int ctr = 0; ctr < s.Length; ctr++)
        {
            Console.Write("U+{0:X4}", Convert.ToUInt16(s[ctr]));
            if (ctr != s.Length - 1) Console.Write(" ");
        }
        Console.WriteLine(")\n");
    }
}
// The example displays the following output:
//       Length of string: 2 (U+0061 U+0308)
//
//       Length of string: 1 (U+00E4)
// </Snippet5>
