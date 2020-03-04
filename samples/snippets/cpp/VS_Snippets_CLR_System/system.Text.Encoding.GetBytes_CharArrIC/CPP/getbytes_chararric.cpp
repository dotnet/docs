
// The following code example determines the number of bytes required to encode three characters from a character array,
// encodes the characters, and displays the resulting bytes.
// <Snippet1>
using namespace System;
using namespace System::Text;
void PrintCountsAndBytes( array<Char>^chars, int index, int count, Encoding^ enc );
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
      L'z',L'a',L'\u0306',L'\u01FD',L'\u03B2',L'\xD8FF',L'\xDCFF'
   };
   
   // Get different encodings.
   Encoding^ u7 = Encoding::UTF7;
   Encoding^ u8 = Encoding::UTF8;
   Encoding^ u16LE = Encoding::Unicode;
   Encoding^ u16BE = Encoding::BigEndianUnicode;
   Encoding^ u32 = Encoding::UTF32;
   
   // Encode three characters starting at index 4, and print out the counts and the resulting bytes.
   PrintCountsAndBytes( myChars, 4, 3, u7 );
   PrintCountsAndBytes( myChars, 4, 3, u8 );
   PrintCountsAndBytes( myChars, 4, 3, u16LE );
   PrintCountsAndBytes( myChars, 4, 3, u16BE );
   PrintCountsAndBytes( myChars, 4, 3, u32 );
}

void PrintCountsAndBytes( array<Char>^chars, int index, int count, Encoding^ enc )
{
   
   // Display the name of the encoding used.
   Console::Write( "{0,-30} :", enc );
   
   // Display the exact byte count.
   int iBC = enc->GetByteCount( chars, index, count );
   Console::Write( " {0,-3}", iBC );
   
   // Display the maximum byte count.
   int iMBC = enc->GetMaxByteCount( count );
   Console::Write( " {0,-3} :", iMBC );
   
   // Encode the array of chars.
   array<Byte>^bytes = enc->GetBytes( chars, index, count );
   
   // The following is an alternative way to encode the array of chars:
   // byte[] bytes = new byte[iBC];
   // enc.GetBytes( chars, index, count, bytes, bytes.GetLowerBound(0) );
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

System.Text.UTF7Encoding       : 10  11  :2B 41 37 4C 59 2F 39 7A 2F 2D
System.Text.UTF8Encoding       : 6   12  :CE B2 F1 8F B3 BF
System.Text.UnicodeEncoding    : 6   8   :B2 03 FF D8 FF DC
System.Text.UnicodeEncoding    : 6   8   :03 B2 D8 FF DC FF
System.Text.UTF32Encoding      : 8   16  :B2 03 00 00 FF FC 04 00

*/
// </Snippet1>
