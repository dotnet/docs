// <Snippet12>
using System;
using System.Globalization;
using System.Threading;

public class Example
{
   public static void Main()
   {
      double value = 1634.92;
      CultureInfo.CurrentCulture = new CultureInfo("fr-CA");
      Console.WriteLine("Current Culture: {0}", 
                        CultureInfo.CurrentCulture.Name);
      Console.WriteLine("{0:C2}\n", value);
      
      Thread.CurrentThread.CurrentCulture = new CultureInfo("fr");
      Console.WriteLine("Current Culture: {0}", 
                        CultureInfo.CurrentCulture.Name);
      Console.WriteLine("{0:C2}", value);
   }
}
// The example displays the following output:
//       Current Culture: fr-CA
//       1 634,92 $
//       
//       Current Culture: fr
//       1 634,92 €
// </Snippet12>
