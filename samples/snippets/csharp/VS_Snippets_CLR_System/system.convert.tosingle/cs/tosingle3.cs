// <Snippet16>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      string[] values = { "123456789", "12345.6789", "12 345,6789",
                          "123,456.789", "123 456,789", "123,456,789.0123",
                          "123 456 789,0123", "1.235e12", "1.03221e-05", 
                          Double.MaxValue.ToString() };
      CultureInfo[] cultures = { new CultureInfo("en-US"),
                                 new CultureInfo("fr-FR") }; 

      foreach (CultureInfo culture in cultures)
      {
         Console.WriteLine("String -> Single Conversion Using the {0} Culture",
                           culture.Name);
         foreach (string value in values)
         {
            Console.Write("{0,22}  ->  ", value);
            try {
               Console.WriteLine(Convert.ToSingle(value, culture));
            }
            catch (FormatException) {
               Console.WriteLine("FormatException");
            }
            catch (OverflowException) {
               Console.WriteLine("OverflowException");
            }
         }
         Console.WriteLine();
      }                     
   }
}
// The example displays the following output:
//    String -> Single Conversion Using the en-US Culture
//                 123456789  ->  1.234568E+08
//                12345.6789  ->  12345.68
//               12 345,6789  ->  FormatException
//               123,456.789  ->  123456.8
//               123 456,789  ->  FormatException
//          123,456,789.0123  ->  1.234568E+08
//          123 456 789,0123  ->  FormatException
//                  1.235e12  ->  1.235E+12
//               1.03221e-05  ->  1.03221E-05
//     1.79769313486232E+308  ->  Overflow
//    
//    String -> Single Conversion Using the fr-FR Culture
//                 123456789  ->  1.234568E+08
//                12345.6789  ->  FormatException
//               12 345,6789  ->  12345.68
//               123,456.789  ->  FormatException
//               123 456,789  ->  123456.8
//          123,456,789.0123  ->  FormatException
//          123 456 789,0123  ->  1.234568E+08
//                  1.235e12  ->  FormatException
//               1.03221e-05  ->  FormatException
//     1.79769313486232E+308  ->  FormatException
// </Snippet16>
