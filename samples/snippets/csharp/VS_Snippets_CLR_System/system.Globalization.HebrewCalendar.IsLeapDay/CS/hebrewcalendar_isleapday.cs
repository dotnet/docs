// The following code example calls IsLeapDay for the last day of the second month (February) for five years in each of the eras.

// <snippet1>
using System;
using System.Globalization;


public class SamplesHebrewCalendar  {

   public static void Main()  {

      // Creates and initializes a HebrewCalendar.
      HebrewCalendar myCal = new HebrewCalendar();

      // Creates a holder for the last day of the second month (February).
      int iLastDay;

      // Displays the header.
      Console.Write( "YEAR\t" );
      for ( int y = 5761; y <= 5765; y++ )
         Console.Write( "\t{0}", y );
      Console.WriteLine();

      // Checks five years in the current era.
      Console.Write( "CurrentEra:" );
      for ( int y = 5761; y <= 5765; y++ )  {
         iLastDay = myCal.GetDaysInMonth( y, 2, HebrewCalendar.CurrentEra );
         Console.Write( "\t{0}", myCal.IsLeapDay( y, 2, iLastDay, HebrewCalendar.CurrentEra ) );
      }
      Console.WriteLine();

      // Checks five years in each of the eras.
      for ( int i = 0; i < myCal.Eras.Length; i++ )  {
         Console.Write( "Era {0}:\t", myCal.Eras[i] );
         for ( int y = 5761; y <= 5765; y++ )  {
            iLastDay = myCal.GetDaysInMonth( y, 2, myCal.Eras[i] );
            Console.Write( "\t{0}", myCal.IsLeapDay( y, 2, iLastDay, myCal.Eras[i] ) );
         }
         Console.WriteLine();
      }

   }

}

/*
This code produces the following output.

YEAR            5761    5762    5763    5764    5765
CurrentEra:     False   False   False   False   False
Era 1:          False   False   False   False   False

*/
// </snippet1>
