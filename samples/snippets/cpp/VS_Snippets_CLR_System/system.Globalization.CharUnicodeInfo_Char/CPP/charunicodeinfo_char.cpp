
// The following code example shows the values returned by each method for different types of characters.
// <snippet1>
using namespace System;
using namespace System::Globalization;
void PrintProperties( Char c );
int main()
{
   Console::WriteLine( "                                        c  Num   Dig   Dec   UnicodeCategory" );
   Console::Write( "U+0061 LATIN SMALL LETTER A            " );
   PrintProperties( L'a' );
   Console::Write( "U+0393 GREEK CAPITAL LETTER GAMMA      " );
   PrintProperties( L'\u0393' );
   Console::Write( "U+0039 DIGIT NINE                      " );
   PrintProperties( L'9' );
   Console::Write( "U+00B2 SUPERSCRIPT TWO                 " );
   PrintProperties( L'\u00B2' );
   Console::Write( "U+00BC VULGAR FRACTION ONE QUARTER     " );
   PrintProperties( L'\u00BC' );
   Console::Write( "U+0BEF TAMIL DIGIT NINE                " );
   PrintProperties( L'\u0BEF' );
   Console::Write( "U+0BF0 TAMIL NUMBER TEN                " );
   PrintProperties( L'\u0BF0' );
   Console::Write( "U+0F33 TIBETAN DIGIT HALF ZERO         " );
   PrintProperties( L'\u0F33' );
   Console::Write( "U+2788 CIRCLED SANS-SERIF DIGIT NINE   " );
   PrintProperties( L'\u2788' );
}

void PrintProperties( Char c )
{
   Console::Write( " {0,-3}", c );
   Console::Write( " {0,-5}", CharUnicodeInfo::GetNumericValue( c ) );
   Console::Write( " {0,-5}", CharUnicodeInfo::GetDigitValue( c ) );
   Console::Write( " {0,-5}", CharUnicodeInfo::GetDecimalDigitValue( c ) );
   Console::WriteLine( "{0}", CharUnicodeInfo::GetUnicodeCategory( c ) );
}

/*
This code produces the following output.  Some characters might not display at the console.

                                        c  Num   Dig   Dec   UnicodeCategory
U+0061 LATIN SMALL LETTER A             a   -1    -1    -1   LowercaseLetter
U+0393 GREEK CAPITAL LETTER GAMMA       \u0393   -1    -1    -1   UppercaseLetter
U+0039 DIGIT NINE                       9   9     9     9    DecimalDigitNumber
U+00B2 SUPERSCRIPT TWO                  \u00B2   2     2     2    OtherNumber
U+00BC VULGAR FRACTION ONE QUARTER      \u00BC   0.25  -1    -1   OtherNumber
U+0BEF TAMIL DIGIT NINE                 \u0BEF   9     9     9    DecimalDigitNumber
U+0BF0 TAMIL NUMBER TEN                 \u0BF0   10    -1    -1   OtherNumber
U+0F33 TIBETAN DIGIT HALF ZERO          \u0F33   -0.5  -1    -1   OtherNumber
U+2788 CIRCLED SANS-SERIF DIGIT NINE    \u2788   9     9     -1   OtherNumber

*/
// </snippet1>
