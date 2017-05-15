// The following code example calls IsLeapMonth for all the months in five years in the current era.

// <snippet1>
using System;
using System.Globalization;


public class SamplesHijriCalendar  {

   public static void Main()  {

      // Creates and initializes a HijriCalendar.
      HijriCalendar myCal = new HijriCalendar();

      // Checks all the months in five years in the current era.
      int iMonthsInYear;
      for ( int y = 1421; y <= 1425; y++ )  {
         Console.Write( "{0}:\t", y );
         iMonthsInYear = myCal.GetMonthsInYear( y, HijriCalendar.CurrentEra );
         for ( int m = 1; m <= iMonthsInYear; m++ )
            Console.Write( "\t{0}", myCal.IsLeapMonth( y, m, HijriCalendar.CurrentEra ) );
         Console.WriteLine();
      }

   }

}

/*
This code produces the following output.

1421:           False   False   False   False   False   False   False   False   False   False   False   False
1422:           False   False   False   False   False   False   False   False   False   False   False   False
1423:           False   False   False   False   False   False   False   False   False   False   False   False
1424:           False   False   False   False   False   False   False   False   False   False   False   False
1425:           False   False   False   False   False   False   False   False   False   False   False   False

*/
// </snippet1>
