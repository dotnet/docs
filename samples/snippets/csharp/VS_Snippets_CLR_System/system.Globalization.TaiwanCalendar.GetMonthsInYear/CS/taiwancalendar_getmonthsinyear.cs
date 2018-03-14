// The following code example calls GetMonthsInYear for 5 years in each era.

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

      // Displays the value of the CurrentEra property.
      Console.Write( "CurrentEra:" );
      for ( int y = 90; y <= 94; y++ )
         Console.Write( "\t{0}", myCal.GetMonthsInYear( y, TaiwanCalendar.CurrentEra ) );
      Console.WriteLine();

      // Displays the values in the Eras property.
      for ( int i = 0; i < myCal.Eras.Length; i++ )  {
         Console.Write( "Era {0}:\t", myCal.Eras[i] );
         for ( int y = 90; y <= 94; y++ )
            Console.Write( "\t{0}", myCal.GetMonthsInYear( y, myCal.Eras[i] ) );
         Console.WriteLine();
      }

   }

}

/*
This code produces the following output.

YEAR            90      91      92      93      94
CurrentEra:     12      12      12      12      12
Era 1:          12      12      12      12      12

*/
// </snippet1>
