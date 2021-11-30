// <Snippet10>
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Example6
{
   public static void Main6()
   {
      BinaryFormatter formatter = new BinaryFormatter();

      DateTime dateOriginal = new DateTime(2013, 3, 30, 18, 0, 0);
      dateOriginal = DateTime.SpecifyKind(dateOriginal, DateTimeKind.Local);

      // Serialize a date.
      if (! File.Exists("DateInfo.dat")) {
         StreamWriter sw = new StreamWriter("DateInfo.dat");
         sw.Write("{0:G}|{0:s}|{0:o}", dateOriginal);
         sw.Close();
         Console.WriteLine("Serialized dates to DateInfo.dat");
      }
      // Serialize the data as a binary value.
      if (! File.Exists("DateInfo.bin")) {
         FileStream fsIn = new FileStream("DateInfo.bin", FileMode.Create);
         formatter.Serialize(fsIn, dateOriginal);
         fsIn.Close();
         Console.WriteLine("Serialized date to DateInfo.bin");
      }
      Console.WriteLine();

      // Restore the date from string values.
      StreamReader sr = new StreamReader("DateInfo.dat");
      string datesToSplit = sr.ReadToEnd();
      string[] dateStrings = datesToSplit.Split('|');
      foreach (var dateStr in dateStrings) {
         DateTime newDate = DateTime.Parse(dateStr);
         Console.WriteLine("'{0}' --> {1} {2}",
                           dateStr, newDate, newDate.Kind);
      }
      Console.WriteLine();

      // Restore the date from binary data.
      FileStream fsOut = new FileStream("DateInfo.bin", FileMode.Open);
      DateTime restoredDate = (DateTime) formatter.Deserialize(fsOut);
      Console.WriteLine("{0} {1}", restoredDate, restoredDate.Kind);
   }
}
// </Snippet10>
