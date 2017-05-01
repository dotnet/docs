
// The following code example calls IsLeapDay for the last day of the second 
// month (February) for five years in each of the eras.
// <snippet1>
using namespace System;
using namespace System::Globalization;
int main()
{
   
   // Creates and initializes a GregorianCalendar.
   GregorianCalendar^ myCal = gcnew GregorianCalendar;
   
   // Creates a holder for the last day of the second month (February).
   int iLastDay;
   
   // Displays the header.
   Console::Write( "YEAR\t" );
   for ( int y = 2001; y <= 2005; y++ )
      Console::Write( "\t {0}", y );
   Console::WriteLine();
   
   // Checks five years in the current era.
   Console::Write( "CurrentEra:" );
   for ( int y = 2001; y <= 2005; y++ )
   {
      iLastDay = myCal->GetDaysInMonth( y, 2, GregorianCalendar::CurrentEra );
      Console::Write( "\t {0}", myCal->IsLeapDay( y, 2, iLastDay, GregorianCalendar::CurrentEra ) );

   }
   Console::WriteLine();
   
   // Checks five years in each of the eras.
   for ( int i = 0; i < myCal->Eras->Length; i++ )
   {
      Console::Write( "Era {0}:\t", myCal->Eras[ i ] );
      for ( int y = 2001; y <= 2005; y++ )
      {
         iLastDay = myCal->GetDaysInMonth( y, 2, myCal->Eras[ i ] );
         Console::Write( "\t {0}", myCal->IsLeapDay( y, 2, iLastDay, myCal->Eras[ i ] ) );

      }
      Console::WriteLine();

   }
}

/*
This code produces the following output.

YEAR            2001    2002    2003    2004    2005
CurrentEra:     False   False   False   True    False
Era 1:          False   False   False   True    False

*/
// </snippet1>
