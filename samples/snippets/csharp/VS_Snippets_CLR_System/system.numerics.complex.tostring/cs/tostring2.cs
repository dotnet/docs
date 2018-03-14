// <Snippet2>
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
      foreach (Complex c1 in c)
      {
         foreach (CultureInfo culture in cultures)
            Console.Write("{0} ({1})    ", c1.ToString(culture), culture.Name);

         Console.WriteLine();
      }                          
   }
}
// The example displays the following output:
//       (17.3, 14.1) (en-US)    (17,3, 14,1) (fr-FR)
//       (-18.9, 147.2) (en-US)    (-18,9, 147,2) (fr-FR)
//       (13.472, -18.115) (en-US)    (13,472, -18,115) (fr-FR)
//       (-11.154, -17.002) (en-US)    (-11,154, -17,002) (fr-FR)
// </Snippet2>