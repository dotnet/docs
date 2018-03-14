
// The following code example displays the value of MonthDayPattern for selected cultures.
// <snippet1>
using namespace System;
using namespace System::Globalization;
void PrintPattern( String^ myCulture )
{
   CultureInfo^ MyCI = gcnew CultureInfo( myCulture,false );
   DateTimeFormatInfo^ myDTFI = MyCI->DateTimeFormat;
   Console::WriteLine( " {0} {1}", myCulture, myDTFI->MonthDayPattern );
}

int main()
{
   
   // Displays the values of the pattern properties.
   Console::WriteLine( " CULTURE    PROPERTY VALUE" );
   PrintPattern( "en-US" );
   PrintPattern( "ja-JP" );
   PrintPattern( "fr-FR" );
}

/*
This code produces the following output.  The question marks take the place of native script characters.

CULTURE    PROPERTY VALUE
en-US     MMMM dd
ja-JP     M'?'d'?'
fr-FR     d MMMM

*/
// </snippet1>
