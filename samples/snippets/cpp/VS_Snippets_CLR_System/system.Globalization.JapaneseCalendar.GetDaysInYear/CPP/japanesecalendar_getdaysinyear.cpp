
// The following code example calls GetDaysInYear for 5 years in each era.
// <snippet1>
using namespace System;
using namespace System::Globalization;
int main()
{
   
   // Creates and initializes a JapaneseCalendar.
   JapaneseCalendar^ myCal = gcnew JapaneseCalendar;
   
   // Displays the header.
   Console::Write( "YEAR\t" );
   for ( int y = 1; y <= 5; y++ )
      Console::Write( "\t {0}", y );
   Console::WriteLine();
   
   // Displays the value of the CurrentEra property.
   Console::Write( "CurrentEra:" );
   for ( int y = 1; y <= 5; y++ )
      Console::Write( "\t {0}", myCal->GetDaysInYear( y, JapaneseCalendar::CurrentEra ) );
   Console::WriteLine();
   
   // Displays the values in the Eras property.
   for ( int i = 0; i < myCal->Eras->Length; i++ )
   {
      Console::Write( "Era {0}:\t", myCal->Eras[ i ] );
      for ( int y = 1; y <= 5; y++ )
         Console::Write( "\t {0}", myCal->GetDaysInYear( y, myCal->Eras[ i ] ) );
      Console::WriteLine();

   }
}

/*
This code produces the following output.

YEAR            1       2       3       4       5
CurrentEra:     365     365     365     366     365
Era 4:          365     365     365     366     365
Era 3:          365     365     366     365     365
Era 2:          366     365     365     365     366
Era 1:          366     365     365     365     366

*/
// </snippet1>
