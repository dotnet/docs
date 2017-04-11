using System;
using System.Globalization;

public class Class1
{
   public static void Main()
   {
      ShowDefaultToString();
      ShowCultureSpecificToString();
      ShowDefaultFullDateAndTime();
      ShowCultureSpecificFullDateAndTime();
   }

   private static void ShowDefaultToString()
   {
      // <Snippet1>
      DateTime date1 = new DateTime(2008, 3, 1, 7, 0, 0);
      Console.WriteLine(date1.ToString());
      // For en-US culture, displays 3/1/2008 7:00:00 AM
      // </Snippet1>
   }

   private static void ShowCultureSpecificToString()
   {
      // <Snippet2>
      DateTime date1 = new DateTime(2008, 3, 1, 7, 0, 0);
      Console.WriteLine(date1.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR")));
      // Displays 01/03/2008 07:00:00
      // </Snippet2>
   }

   private static void ShowDefaultFullDateAndTime()
   {
      // <Snippet3>
      DateTime date1 = new DateTime(2008, 3, 1, 7, 0, 0);
      Console.WriteLine(date1.ToString("F"));
      // Displays Saturday, March 01, 2008 7:00:00 AM
      // </Snippet3>
   }

   private static void ShowCultureSpecificFullDateAndTime()
   {
      // <Snippet4>
      DateTime date1 = new DateTime(2008, 3, 1, 7, 0, 0);
      Console.WriteLine(date1.ToString("F", new System.Globalization.CultureInfo("fr-FR")));
      // Displays samedi 1 mars 2008 07:00:00
      // </Snippet4>      
   }
}
