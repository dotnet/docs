// The following code example calls IsLeapYear for five years in each of the eras.

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

      // Checks five years in the current era.
      Console.Write( "CurrentEra:" );
      for ( int y = 4334; y <= 4338; y++ )
         Console.Write( "\t{0}", myCal.IsLeapYear( y, KoreanCalendar.CurrentEra ) );
      Console.WriteLine();

      // Checks five years in each of the eras.
      for ( int i = 0; i < myCal.Eras.Length; i++ )  {
         Console.Write( "Era {0}:\t", myCal.Eras[i] );
         for ( int y = 4334; y <= 4338; y++ )
            Console.Write( "\t{0}", myCal.IsLeapYear( y, myCal.Eras[i] ) );
         Console.WriteLine();
      }

   }

}

/*
This code produces the following output.

YEAR            4334    4335    4336    4337    4338
CurrentEra:     False   False   False   True    False
Era 1:          False   False   False   True    False

*/
// </snippet1>
