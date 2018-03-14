
// The following code example determines the number of bytes required to encode a character array,
// encodes the characters, and displays the resulting bytes.
// <Snippet1>
using namespace System;
using namespace System::Text;
void PrintCountsAndBytes( array<Char>^chars, Encoding^ enc );
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
   array<Char>^myChars = gcnew array<Char>{
      L'z','a',L'\u0306',L'\u01FD',L'\u03B2',L'\xD8FF',L'\xDCFF'
   };
   
   // Get different encodings.
   Encoding^ u7 = Encoding::UTF7;
   Encoding^ u8 = Encoding::UTF8;
   Encoding^ u16LE = Encoding::Unicode;
   Encoding^ u16BE = Encoding::BigEndianUnicode;
   Encoding^ u32 = Encoding::UTF32;
   
   // Encode the entire array, and print out the counts and the resulting bytes.
   PrintCountsAndBytes( myChars, u7 );
   PrintCountsAndBytes( myChars, u8 );
   PrintCountsAndBytes( myChars, u16LE );
   PrintCountsAndBytes( myChars, u16BE );
   PrintCountsAndBytes( myChars, u32 );
}

void PrintCountsAndBytes( array<Char>^chars, Encoding^ enc )
{
   
   // Display the name of the encoding used.
   Console::Write( "{0,-30} :", enc );
   
   // Display the exact byte count.
   int iBC = enc->GetByteCount( chars );
   Console::Write( " {0,-3}", iBC );
   
   // Display the maximum byte count.
   int iMBC = enc->GetMaxByteCount( chars->Length );
   Console::Write( " {0,-3} :", iMBC );
   
   // Encode the array of chars.
   array<Byte>^bytes = enc->GetBytes( chars );
   
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

System.Text.UTF7Encoding       : 18  23  :7A 61 2B 41 77 59 42 2F 51 4F 79 32 50 2F 63 2F 77 2D
System.Text.UTF8Encoding       : 12  24  :7A 61 CC 86 C7 BD CE B2 F1 8F B3 BF
System.Text.UnicodeEncoding    : 14  16  :7A 00 61 00 06 03 FD 01 B2 03 FF D8 FF DC
System.Text.UnicodeEncoding    : 14  16  :00 7A 00 61 03 06 01 FD 03 B2 D8 FF DC FF
System.Text.UTF32Encoding      : 24  32  :7A 00 00 00 61 00 00 00 06 03 00 00 FD 01 00 00 B2 03 00 00 FF FC 04 00

*/
// </Snippet1>
