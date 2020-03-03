
// The following code example calls IsLeapMonth for all the months in five years in the current era.
// <snippet1>
using namespace System;
using namespace System::Globalization;
int main()
{
   
   // Creates and initializes a KoreanCalendar.
   KoreanCalendar^ myCal = gcnew KoreanCalendar;
   
   // Checks all the months in five years in the current era.
   int iMonthsInYear;
   for ( int y = 4334; y <= 4338; y++ )
   {
      Console::Write( " {0}:\t", y );
      iMonthsInYear = myCal->GetMonthsInYear( y, KoreanCalendar::CurrentEra );
      for ( int m = 1; m <= iMonthsInYear; m++ )
         Console::Write( "\t {0}", myCal->IsLeapMonth( y, m, KoreanCalendar::CurrentEra ) );
      Console::WriteLine();

   }
}

/*
This code produces the following output.

4334:           False   False   False   False   False   False   False   False   False   False   False   False
4335:           False   False   False   False   False   False   False   False   False   False   False   False
4336:           False   False   False   False   False   False   False   False   False   False   False   False
4337:           False   False   False   False   False   False   False   False   False   False   False   False
4338:           False   False   False   False   False   False   False   False   False   False   False   False

*/
// </snippet1>
