
//<Snippet1>
// Example of Convert::ToDateTime( String*, IFormatProvider* ).
using namespace System;
using namespace System::Globalization;
using namespace System::Collections;
const __wchar_t * protoFmt = L"{0,-18}{1,-12}{2}";

// Get the exception type name; remove the namespace prefix.
String^ GetExceptionType( Exception^ ex )
{
   String^ exceptionType = ex->GetType()->ToString();
   return exceptionType->Substring( exceptionType->LastIndexOf( '.' ) + 1 );
}

// Convert each string in the dateStrings array.
void StringToDateTime( String^ cultureName )
{
   array<String^>^dateStrings = gcnew array<String^>(7);
   dateStrings[ 0 ] = "01/02/03";
   dateStrings[ 1 ] = "2001/02/03";
   dateStrings[ 2 ] = "01/2002/03";
   dateStrings[ 3 ] = "01/02/2003";
   dateStrings[ 4 ] = "21/02/03";
   dateStrings[ 5 ] = "01/22/03";
   dateStrings[ 6 ] = "01/02/23";
   CultureInfo^ culture = gcnew CultureInfo( cultureName );
   Console::WriteLine();

   // Code foreach( String* dateStr in dateStrings ).
   IEnumerator^ myEnum = dateStrings->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      String^ dateStr = safe_cast<String^>(myEnum->Current);
      DateTime dateTimeValue;

      // Display the first part of the output line.
      Console::Write( gcnew String( protoFmt ), dateStr, cultureName, "" );
      try
      {
         // Convert the string to a DateTime object.
         dateTimeValue = Convert::ToDateTime( dateStr, culture );

         // Display the DateTime object in a fixed format 
         // if Convert succeeded.
         Console::WriteLine( "{0:yyyy-MMM-dd}", dateTimeValue );
      }
      catch ( Exception^ ex ) 
      {
         // Display the exception type if Parse failed.
         Console::WriteLine( "{0}", GetExceptionType( ex ) );
      }
   }
}

int main()
{
   Console::WriteLine( "This example of "
   "Convert::ToDateTime( String*, IFormatProvider* ) "
   "\ngenerates the following output. Several strings are "
   "converted \nto DateTime objects using formatting "
   "information from different \ncultures, and then the "
   "strings are displayed in a \nculture-invariant form.\n" );
   Console::WriteLine( gcnew String( protoFmt ), "Date String", "Culture", "DateTime or Exception" );
   Console::WriteLine( gcnew String( protoFmt ), "-----------", "-------", "---------------------" );
   StringToDateTime( "en-US" );
   StringToDateTime( "ru-RU" );
   StringToDateTime( "ja-JP" );
}

/*
This example of Convert::ToDateTime( String*, IFormatProvider* )
generates the following output. Several strings are converted
to DateTime objects using formatting information from different
cultures, and then the strings are displayed in a
culture-invariant form.

Date String       Culture     DateTime or Exception
-----------       -------     ---------------------

01/02/03          en-US       2003-Jan-02
2001/02/03        en-US       2001-Feb-03
01/2002/03        en-US       2002-Jan-03
01/02/2003        en-US       2003-Jan-02
21/02/03          en-US       FormatException
01/22/03          en-US       2003-Jan-22
01/02/23          en-US       2023-Jan-02

01/02/03          ru-RU       2003-Feb-01
2001/02/03        ru-RU       2001-Feb-03
01/2002/03        ru-RU       2002-Jan-03
01/02/2003        ru-RU       2003-Feb-01
21/02/03          ru-RU       2003-Feb-21
01/22/03          ru-RU       FormatException
01/02/23          ru-RU       2023-Feb-01

01/02/03          ja-JP       2001-Feb-03
2001/02/03        ja-JP       2001-Feb-03
01/2002/03        ja-JP       2002-Jan-03
01/02/2003        ja-JP       2003-Jan-02
21/02/03          ja-JP       2021-Feb-03
01/22/03          ja-JP       FormatException
01/02/23          ja-JP       2001-Feb-23
*/
//</Snippet1>
