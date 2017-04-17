
// The following code example determines the number of bytes required to encode a string or a range in the string,
// encodes the characters, and displays the resulting bytes.
// <Snippet1>
using namespace System;
using namespace System::Text;
void PrintCountsAndBytes( String^ s, Encoding^ enc );
void PrintCountsAndBytes( String^ s, int index, int count, Encoding^ enc );
void PrintHexBytes( array<Byte>^bytes );
int main()
{
   
   // The characters to encode:
   //    Latin Small Letter Z (U+007A)
   //    Latin Small Letter A (U+0061)
   //    Combining Breve (U+0306)
   //    Latin Small Letter AE With Acute (U+01FD)
   //    Greek Small Letter Beta (U+03B2)
   //    a high-surrogate value (U+D8FF)
   //    a low-surrogate value (U+DCFF)
   String^ myStr = L"za\u0306\u01FD\u03B2\xD8FF\xDCFF";
   
   // Get different encodings.
   Encoding^ u7 = Encoding::UTF7;
   Encoding^ u8 = Encoding::UTF8;
   Encoding^ u16LE = Encoding::Unicode;
   Encoding^ u16BE = Encoding::BigEndianUnicode;
   Encoding^ u32 = Encoding::UTF32;
   
   // Encode the entire string, and print out the counts and the resulting bytes.
   Console::WriteLine( "Encoding the entire string:" );
   PrintCountsAndBytes( myStr, u7 );
   PrintCountsAndBytes( myStr, u8 );
   PrintCountsAndBytes( myStr, u16LE );
   PrintCountsAndBytes( myStr, u16BE );
   PrintCountsAndBytes( myStr, u32 );
   Console::WriteLine();
   
   // Encode three characters starting at index 4, and print out the counts and the resulting bytes.
   Console::WriteLine( "Encoding the characters from index 4 through 6:" );
   PrintCountsAndBytes( myStr, 4, 3, u7 );
   PrintCountsAndBytes( myStr, 4, 3, u8 );
   PrintCountsAndBytes( myStr, 4, 3, u16LE );
   PrintCountsAndBytes( myStr, 4, 3, u16BE );
   PrintCountsAndBytes( myStr, 4, 3, u32 );
}

void PrintCountsAndBytes( String^ s, Encoding^ enc )
{
   
   // Display the name of the encoding used.
   Console::Write( "{0,-30} :", enc );
   
   // Display the exact byte count.
   int iBC = enc->GetByteCount( s );
   Console::Write( " {0,-3}", iBC );
   
   // Display the maximum byte count.
   int iMBC = enc->GetMaxByteCount( s->Length );
   Console::Write( " {0,-3} :", iMBC );
   
   // Encode the entire string.
   array<Byte>^bytes = enc->GetBytes( s );
   
   // Display all the encoded bytes.
   PrintHexBytes( bytes );
}

void PrintCountsAndBytes( String^ s, int index, int count, Encoding^ enc )
{
   
   // Display the name of the encoding used.
   Console::Write( "{0,-30} :", enc );
   
   // Display the exact byte count.
   int iBC = enc->GetByteCount( s->ToCharArray(), index, count );
   Console::Write( " {0,-3}", iBC );
   
   // Display the maximum byte count.
   int iMBC = enc->GetMaxByteCount( count );
   Console::Write( " {0,-3} :", iMBC );
   
   // Encode a range of characters in the string.
   array<Byte>^bytes = gcnew array<Byte>(iBC);
   enc->GetBytes( s, index, count, bytes, bytes->GetLowerBound( 0 ) );
   
   // Display all the encoded bytes.
   PrintHexBytes( bytes );
}

void PrintHexBytes( array<Byte>^bytes )
{
   if ( (bytes == nullptr) || (bytes->Length == 0) )
      Console::WriteLine( "<none>" );
   else
   {
      for ( int i = 0; i < bytes->Length; i++ )
         Console::Write( "{0:X2} ", bytes[ i ] );
      Console::WriteLine();
   }
}

/* 
This code produces the following output.

Encoding the entire string:
System.Text.UTF7Encoding       : 18  23  :7A 61 2B 41 77 59 42 2F 51 4F 79 32 50 2F 63 2F 77 2D
System.Text.UTF8Encoding       : 12  24  :7A 61 CC 86 C7 BD CE B2 F1 8F B3 BF
System.Text.UnicodeEncoding    : 14  16  :7A 00 61 00 06 03 FD 01 B2 03 FF D8 FF DC
System.Text.UnicodeEncoding    : 14  16  :00 7A 00 61 03 06 01 FD 03 B2 D8 FF DC FF
System.Text.UTF32Encoding      : 24  32  :7A 00 00 00 61 00 00 00 06 03 00 00 FD 01 00 00 B2 03 00 00 FF FC 04 00

Encoding the characters from index 4 through 6:
System.Text.UTF7Encoding       : 10  11  :2B 41 37 4C 59 2F 39 7A 2F 2D
System.Text.UTF8Encoding       : 6   12  :CE B2 F1 8F B3 BF
System.Text.UnicodeEncoding    : 6   8   :B2 03 FF D8 FF DC
System.Text.UnicodeEncoding    : 6   8   :03 B2 D8 FF DC FF
System.Text.UTF32Encoding      : 8   16  :B2 03 00 00 FF FC 04 00

*/
// </Snippet1>
