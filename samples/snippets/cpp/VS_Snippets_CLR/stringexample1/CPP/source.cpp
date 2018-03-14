

// This is the main project file for VC++ application project
// generated using an Application Wizard.
#define _UNICODE

#include <tchar.h>

using namespace System;
using namespace System::Text;

// This is the entry point for this application
int _tmain( void )
{
   //<snippet1>
   // Unicode Mathematical operators
   wchar_t charArray1[4] = {L'\x2200',L'\x2202',L'\x200F',L'\x2205'};
   wchar_t * lptstr1 =  &charArray1[ 0 ];
   String^ wszMathSymbols = gcnew String( lptstr1 );

   // Unicode Letterlike Symbols
   wchar_t charArray2[4] = {L'\x2111',L'\x2118',L'\x2122',L'\x2126'};
   wchar_t * lptstr2 =  &charArray2[ 0 ];
   String^ wszLetterLike = gcnew String( lptstr2 );

   // Compare Strings - the result is false
   Console::WriteLine( String::Concat( L"The Strings are equal? ", (0 == String::Compare( wszLetterLike, wszMathSymbols ) ? (String^)"TRUE" : "FALSE") ) );
   //</snippet1>

   //<snippet2>
   // Null terminated ASCII characters in a simple char array
   char charArray3[4] = {0x41,0x42,0x43,0x00};
   char * pstr3 =  &charArray3[ 0 ];
   String^ szAsciiUpper = gcnew String( pstr3 );
   char charArray4[4] = {0x61,0x62,0x63,0x00};
   char * pstr4 =  &charArray4[ 0 ];
   String^ szAsciiLower = gcnew String( pstr4,0,sizeof(charArray4) );

   // Prints "ABC abc"
   Console::WriteLine( String::Concat( szAsciiUpper,  " ", szAsciiLower ) );

   // Compare Strings - the result is true
   Console::WriteLine( String::Concat(  "The Strings are equal when capitalized ? ", (0 == String::Compare( szAsciiUpper->ToUpper(), szAsciiLower->ToUpper() ) ? (String^)"TRUE" :  "FALSE") ) );

   // This is the effective equivalent of another Compare method, which ignores case
   Console::WriteLine( String::Concat(  "The Strings are equal when capitalized ? ", (0 == String::Compare( szAsciiUpper, szAsciiLower, true ) ? (String^)"TRUE" :  "FALSE") ) );
   //</snippet2>

   //<snippet3>
   // Create a Unicode String with 5 Greek Alpha characters
   String^ szGreekAlpha = gcnew String( L'\x0391',5 );

   // Create a Unicode String with a Greek Omega character
   wchar_t charArray5[3] = {L'\x03A9',L'\x03A9',L'\x03A9'};
   String^ szGreekOmega = gcnew String( charArray5,2,1 );
   String^ szGreekLetters = String::Concat( szGreekOmega, szGreekAlpha, szGreekOmega->Clone() );

   // Examine the result
   Console::WriteLine( szGreekLetters );

   // The first index of Alpha
   int ialpha = szGreekLetters->IndexOf( L'\x0391' );

   // The last index of Omega
   int iomega = szGreekLetters->LastIndexOf( L'\x03A9' );
   Console::WriteLine( String::Concat(  "The Greek letter Alpha first appears at index ", Convert::ToString( ialpha ) ) );
   Console::WriteLine( String::Concat(  " and Omega last appears at index ", Convert::ToString( iomega ),  " in this String." ) );
   //</snippet3>

   //<snippet4>
   char asciiChars[6] = {0x51,0x52,0x53,0x54,0x54,0x56};
   char * pstr6 =  &asciiChars[ 0 ];
   UTF8Encoding^ encoding = gcnew UTF8Encoding( true,true );
   String^ utfeightstring = gcnew String( pstr6,0,sizeof(asciiChars),encoding );

   // prints "QRSTTV"
   Console::WriteLine( String::Concat(  "The UTF8 String is ", utfeightstring ) );
   //</snippet4>
   return 0;
}
