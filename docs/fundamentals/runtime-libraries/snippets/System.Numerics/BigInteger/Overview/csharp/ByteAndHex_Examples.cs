using System;
using System.Globalization;
using System.Numerics;

public class ByteHexExample
{
    public static void Main()
    {
        RoundtripBigInteger();
        Console.WriteLine();
        RoundtripInt16();
        Console.WriteLine();
        HandleSignsInByteArray();
        Console.WriteLine();
        RoundtripAmbiguous();
        Console.WriteLine();
        RoundtripWithHex();
    }

    private static void RoundtripBigInteger()
    {
        Console.WriteLine("Round-trip bytes");

        // <Snippet1>
        BigInteger number = BigInteger.Pow(Int64.MaxValue, 2);
        Console.WriteLine(number);

        // Write the BigInteger value to a byte array.
        byte[] bytes = number.ToByteArray();

        // Display the byte array.
        foreach (byte byteValue in bytes)
            Console.Write("0x{0:X2} ", byteValue);
        Console.WriteLine();

        // Restore the BigInteger value from a Byte array.
        BigInteger newNumber = new BigInteger(bytes);
        Console.WriteLine(newNumber);
        // The example displays the following output:
        //    8.5070591730234615847396907784E+37
        //    0x01 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0xFF 0xFF 0xFF 0xFF 0xFF 0xFF 0xFF 0x3F
        //
        //    8.5070591730234615847396907784E+37
        // </Snippet1>
    }

    private static void RoundtripInt16()
    {
        Console.WriteLine();
        Console.WriteLine("Round-trip an Int16 value:");
        // <Snippet2>
        short originalValue = 30000;
        Console.WriteLine(originalValue);

        // Convert the Int16 value to a byte array.
        byte[] bytes = BitConverter.GetBytes(originalValue);

        // Display the byte array.
        foreach (byte byteValue in bytes)
            Console.Write("0x{0} ", byteValue.ToString("X2"));
        Console.WriteLine();

        // Pass byte array to the BigInteger constructor.
        BigInteger number = new BigInteger(bytes);
        Console.WriteLine(number);
        // The example displays the following output:
        //       30000
        //       0x30 0x75
        //       30000
        // </Snippet2>
    }

    private static void HandleSignsInByteArray()
    {
        // <Snippet3>
        int negativeNumber = -1000000;
        uint positiveNumber = 4293967296;

        byte[] negativeBytes = BitConverter.GetBytes(negativeNumber);
        BigInteger negativeBigInt = new BigInteger(negativeBytes);
        Console.WriteLine(negativeBigInt.ToString("N0"));

        byte[] tempPosBytes = BitConverter.GetBytes(positiveNumber);
        byte[] positiveBytes = new byte[tempPosBytes.Length + 1];
        Array.Copy(tempPosBytes, positiveBytes, tempPosBytes.Length);
        BigInteger positiveBigInt = new BigInteger(positiveBytes);
        Console.WriteLine(positiveBigInt.ToString("N0"));
        // The example displays the following output:
        //    -1,000,000
        //    4,293,967,296
        // </Snippet3>
    }

    private static void RoundtripAmbiguous()
    {
        Console.WriteLine("Round-trip an Ambiguous Value:");
        // <Snippet4>
        BigInteger positiveValue = 15777216;
        BigInteger negativeValue = -1000000;

        Console.WriteLine("Positive value: " + positiveValue.ToString("N0"));
        byte[] bytes = positiveValue.ToByteArray();

        foreach (byte byteValue in bytes)
            Console.Write("{0:X2} ", byteValue);
        Console.WriteLine();
        positiveValue = new BigInteger(bytes);
        Console.WriteLine("Restored positive value: " + positiveValue.ToString("N0"));

        Console.WriteLine();

        Console.WriteLine("Negative value: " + negativeValue.ToString("N0"));
        bytes = negativeValue.ToByteArray();
        foreach (byte byteValue in bytes)
            Console.Write("{0:X2} ", byteValue);
        Console.WriteLine();
        negativeValue = new BigInteger(bytes);
        Console.WriteLine("Restored negative value: " + negativeValue.ToString("N0"));
        // The example displays the following output:
        //       Positive value: 15,777,216
        //       C0 BD F0 00
        //       Restored positive value: 15,777,216
        //
        //       Negative value: -1,000,000
        //       C0 BD F0
        //       Restored negative value: -1,000,000
        // </Snippet4>
    }

    private static void RoundtripWithHex()
    {
        // <Snippet5>
        BigInteger negativeNumber = -1000000;
        BigInteger positiveNumber = 15777216;

        string negativeHex = negativeNumber.ToString("X");
        string positiveHex = positiveNumber.ToString("X");

        BigInteger negativeNumber2, positiveNumber2;
        negativeNumber2 = BigInteger.Parse(negativeHex,
                                           NumberStyles.HexNumber);
        positiveNumber2 = BigInteger.Parse(positiveHex,
                                           NumberStyles.HexNumber);

        Console.WriteLine($"Converted {negativeNumber:N0} to {negativeHex} back to {negativeNumber2:N0}.");
        Console.WriteLine($"Converted {positiveNumber:N0} to {positiveHex} back to {positiveNumber2:N0}.");
        // The example displays the following output:
        //       Converted -1,000,000 to F0BDC0 back to -1,000,000.
        //       Converted 15,777,216 to 0F0BDC0 back to 15,777,216.
        // </Snippet5>
    }
}
