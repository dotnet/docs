using System;
using System.Globalization;

public class SamplesJapaneseCalendar  {

   public static void Main()  {

      // Creates and initializes a JapaneseCalendar.
      JapaneseCalendar myCal = new JapaneseCalendar();

      // Displays the header.
      Console.Write("YEAR\t");
      for (int y = 1; y <= 5; y++ )
         Console.Write($"\t{y}");
      Console.WriteLine();

      // Displays the value of the CurrentEra property.
      Console.Write("CurrentEra:");
      for (int y = 1; y <= 5; y++ )
         Console.Write($"\t{myCal.GetMonthsInYear(y, JapaneseCalendar.CurrentEra)}");
      Console.WriteLine();

      // Displays the values in the Eras property.
      for (int i = 0; i < myCal.Eras.Length; i++ )  {
         Console.Write($"Era {myCal.Eras[i]}:\t");
         for (int y = 1; y <= 5; y++ )
            Console.Write("\t{myCal.GetMonthsInYear(y, myCal.Eras[i])}");
         Console.WriteLine();
      }
   }
}
