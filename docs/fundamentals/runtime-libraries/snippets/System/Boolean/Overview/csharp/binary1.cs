// <Snippet1>
using System;

public class Example1
{
    public static void Main()
    {
        bool[] flags = { true, false };
        foreach (var flag in flags)
        {
            // Get binary representation of flag.
            Byte value = BitConverter.GetBytes(flag)[0];
            Console.WriteLine($"Original value: {flag}");
            Console.WriteLine("Binary value:   {0} ({1})", value,
                              GetBinaryString(value));
            // Restore the flag from its binary representation.
            bool newFlag = BitConverter.ToBoolean(new Byte[] { value }, 0);
            Console.WriteLine($"Restored value: {flag}\n");
        }
    }

    private static string GetBinaryString(Byte value)
    {
        string retVal = Convert.ToString(value, 2);
        return new string('0', 8 - retVal.Length) + retVal;
    }
}
// The example displays the following output:
//       Original value: True
//       Binary value:   1 (00000001)
//       Restored value: True
//
//       Original value: False
//       Binary value:   0 (00000000)
//       Restored value: False
// </Snippet1>
