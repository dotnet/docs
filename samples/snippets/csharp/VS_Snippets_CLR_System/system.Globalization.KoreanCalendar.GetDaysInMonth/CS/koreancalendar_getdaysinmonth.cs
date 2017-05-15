// The following code example calls GetDaysInMonth for the second month in each of 5 years in each era.

// <snippet1>
using System;
using System.Globalization;


public class SamplesKoreanCalendar  {

   public static void Main()  {

      // Creates and initializes a KoreanCalendar.
      KoreanCalendar myCal = new KoreanCalendar();

      // Displays the header.
      Console.Write( "YEAR\t" );
      for ( int y = 4334; y <= 4338; y++ )
         Console.Write( "\t{0}", y );
      Console.WriteLine();

      // Displays the value of the CurrentEra property.
      Console.Write( "CurrentEra:" );
      for ( int y = 4334; y <= 4338; y++ )
         Console.Write( "\t{0}", myCal.GetDaysInMonth( y, 2, KoreanCalendar.CurrentEra ) );
      Console.WriteLine();

      // Displays the values in the Eras property.
      for ( int i = 0; i < myCal.Eras.Length; i++ )  {
         Console.Write( "Era {0}:\t", myCal.Eras[i] );
         for ( int y = 4334; y <= 4338; y++ )
            Console.Write( "\t{0}", myCal.GetDaysInMonth( y, 2, myCal.Eras[i] ) );
         Console.WriteLine();
      }

   }

}

/*
This code produces the following output.

YEAR            4334    4335    4336    4337    4338
CurrentEra:     28      28      28      29      28
Era 1:          28      28      28      29      28

*/
// </snippet1>
