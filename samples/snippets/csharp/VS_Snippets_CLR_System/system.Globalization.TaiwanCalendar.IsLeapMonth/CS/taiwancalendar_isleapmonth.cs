// The following code example calls IsLeapMonth for all the months in five years in the current era.

// <snippet1>
using System;
using System.Globalization;


public class SamplesTaiwanCalendar  {

   public static void Main()  {

      // Creates and initializes a TaiwanCalendar.
      TaiwanCalendar myCal = new TaiwanCalendar();

      // Checks all the months in five years in the current era.
      int iMonthsInYear;
      for ( int y = 90; y <= 94; y++ )  {
         Console.Write( "{0}:\t", y );
         iMonthsInYear = myCal.GetMonthsInYear( y, TaiwanCalendar.CurrentEra );
         for ( int m = 1; m <= iMonthsInYear; m++ )
            Console.Write( "\t{0}", myCal.IsLeapMonth( y, m, TaiwanCalendar.CurrentEra ) );
         Console.WriteLine();
      }

   }

}

/*
This code produces the following output.

90:             False   False   False   False   False   False   False   False   False   False   False   False
91:             False   False   False   False   False   False   False   False   False   False   False   False
92:             False   False   False   False   False   False   False   False   False   False   False   False
93:             False   False   False   False   False   False   False   False   False   False   False   False
94:             False   False   False   False   False   False   False   False   False   False   False   False

*/
// </snippet1>
