// <Snippet12>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      string[] values = { "123456789", "12345.6789", "12 345,6789",
                          "123,456.789", "123 456,789", "123,456,789.0123",
                          "123 456 789,0123" };
      CultureInfo[] cultures = { new CultureInfo("en-US"),
                                 new CultureInfo("fr-FR") }; 

      foreach (CultureInfo culture in cultures)
      {
         Console.WriteLine("String -> Decimal Conversion Using the {0} Culture",
                           culture.Name);
         foreach (string value in values)
         {
            Console.Write("{0,20}  ->  ", value);
            try {
               Console.WriteLine(Convert.ToDecimal(value, culture));
            }
            catch (FormatException) {
               Console.WriteLine("FormatException");
            }
         }
         Console.WriteLine();
      }                     
   }
}
// The example displays the following output:
//       String -> Decimal Conversion Using the en-US Culture
//                  123456789  ->  123456789
//                 12345.6789  ->  12345.6789
//                12 345,6789  ->  FormatException
//                123,456.789  ->  123456.789
//                123 456,789  ->  FormatException
//           123,456,789.0123  ->  123456789.0123
//           123 456 789,0123  ->  FormatException
//       
//       String -> Decimal Conversion Using the fr-FR Culture
//                  123456789  ->  123456789
//                 12345.6789  ->  FormatException
//                12 345,6789  ->  12345.6789
//                123,456.789  ->  FormatException
//                123 456,789  ->  123456.789
//           123,456,789.0123  ->  FormatException
//           123 456 789,0123  ->  123456789.0123
// </Snippet12>
