
//<Snippet1>
// Sample for the Decimal::ToString( ) methods.
using namespace System;
using namespace System::Globalization;
using namespace System::Collections;
int main()
{
   Decimal nineBillPlus = Convert::ToDecimal( "9876543210.9876543210" );
   Console::WriteLine( "This example of\n"
   "   Decimal::ToString( ), \n"
   "   Decimal::ToString( String* ),\n"
   "   Decimal::ToString( IFormatProvider* ), and \n"
   "   Decimal::ToString( String*, IFormatProvider* )\n"
   "generates the following output when run in the "
   "[{0}] culture.\nDecimal numbers are formatted "
   "with various combinations \nof format strings "
   "and IFormatProvider.", CultureInfo::CurrentCulture->Name );
   
   // Format the number without and with format strings.
   Console::WriteLine( "\nIFormatProvider is not "
   "used; the default culture is [{0}]:", CultureInfo::CurrentCulture->Name );
   Console::WriteLine( "   {0,-30}{1}", "No format string:", nineBillPlus.ToString() );
   Console::WriteLine( "   {0,-30}{1}", "'N' format string:", nineBillPlus.ToString( "N" ) );
   Console::WriteLine( "   {0,-30}{1}", "'N5' format string:", nineBillPlus.ToString( "N5" ) );
   
   // Create a CultureInfo object for another culture. Use
   // [Dutch - The Netherlands] unless the current culture
   // is Dutch language. In that case use [English - U.S.].
   String^ cultureName = CultureInfo::CurrentCulture->Name->Substring( 0, 2 )->Equals( "nl" ) ? (String^)"en-US" : "nl-NL";
   CultureInfo^ culture = gcnew CultureInfo( cultureName );
   
   // Use the CultureInfo object for an IFormatProvider.
   Console::WriteLine( "\nA CultureInfo object "
   "for [{0}] is used for the IFormatProvider: ", cultureName );
   Console::WriteLine( "   {0,-30}{1}", "No format string:", nineBillPlus.ToString( culture ) );
   Console::WriteLine( "   {0,-30}{1}", "'N5' format string:", nineBillPlus.ToString( "N5", culture ) );
   
   // Get the NumberFormatInfo object from CultureInfo, and
   // then change the digit group size to 4 and the digit
   // separator to '_'.
   NumberFormatInfo^ numInfo = culture->NumberFormat;
   array<Int32>^sizes = {4};
   numInfo->NumberGroupSizes = sizes;
   numInfo->NumberGroupSeparator = "_";
   
   // Use a NumberFormatInfo object for IFormatProvider.
   Console::WriteLine( "\nA NumberFormatInfo object with digit group "
   "size = 4 and \ndigit separator "
   "= '_' is used for the IFormatProvider:" );
   Console::WriteLine( "   {0,-30}{1}", "'N5' format string:", nineBillPlus.ToString( "N5", culture ) );
}

/*
This example of
   Decimal::ToString( ),
   Decimal::ToString( String* ),
   Decimal::ToString( IFormatProvider* ), and
   Decimal::ToString( String*, IFormatProvider* )
generates the following output when run in the [en-US] culture.
Decimal numbers are formatted with various combinations
of format strings and IFormatProvider.

IFormatProvider is not used; the default culture is [en-US]:
   No format string:             9876543210.9876543210
   'N' format string:            9,876,543,210.99
   'N5' format string:           9,876,543,210.98765

A CultureInfo object for [nl-NL] is used for the IFormatProvider:
   No format string:             9876543210,9876543210
   'N5' format string:           9.876.543.210,98765

A NumberFormatInfo object with digit group size = 4 and
digit separator = '_' is used for the IFormatProvider:
   'N5' format string:           98_7654_3210,98765
*/
//</Snippet1>
