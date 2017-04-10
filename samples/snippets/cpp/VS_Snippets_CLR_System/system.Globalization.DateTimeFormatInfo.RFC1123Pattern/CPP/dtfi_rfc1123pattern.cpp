
// The following code example displays the value of RFC1123Pattern for selected cultures.
// <snippet1>
using namespace System;
using namespace System::Globalization;
void PrintPattern( String^ myCulture )
{
   CultureInfo^ MyCI = gcnew CultureInfo( myCulture,false );
   DateTimeFormatInfo^ myDTFI = MyCI->DateTimeFormat;
   Console::WriteLine( " {0} {1}", myCulture, myDTFI->RFC1123Pattern );
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
en-US     ddd, dd MMM yyyy HH':'mm':'ss 'GMT'
ja-JP     ddd, dd MMM yyyy HH':'mm':'ss 'GMT'
fr-FR     ddd, dd MMM yyyy HH':'mm':'ss 'GMT'

*/
// </snippet1>
