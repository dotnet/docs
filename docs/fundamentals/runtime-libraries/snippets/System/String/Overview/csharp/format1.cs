// <Snippet8>
using System;
using System.Globalization;

public class Example9
{
   public static void Main()
   {
      DateTime date = new DateTime(2011, 3, 1);
      CultureInfo[] cultures = { CultureInfo.InvariantCulture, 
                                 new CultureInfo("en-US"), 
                                 new CultureInfo("fr-FR") };

      foreach (var culture in cultures)
         Console.WriteLine("{0,-12} {1}", String.IsNullOrEmpty(culture.Name) ?
                           "Invariant" : culture.Name, 
                           date.ToString("d", culture));                                    
   }
}
// The example displays the following output:
//       Invariant    03/01/2011
//       en-US        3/1/2011
//       fr-FR        01/03/2011
// </Snippet8>
