// <Snippet1>
using System;
using System.IO;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      // Persist the date and time data.
      StreamWriter sw = new StreamWriter(@".\DateData.dat");

      // Create a DateTime value.
      DateTime dtIn = DateTime.Now;
      // Retrieve a CultureInfo object.
      CultureInfo invC = CultureInfo.InvariantCulture;

      // Convert the date to a string and write it to a file.
      sw.WriteLine(dtIn.ToString("r", invC));
      sw.Close();

      // Restore the date and time data.
      StreamReader sr = new StreamReader(@".\DateData.dat");
      String input;
      while ((input = sr.ReadLine()) != null)
      {
         Console.WriteLine($"Stored data: {input}\n");

         // Parse the stored string.
         DateTime dtOut = DateTime.Parse(input, invC, DateTimeStyles.RoundtripKind);

         // Create a French (France) CultureInfo object.
         CultureInfo frFr = new CultureInfo("fr-FR");
         // Displays the date formatted for the "fr-FR" culture.
         Console.WriteLine("Date formatted for the {0} culture: {1}" ,
                           frFr.Name, dtOut.ToString("f", frFr));

         // Creates a German (Germany) CultureInfo object.
         CultureInfo deDe= new CultureInfo("de-De");
         // Displays the date formatted for the "de-DE" culture.
         Console.WriteLine("Date formatted for {0} culture: {1}" ,
                           deDe.Name, dtOut.ToString("f", deDe));
      }
      sr.Close();
   }
}
// The example displays the following output:
//    Stored data: Tue, 15 May 2012 16:34:16 GMT
//
//    Date formatted for the fr-FR culture: mardi 15 mai 2012 16:34
//    Date formatted for de-DE culture: Dienstag, 15. Mai 2012 16:34
// </Snippet1>
