
//<Snippet1>
// Example for the Byte::ToString( ) methods.
using namespace System;
using namespace System::Globalization;
void RunToStringDemo()
{
   Byte smallValue = 13;
   Byte largeValue = 234;
   
   // Format the Byte values without and with format strings.
   Console::WriteLine( "\nIFormatProvider is not used:" );
   Console::WriteLine( "   {0,-20}{1,10}{2,10}", "No format string:", smallValue.ToString(), largeValue.ToString() );
   Console::WriteLine( "   {0,-20}{1,10}{2,10}", "'X2' format string:", smallValue.ToString( "X2" ), largeValue.ToString( "X2" ) );
   
   // Get the NumberFormatInfo object from the invariant culture.
   CultureInfo^ culture = gcnew CultureInfo( "" );
   NumberFormatInfo^ numInfo = culture->NumberFormat;
   
   // Set the digit grouping to 1, set the digit separator
   // to underscore, and set decimal digits to 0.
   array<Int32>^sizes = {1};
   numInfo->NumberGroupSizes = sizes;
   numInfo->NumberGroupSeparator = "_";
   numInfo->NumberDecimalDigits = 0;
   
   // Use the NumberFormatInfo object for an IFormatProvider.
   Console::WriteLine( "\nA NumberFormatInfo object with digit group "
   "size = 1 and \ndigit separator "
   "= '_' is used for the IFormatProvider:" );
   Console::WriteLine( "   {0,-20}{1,10}{2,10}", "No format string:", smallValue.ToString( numInfo ), largeValue.ToString( numInfo ) );
   Console::WriteLine( "   {0,-20}{1,10}{2,10}", "'N' format string:", smallValue.ToString( "N", numInfo ), largeValue.ToString( "N", numInfo ) );
}

int main()
{
   Console::WriteLine( "This example of\n   Byte::ToString( ),\n"
   "   Byte::ToString( String* ),\n"
   "   Byte::ToString( IFormatProvider* ), and\n"
   "   Byte::ToString( String*, IFormatProvider* )\n"
   "generates the following output when formatting "
   "Byte values \nwith combinations of format "
   "strings and IFormatProvider." );
   RunToStringDemo();
}

/*
This example of
   Byte::ToString( ),
   Byte::ToString( String* ),
   Byte::ToString( IFormatProvider* ), and
   Byte::ToString( String*, IFormatProvider* )
generates the following output when formatting Byte values
with combinations of format strings and IFormatProvider.

IFormatProvider is not used:
   No format string:           13       234
   'X2' format string:         0D        EA

A NumberFormatInfo object with digit group size = 1 and
digit separator = '_' is used for the IFormatProvider:
   No format string:           13       234
   'N' format string:         1_3     2_3_4
*/
//</Snippet1>
