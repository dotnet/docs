using System;

public class Example5
{
    public static void Main()
    {
        PerformDecimalConversions();
        Console.WriteLine("-----");
        PerformCustomConversions();
    }

    private static void PerformDecimalConversions()
    {
        // <Snippet1>
        byte byteValue = 16;
        short shortValue = -1024;
        int intValue = -1034000;
        long longValue = 1152921504606846976;
        ulong ulongValue = UInt64.MaxValue;

        decimal decimalValue;

        decimalValue = byteValue;
        Console.WriteLine("After assigning a {0} value, the Decimal value is {1}.",
                          byteValue.GetType().Name, decimalValue);

        decimalValue = shortValue;
        Console.WriteLine("After assigning a {0} value, the Decimal value is {1}.",
                          shortValue.GetType().Name, decimalValue);

        decimalValue = intValue;
        Console.WriteLine("After assigning a {0} value, the Decimal value is {1}.",
                          intValue.GetType().Name, decimalValue);

        decimalValue = longValue;
        Console.WriteLine("After assigning a {0} value, the Decimal value is {1}.",
                          longValue.GetType().Name, decimalValue);

      decimalValue = ulongValue;
      Console.WriteLine("After assigning a {0} value, the Decimal value is {1}.",
                        ulongValue.GetType().Name, decimalValue);
      // The example displays the following output:
      //    After assigning a Byte value, the Decimal value is 16.
      //    After assigning a Int16 value, the Decimal value is -1024.
      //    After assigning a Int32 value, the Decimal value is -1034000.
      //    After assigning a Int64 value, the Decimal value is 1152921504606846976.
      //    After assigning a UInt64 value, the Decimal value is 18446744073709551615.
      // </Snippet1>
   }

    private static void PerformCustomConversions()
    {
        // <Snippet3>
        SByte sbyteValue = -120;
        ByteWithSign value = sbyteValue;
        Console.WriteLine(value);
        value = Byte.MaxValue;
        Console.WriteLine(value);
        // The example displays the following output:
        //       -120
        //       255
        // </Snippet3>
    }
}

// <Snippet2>
public struct ByteWithSign
{
    private SByte signValue;
    private Byte value;

    public static implicit operator ByteWithSign(SByte value)
    {
        ByteWithSign newValue;
        newValue.signValue = (SByte)Math.Sign(value);
        newValue.value = (byte)Math.Abs(value);
        return newValue;
    }

    public static implicit operator ByteWithSign(Byte value)
    {
        ByteWithSign newValue;
        newValue.signValue = 1;
        newValue.value = value;
        return newValue;
    }

    public override string ToString()
    {
        return (signValue * value).ToString();
    }
}
// </Snippet2>
