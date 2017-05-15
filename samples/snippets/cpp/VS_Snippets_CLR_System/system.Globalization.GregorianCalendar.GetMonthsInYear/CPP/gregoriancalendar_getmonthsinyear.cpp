
// The following code example calls GetMonthsInYear for 5 years in each era.
// <snippet1>
using namespace System;
using namespace System::Globalization;
int main()
{
   
   // Creates and initializes a GregorianCalendar.
   GregorianCalendar^ myCal = gcnew GregorianCalendar;
   
   // Displays the header.
   Console::Write( "YEAR\t" );
   for ( int y = 2001; y <= 2005; y++ )
      Console::Write( "\t {0}", y );
   Console::WriteLine();
   
   // Displays the value of the CurrentEra property.
   Console::Write( "CurrentEra:" );
   for ( int y = 2001; y <= 2005; y++ )
      Console::Write( "\t {0}", myCal->GetMonthsInYear( y, GregorianCalendar::CurrentEra ) );
   Console::WriteLine();
   
   // Displays the values in the Eras property.
   for ( int i = 0; i < myCal->Eras->Length; i++ )
   {
      Console::Write( "Era {0}:\t", myCal->Eras[ i ] );
      for ( int y = 2001; y <= 2005; y++ )
         Console::Write( "\t {0}", myCal->GetMonthsInYear( y, myCal->Eras[ i ] ) );
      Console::WriteLine();

   }
}

/*
This code produces the following output.

YEAR            2001    2002    2003    2004    2005
CurrentEra:     12      12      12      12      12
Era 1:          12      12      12      12      12

*/
// </snippet1>
