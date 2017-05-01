// <Snippet2>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      DateTime date1 = new DateTime(2001, 11, 12);
      string[] cultureNames = { "en-US", "fr-FR", "ru-RU", "de-DE" };
      Console.WriteLine("{0,-7} {1,-20} {2:D}\n", "Culture", "Long Date Pattern", "Date");
      foreach (var cultureName in cultureNames) {
         CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
         Console.WriteLine("{0,-7} {1,-20} {2}", 
                           culture.Name, 
                           culture.DateTimeFormat.LongDatePattern, 
                           date1.ToString("D", culture));                 
      }
   }
}
// The example displays the following output:
//    Culture Long Date Pattern    Date
//    en-US   dddd, MMMM dd, yyyy  Saturday, November 12, 2011
//    fr-FR   dddd d MMMM yyyy     samedi 12 novembre 2011
//    ru-RU   d MMMM yyyy 'г.'     12 ноября 2011 г.
//    de-DE   dddd, d. MMMM yyyy   Samstag, 12. November 2011
// </Snippet2>
