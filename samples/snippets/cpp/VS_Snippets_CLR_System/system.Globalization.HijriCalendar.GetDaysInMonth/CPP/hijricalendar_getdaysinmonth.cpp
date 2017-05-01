
// The following code example calls GetDaysInMonth for the twelfth month in 
// each of 5 years in each era.
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
   
   // Displays the value of the CurrentEra property.
   Console::Write( "CurrentEra:" );
   for ( int y = 1421; y <= 1425; y++ )
      Console::Write( "\t {0}", myCal->GetDaysInMonth( y, 12, HijriCalendar::CurrentEra ) );
   Console::WriteLine();
   
   // Displays the values in the Eras property.
   for ( int i = 0; i < myCal->Eras->Length; i++ )
   {
      Console::Write( "Era {0}:\t", myCal->Eras[ i ] );
      for ( int y = 1421; y <= 1425; y++ )
         Console::Write( "\t {0}", myCal->GetDaysInMonth( y, 12, myCal->Eras[ i ] ) );
      Console::WriteLine();

   }
}

/*
This code produces the following output. The results might vary depending on
the settings in Regional and Language Options (or Regional Options or Regional Settings).

YEAR            1421    1422    1423    1424    1425
CurrentEra:     29      29      30      29      29
Era 1:          29      29      30      29      29

*/
// </snippet1>
