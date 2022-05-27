// <Snippet11>
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Example9
{
   public static void Main9()
   {
      BinaryFormatter formatter = new BinaryFormatter();

      // Serialize a date.
      DateTime dateOriginal = new DateTime(2013, 3, 30, 18, 0, 0);
      dateOriginal = DateTime.SpecifyKind(dateOriginal, DateTimeKind.Local);

      // Serialize the date in string form.
      if (! File.Exists("DateInfo2.dat")) {
         StreamWriter sw = new StreamWriter("DateInfo2.dat");
         sw.Write("{0:o}|{1:r}|{1:u}", dateOriginal,
                                       dateOriginal.ToUniversalTime());
         sw.Close();
         Console.WriteLine("Serialized dates to DateInfo.dat");
      }
      // Serialize the date as a binary value.
      if (! File.Exists("DateInfo2.bin")) {
         FileStream fsIn = new FileStream("DateInfo2.bin", FileMode.Create);
         formatter.Serialize(fsIn, dateOriginal.ToUniversalTime());
         fsIn.Close();
         Console.WriteLine("Serialized date to DateInfo.bin");
      }
      Console.WriteLine();

      // Restore the date from string values.
      StreamReader sr = new StreamReader("DateInfo2.dat");
      string datesToSplit = sr.ReadToEnd();
      string[] dateStrings = datesToSplit.Split('|');
      for (int ctr = 0; ctr < dateStrings.Length; ctr++) {
         DateTime newDate = DateTime.Parse(dateStrings[ctr]);
         if (ctr == 1) {
            Console.WriteLine("'{0}' --> {1} {2}",
                              dateStrings[ctr], newDate, newDate.Kind);
         }
         else {
            DateTime newLocalDate = newDate.ToLocalTime();
            Console.WriteLine("'{0}' --> {1} {2}",
                              dateStrings[ctr], newLocalDate, newLocalDate.Kind);
         }
      }
      Console.WriteLine();

      // Restore the date from binary data.
      FileStream fsOut = new FileStream("DateInfo2.bin", FileMode.Open);
      DateTime restoredDate = (DateTime) formatter.Deserialize(fsOut);
      restoredDate = restoredDate.ToLocalTime();
      Console.WriteLine("{0} {1}", restoredDate, restoredDate.Kind);
   }
}
// </Snippet11>
