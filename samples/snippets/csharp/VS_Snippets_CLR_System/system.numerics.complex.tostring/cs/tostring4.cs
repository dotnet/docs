// <Snippet4>
using System;
using System.Globalization;
using System.Numerics;

public class Example
{
   public static void Main()
   {
      Complex[] c = { new Complex(17.3, 14.1), 
                      new Complex(-18.9, 147.2), 
                      new Complex(13.472, -18.115), 
                      new Complex(-11.154, -17.002) };
      CultureInfo[] cultures = { new CultureInfo("en-US"), 
                                 new CultureInfo("fr-FR") }; 
      string[] formats = { "F2", "N2", "G5" }; 

      foreach (Complex c1 in c)
      {
         foreach (string format in formats)
         {
            Console.Write("{0} format string:   ", format);
            foreach (CultureInfo culture in cultures)
               Console.Write("{0} ({1})    ", c1.ToString(format, culture), culture.Name);

            Console.WriteLine();
         }
         Console.WriteLine();
      }                          
   }
}
// The example displays the following output:
//    F2 format string:   (17.30, 14.10) (en-US)    (17,30, 14,10) (fr-FR)
//    N2 format string:   (17.30, 14.10) (en-US)    (17,30, 14,10) (fr-FR)
//    G5 format string:   (17.3, 14.1) (en-US)    (17,3, 14,1) (fr-FR)
//    
//    F2 format string:   (-18.90, 147.20) (en-US)    (-18,90, 147,20) (fr-FR)
//    N2 format string:   (-18.90, 147.20) (en-US)    (-18,90, 147,20) (fr-FR)
//    G5 format string:   (-18.9, 147.2) (en-US)    (-18,9, 147,2) (fr-FR)
//    
//    F2 format string:   (13.47, -18.12) (en-US)    (13,47, -18,12) (fr-FR)
//    N2 format string:   (13.47, -18.12) (en-US)    (13,47, -18,12) (fr-FR)
//    G5 format string:   (13.472, -18.115) (en-US)    (13,472, -18,115) (fr-FR)
//    
//    F2 format string:   (-11.15, -17.00) (en-US)    (-11,15, -17,00) (fr-FR)
//    N2 format string:   (-11.15, -17.00) (en-US)    (-11,15, -17,00) (fr-FR)
//    G5 format string:   (-11.154, -17.002) (en-US)    (-11,154, -17,002) (fr-FR)
// </Snippet4>
