// The following code example calls IsLeapYear for five years in each of the eras.

// <snippet1>
using System;
using System.Globalization;


public class SamplesTaiwanCalendar  {

   public static void Main()  {

      // Creates and initializes a TaiwanCalendar.
      TaiwanCalendar myCal = new TaiwanCalendar();

      // Displays the header.
      Console.Write( "YEAR\t" );
      for ( int y = 90; y <= 94; y++ )
         Console.Write( "\t{0}", y );
      Console.WriteLine();

      // Checks five years in the current era.
      Console.Write( "CurrentEra:" );
      for ( int y = 90; y <= 94; y++ )
         Console.Write( "\t{0}", myCal.IsLeapYear( y, TaiwanCalendar.CurrentEra ) );
      Console.WriteLine();

      // Checks five years in each of the eras.
      for ( int i = 0; i < myCal.Eras.Length; i++ )  {
         Console.Write( "Era {0}:\t", myCal.Eras[i] );
         for ( int y = 90; y <= 94; y++ )
            Console.Write( "\t{0}", myCal.IsLeapYear( y, myCal.Eras[i] ) );
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
