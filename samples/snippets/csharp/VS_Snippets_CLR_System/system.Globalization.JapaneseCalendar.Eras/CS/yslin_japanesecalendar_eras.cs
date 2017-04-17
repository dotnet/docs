// The following code example displays the values contained in the Eras property.


// <snippet1>
using System;
using System.Globalization;


public class SamplesJapaneseCalendar  {

   public static void Main()  {

      // Creates and initializes a JapaneseCalendar.
      JapaneseCalendar myCal = new JapaneseCalendar();

      // Displays the values in the Eras property.
      for ( int i = 0; i < myCal.Eras.Length; i++ )  {
         Console.WriteLine( "Eras[{0}] = {1}", i, myCal.Eras[i] );
      }

   }

}

/*
This code produces the following output.

Eras[0] = 4
Eras[1] = 3
Eras[2] = 2
Eras[3] = 1

*/
// </snippet1>
