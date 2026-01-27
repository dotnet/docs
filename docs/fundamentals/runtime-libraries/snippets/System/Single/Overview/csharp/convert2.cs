using System;

public class Example5
{
    public static void Main()
    {
        // <Snippet21>
        float[] values = { Single.MinValue, -67890.1234f, -12345.6789f,
                         12345.6789f, 67890.1234f, Single.MaxValue,
                         Single.NaN, Single.PositiveInfinity,
                         Single.NegativeInfinity };
        checked
        {
            foreach (var value in values)
            {
                try
                {
                    Int64 lValue = (long)value;
                    Console.WriteLine($"{value} ({value.GetType().Name}) --> {lValue} (0x{lValue:X16}) ({lValue.GetType().Name})");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"Unable to convert {value} to Int64.");
                }
                try
                {
                    UInt64 ulValue = (ulong)value;
                    Console.WriteLine($"{value} ({value.GetType().Name}) --> {ulValue} (0x{ulValue:X16}) ({ulValue.GetType().Name})");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"Unable to convert {value} to UInt64.");
                }
                try
                {
                    Decimal dValue = (decimal)value;
                    Console.WriteLine($"{value} ({value.GetType().Name}) --> {dValue} ({dValue.GetType().Name})");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"Unable to convert {value} to Decimal.");
                }

                Double dblValue = value;
                Console.WriteLine($"{value} ({value.GetType().Name}) --> {dblValue} ({dblValue.GetType().Name})");
                Console.WriteLine();
            }
        }

        // The example displays the following output for conversions performed
        // in a checked context:
        //       Unable to convert -3.402823E+38 to Int64.
        //       Unable to convert -3.402823E+38 to UInt64.
        //       Unable to convert -3.402823E+38 to Decimal.
        //       -3.402823E+38 (Single) --> -3.40282346638529E+38 (Double)
        //
        //       -67890.13 (Single) --> -67890 (0xFFFFFFFFFFFEF6CE) (Int64)
        //       Unable to convert -67890.13 to UInt64.
        //       -67890.13 (Single) --> -67890.12 (Decimal)
        //       -67890.13 (Single) --> -67890.125 (Double)
        //
        //       -12345.68 (Single) --> -12345 (0xFFFFFFFFFFFFCFC7) (Int64)
        //       Unable to convert -12345.68 to UInt64.
        //       -12345.68 (Single) --> -12345.68 (Decimal)
        //       -12345.68 (Single) --> -12345.6787109375 (Double)
        //
        //       12345.68 (Single) --> 12345 (0x0000000000003039) (Int64)
        //       12345.68 (Single) --> 12345 (0x0000000000003039) (UInt64)
        //       12345.68 (Single) --> 12345.68 (Decimal)
        //       12345.68 (Single) --> 12345.6787109375 (Double)
        //
        //       67890.13 (Single) --> 67890 (0x0000000000010932) (Int64)
        //       67890.13 (Single) --> 67890 (0x0000000000010932) (UInt64)
        //       67890.13 (Single) --> 67890.12 (Decimal)
        //       67890.13 (Single) --> 67890.125 (Double)
        //
        //       Unable to convert 3.402823E+38 to Int64.
        //       Unable to convert 3.402823E+38 to UInt64.
        //       Unable to convert 3.402823E+38 to Decimal.
        //       3.402823E+38 (Single) --> 3.40282346638529E+38 (Double)
        //
        //       Unable to convert NaN to Int64.
        //       Unable to convert NaN to UInt64.
        //       Unable to convert NaN to Decimal.
        //       NaN (Single) --> NaN (Double)
        //
        //       Unable to convert ∞ to Int64.
        //       Unable to convert ∞ to UInt64.
        //       Unable to convert ∞ to Decimal.
        //       ∞ (Single) --> ∞ (Double)
        //
        //       Unable to convert -∞ to Int64.
        //       Unable to convert -∞ to UInt64.
        //       Unable to convert -∞ to Decimal.
        //       -∞ (Single) --> -∞ (Double)
        // </Snippet21>
    }
}
