
//<Snippet1>
// Example of the Single::Parse( ) methods.
using namespace System;
using namespace System::Globalization;
using namespace System::Collections;

// Get the exception type name; remove the namespace prefix.
String^ GetExceptionType( Exception^ ex )
{
   String^ exceptionType = ex->GetType()->ToString();
   return exceptionType->Substring( exceptionType->LastIndexOf( '.' ) + 1 );
}


// Parse each string in the singleFormats array, using 
// NumberStyles and IFormatProvider, if specified.
void SingleParse( NumberStyles styles, IFormatProvider^ provider )
{
   array<String^>^singleFormats = gcnew array<String^>(6);
   singleFormats[ 0 ] = " 987.654E-2";
   singleFormats[ 1 ] = "987,654E-2 ";
   singleFormats[ 2 ] = "(98765,43210)";
   singleFormats[ 3 ] = "9,876,543.210";
   singleFormats[ 4 ] = "9.876.543,210";
   singleFormats[ 5 ] = "98_76_54_32,19";
   
   // Code foreach( String* singleString in singleFormats ).
   IEnumerator^ myEnum = singleFormats->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      String^ singleString = safe_cast<String^>(myEnum->Current);
      float singleNumber;
      
      // Display the first part of the output line.
      Console::Write( "  Parse of {0,-20}", String::Format( "\"{0}\"", singleString ) );
      try
      {
         
         // Use the appropriate Single::Parse overload, based on 
         // the parameters that are specified.
         if ( provider == (IFormatProvider^)nullptr )
         {
            if ( (int)styles < 0 )
                        singleNumber = Single::Parse( singleString );
            else
                        singleNumber = Single::Parse( singleString, styles );
         }
         else
         if ( (int)styles < 0 )
                  singleNumber = Single::Parse( singleString, provider );
         else
                  singleNumber = Single::Parse( singleString, styles, provider );
         
         // Display the resulting value if Parse succeeded.
         Console::WriteLine( "success: {0}", singleNumber );
      }
      catch ( Exception^ ex ) 
      {
         
         // Display the exception type if Parse failed.
         Console::WriteLine( "failed:  {0}", GetExceptionType( ex ) );
      }

   }
}

int main()
{
   IFormatProvider^ null = nullptr;
   Console::WriteLine( "This example of\n"
   "  Single::Parse( String* ),\n"
   "  Single::Parse( String*, NumberStyles ),\n"
   "  Single::Parse( String*, IFormatProvider* ), and\n"
   "  Single::Parse( String*, NumberStyles, "
   "IFormatProvider* )\ngenerates the "
   "following output when run in the [{0}] culture.", CultureInfo::CurrentCulture->Name );
   Console::WriteLine( "Several string representations "
   "of Single values are parsed." );
   
   // Do not use IFormatProvider or NumberStyles.
   Console::WriteLine( "\nNumberStyles and IFormatProvider "
   "are not used; current culture is [{0}]:", CultureInfo::CurrentCulture->Name );
   SingleParse( ((NumberStyles)( -1)), nullptr );
   
   // Use the NumberStyle for Currency.
   Console::WriteLine( "\nNumberStyles::Currency "
   "is used; IFormatProvider is not used:" );
   SingleParse( NumberStyles::Currency, nullptr );
   
   // Create a CultureInfo object for another culture. Use
   // [Dutch - The Netherlands] unless the current culture
   // is Dutch language. In that case use [English - U.S.].
   String^ cultureName = CultureInfo::CurrentCulture->Name->Substring( 0, 2 )->Equals( "nl" ) ? (String^)"en-US" : "nl-NL";
   CultureInfo^ culture = gcnew CultureInfo( cultureName );
   Console::WriteLine( "\nNumberStyles is not used; "
   "[{0}] culture IFormatProvider is used:", culture->Name );
   SingleParse( ((NumberStyles)( -1)), culture );
   
   // Get the NumberFormatInfo object from CultureInfo, and
   // then change the digit group size to 2 and the digit
   // separator to '_'.
   NumberFormatInfo^ numInfo = culture->NumberFormat;
   array<Int32>^sizes = {2};
   numInfo->NumberGroupSizes = sizes;
   numInfo->NumberGroupSeparator = "_";
   
   // Use the NumberFormatInfo object as the IFormatProvider.
   Console::WriteLine( "\nNumberStyles::Currency is used, "
   "group size = 2, separator = \"_\":" );
   SingleParse( NumberStyles::Currency, numInfo );
}

/*
This example of
  Single::Parse( String* ),
  Single::Parse( String*, NumberStyles ),
  Single::Parse( String*, IFormatProvider* ), and
  Single::Parse( String*, NumberStyles, IFormatProvider* )
generates the following output when run in the [en-US] culture.
Several string representations of Single values are parsed.

NumberStyles and IFormatProvider are not used; current culture is [en-US]:
  Parse of " 987.654E-2"       success: 9.87654
  Parse of "987,654E-2 "       success: 9876.54
  Parse of "(98765,43210)"     failed:  FormatException
  Parse of "9,876,543.210"     success: 9876543
  Parse of "9.876.543,210"     failed:  FormatException
  Parse of "98_76_54_32,19"    failed:  FormatException

NumberStyles::Currency is used; IFormatProvider is not used:
  Parse of " 987.654E-2"       failed:  FormatException
  Parse of "987,654E-2 "       failed:  FormatException
  Parse of "(98765,43210)"     success: -9.876543E+09
  Parse of "9,876,543.210"     success: 9876543
  Parse of "9.876.543,210"     failed:  FormatException
  Parse of "98_76_54_32,19"    failed:  FormatException

NumberStyles is not used; [nl-NL] culture IFormatProvider is used:
  Parse of " 987.654E-2"       success: 9876.54
  Parse of "987,654E-2 "       success: 9.87654
  Parse of "(98765,43210)"     failed:  FormatException
  Parse of "9,876,543.210"     failed:  FormatException
  Parse of "9.876.543,210"     success: 9876543
  Parse of "98_76_54_32,19"    failed:  FormatException

NumberStyles::Currency is used, group size = 2, separator = "_":
  Parse of " 987.654E-2"       failed:  FormatException
  Parse of "987,654E-2 "       failed:  FormatException
  Parse of "(98765,43210)"     success: -98765.43
  Parse of "9,876,543.210"     failed:  FormatException
  Parse of "9.876.543,210"     success: 9876543
  Parse of "98_76_54_32,19"    success: 9.876543E+07
*/
//</Snippet1>
