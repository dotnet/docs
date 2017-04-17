// The following code example calls IsLeapDay for the last day of the second month (February) for five years in each of the eras.

// <snippet1>
using System;
using System.Globalization;


public class SamplesJapaneseCalendar  {

   public static void Main()  {

      // Creates and initializes a JapaneseCalendar.
      JapaneseCalendar myCal = new JapaneseCalendar();

      // Creates a holder for the last day of the second month (February).
      int iLastDay;

      // Displays the header.
      Console.Write( "YEAR\t" );
      for ( int y = 1; y <= 5; y++ )
         Console.Write( "\t{0}", y );
      Console.WriteLine();

      // Checks five years in the current era.
      Console.Write( "CurrentEra:" );
      for ( int y = 1; y <= 5; y++ )  {
         iLastDay = myCal.GetDaysInMonth( y, 2, JapaneseCalendar.CurrentEra );
         Console.Write( "\t{0}", myCal.IsLeapDay( y, 2, iLastDay, JapaneseCalendar.CurrentEra ) );
      }
      Console.WriteLine();

      // Checks five years in each of the eras.
      for ( int i = 0; i < myCal.Eras.Length; i++ )  {
         Console.Write( "Era {0}:\t", myCal.Eras[i] );
         for ( int y = 1; y <= 5; y++ )  {
            iLastDay = myCal.GetDaysInMonth( y, 2, myCal.Eras[i] );
            Console.Write( "\t{0}", myCal.IsLeapDay( y, 2, iLastDay, myCal.Eras[i] ) );
         }
         Console.WriteLine();
      }

   }

}

/*
This code produces the following output.

YEAR            1       2       3       4       5
CurrentEra:     False   False   False   True    False
Era 4:          False   False   False   True    False
Era 3:          False   False   True    False   False
Era 2:          True    False   False   False   True
Era 1:          True    False   False   False   True

*/
// </snippet1>
