// <Snippet6>
using System;
using System.Globalization;
using System.Numerics;

public struct HexValue
{
    public int Sign;
    public string Value;
}

public class ByteHexExample2
{
    public static void Main()
    {
        uint positiveNumber = 4039543321;
        int negativeNumber = -255423975;

        // Convert the numbers to hex strings.
        HexValue hexValue1, hexValue2;
        hexValue1.Value = positiveNumber.ToString("X");
        hexValue1.Sign = Math.Sign(positiveNumber);

        hexValue2.Value = Convert.ToString(negativeNumber, 16);
        hexValue2.Sign = Math.Sign(negativeNumber);

        // Round-trip the hexadecimal values to BigInteger values.
        string hexString;
        BigInteger positiveBigInt, negativeBigInt;

        hexString = (hexValue1.Sign == 1 ? "0" : "") + hexValue1.Value;
        positiveBigInt = BigInteger.Parse(hexString, NumberStyles.HexNumber);
        Console.WriteLine($"Converted {positiveNumber} to {hexValue1.Value} and back to {positiveBigInt}.");

        hexString = (hexValue2.Sign == 1 ? "0" : "") + hexValue2.Value;
        negativeBigInt = BigInteger.Parse(hexString, NumberStyles.HexNumber);
        Console.WriteLine($"Converted {negativeNumber} to {hexValue2.Value} and back to {negativeBigInt}.");
    }
}
// The example displays the following output:
//       Converted 4039543321 to F0C68A19 and back to 4039543321.
//       Converted -255423975 to f0c68a19 and back to -255423975.
// </Snippet6>
