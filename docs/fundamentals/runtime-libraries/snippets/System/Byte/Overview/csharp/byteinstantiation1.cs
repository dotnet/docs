using System;

public class Example2
{
    public static void Main()
    {
        InstantiateByAssignment();
        InstantiateByNarrowingConversion();
        Parse();
    }

    private static void InstantiateByAssignment()
    {
        // <Snippet1>
        byte value1 = 64;
        byte value2 = 255;
        // </Snippet1>
        Console.WriteLine($"{value1}   {value2}");
    }

    private static void InstantiateByNarrowingConversion()
    {
        // <Snippet2>
        int int1 = 128;
        try
        {
            byte value1 = (byte)int1;
            Console.WriteLine(value1);
        }
        catch (OverflowException)
        {
            Console.WriteLine($"{int1} is out of range of a byte.");
        }

        double dbl2 = 3.997;
        try
        {
            byte value2 = (byte)dbl2;
            Console.WriteLine(value2);
        }
        catch (OverflowException)
        {
            Console.WriteLine($"{dbl2} is out of range of a byte.");
        }
        // The example displays the following output:
        //       128
        //       3
        // </Snippet2>
    }

    private static void Parse()
    {
        // <Snippet3>
        string string1 = "244";
        try
        {
            byte byte1 = Byte.Parse(string1);
            Console.WriteLine(byte1);
        }
        catch (OverflowException)
        {
            Console.WriteLine($"'{string1}' is out of range of a byte.");
        }
        catch (FormatException)
        {
            Console.WriteLine($"'{string1}' is out of range of a byte.");
        }

        string string2 = "F9";
        try
        {
            byte byte2 = Byte.Parse(string2,
                                    System.Globalization.NumberStyles.HexNumber);
            Console.WriteLine(byte2);
        }
        catch (OverflowException)
        {
            Console.WriteLine($"'{string2}' is out of range of a byte.");
        }
        catch (FormatException)
        {
            Console.WriteLine($"'{string2}' is out of range of a byte.");
        }
        // The example displays the following output:
        //       244
        //       249
        // </Snippet3>
    }
}
