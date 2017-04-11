
// The following code example displays the value of UniversalSortableDateTimePattern 
// for selected cultures.
// <snippet1>
using namespace System;
using namespace System::Globalization;
void PrintPattern( String^ myCulture )
{
   CultureInfo^ MyCI = gcnew CultureInfo( myCulture,false );
   DateTimeFormatInfo^ myDTFI = MyCI->DateTimeFormat;
   Console::WriteLine( " {0} {1}", myCulture, myDTFI->UniversalSortableDateTimePattern );
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
en-US     yyyy'-'MM'-'dd HH':'mm':'ss'Z'
ja-JP     yyyy'-'MM'-'dd HH':'mm':'ss'Z'
fr-FR     yyyy'-'MM'-'dd HH':'mm':'ss'Z'

*/
// </snippet1>
