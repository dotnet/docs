// The following code example uses an encoder and a decoder to encode a string into an array of bytes,
// and then decode the bytes into an array of characters.

// <Snippet1>
using System;
using System.Text;

public class SamplesUnicodeEncoding  {

   public static void Main()  {

      // Get an encoder and a decoder from UnicodeEncoding.
      UnicodeEncoding u16 = new UnicodeEncoding( false, true, true );
      Encoder myEnc = u16.GetEncoder();
      Decoder myDec = u16.GetDecoder();

      // The characters to encode:
      //    Latin Small Letter Z (U+007A)
      //    Latin Small Letter A (U+0061)
      //    Combining Breve (U+0306)
      //    Latin Small Letter AE With Acute (U+01FD)
      //    Greek Small Letter Beta (U+03B2)
      char[] myChars = new char[5] { 'z', 'a', '\u0306', '\u01FD', '\u03B2' };
      Console.Write( "The original characters : " );
      Console.WriteLine( myChars );

      // Encode the character array.
      int iBC  = myEnc.GetByteCount( myChars, 0, myChars.Length, true );
      byte[] myBytes = new byte[iBC];
      myEnc.GetBytes( myChars, 0, myChars.Length, myBytes, 0, true );

      // Print the resulting bytes.
      Console.Write( "Using the encoder       : " );
      for ( int i = 0; i < myBytes.Length; i++ )
         Console.Write( "{0:X2} ", myBytes[i] );
      Console.WriteLine();

      // Decode the byte array back into an array of characters.
      int iCC  = myDec.GetCharCount( myBytes, 0, myBytes.Length, true );
      char[] myDecodedChars = new char[iCC];
      myDec.GetChars( myBytes, 0, myBytes.Length, myDecodedChars, 0, true );

      // Print the resulting characters.
      Console.Write( "Using the decoder       : " );
      Console.WriteLine( myDecodedChars );

   }

}


/* 
This code produces the following output.  The question marks take the place of characters that cannot be displayed at the console.

The original characters : za??ß
Using the encoder       : 7A 00 61 00 06 03 FD 01 B2 03
Using the decoder       : za??ß

*/

// </Snippet1>

