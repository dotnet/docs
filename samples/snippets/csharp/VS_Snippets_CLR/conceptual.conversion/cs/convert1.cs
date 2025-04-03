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
        Console.WriteLine($"Converted the {integralValue.GetType().Name} value {integralValue} to " +
                                          "the {decimalValue.GetType().Name} value {decimalValue:N2}.");
        // Convert a Byte value to an Int32 value (a widening conversion).
        byte byteValue = Byte.MaxValue;
        int integralValue2 = Convert.ToInt32(byteValue);
        Console.WriteLine($"Converted the {byteValue.GetType().Name} value {byteValue} to " +
                                          "the {integralValue2.GetType().Name} value {integralValue2:G}.");

        // Convert a Double value to an Int32 value (a narrowing conversion).
        double doubleValue = 16.32513e12;
        try
        {
            long longValue = Convert.ToInt64(doubleValue);
            Console.WriteLine($"Converted the {doubleValue.GetType().Name} value {doubleValue:E} to " +
                                              "the {longValue.GetType().Name} value {longValue:N0}.");
        }
        catch (OverflowException)
        {
            Console.WriteLine($"Unable to convert the {doubleValue.GetType().Name:E} value {doubleValue}.");
        }

        // Convert a signed byte to a byte (a narrowing conversion).
        sbyte sbyteValue = -16;
        try
        {
            byte byteValue2 = Convert.ToByte(sbyteValue);
            Console.WriteLine($"Converted the {sbyteValue.GetType().Name} value {sbyteValue} to " +
                                              "the {byteValue2.GetType().Name} value {byteValue2:G}.");
        }
        catch (OverflowException)
        {
            Console.WriteLine($"Unable to convert the {sbyteValue.GetType().Name} value {sbyteValue}.");
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
        Console.WriteLine($"{decimalValue} converted to {doubleValue}.");

        doubleValue = 42.72;
        try
        {
            int integerValue = Convert.ToInt32(doubleValue);
            Console.WriteLine($"{doubleValue} converted to {integerValue}.");
        }
        catch (OverflowException)
        {
            Console.WriteLine($"Unable to convert {doubleValue} to an integer.");
        }
        // The example displays the following output:
        //       13956810.96702888123451471211 converted to 13956810.9670289.
        //       42.72 converted to 43.
        // </Snippet9>
    }
}
