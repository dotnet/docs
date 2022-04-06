using System;

public class Example
{
    public static void Main()
    {
        PerformConversions();
        Console.WriteLine("-----");
        LosePrecision();
    }

    private static void PerformConversions()
    {
        // <Snippet8>
        // Convert an Int32 value to a Decimal (a widening conversion).
        int integralValue = 12534;
        decimal decimalValue = Convert.ToDecimal(integralValue);
        Console.WriteLine("Converted the {0} value {1} to " +
                                          "the {2} value {3:N2}.",
                                          integralValue.GetType().Name,
                                          integralValue,
                                          decimalValue.GetType().Name,
                                          decimalValue);
        // Convert a Byte value to an Int32 value (a widening conversion).
        byte byteValue = Byte.MaxValue;
        int integralValue2 = Convert.ToInt32(byteValue);
        Console.WriteLine("Converted the {0} value {1} to " +
                                          "the {2} value {3:G}.",
                                          byteValue.GetType().Name,
                                          byteValue,
                                          integralValue2.GetType().Name,
                                          integralValue2);

        // Convert a Double value to an Int32 value (a narrowing conversion).
        double doubleValue = 16.32513e12;
        try
        {
            long longValue = Convert.ToInt64(doubleValue);
            Console.WriteLine("Converted the {0} value {1:E} to " +
                                              "the {2} value {3:N0}.",
                                              doubleValue.GetType().Name,
                                              doubleValue,
                                              longValue.GetType().Name,
                                              longValue);
        }
        catch (OverflowException)
        {
            Console.WriteLine("Unable to convert the {0:E} value {1}.",
                                              doubleValue.GetType().Name, doubleValue);
        }

        // Convert a signed byte to a byte (a narrowing conversion).
        sbyte sbyteValue = -16;
        try
        {
            byte byteValue2 = Convert.ToByte(sbyteValue);
            Console.WriteLine("Converted the {0} value {1} to " +
                                              "the {2} value {3:G}.",
                                              sbyteValue.GetType().Name,
                                              sbyteValue,
                                              byteValue2.GetType().Name,
                                              byteValue2);
        }
        catch (OverflowException)
        {
            Console.WriteLine("Unable to convert the {0} value {1}.",
                                              sbyteValue.GetType().Name, sbyteValue);
        }
        // The example displays the following output:
        //       Converted the Int32 value 12534 to the Decimal value 12,534.00.
        //       Converted the Byte value 255 to the Int32 value 255.
        //       Converted the Double value 1.632513E+013 to the Int64 value 16,325,130,000,000.
        //       Unable to convert the SByte value -16.
        // </Snippet8>
    }

    private static void LosePrecision()
    {
        // <Snippet9>
        double doubleValue;

        // Convert a Double to a Decimal.
        decimal decimalValue = 13956810.96702888123451471211m;
        doubleValue = Convert.ToDouble(decimalValue);
        Console.WriteLine("{0} converted to {1}.", decimalValue, doubleValue);

        doubleValue = 42.72;
        try
        {
            int integerValue = Convert.ToInt32(doubleValue);
            Console.WriteLine("{0} converted to {1}.",
                                              doubleValue, integerValue);
        }
        catch (OverflowException)
        {
            Console.WriteLine("Unable to convert {0} to an integer.",
                                              doubleValue);
        }
        // The example displays the following output:
        //       13956810.96702888123451471211 converted to 13956810.9670289.
        //       42.72 converted to 43.
        // </Snippet9>
    }
}
