
// The following code example displays the value of LongDatePattern for selected cultures.
// <snippet1>
using namespace System;
using namespace System::Globalization;
void PrintPattern( String^ myCulture )
{
   CultureInfo^ MyCI = gcnew CultureInfo( myCulture,false );
   DateTimeFormatInfo^ myDTFI = MyCI->DateTimeFormat;
   Console::WriteLine( " {0} {1}", myCulture, myDTFI->LongDatePattern );
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
en-US     dddd, MMMM dd, yyyy
ja-JP     yyyy'?'M'?'d'?'
fr-FR     dddd d MMMM yyyy

*/
// </snippet1>
