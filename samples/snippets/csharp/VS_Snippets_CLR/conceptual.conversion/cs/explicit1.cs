using System;

public class Example2
{
    public static void Main()
    {
        PerformIntegerConversion();
        Console.WriteLine("-----");
        PerformCustomConversion();
        Console.WriteLine("-----");
        CheckedAndUnchecked();
    }

    private static void PerformIntegerConversion()
    {
        // <Snippet4>
        long number1 = int.MaxValue + 20L;
        uint number2 = int.MaxValue - 1000;
        ulong number3 = int.MaxValue;

        int intNumber;

        try
        {
            intNumber = checked((int)number1);
            Console.WriteLine("After assigning a {0} value, the Integer value is {1}.",
                              number1.GetType().Name, intNumber);
        }
        catch (OverflowException)
        {
            if (number1 > int.MaxValue)
                Console.WriteLine("Conversion failed: {0} exceeds {1}.",
                                  number1, int.MaxValue);
            else
                Console.WriteLine("Conversion failed: {0} is less than {1}.",
                                  number1, int.MinValue);
        }

        try
        {
            intNumber = checked((int)number2);
            Console.WriteLine("After assigning a {0} value, the Integer value is {1}.",
                              number2.GetType().Name, intNumber);
        }
        catch (OverflowException)
        {
            Console.WriteLine("Conversion failed: {0} exceeds {1}.",
                              number2, int.MaxValue);
        }

        try
        {
            intNumber = checked((int)number3);
            Console.WriteLine("After assigning a {0} value, the Integer value is {1}.",
                              number3.GetType().Name, intNumber);
        }
        catch (OverflowException)
        {
            Console.WriteLine("Conversion failed: {0} exceeds {1}.",
                              number1, int.MaxValue);
        }

        // The example displays the following output:
        //    Conversion failed: 2147483667 exceeds 2147483647.
        //    After assigning a UInt32 value, the Integer value is 2147482647.
        //    After assigning a UInt64 value, the Integer value is 2147483647.
        // </Snippet4>
    }

    private static void PerformCustomConversion()
    {
        // <Snippet6>
        ByteWithSignE value;

        try
        {
            int intValue = -120;
            value = (ByteWithSignE)intValue;
            Console.WriteLine(value);
        }
        catch (OverflowException e)
        {
            Console.WriteLine(e.Message);
        }

        try
        {
            uint uintValue = 1024;
            value = (ByteWithSignE)uintValue;
            Console.WriteLine(value);
        }
        catch (OverflowException e)
        {
            Console.WriteLine(e.Message);
        }
        // The example displays the following output:
        //       -120
        //       '1024' is out of range of the ByteWithSignE data type.
        // </Snippet6>
    }

    private static void CheckedAndUnchecked()
    {
        // <Snippet12>
        int largeValue = Int32.MaxValue;
        byte newValue;

        try
        {
            newValue = unchecked((byte)largeValue);
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              largeValue.GetType().Name, largeValue,
                              newValue.GetType().Name, newValue);
        }
        catch (OverflowException)
        {
            Console.WriteLine("{0} is outside the range of the Byte data type.",
                              largeValue);
        }

        try
        {
            newValue = checked((byte)largeValue);
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              largeValue.GetType().Name, largeValue,
                              newValue.GetType().Name, newValue);
        }
        catch (OverflowException)
        {
            Console.WriteLine("{0} is outside the range of the Byte data type.",
                              largeValue);
        }
        // The example displays the following output:
        //    Converted the Int32 value 2147483647 to the Byte value 255.
        //    2147483647 is outside the range of the Byte data type.
        // </Snippet12>
    }
}

// <Snippet5>
public struct ByteWithSignE
{
    private SByte signValue;
    private Byte value;

    private const byte MaxValue = byte.MaxValue;
    private const int MinValue = -1 * byte.MaxValue;

    public static explicit operator ByteWithSignE(int value)
    {
        // Check for overflow.
        if (value > ByteWithSignE.MaxValue || value < ByteWithSignE.MinValue)
            throw new OverflowException(String.Format("'{0}' is out of range of the ByteWithSignE data type.",
                                                      value));

        ByteWithSignE newValue;
        newValue.signValue = (SByte)Math.Sign(value);
        newValue.value = (byte)Math.Abs(value);
        return newValue;
    }

    public static explicit operator ByteWithSignE(uint value)
    {
        if (value > ByteWithSignE.MaxValue)
            throw new OverflowException(String.Format("'{0}' is out of range of the ByteWithSignE data type.",
                                                      value));

        ByteWithSignE newValue;
        newValue.signValue = 1;
        newValue.value = (byte)value;
        return newValue;
    }

    public override string ToString()
    {
        return (signValue * value).ToString();
    }
}
// </Snippet5>
