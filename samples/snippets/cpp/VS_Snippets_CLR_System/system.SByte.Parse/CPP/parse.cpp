
//<Snippet1>
// Example of the SByte::Parse( ) methods.
using namespace System;
using namespace System::Globalization;
using namespace System::Collections;
void SByteParse( NumberStyles styles, IFormatProvider^ provider )
{
   array<String^>^sbyteFormats = gcnew array<String^>(6);
   sbyteFormats[ 0 ] = " 99 ";
   sbyteFormats[ 1 ] = " +123 ";
   sbyteFormats[ 2 ] = " (123) ";
   sbyteFormats[ 3 ] = " -123 ";
   sbyteFormats[ 4 ] = " 1_2_3";
   sbyteFormats[ 5 ] = " 7E ";
   
   // Parse each string in the sbyteFormats array, using 
   // NumberStyles and IFormatProvider, if specified.
   // Implements foreach( String* sbyteString in sbyteFormats ).
   IEnumerator^ myEnum = sbyteFormats->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      String^ sbyteString = safe_cast<String^>(myEnum->Current);
      SByte sbyteNumber;
      
      // Display the first part of the output line.
      Console::Write(  "  Parse of {0,-12}", String::Format(  "\"{0}\"", sbyteString ) );
      try
      {
         
         // Use the appropriate SByte.Parse overload, based 
         // on the parameters that are specified.
         if ( provider == (IFormatProvider^)nullptr )
                  if ( (int)styles < 0 )
                  sbyteNumber = SByte::Parse( sbyteString );
         else
                  sbyteNumber = SByte::Parse( sbyteString, styles );
         else
         if ( (int)styles < 0 )
                  sbyteNumber = SByte::Parse( sbyteString, provider );
         else
                  sbyteNumber = SByte::Parse( sbyteString, styles, provider );
         
         // Display the resulting value if Parse succeeded.
         Console::WriteLine( "succeeded: {0}", sbyteNumber );
      }
      catch ( Exception^ ex ) 
      {
         
         // Display the exception message if Parse failed.
         Console::WriteLine( "failed: {0}", ex->Message );
      }

   }
}

void RunParseDemo()
{
   IFormatProvider^ null = nullptr;
   
   // Do not use IFormatProvider or NumberStyles.
   Console::WriteLine( "\nNumberStyles and IFormatProvider are not used:" );
   SByteParse( (NumberStyles)( -1), nullptr );
   
   // Use NumberStyles::HexNumber; do not use IFormatProvider.
   Console::WriteLine( "\nNumberStyles::HexNumber "
   "is used; IFormatProvider is not used:" );
   SByteParse( NumberStyles::HexNumber, nullptr );
   
   // Get the NumberFormatInfo object from the invariant 
   // culture, and enable parentheses to indicate negative.
   CultureInfo^ culture = gcnew CultureInfo( "" );
   NumberFormatInfo^ numFormat = culture->NumberFormat;
   numFormat->NumberNegativePattern = 0;
   
   // Change the digit group separator to '_' and the digit
   // group size to 1.
   numFormat->NumberGroupSeparator = "_";
   array<Int32>^sizes = {1};
   numFormat->NumberGroupSizes = sizes;
   
   // Use the NumberFormatInfo object as the IFormatProvider.
   Console::WriteLine( "\nA NumberStyles value is not used, "
   "but the IFormatProvider sets the group \nseparator = "
   "'_', group size = 1, and negative pattern = ( ):" );
   SByteParse( (NumberStyles)( -1), numFormat );
   
   // Use NumberStyles::Number and NumberStyles::AllowParentheses.
   Console::WriteLine( "\nNumberStyles::Number, NumberStyles::AllowParentheses, "
   "and the same \nIFormatProvider are used:" );
   SByteParse( (NumberStyles)(NumberStyles::Number | NumberStyles::AllowParentheses), numFormat );
}

int main()
{
   Console::WriteLine( "This example of\n"
   "  SByte::Parse( String* ),\n"
   "  SByte::Parse( String*, NumberStyles ),\n"
   "  SByte::Parse( String*, IFormatProvider* ), and\n"
   "  SByte::Parse( String*, NumberStyles, IFormatProvider* )"
   "\ngenerates the following output when "
   "parsing string representations\nof SByte "
   "values with each of these forms of SByte::Parse( )." );
   RunParseDemo();
}

/*
This example of
  SByte::Parse( String* ),
  SByte::Parse( String*, NumberStyles ),
  SByte::Parse( String*, IFormatProvider* ), and
  SByte::Parse( String*, NumberStyles, IFormatProvider* )
generates the following output when parsing string representations
of SByte values with each of these forms of SByte::Parse( ).

NumberStyles and IFormatProvider are not used:
  Parse of " 99 "      succeeded: 99
  Parse of " +123 "    succeeded: 123
  Parse of " (123) "   failed: Input string was not in a correct format.
  Parse of " -123 "    succeeded: -123
  Parse of " 1_2_3"    failed: Input string was not in a correct format.
  Parse of " 7E "      failed: Input string was not in a correct format.

NumberStyles::HexNumber is used; IFormatProvider is not used:
  Parse of " 99 "      succeeded: -103
  Parse of " +123 "    failed: Input string was not in a correct format.
  Parse of " (123) "   failed: Input string was not in a correct format.
  Parse of " -123 "    failed: Input string was not in a correct format.
  Parse of " 1_2_3"    failed: Input string was not in a correct format.
  Parse of " 7E "      succeeded: 126

A NumberStyles value is not used, but the IFormatProvider sets the group
separator = '_', group size = 1, and negative pattern = ( ):
  Parse of " 99 "      succeeded: 99
  Parse of " +123 "    succeeded: 123
  Parse of " (123) "   failed: Input string was not in a correct format.
  Parse of " -123 "    succeeded: -123
  Parse of " 1_2_3"    failed: Input string was not in a correct format.
  Parse of " 7E "      failed: Input string was not in a correct format.

NumberStyles::Number, NumberStyles::AllowParentheses, and the same
IFormatProvider are used:
  Parse of " 99 "      succeeded: 99
  Parse of " +123 "    succeeded: 123
  Parse of " (123) "   succeeded: -123
  Parse of " -123 "    succeeded: -123
  Parse of " 1_2_3"    succeeded: 123
  Parse of " 7E "      failed: Input string was not in a correct format.
*/
//</Snippet1>
