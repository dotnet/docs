
// The following code example calls IsLeapYear for five years in each of the eras.
// <snippet1>
using namespace System;
using namespace System::Globalization;
int main()
{
   
   // Creates and initializes a HijriCalendar.
   HijriCalendar^ myCal = gcnew HijriCalendar;
   
   // Displays the header.
   Console::Write( "YEAR\t" );
   for ( int y = 1421; y <= 1425; y++ )
      Console::Write( "\t {0}", y );
   Console::WriteLine();
   
   // Checks five years in the current era.
   Console::Write( "CurrentEra:" );
   for ( int y = 1421; y <= 1425; y++ )
      Console::Write( "\t {0}", myCal->IsLeapYear( y, HijriCalendar::CurrentEra ) );
   Console::WriteLine();
   
   // Checks five years in each of the eras.
   for ( int i = 0; i < myCal->Eras->Length; i++ )
   {
      Console::Write( "Era {0}:\t", myCal->Eras[ i ] );
      for ( int y = 1421; y <= 1425; y++ )
         Console::Write( "\t {0}", myCal->IsLeapYear( y, myCal->Eras[ i ] ) );
      Console::WriteLine();

   }
}

/*
This code produces the following output.

YEAR            1421    1422    1423    1424    1425
CurrentEra:     False   False   True    False   False
Era 1:          False   False   True    False   False

*/
// </snippet1>
