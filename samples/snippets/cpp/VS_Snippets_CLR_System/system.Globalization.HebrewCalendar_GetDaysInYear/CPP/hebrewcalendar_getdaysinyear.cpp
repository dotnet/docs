
// The following code example calls GetDaysInYear for 5 years in each era.
// <snippet1>
using namespace System;
using namespace System::Globalization;
int main()
{
   
   // Creates and initializes a HebrewCalendar.
   HebrewCalendar^ myCal = gcnew HebrewCalendar;
   
   // Displays the header.
   Console::Write( "YEAR\t" );
   for ( int y = 5761; y <= 5765; y++ )
      Console::Write( "\t {0}", y );
   Console::WriteLine();
   
   // Displays the value of the CurrentEra property.
   Console::Write( "CurrentEra:" );
   for ( int y = 5761; y <= 5765; y++ )
      Console::Write( "\t {0}", myCal->GetDaysInYear( y, HebrewCalendar::CurrentEra ) );
   Console::WriteLine();
   
   // Displays the values in the Eras property.
   for ( int i = 0; i < myCal->Eras->Length; i++ )
   {
      Console::Write( "Era {0}:\t", myCal->Eras[ i ] );
      for ( int y = 5761; y <= 5765; y++ )
         Console::Write( "\t {0}", myCal->GetDaysInYear( y, myCal->Eras[ i ] ) );
      Console::WriteLine();

   }
}

/*
This code produces the following output.

YEAR            5761    5762    5763    5764    5765
CurrentEra:     353     354     385     355     383
Era 1:          353     354     385     355     383

*/
// </snippet1>
