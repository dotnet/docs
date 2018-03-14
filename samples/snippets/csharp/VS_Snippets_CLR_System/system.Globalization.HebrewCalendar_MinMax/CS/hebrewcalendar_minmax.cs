// The following code example gets the minimum date and the maximum date of the calendar.

// <snippet1>
using System;
using System.Globalization;


public class SamplesCalendar  {

   public static void Main()  {

      // Create an instance of the calendar.
      HebrewCalendar myCal = new HebrewCalendar();
      Console.WriteLine( myCal.ToString() );

      // Create an instance of the GregorianCalendar.
      GregorianCalendar myGre = new GregorianCalendar();

      // Display the MinSupportedDateTime and its equivalent in the GregorianCalendar.
      DateTime myMin = myCal.MinSupportedDateTime;
      Console.Write( "MinSupportedDateTime: {0:D2}/{1:D2}/{2:D4}", myCal.GetMonth(myMin), myCal.GetDayOfMonth(myMin), myCal.GetYear(myMin) );
      Console.WriteLine( " (in Gregorian, {0:D2}/{1:D2}/{2:D4})", myGre.GetMonth(myMin), myGre.GetDayOfMonth(myMin), myGre.GetYear(myMin) );

      // Display the MaxSupportedDateTime and its equivalent in the GregorianCalendar.
      DateTime myMax = myCal.MaxSupportedDateTime;
      Console.Write( "MaxSupportedDateTime: {0:D2}/{1:D2}/{2:D4}", myCal.GetMonth(myMax), myCal.GetDayOfMonth(myMax), myCal.GetYear(myMax) );
      Console.WriteLine( " (in Gregorian, {0:D2}/{1:D2}/{2:D4})", myGre.GetMonth(myMax), myGre.GetDayOfMonth(myMax), myGre.GetYear(myMax) );

   }

}


/*
This code produces the following output.

System.Globalization.HebrewCalendar
MinSupportedDateTime: 04/07/5343 (in Gregorian, 01/01/1583)
MaxSupportedDateTime: 13/29/5999 (in Gregorian, 09/29/2239)

*/
// </snippet1>
