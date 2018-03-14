// The following code example determines the number of bytes required to encode three characters from a character array,
// then encodes the characters and displays the resulting bytes.

// <Snippet1>
using System;
using System.Text;

public class SamplesUTF32Encoding  {

   public static void Main()  {

      // The characters to encode:
      //    Latin Small Letter Z (U+007A)
      //    Latin Small Letter A (U+0061)
      //    Combining Breve (U+0306)
      //    Latin Small Letter AE With Acute (U+01FD)
      //    Greek Small Letter Beta (U+03B2)
      //    a high-surrogate value (U+D8FF)
      //    a low-surrogate value (U+DCFF)
      char[] myChars = new char[7] { 'z', 'a', '\u0306', '\u01FD', '\u03B2', '\uD8FF', '\uDCFF' };

      // Create instances of different encodings.
      UTF7Encoding  u7       = new UTF7Encoding();
      UTF8Encoding  u8Nobom  = new UTF8Encoding( false, true );
      UTF8Encoding  u8Bom    = new UTF8Encoding( true,  true );
      UTF32Encoding u32Nobom = new UTF32Encoding( false, false, true );
      UTF32Encoding u32Bom   = new UTF32Encoding( false, true,  true );

      // Encode three characters starting at index 4 and print out the counts and the resulting bytes.
      PrintCountsAndBytes( myChars, 4, 3, u7 );
      PrintCountsAndBytes( myChars, 4, 3, u8Nobom );
      PrintCountsAndBytes( myChars, 4, 3, u8Bom );
      PrintCountsAndBytes( myChars, 4, 3, u32Nobom );
      PrintCountsAndBytes( myChars, 4, 3, u32Bom );

   }


   public static void PrintCountsAndBytes( char[] chars, int index, int count, Encoding enc )  {

      // Display the name of the encoding used.
      Console.Write( "{0,-25} :", enc.ToString() );

      // Display the exact byte count.
      int iBC  = enc.GetByteCount( chars, index, count );
      Console.Write( " {0,-3}", iBC );

      // Display the maximum byte count.
      int iMBC = enc.GetMaxByteCount( count );
      Console.Write( " {0,-3} :", iMBC );

      // Get the byte order mark, if any.
      byte[] preamble = enc.GetPreamble();

      // Combine the preamble and the encoded bytes.
      byte[] bytes = new byte[preamble.Length + iBC];
      Array.Copy( preamble, bytes, preamble.Length );
      enc.GetBytes( chars, index, count, bytes, preamble.Length );

      // Display all the encoded bytes.
      PrintHexBytes( bytes );

   }


   public static void PrintHexBytes( byte[] bytes )  {

      if (( bytes == null ) || ( bytes.Length == 0 ))
         Console.WriteLine( "<none>" );
      else  {
         for ( int i = 0; i < bytes.Length; i++ )
            Console.Write( "{0:X2} ", bytes[i] );
         Console.WriteLine();
      }

   }

}


/* 
This code produces the following output.

System.Text.UTF7Encoding  : 10  11  :2B 41 37 4C 59 2F 39 7A 2F 2D
System.Text.UTF8Encoding  : 6   12  :CE B2 F1 8F B3 BF
System.Text.UTF8Encoding  : 6   12  :EF BB BF CE B2 F1 8F B3 BF
System.Text.UTF32Encoding : 8   12  :B2 03 00 00 FF FC 04 00
System.Text.UTF32Encoding : 8   12  :FF FE 00 00 B2 03 00 00 FF FC 04 00

*/

// </Snippet1>

