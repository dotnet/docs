
// The following code example calls IsLeapMonth for all the months in five years 
// in the current era.
// <snippet1>
using namespace System;
using namespace System::Globalization;
int main()
{
   
   // Creates and initializes a GregorianCalendar.
   GregorianCalendar^ myCal = gcnew GregorianCalendar;
   
   // Checks all the months in five years in the current era.
   int iMonthsInYear;
   for ( int y = 2001; y <= 2005; y++ )
   {
      Console::Write( " {0}:\t", y );
      iMonthsInYear = myCal->GetMonthsInYear( y, GregorianCalendar::CurrentEra );
      for ( int m = 1; m <= iMonthsInYear; m++ )
         Console::Write( "\t {0}", myCal->IsLeapMonth( y, m, GregorianCalendar::CurrentEra ) );
      Console::WriteLine();

   }
}

/*
This code produces the following output.

2001:           False   False   False   False   False   False   False   False   False   False   False   False
2002:           False   False   False   False   False   False   False   False   False   False   False   False
2003:           False   False   False   False   False   False   False   False   False   False   False   False
2004:           False   False   False   False   False   False   False   False   False   False   False   False
2005:           False   False   False   False   False   False   False   False   False   False   False   False

*/
// </snippet1>
