
// The following code example calls IsLeapMonth for all the months 
// in five years in the current era.
// <snippet1>
using namespace System;
using namespace System::Globalization;
int main()
{
   
   // Creates and initializes a JapaneseCalendar.
   JapaneseCalendar^ myCal = gcnew JapaneseCalendar;
   
   // Checks all the months in five years in the current era.
   int iMonthsInYear;
   for ( int y = 1; y <= 5; y++ )
   {
      Console::Write( " {0}:\t", y );
      iMonthsInYear = myCal->GetMonthsInYear( y, JapaneseCalendar::CurrentEra );
      for ( int m = 1; m <= iMonthsInYear; m++ )
         Console::Write( "\t {0}", myCal->IsLeapMonth( y, m, JapaneseCalendar::CurrentEra ) );
      Console::WriteLine();

   }
}

/*
This code produces the following output.

1:              False   False   False   False   False   False   False   False   False   False   False   False
2:              False   False   False   False   False   False   False   False   False   False   False   False
3:              False   False   False   False   False   False   False   False   False   False   False   False
4:              False   False   False   False   False   False   False   False   False   False   False   False
5:              False   False   False   False   False   False   False   False   False   False   False   False

*/
// </snippet1>
