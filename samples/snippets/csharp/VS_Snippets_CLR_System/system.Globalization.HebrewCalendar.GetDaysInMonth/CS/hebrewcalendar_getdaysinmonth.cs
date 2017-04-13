// The following code example calls GetDaysInMonth for the second month in each of 5 years in each era.

// <snippet1>
using System;
using System.Globalization;


public class SamplesHebrewCalendar  {

   public static void Main()  {

      // Creates and initializes a HebrewCalendar.
      HebrewCalendar myCal = new HebrewCalendar();

      // Displays the header.
      Console.Write( "YEAR\t" );
      for ( int y = 5761; y <= 5765; y++ )
         Console.Write( "\t{0}", y );
      Console.WriteLine();

      // Displays the value of the CurrentEra property.
      Console.Write( "CurrentEra:" );
      for ( int y = 5761; y <= 5765; y++ )
         Console.Write( "\t{0}", myCal.GetDaysInMonth( y, 2, HebrewCalendar.CurrentEra ) );
      Console.WriteLine();

      // Displays the values in the Eras property.
      for ( int i = 0; i < myCal.Eras.Length; i++ )  {
         Console.Write( "Era {0}:\t", myCal.Eras[i] );
         for ( int y = 5761; y <= 5765; y++ )
            Console.Write( "\t{0}", myCal.GetDaysInMonth( y, 2, myCal.Eras[i] ) );
         Console.WriteLine();
      }

   }

}

/*
This code produces the following output.

YEAR            5761    5762    5763    5764    5765
CurrentEra:     29      29      30      30      29
Era 1:          29      29      30      30      29

*/
// </snippet1>
