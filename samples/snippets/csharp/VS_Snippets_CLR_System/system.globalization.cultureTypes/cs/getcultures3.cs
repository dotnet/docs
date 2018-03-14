using System;
using System.Globalization;

public class Example
{
   private const int LOCALE_CUSTOM_UNSPECIFIED = 0x1000;

   public static void Main()
   {
      // <Snippet2>
      CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.UserCustomCulture |
                                                       CultureTypes.SpecificCultures);
      // </Snippet2>
      Console.WriteLine("Specific Custom Cultures");
      foreach (var culture in cultures) {
         if ((culture.CultureTypes & CultureTypes.UserCustomCulture) == CultureTypes.UserCustomCulture) {
            Console.WriteLine("   {0}, LCID {1:X8}: {2}", culture.Name, culture.LCID, culture.EnglishName);
            Console.WriteLine("        {0:G}", culture.CultureTypes);
         }
      }
      Console.WriteLine("\nPress Enter to continue...");
      Console.ReadLine();
      Main2();
   }

   private static void Main2()
   {
      Console.Clear();

      // <Snippet3>
      CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.UserCustomCulture |
                                                       CultureTypes.NeutralCultures);
      // </Snippet3>
      foreach (var culture in cultures)
         if (culture.LCID == LOCALE_CUSTOM_UNSPECIFIED)
            Console.WriteLine("{0}, LCID 0x{1:X8}: {2}\n     {3:G}",
                              culture.Name, culture.LCID, culture.EnglishName,
                              culture.CultureTypes);
   }
}
