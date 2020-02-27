
// The following code example calls IsLeapYear for five years in each of the eras.
// <snippet1>
using namespace System;
using namespace System::Globalization;
int main()
{
   
   // Creates and initializes a ThaiBuddhistCalendar.
   ThaiBuddhistCalendar^ myCal = gcnew ThaiBuddhistCalendar;
   
   // Displays the header.
   Console::Write( "YEAR\t" );
   for ( int y = 2544; y <= 2548; y++ )
      Console::Write( "\t {0}", y );
   Console::WriteLine();
   
   // Checks five years in the current era.
   Console::Write( "CurrentEra:" );
   for ( int y = 2544; y <= 2548; y++ )
      Console::Write( "\t {0}", myCal->IsLeapYear( y, ThaiBuddhistCalendar::CurrentEra ) );
   Console::WriteLine();
   
   // Checks five years in each of the eras.
   for ( int i = 0; i < myCal->Eras->Length; i++ )
   {
      Console::Write( "Era {0}:\t", myCal->Eras[ i ] );
      for ( int y = 2544; y <= 2548; y++ )
         Console::Write( "\t {0}", myCal->IsLeapYear( y, myCal->Eras[ i ] ) );
      Console::WriteLine();

   }
}

/*
This code produces the following output.

YEAR            2544    2545    2546    2547    2548
CurrentEra:     False   False   False   True    False
Era 1:          False   False   False   True    False

*/
// </snippet1>
