// The following code example determines the number of bytes required to encode a string,
// then encodes the string and displays the resulting bytes.

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
      String myStr = "za\u0306\u01FD\u03B2\uD8FF\uDCFF";

      // Create instances of different encodings.
      UTF7Encoding  u7       = new UTF7Encoding();
      UTF8Encoding  u8Nobom  = new UTF8Encoding( false, true );
      UTF8Encoding  u8Bom    = new UTF8Encoding( true,  true );
      UTF32Encoding u32Nobom = new UTF32Encoding( false, false, true );
      UTF32Encoding u32Bom   = new UTF32Encoding( false, true,  true );

      // Get the byte counts and the bytes.
      PrintCountsAndBytes( myStr, u7 );
      PrintCountsAndBytes( myStr, u8Nobom );
      PrintCountsAndBytes( myStr, u8Bom );
      PrintCountsAndBytes( myStr, u32Nobom );
      PrintCountsAndBytes( myStr, u32Bom );

   }


   public static void PrintCountsAndBytes( String s, Encoding enc )  {

      // Display the name of the encoding used.
      Console.Write( "{0,-25} :", enc.ToString() );

      // Display the exact byte count.
      int iBC  = enc.GetByteCount( s );
      Console.Write( " {0,-3}", iBC );

      // Display the maximum byte count.
      int iMBC = enc.GetMaxByteCount( s.Length );
      Console.Write( " {0,-3} :", iMBC );

      // Get the byte order mark, if any.
      byte[] preamble = enc.GetPreamble();

      // Combine the preamble and the encoded bytes.
      byte[] bytes = new byte[preamble.Length + iBC];
      Array.Copy( preamble, bytes, preamble.Length );
      enc.GetBytes( s, 0, s.Length, bytes, preamble.Length );

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

System.Text.UTF7Encoding  : 18  23  :7A 61 2B 41 77 59 42 2F 51 4F 79 32 50 2F 63 2F 77 2D
System.Text.UTF8Encoding  : 12  24  :7A 61 CC 86 C7 BD CE B2 F1 8F B3 BF
System.Text.UTF8Encoding  : 12  24  :EF BB BF 7A 61 CC 86 C7 BD CE B2 F1 8F B3 BF
System.Text.UTF32Encoding : 24  28  :7A 00 00 00 61 00 00 00 06 03 00 00 FD 01 00 00 B2 03 00 00 FF FC 04 00
System.Text.UTF32Encoding : 24  28  :FF FE 00 00 7A 00 00 00 61 00 00 00 06 03 00 00 FD 01 00 00 B2 03 00 00 FF FC 04 00

*/

// </Snippet1>

