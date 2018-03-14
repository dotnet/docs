using System;

public class Example
{
   public static void Main()
   {
      PadInteger();
      Console.WriteLine("-----");
      PadIntegerWithNZeroes();
      Console.WriteLine("-----");
      PadNumber();
      Console.WriteLine("-----");
      PadNumberWithNZeroes();
   }

   private static void PadInteger()
   {
      // <Snippet1>
      byte byteValue = 254;
      short shortValue = 10342;
      int intValue = 1023983;
      long lngValue = 6985321;               
      ulong ulngValue = UInt64.MaxValue;
      
      // Display integer values by calling the ToString method.
      Console.WriteLine("{0,22} {1,22}", byteValue.ToString("D8"), byteValue.ToString("X8"));
      Console.WriteLine("{0,22} {1,22}", shortValue.ToString("D8"), shortValue.ToString("X8"));
      Console.WriteLine("{0,22} {1,22}", intValue.ToString("D8"), intValue.ToString("X8"));
      Console.WriteLine("{0,22} {1,22}", lngValue.ToString("D8"), lngValue.ToString("X8"));
      Console.WriteLine("{0,22} {1,22}", ulngValue.ToString("D8"), ulngValue.ToString("X8"));
      Console.WriteLine();
      
      // Display the same integer values by using composite formatting.
      Console.WriteLine("{0,22:D8} {0,22:X8}", byteValue);
      Console.WriteLine("{0,22:D8} {0,22:X8}", shortValue);
      Console.WriteLine("{0,22:D8} {0,22:X8}", intValue);
      Console.WriteLine("{0,22:D8} {0,22:X8}", lngValue);
      Console.WriteLine("{0,22:D8} {0,22:X8}", ulngValue);
      // The example displays the following output:
      //                     00000254               000000FE
      //                     00010342               00002866
      //                     01023983               000F9FEF
      //                     06985321               006A9669
      //         18446744073709551615       FFFFFFFFFFFFFFFF
      //       
      //                     00000254               000000FE
      //                     00010342               00002866
      //                     01023983               000F9FEF
      //                     06985321               006A9669
      //         18446744073709551615       FFFFFFFFFFFFFFFF
      //         18446744073709551615       FFFFFFFFFFFFFFFF
      // </Snippet1>
   }

   private static void PadIntegerWithNZeroes()
   {
      // <Snippet2>
      int value = 160934;
      int decimalLength = value.ToString("D").Length + 5;
      int hexLength = value.ToString("X").Length + 5;
      Console.WriteLine(value.ToString("D" + decimalLength.ToString()));
      Console.WriteLine(value.ToString("X" + hexLength.ToString()));
      // The example displays the following output:
      //       00000160934
      //       00000274A6      
      // </Snippet2>
   }

   private static void PadNumber()
   {
      // <Snippet3>
      string fmt = "00000000.##";
      int intValue = 1053240;
      decimal decValue = 103932.52m;
      float sngValue = 1549230.10873992f;
      double dblValue = 9034521202.93217412;
      
      // Display the numbers using the ToString method.
      Console.WriteLine(intValue.ToString(fmt));
      Console.WriteLine(decValue.ToString(fmt));           
      Console.WriteLine(sngValue.ToString(fmt));
      Console.WriteLine(dblValue.ToString(fmt));           
      Console.WriteLine();
      
      // Display the numbers using composite formatting.
      string formatString = " {0,15:" + fmt + "}";
      Console.WriteLine(formatString, intValue);      
      Console.WriteLine(formatString, decValue);      
      Console.WriteLine(formatString, sngValue);      
      Console.WriteLine(formatString, dblValue);      
      // The example displays the following output:
      //       01053240
      //       00103932.52
      //       01549230
      //       9034521202.93
      //       
      //               01053240
      //            00103932.52
      //               01549230
      //          9034521202.93      
      // </Snippet3>
   }
   
   private static void PadNumberWithNZeroes()
   {
      // <Snippet4>
      double[] dblValues = { 9034521202.93217412, 9034521202 };
      foreach (double dblValue in dblValues)
      {
         string decSeparator = System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
         string fmt, formatString;
         
         if (dblValue.ToString().Contains(decSeparator))
         {
            int digits = dblValue.ToString().IndexOf(decSeparator);
            fmt = new String('0', 5) + new String('#', digits) + ".##";
         }
         else
         {
            fmt = new String('0', dblValue.ToString().Length);   
         }
         formatString = "{0,20:" + fmt + "}";

         Console.WriteLine(dblValue.ToString(fmt));
         Console.WriteLine(formatString, dblValue);
      }
      // The example displays the following output:
      //       000009034521202.93
      //         000009034521202.93
      //       9034521202
      //                 9034521202            
      // </Snippet4>
   }
}
