public class Example
{
   public static void Main()
   {
      Console.WindowWidth = 100;
      
      byte byteValue = 124;
      Console.WriteLine(String.Format(new BinaryFormatter(), 
                                      "{0} (binary: {0:B}) (hex: {0:H})", byteValue));
      
      int intValue = 23045;
      Console.WriteLine(String.Format(new BinaryFormatter(), 
                                      "{0} (binary: {0:B}) (hex: {0:H})", intValue));
      
      ulong ulngValue = 31906574882;
      Console.WriteLine(String.Format(new BinaryFormatter(), 
                                      "{0}\n   (binary: {0:B})\n   (hex: {0:H})", 
                                      ulngValue));

      BigInteger bigIntValue = BigInteger.Multiply(Int64.MaxValue, 2);
      Console.WriteLine(String.Format(new BinaryFormatter(), 
                                      "{0}\n   (binary: {0:B})\n   (hex: {0:H})", 
                                      bigIntValue));
   }
}
// The example displays the following output:
//    124 (binary: 01111100) (hex: 7c)
//    23045 (binary: 00000000 00000000 01011010 00000101) (hex: 00 00 5a 05)
//    31906574882
//       (binary: 00000000 00000000 00000000 00000111 01101101 11000111 10110010 00100010)
//       (hex: 00 00 00 07 6d c7 b2 22)
//    18446744073709551614
//       (binary: 00000000 11111111 11111111 11111111 11111111 11111111 11111111 11111111 11111110)
//       (hex: 00 ff ff ff ff ff ff ff fe)