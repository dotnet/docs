using System;

public class Example3
{
    public static void Main()
    {
        ConvertBoolean();
        Console.WriteLine("-----");
        ConvertChar();
        Console.WriteLine("-----");
        ConvertInt16();
        Console.WriteLine("-----");
        ConvertInt32();
        Console.WriteLine("-----");
        ConvertInt64();
        Console.WriteLine("-----");
        ConvertObject();
        Console.WriteLine("-----");
        ConvertSByte();
        Console.WriteLine("-----");
        ConvertUInt16();
        Console.WriteLine("-----");
        ConvertUInt32();
        Console.WriteLine("-----");
        ConvertUInt64();
    }
    private static void ConvertBoolean()
    {
        // <Snippet1>
        bool falseFlag = false;
        bool trueFlag = true;

        Console.WriteLine("{0} converts to {1}.", falseFlag,
                          Convert.ToByte(falseFlag));
        Console.WriteLine("{0} converts to {1}.", trueFlag,
                          Convert.ToByte(trueFlag));
        // The example displays the following output:
        //       False converts to 0.
        //       True converts to 1.
        // </Snippet1>
    }

    private static void ConvertChar()
    {
        // <Snippet2>
        char[] chars = { 'a', 'z', '\x0007', '\x03FF' };
        foreach (char ch in chars)
        {
            try
            {
                byte result = Convert.ToByte(ch);
                Console.WriteLine($"{ch} is converted to {result}.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Unable to convert u+{0} to a byte.",
                                  Convert.ToInt16(ch).ToString("X4"));
            }
        }
        // The example displays the following output:
        //       a is converted to 97.
        //       z is converted to 122.
        //        is converted to 7.
        //       Unable to convert u+03FF to a byte.
        // </Snippet2>
    }

    private static void ConvertInt16()
    {
        // <Snippet3>
        short[] numbers = { Int16.MinValue, -1, 0, 121, 340, Int16.MaxValue };
        byte result;
        foreach (short number in numbers)
        {
            try
            {
                result = Convert.ToByte(number);
                Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                                  number.GetType().Name, number,
                                  result.GetType().Name, result);
            }
            catch (OverflowException)
            {
                Console.WriteLine("The {0} value {1} is outside the range of the Byte type.",
                                  number.GetType().Name, number);
            }
        }
        // The example displays the following output:
        //       The Int16 value -32768 is outside the range of the Byte type.
        //       The Int16 value -1 is outside the range of the Byte type.
        //       Converted the Int16 value 0 to the Byte value 0.
        //       Converted the Int16 value 121 to the Byte value 121.
        //       The Int16 value 340 is outside the range of the Byte type.
        //       The Int16 value 32767 is outside the range of the Byte type.
        // </Snippet3>
    }

    private static void ConvertInt32()
    {
        // <Snippet4>
        int[] numbers = { Int32.MinValue, -1, 0, 121, 340, Int32.MaxValue };
        byte result;
        foreach (int number in numbers)
        {
            try
            {
                result = Convert.ToByte(number);
                Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                                  number.GetType().Name, number,
                                  result.GetType().Name, result);
            }
            catch (OverflowException)
            {
                Console.WriteLine("The {0} value {1} is outside the range of the Byte type.",
                                  number.GetType().Name, number);
            }
        }
        // The example displays the following output:
        //       The Int32 value -2147483648 is outside the range of the Byte type.
        //       The Int32 value -1 is outside the range of the Byte type.
        //       Converted the Int32 value 0 to the Byte value 0.
        //       Converted the Int32 value 121 to the Byte value 121.
        //       The Int32 value 340 is outside the range of the Byte type.
        //       The Int32 value 2147483647 is outside the range of the Byte type.
        // </Snippet4>
    }

    private static void ConvertInt64()
    {
        // <Snippet5>
        long[] numbers = { Int64.MinValue, -1, 0, 121, 340, Int64.MaxValue };
        byte result;
        foreach (long number in numbers)
        {
            try
            {
                result = Convert.ToByte(number);
                Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                                  number.GetType().Name, number,
                                  result.GetType().Name, result);
            }
            catch (OverflowException)
            {
                Console.WriteLine("The {0} value {1} is outside the range of the Byte type.",
                                  number.GetType().Name, number);
            }
        }
        // The example displays the following output:
        //       The Int64 value -9223372036854775808 is outside the range of the Byte type.
        //       The Int64 value -1 is outside the range of the Byte type.
        //       Converted the Int64 value 0 to the Byte value 0.
        //       Converted the Int64 value 121 to the Byte value 121.
        //       The Int64 value 340 is outside the range of the Byte type.
        //       The Int64 value 9223372036854775807 is outside the range of the Byte type.
        // </Snippet5>
    }

    private static void ConvertObject()
    {
        // <Snippet6>
        object[] values = { true, -12, 163, 935, 'x', "104", "103.0", "-1",
                          "1.00e2", "One", 1.00e2};
        byte result;
        foreach (object value in values)
        {
            try
            {
                result = Convert.ToByte(value);
                Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                                  value.GetType().Name, value,
                                  result.GetType().Name, result);
            }
            catch (OverflowException)
            {
                Console.WriteLine("The {0} value {1} is outside the range of the Byte type.",
                                  value.GetType().Name, value);
            }
            catch (FormatException)
            {
                Console.WriteLine("The {0} value {1} is not in a recognizable format.",
                                  value.GetType().Name, value);
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("No conversion to a Byte exists for the {0} value {1}.",
                                  value.GetType().Name, value);
            }
        }
        // The example displays the following output:
        //       Converted the Boolean value True to the Byte value 1.
        //       The Int32 value -12 is outside the range of the Byte type.
        //       Converted the Int32 value 163 to the Byte value 163.
        //       The Int32 value 935 is outside the range of the Byte type.
        //       Converted the Char value x to the Byte value 120.
        //       Converted the String value 104 to the Byte value 104.
        //       The String value 103.0 is not in a recognizable format.
        //       The String value -1 is outside the range of the Byte type.
        //       The String value 1.00e2 is not in a recognizable format.
        //       The String value One is not in a recognizable format.
        //       Converted the Double value 100 to the Byte value 100.
        // </Snippet6>
    }

    private static void ConvertSByte()
    {
        // <Snippet7>
        sbyte[] numbers = { SByte.MinValue, -1, 0, 10, SByte.MaxValue };
        byte result;
        foreach (sbyte number in numbers)
        {
            try
            {
                result = Convert.ToByte(number);
                Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                                  number.GetType().Name, number,
                                  result.GetType().Name, result);
            }
            catch (OverflowException)
            {
                Console.WriteLine("The {0} value {1} is outside the range of the Byte type.",
                                  number.GetType().Name, number);
            }
        }
        // The example displays the following output:
        //       The SByte value -128 is outside the range of the Byte type.
        //       The SByte value -1 is outside the range of the Byte type.
        //       Converted the SByte value 0 to the Byte value 0.
        //       Converted the SByte value 10 to the Byte value 10.
        //       Converted the SByte value 127 to the Byte value 127.
        // </Snippet7>
    }

    private static void ConvertUInt16()
    {
        // <Snippet8>
        ushort[] numbers = { UInt16.MinValue, 121, 340, UInt16.MaxValue };
        byte result;
        foreach (ushort number in numbers)
        {
            try
            {
                result = Convert.ToByte(number);
                Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                                  number.GetType().Name, number,
                                  result.GetType().Name, result);
            }
            catch (OverflowException)
            {
                Console.WriteLine("The {0} value {1} is outside the range of the Byte type.",
                                  number.GetType().Name, number);
            }
        }
        // The example displays the following output:
        //       Converted the UInt16 value 0 to the Byte value 0.
        //       Converted the UInt16 value 121 to the Byte value 121.
        //       The UInt16 value 340 is outside the range of the Byte type.
        //       The UInt16 value 65535 is outside the range of the Byte type.
        // </Snippet8>
    }

    private static void ConvertUInt32()
    {
        // <Snippet9>
        uint[] numbers = { UInt32.MinValue, 121, 340, UInt32.MaxValue };
        byte result;
        foreach (uint number in numbers)
        {
            try
            {
                result = Convert.ToByte(number);
                Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                                  number.GetType().Name, number,
                                  result.GetType().Name, result);
            }
            catch (OverflowException)
            {
                Console.WriteLine("The {0} value {1} is outside the range of the Byte type.",
                                  number.GetType().Name, number);
            }
        }
        // The example displays the following output:
        //       Converted the UInt32 value 0 to the Byte value 0.
        //       Converted the UInt32 value 121 to the Byte value 121.
        //       The UInt32 value 340 is outside the range of the Byte type.
        //       The UInt32 value 4294967295 is outside the range of the Byte type.
        // </Snippet9>
    }

    private static void ConvertUInt64()
    {
        // <Snippet10>
        ulong[] numbers = { UInt64.MinValue, 121, 340, UInt64.MaxValue };
        byte result;
        foreach (ulong number in numbers)
        {
            try
            {
                result = Convert.ToByte(number);
                Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                                  number.GetType().Name, number,
                                  result.GetType().Name, result);
            }
            catch (OverflowException)
            {
                Console.WriteLine("The {0} value {1} is outside the range of the Byte type.",
                                  number.GetType().Name, number);
            }
        }
        // The example displays the following output:
        //       Converted the UInt64 value 0 to the Byte value 0.
        //       Converted the UInt64 value 121 to the Byte value 121.
        //       The UInt64 value 340 is outside the range of the Byte type.
        //       The UInt64 value 18446744073709551615 is outside the range of the Byte type.
        // </Snippet10>
    }
}
