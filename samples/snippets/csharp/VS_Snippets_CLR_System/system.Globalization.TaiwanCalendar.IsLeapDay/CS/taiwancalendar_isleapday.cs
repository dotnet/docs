// The following code example calls IsLeapDay for the last day of the second month (February) for five years in each of the eras.

// <snippet1>
using System;
using System.Globalization;


public class SamplesTaiwanCalendar  {

   public static void Main()  {

      // Creates and initializes a TaiwanCalendar.
      TaiwanCalendar myCal = new TaiwanCalendar();

      // Creates a holder for the last day of the second month (February).
      int iLastDay;

      // Displays the header.
      Console.Write( "YEAR\t" );
      for ( int y = 90; y <= 94; y++ )
         Console.Write( "\t{0}", y );
      Console.WriteLine();

      // Checks five years in the current era.
      Console.Write( "CurrentEra:" );
      for ( int y = 90; y <= 94; y++ )  {
         iLastDay = myCal.GetDaysInMonth( y, 2, TaiwanCalendar.CurrentEra );
         Console.Write( "\t{0}", myCal.IsLeapDay( y, 2, iLastDay, TaiwanCalendar.CurrentEra ) );
      }
      Console.WriteLine();

      // Checks five years in each of the eras.
      for ( int i = 0; i < myCal.Eras.Length; i++ )  {
         Console.Write( "Era {0}:\t", myCal.Eras[i] );
         for ( int y = 90; y <= 94; y++ )  {
            iLastDay = myCal.GetDaysInMonth( y, 2, myCal.Eras[i] );
            Console.Write( "\t{0}", myCal.IsLeapDay( y, 2, iLastDay, myCal.Eras[i] ) );
         }
         Console.WriteLine();
      }

   }

}

/*
This code produces the following output.

YEAR            90      91      92      93      94
CurrentEra:     False   False   False   True    False
Era 1:          False   False   False   True    False

*/
// </snippet1>
