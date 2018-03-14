// <Snippet3>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      CultureInfo[] cultures = new CultureInfo[] {CultureInfo.InvariantCulture, 
                                                  new CultureInfo("en-us"), 
                                                  new CultureInfo("fr-fr"), 
                                                  new CultureInfo("de-DE"), 
                                                  new CultureInfo("es-ES"),
                                                  new CultureInfo("ja-JP")};

      DateTime thisDate = new DateTime(2009, 5, 1, 9, 0, 0);                                            

      foreach (CultureInfo culture in cultures)
      {
         string cultureName; 
         if (string.IsNullOrEmpty(culture.Name))
            cultureName = culture.NativeName;
         else
            cultureName = culture.Name;
      
         Console.WriteLine("In {0}, {1}", 
                           cultureName, thisDate.ToString(culture));
      }                                            
      }
}
// The example produces the following output:
//    In Invariant Language (Invariant Country), 05/01/2009 09:00:00
//    In en-US, 5/1/2009 9:00:00 AM
//    In fr-FR, 01/05/2009 09:00:00
//    In de-DE, 01.05.2009 09:00:00
//    In es-ES, 01/05/2009 9:00:00
//    In ja-JP, 2009/05/01 9:00:00
// </Snippet3>
