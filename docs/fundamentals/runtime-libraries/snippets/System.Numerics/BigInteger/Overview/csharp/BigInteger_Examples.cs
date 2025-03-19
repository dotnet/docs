using System;
using System.Numerics;

public class Example
{
   public static void Main()
   {
      // <Snippet1>
      BigInteger bigIntFromDouble = new BigInteger(179032.6541);
      Console.WriteLine(bigIntFromDouble);
      BigInteger bigIntFromInt64 = new BigInteger(934157136952);
      Console.WriteLine(bigIntFromInt64);
      // The example displays the following output:
      //   179032
      //   934157136952		
      // </Snippet1>

      Console.WriteLine();

      // <Snippet2>
      long longValue = 6315489358112;
      BigInteger assignedFromLong = longValue;
      Console.WriteLine(assignedFromLong);
      // The example displays the following output:
      //   6315489358112
      // </Snippet2>

      Console.WriteLine();
      Console.WriteLine("Casting:");
      // <Snippet3>
      BigInteger assignedFromDouble = (BigInteger) 179032.6541;
      Console.WriteLine(assignedFromDouble);
      BigInteger assignedFromDecimal = (BigInteger) 64312.65m;
      Console.WriteLine(assignedFromDecimal);
      // The example displays the following output:
      //   179032
      //   64312
      // </Snippet3>

      Console.WriteLine();

      // <Snippet4>
      byte[] byteArray = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0};
      BigInteger newBigInt = new BigInteger(byteArray);
      Console.WriteLine("The value of newBigInt is {0} (or 0x{0:x}).", newBigInt);
      // The example displays the following output:
      //   The value of newBigInt is 4759477275222530853130 (or 0x102030405060708090a).
      // </Snippet4>

      Console.WriteLine();

      // <Snippet5>
      string positiveString = "91389681247993671255432112000000";
      string negativeString = "-90315837410896312071002088037140000";
      BigInteger posBigInt = 0;
      BigInteger negBigInt = 0;

      try {
         posBigInt = BigInteger.Parse(positiveString);
         Console.WriteLine(posBigInt);
      }
      catch (FormatException)
      {
         Console.WriteLine($"Unable to convert the string '{positiveString}' to a BigInteger value.");
      }

      if (BigInteger.TryParse(negativeString, out negBigInt))
        Console.WriteLine(negBigInt);
      else
         Console.WriteLine($"Unable to convert the string '{negativeString}' to a BigInteger value.");

      // The example displays the following output:
      //   9.1389681247993671255432112E+31
      //   -9.0315837410896312071002088037E+34
      // </Snippet5>

      Console.WriteLine();

     // <Snippet6>
      BigInteger number = BigInteger.Pow(UInt64.MaxValue, 3);
      Console.WriteLine(number);
      // The example displays the following output:
      //    6277101735386680762814942322444851025767571854389858533375
      // </Snippet6>
   }
}
