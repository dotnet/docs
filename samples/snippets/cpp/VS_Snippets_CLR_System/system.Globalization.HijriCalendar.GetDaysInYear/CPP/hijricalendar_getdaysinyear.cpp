
// The following code example calls GetDaysInYear for 5 years in each era.
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
      Console::Write( "\t {0}", myCal->GetDaysInYear( y, HijriCalendar::CurrentEra ) );
   Console::WriteLine();
   
   // Displays the values in the Eras property.
   for ( int i = 0; i < myCal->Eras->Length; i++ )
   {
      Console::Write( "Era {0}:\t", myCal->Eras[ i ] );
      for ( int y = 1421; y <= 1425; y++ )
         Console::Write( "\t {0}", myCal->GetDaysInYear( y, myCal->Eras[ i ] ) );
      Console::WriteLine();

   }
}

/*
This code produces the following output. The results might vary depending on
the settings in Regional and Language Options (or Regional Options or Regional Settings).

YEAR            1421    1422    1423    1424    1425
CurrentEra:     354     354     355     354     354
Era 1:          354     354     355     354     354

*/
// </snippet1>
