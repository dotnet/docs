
// The following code example calls IsLeapMonth for all the months in five years in the current era.
// <snippet1>
using namespace System;
using namespace System::Globalization;
int main()
{
   
   // Creates and initializes a ThaiBuddhistCalendar.
   ThaiBuddhistCalendar^ myCal = gcnew ThaiBuddhistCalendar;
   
   // Checks all the months in five years in the current era.
   int iMonthsInYear;
   for ( int y = 2544; y <= 2548; y++ )
   {
      Console::Write( " {0}:\t", y );
      iMonthsInYear = myCal->GetMonthsInYear( y, ThaiBuddhistCalendar::CurrentEra );
      for ( int m = 1; m <= iMonthsInYear; m++ )
         Console::Write( "\t {0}", myCal->IsLeapMonth( y, m, ThaiBuddhistCalendar::CurrentEra ) );
      Console::WriteLine();

   }
}

/*
This code produces the following output.

2544:           False   False   False   False   False   False   False   False   False   False   False   False
2545:           False   False   False   False   False   False   False   False   False   False   False   False
2546:           False   False   False   False   False   False   False   False   False   False   False   False
2547:           False   False   False   False   False   False   False   False   False   False   False   False
2548:           False   False   False   False   False   False   False   False   False   False   False   False

*/
// </snippet1>
