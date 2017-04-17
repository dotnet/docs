using System;
using System.Globalization;
using System.Numerics;

public class Example
{
   public static void Main()
   {
      ToStringDft();
      Console.WriteLine("-----");
      RoundtripValue();
      Console.WriteLine("-----");
      ToFormattedString();
      Console.WriteLine("-----");
      FormatStringWithProvider();
   }

   private static void ToStringDft()
   {
      // <Snippet1>
      // Initialize a BigInteger value.
      BigInteger value = BigInteger.Add(UInt64.MaxValue, 1024);

      // Display value using the default ToString method.
      Console.WriteLine(value.ToString());     
      // Display value using some standard format specifiers.
      Console.WriteLine(value.ToString("G"));
      Console.WriteLine(value.ToString("C"));
      Console.WriteLine(value.ToString("D"));
      Console.WriteLine(value.ToString("F"));
      Console.WriteLine(value.ToString("N"));
      Console.WriteLine(value.ToString("X"));       
      // The example displays the following output on a system whose current 
      // culture is en-US:
      //       18446744073709552639
      //       18446744073709552639
      //       $18,446,744,073,709,552,639.00
      //       18446744073709552639
      //       18446744073709552639.00
      //       18,446,744,073,709,552,639.00
      //       100000000000003FF      
      // </Snippet1>
   }

   private static void RoundtripValue()
   {
      // <Snippet2>
      // Create number with 50+ digits and store it to two strings.
      BigInteger originalNumber = BigInteger.Pow(UInt64.MaxValue, Byte.MaxValue);
      string generalString = originalNumber.ToString("G");
      string roundTripString = originalNumber.ToString("R");
      Console.WriteLine("The original value has {0} hexadecmal digits.\n", 
                        originalNumber.ToString("X").Length);
      
      // Attempt to round-trip strings and compare them with the original.
      Console.WriteLine("Parsing the string formatted with the 'G' format string.");
      BigInteger generalBigInteger = BigInteger.Parse(generalString, 
                                     NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint);
      if (originalNumber.Equals(generalBigInteger))
         Console.WriteLine("The values are equal. No data has been lost.\n");
      else            
         Console.WriteLine("The values are not equal. Data has been lost.\n");
      
      Console.WriteLine("Parsing the string formatted with the 'R' format string.");
      BigInteger roundTripBigInteger = BigInteger.Parse(roundTripString);
      if (originalNumber.Equals(roundTripBigInteger))
         Console.WriteLine("The values are equal. No data has been lost.\n");
      else            
         Console.WriteLine("The values are not equal. Data has been lost.\n");
      // The example displays the following output:
      //       The original value has 4080 hexadecmal digits.
      //       
      //       Parsing the string formatted with the 'G' format string.
      //       The values are not equal. Data has been lost.
      //       
      //       Parsing the string formatted with the 'R' format string.
      //       The values are equal. No data has been lost.            
      // </Snippet2>
   }

   private static void ToFormattedString()
   {
      // <Snippet3>
      BigInteger value = BigInteger.Parse("-903145792771643190182");
      string[] specifiers = { "C", "D", "D25", "E", "E4", "e8", "F0", 
                              "G", "N0", "P", "R", "X", "0,0.000", 
                              "#,#.00#;(#,#.00#)" };
      
      foreach (string specifier in specifiers)
         Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));

      // The example displays the following output:
      //       C: ($903,145,792,771,643,190,182.00)
      //       D: -903145792771643190182
      //       D25: -0000903145792771643190182
      //       E: -9.031457E+020
      //       E4: -9.0314E+020
      //       e8: -9.03145792e+020
      //       F0: -903145792771643190182
      //       G: -903145792771643190182
      //       N0: -903,145,792,771,643,190,182
      //       P: -90,314,579,277,164,319,018,200.00 %
      //       R: -903145792771643190182
      //       X: CF0A55968BB1A7545A
      //       0,0.000: -903,145,792,771,643,190,182.000
      //       #,#.00#;(#,#.00#): (903,145,792,771,643,190,182.00)
      // </Snippet3>      
   }

   private static void FormatStringWithProvider()
   {
      // <Snippet4>
      // Redefine the negative sign as the tilde for the invariant culture.
      NumberFormatInfo bigIntegerFormatter = new NumberFormatInfo();
      bigIntegerFormatter.NegativeSign = "~";

      BigInteger value = BigInteger.Parse("-903145792771643190182");
      string[] specifiers = { "C", "D", "D25", "E", "E4", "e8", "F0", 
                              "G", "N0", "P", "R", "X", "0,0.000", 
                              "#,#.00#;(#,#.00#)" };
      
      foreach (string specifier in specifiers)
         Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier, 
                           bigIntegerFormatter));

      // The example displays the following output:
      //    C: (☼903,145,792,771,643,190,182.00)
      //    D: ~903145792771643190182
      //    D25: ~0000903145792771643190182
      //    E: ~9.031457E+020
      //    E4: ~9.0314E+020
      //    e8: ~9.03145792e+020
      //    F0: ~903145792771643190182
      //    G: ~903145792771643190182
      //    N0: ~903,145,792,771,643,190,182
      //    P: ~90,314,579,277,164,319,018,200.00 %
      //    R: ~903145792771643190182
      //    X: CF0A55968BB1A7545A
      //    0,0.000: ~903,145,792,771,643,190,182.000
      //    #,#.00#;(#,#.00#): (903,145,792,771,643,190,182.00)
      // </Snippet4>      
   } 
}
