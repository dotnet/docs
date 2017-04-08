
// The following code example displays the values contained in the Eras property.
// <snippet1>
using namespace System;
using namespace System::Globalization;
int main()
{
   
   // Creates and initializes a JapaneseCalendar.
   JapaneseCalendar^ myCal = gcnew JapaneseCalendar;
   
   // Displays the values in the Eras property.
   for ( int i = 0; i < myCal->Eras->Length; i++ )
   {
      Console::WriteLine( "Eras[ {0}] = {1}", i, myCal->Eras[ i ] );

   }
}

/*
This code produces the following output.

Eras->Item[0] = 4
Eras->Item[1] = 3
Eras->Item[2] = 2
Eras->Item[3] = 1

*/
// </snippet1>
