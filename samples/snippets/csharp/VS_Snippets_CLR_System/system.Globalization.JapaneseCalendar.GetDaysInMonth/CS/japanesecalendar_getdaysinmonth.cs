// The following code example calls GetDaysInMonth for the second month in each of 5 years in each era.

// <snippet1>
using System;
using System.Globalization;


public class SamplesJapaneseCalendar  {

   public static void Main()  {

      // Creates and initializes a JapaneseCalendar.
      JapaneseCalendar myCal = new JapaneseCalendar();

      // Displays the header.
      Console.Write( "YEAR\t" );
      for ( int y = 1; y <= 5; y++ )
         Console.Write( "\t{0}", y );
      Console.WriteLine();

      // Displays the value of the CurrentEra property.
      Console.Write( "CurrentEra:" );
      for ( int y = 1; y <= 5; y++ )
         Console.Write( "\t{0}", myCal.GetDaysInMonth( y, 2, JapaneseCalendar.CurrentEra ) );
      Console.WriteLine();

      // Displays the values in the Eras property.
      for ( int i = 0; i < myCal.Eras.Length; i++ )  {
         Console.Write( "Era {0}:\t", myCal.Eras[i] );
         for ( int y = 1; y <= 5; y++ )
            Console.Write( "\t{0}", myCal.GetDaysInMonth( y, 2, myCal.Eras[i] ) );
         Console.WriteLine();
      }

   }

}

/*
This code produces the following output.

YEAR            1       2       3       4       5
CurrentEra:     28      28      28      29      28
Era 4:          28      28      28      29      28
Era 3:          28      28      29      28      28
Era 2:          29      28      28      28      29
Era 1:          29      28      28      28      29

*/
// </snippet1>
