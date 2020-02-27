
// The following code example displays the value of SortableDateTimePattern for selected cultures.
// <snippet1>
using namespace System;
using namespace System::Globalization;
void PrintPattern( String^ myCulture )
{
   CultureInfo^ MyCI = gcnew CultureInfo( myCulture,false );
   DateTimeFormatInfo^ myDTFI = MyCI->DateTimeFormat;
   Console::WriteLine( " {0} {1}", myCulture, myDTFI->SortableDateTimePattern );
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
This code produces the following output.

CULTURE    PROPERTY VALUE
en-US     yyyy'-'MM'-'dd'T'HH':'mm':'ss
ja-JP     yyyy'-'MM'-'dd'T'HH':'mm':'ss
fr-FR     yyyy'-'MM'-'dd'T'HH':'mm':'ss

*/
// </snippet1>
