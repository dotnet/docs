using System;

public class Example
{
   public static void Main()
   {
      ConvertDateTimeWithProvider();
      Console.WriteLine("-----");
      ConvertDecimalWithProvider();
      Console.WriteLine("-----");
      ConvertDoubleWithProvider();
      Console.WriteLine();
      ConvertByteWithProvider();
      Console.WriteLine();
      ConvertSByteWithProvider();
      Console.WriteLine("-----");
      ConvertSingleWithProvider();
      Console.WriteLine("-----");
      ConvertInt16WithProvider();
      Console.WriteLine("-----");
      ConvertInt32WithProvider();
      Console.WriteLine("-----");
      ConvertInt64WithProvider();
      ConvertUInt16WithProvider();
      Console.WriteLine("-----");
      ConvertUInt32WithProvider();
      Console.WriteLine("-----");
      ConvertUInt64WithProvider();      
   }

   private static void ConvertDateTimeWithProvider()
   {
      // <Snippet13>
      // Specify the date to be formatted using various cultures.
      DateTime tDate = new DateTime(2010, 4, 15, 20, 30, 40, 333);
      // Specify the cultures.
      string[] cultureNames = { "en-US", "es-AR", "fr-FR", "hi-IN",
                                "ja-JP", "nl-NL", "ru-RU", "ur-PK" };
      
      Console.WriteLine("Converting the date {0}: ", 
                        Convert.ToString(tDate, 
                                System.Globalization.CultureInfo.InvariantCulture));

      foreach (string cultureName in cultureNames)
      {
         System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo(cultureName);
         string dateString = Convert.ToString(tDate, culture);
         Console.WriteLine("   {0}:  {1,-12}", 
                           culture.Name, dateString);
      }             
      // The example displays the following output:
      //       Converting the date 04/15/2010 20:30:40:
      //          en-US:  4/15/2010 8:30:40 PM
      //          es-AR:  15/04/2010 08:30:40 p.m.
      //          fr-FR:  15/04/2010 20:30:40
      //          hi-IN:  15-04-2010 20:30:40
      //          ja-JP:  2010/04/15 20:30:40
      //          nl-NL:  15-4-2010 20:30:40
      //          ru-RU:  15.04.2010 20:30:40
      //          ur-PK:  15/04/2010 8:30:40 PM      
      // </Snippet13>
   }

   private static void ConvertDecimalWithProvider()
   {
      // <Snippet14>
      // Define an array of numbers to display.
      decimal[] numbers = { 1734231911290.16m, -17394.32921m,
                            3193.23m, 98012368321.684m };
      // Define the culture names used to display them.
      string[] cultureNames = { "en-US", "fr-FR", "ja-JP", "ru-RU" };
      
      foreach (decimal number in numbers)
      {
         Console.WriteLine("{0}:", Convert.ToString(number,
                                   System.Globalization.CultureInfo.InvariantCulture));
         foreach (string cultureName in cultureNames)
         {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo(cultureName);
            Console.WriteLine("   {0}: {1,20}",
                              culture.Name, Convert.ToString(number, culture));
         }
         Console.WriteLine();
      }   
      // The example displays the following output:
      //    1734231911290.16:
      //       en-US:     1734231911290.16
      //       fr-FR:     1734231911290,16
      //       ja-JP:     1734231911290.16
      //       ru-RU:     1734231911290,16
      //    
      //    -17394.32921:
      //       en-US:         -17394.32921
      //       fr-FR:         -17394,32921
      //       ja-JP:         -17394.32921
      //       ru-RU:         -17394,32921
      //    
      //    3193.23:
      //       en-US:              3193.23
      //       fr-FR:              3193,23
      //       ja-JP:              3193.23
      //       ru-RU:              3193,23
      //    
      //    98012368321.684:
      //       en-US:      98012368321.684
      //       fr-FR:      98012368321,684
      //       ja-JP:      98012368321.684
      //       ru-RU:      98012368321,684
      // </Snippet14>
   }
   
   private static void ConvertDoubleWithProvider()
   {
      // <Snippet15>
      // Define an array of numbers to display.
      double[] numbers = { -1.5345e16, -123.4321, 19092.123, 1.1734231911290e16 };
      // Define the culture names used to display them.
      string[] cultureNames = { "en-US", "fr-FR", "ja-JP", "ru-RU" };
      
      foreach (double number in numbers)
      {
         Console.WriteLine("{0}:", Convert.ToString(number,
                                   System.Globalization.CultureInfo.InvariantCulture));
         foreach (string cultureName in cultureNames)
         {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo(cultureName);
            Console.WriteLine("   {0}: {1,20}",
                              culture.Name, Convert.ToString(number, culture));
         }
         Console.WriteLine();
      }   
      // The example displays the following output:
      //    -1.5345E+16:
      //       en-US:          -1.5345E+16
      //       fr-FR:          -1,5345E+16
      //       ja-JP:          -1.5345E+16
      //       ru-RU:          -1,5345E+16
      //    
      //    -123.4321:
      //       en-US:            -123.4321
      //       fr-FR:            -123,4321
      //       ja-JP:            -123.4321
      //       ru-RU:            -123,4321
      //    
      //    19092.123:
      //       en-US:            19092.123
      //       fr-FR:            19092,123
      //       ja-JP:            19092.123
      //       ru-RU:            19092,123
      //    
      //    1.173423191129E+16:
      //       en-US:   1.173423191129E+16
      //       fr-FR:   1,173423191129E+16
      //       ja-JP:   1.173423191129E+16
      //       ru-RU:   1,173423191129E+16
      // </Snippet15>     
   }

   private static void ConvertByteWithProvider()
   {
      // <Snippet16>
      byte[] numbers = { 12, 100, Byte.MaxValue };
      // Define the culture names used to display them.
      string[] cultureNames = { "en-US", "fr-FR" };
      
      foreach (byte number in numbers)
      {
         Console.WriteLine("{0}:", Convert.ToString(number,
                                   System.Globalization.CultureInfo.InvariantCulture));
         foreach (string cultureName in cultureNames)
         {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo(cultureName);
            Console.WriteLine("   {0}: {1,20}",
                              culture.Name, Convert.ToString(number, culture));
         }
         Console.WriteLine();
      }   
      // The example displays the following output:
      //       12:
      //          en-US:                   12
      //          fr-FR:                   12
      //       
      //       100:
      //          en-US:                  100
      //          fr-FR:                  100
      //       
      //       255:
      //          en-US:                  255
      //          fr-FR:                  255      
      // </Snippet16>
   }

   private static void ConvertSByteWithProvider()
   {
      // <Snippet17>
      sbyte[] numbers = { SByte.MinValue, -12, 17, SByte.MaxValue};
      System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
      nfi.NegativeSign = "~";
      nfi.PositiveSign = "!";
      foreach (sbyte number in numbers)
         Console.WriteLine(Convert.ToString(number, nfi));
      // The example displays the following output:
      //       ~128
      //       ~12
      //       17
      //       127      
      // </Snippet17>
   }

   private static void ConvertSingleWithProvider()
   {
      // <Snippet18>
      // Define an array of numbers to display.
      float[] numbers = { -1.5345e16f, -123.4321f, 19092.123f, 1.1734231911290e16f };
      // Define the culture names used to display them.
      string[] cultureNames = { "en-US", "fr-FR", "ja-JP", "ru-RU" };
      
      foreach (float number in numbers)
      {
         Console.WriteLine("{0}:", Convert.ToString(number,
                                   System.Globalization.CultureInfo.InvariantCulture));
         foreach (string cultureName in cultureNames)
         {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo(cultureName);
            Console.WriteLine("   {0}: {1,20}",
                              culture.Name, Convert.ToString(number, culture));
         }
         Console.WriteLine();
      }   
      // The example displays the following output:
      //    -1.5345E+16:
      //       en-US:          -1.5345E+16
      //       fr-FR:          -1,5345E+16
      //       ja-JP:          -1.5345E+16
      //       ru-RU:          -1,5345E+16
      //    
      //    -123.4321:
      //       en-US:            -123.4321
      //       fr-FR:            -123,4321
      //       ja-JP:            -123.4321
      //       ru-RU:            -123,4321
      //    
      //    19092.123:
      //       en-US:            19092.123
      //       fr-FR:            19092,123
      //       ja-JP:            19092.123
      //       ru-RU:            19092,123
      //    
      //    1.173423191129E+16:
      //       en-US:   1.173423191129E+16
      //       fr-FR:   1,173423191129E+16
      //       ja-JP:   1.173423191129E+16
      //       ru-RU:   1,173423191129E+16
      // </Snippet18>     
   }

   private static void ConvertInt16WithProvider()
   {
      // <Snippet19>
      short[] numbers = { Int16.MinValue, Int16.MaxValue};
      System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
      nfi.NegativeSign = "~";
      nfi.PositiveSign = "!";
      
      foreach (short number in numbers)
         Console.WriteLine("{0,-8}  -->  {1,8}", 
                           Convert.ToString(number, System.Globalization.CultureInfo.InvariantCulture), 
                           Convert.ToString(number, nfi));
      // The example displays the following output:
      //       -32768    -->    ~32768
      //       32767     -->     32767
      // </Snippet19>
   }

   private static void ConvertInt32WithProvider()
   {
      // <Snippet20>
      int[] numbers = { Int32.MinValue, Int32.MaxValue};
      System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
      nfi.NegativeSign = "~";
      nfi.PositiveSign = "!";
      
      foreach (int number in numbers)
         Console.WriteLine("{0,-12}  -->  {1,12}", 
                           Convert.ToString(number, System.Globalization.CultureInfo.InvariantCulture), 
                           Convert.ToString(number, nfi));
      // The example displays the following output:
      //       -2147483648  -->  ~2147483648
      //       2147483647  -->  2147483647
      // </Snippet20>
   }

   private static void ConvertInt64WithProvider()
   {
      // <Snippet21>
      long[] numbers = { ((long) Int32.MinValue) * 2, ((long) Int32.MaxValue) * 2};
      System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
      nfi.NegativeSign = "~";
      nfi.PositiveSign = "!";
      
      foreach (long number in numbers)
         Console.WriteLine("{0,-12}  -->  {1,12}", 
                           Convert.ToString(number, System.Globalization.CultureInfo.InvariantCulture), 
                           Convert.ToString(number, nfi));
      // The example displays the following output:
      //       -4294967296  -->  ~4294967296
      //       4294967294  -->  4294967294
      // </Snippet21>
   }

   private static void ConvertUInt16WithProvider()
   {
      // <Snippet22>
      ushort number = UInt16.MaxValue;
      System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
      nfi.NegativeSign = "~";
      nfi.PositiveSign = "!";
      
      Console.WriteLine("{0,-6}  -->  {1,6}",
                        Convert.ToString(number, System.Globalization.CultureInfo.InvariantCulture),
                        Convert.ToString(number, nfi));
      // The example displays the following output:
      //       65535   -->   65535
      // </Snippet22>
   }   
   
   private static void ConvertUInt32WithProvider()
   {
      // <Snippet23>
      uint number = UInt32.MaxValue;
      System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
      nfi.NegativeSign = "~";
      nfi.PositiveSign = "!";
      
      Console.WriteLine("{0,-8}  -->  {1,8}",
                        Convert.ToString(number, System.Globalization.CultureInfo.InvariantCulture),
                        Convert.ToString(number, nfi));
      // The example displays the following output:
      //       4294967295  -->  4294967295
      // </Snippet23>
   }   
   
   private static void ConvertUInt64WithProvider()
   {
      // <Snippet24>
      ulong number = UInt64.MaxValue;
      System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
      nfi.NegativeSign = "~";
      nfi.PositiveSign = "!";
      
      Console.WriteLine("{0,-12}  -->  {1,12}",
                        Convert.ToString(number, System.Globalization.CultureInfo.InvariantCulture),
                        Convert.ToString(number, nfi));
      // The example displays the following output:
      //    18446744073709551615  -->  18446744073709551615
      // </Snippet24>
   }  
}
