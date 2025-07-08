// <Snippet2>
using System;
using System.Collections.Generic;
using System.Globalization;

public struct ByteString
{
    public string Value;
    public int Sign;
}

public class Example1
{
    public static void Main()
    {
        ByteString[] values = CreateArray(-15, 123, 245);

        byte mask = 0x14;        // Mask all bits but 2 and 4.

        foreach (ByteString strValue in values)
        {
            byte byteValue = Byte.Parse(strValue.Value, NumberStyles.AllowHexSpecifier);
            Console.WriteLine($"{strValue.Sign * byteValue} ({Convert.ToString(byteValue, 2)}) And {mask} ({Convert.ToString(mask, 2)}) = {(strValue.Sign & Math.Sign(mask)) * (byteValue & mask)} ({Convert.ToString(byteValue & mask, 2)})");
        }
    }

    private static ByteString[] CreateArray(params int[] values)
    {
        List<ByteString> byteStrings = new List<ByteString>();

        foreach (object value in values)
        {
            ByteString temp = new ByteString();
            int sign = Math.Sign((int)value);
            temp.Sign = sign;

            // Change two's complement to magnitude-only representation.
            temp.Value = Convert.ToString(((int)value) * sign, 16);

            byteStrings.Add(temp);
        }
        return byteStrings.ToArray();
    }
}
// The example displays the following output:
//       -15 (1111) And 20 (10100) = 4 (100)
//       123 (1111011) And 20 (10100) = 16 (10000)
//       245 (11110101) And 20 (10100) = 20 (10100)
// </Snippet2>
