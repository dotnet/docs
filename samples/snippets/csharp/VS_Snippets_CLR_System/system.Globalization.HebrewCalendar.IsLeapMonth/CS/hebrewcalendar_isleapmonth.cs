// The following code example calls IsLeapMonth for all the months in five years in the current era.

// <snippet1>
using System;
using System.Globalization;


public class SamplesHebrewCalendar  {

   public static void Main()  {

      // Creates and initializes a HebrewCalendar.
      HebrewCalendar myCal = new HebrewCalendar();

      // Checks all the months in five years in the current era.
      int iMonthsInYear;
      for ( int y = 5761; y <= 5765; y++ )  {
         Console.Write( "{0}:\t", y );
         iMonthsInYear = myCal.GetMonthsInYear( y, HebrewCalendar.CurrentEra );
         for ( int m = 1; m <= iMonthsInYear; m++ )
            Console.Write( "\t{0}", myCal.IsLeapMonth( y, m, HebrewCalendar.CurrentEra ) );
         Console.WriteLine();
      }

   }

}

/*
This code produces the following output.

5761:           False   False   False   False   False   False   False   False   False   False   False   False
5762:           False   False   False   False   False   False   False   False   False   False   False   False
5763:           False   False   False   False   False   False   True    False   False   False   False   False   False
5764:           False   False   False   False   False   False   False   False   False   False   False   False
5765:           False   False   False   False   False   False   True    False   False   False   False   False   False

*/
// </snippet1>
