// The following code example demonstrates the behavior of UnicodeEncoding with error detection enabled and without.

// <Snippet1>
using System;
using System.Text;

public class SamplesUnicodeEncoding  {

   public static void Main()  {

      // Create an instance of UnicodeEncoding using little-endian byte order.
      // This will be used for encoding.
      UnicodeEncoding u16LE     = new UnicodeEncoding( false, true );

      // Create two instances of UnicodeEncoding using big-endian byte order: one with error detection and one without.
      // These will be used for decoding.
      UnicodeEncoding u16withED = new UnicodeEncoding( true, true, true );
      UnicodeEncoding u16noED   = new UnicodeEncoding( true, true, false );

      // Create byte arrays from the same string containing the following characters:
      //    Latin Small Letter Z (U+007A)
      //    Latin Small Letter A (U+0061)
      //    Combining Breve (U+0306)
      //    Latin Small Letter AE With Acute (U+01FD)
      //    Greek Small Letter Beta (U+03B2)
      //    Latin Capital Letter U with  Diaeresis (U+00DC)
      String myStr = "za\u0306\u01FD\u03B2\u00DC";

      // Encode the string using little-endian byte order.
      byte[] myBytes = new byte[u16LE.GetByteCount( myStr )];
      u16LE.GetBytes( myStr, 0, myStr.Length, myBytes, 0 );

      // Decode the byte array with error detection.
      Console.WriteLine( "Decoding with error detection:" );
      PrintDecodedString( myBytes, u16withED );

      // Decode the byte array without error detection.
      Console.WriteLine( "Decoding without error detection:" );
      PrintDecodedString( myBytes, u16noED );

   }


   // Decode the bytes and display the string.
   public static void PrintDecodedString( byte[] bytes, Encoding enc )  {

      try  {
         Console.WriteLine( "   Decoded string: {0}", enc.GetString( bytes, 0, bytes.Length ) );
      }
      catch ( System.ArgumentException e )  {
         Console.WriteLine( e.ToString() );
      }

      Console.WriteLine();

   }

}

// </Snippet1>



/* BUGBUG: Reproduce this output in retail build, then add to the snippet.
This code produces the following output.

Decoding with error detection:
System.ArgumentException: Invalid byte was found at byte index 3.
   at System.Text.UnicodeEncoding.GetCharCount(Byte* bytes, Int32 count, DecoderNLS baseDecoder)
   at System.String.CreateStringFromEncoding(Byte* bytes, Int32 byteLength, Encoding encoding)
   at System.Text.UnicodeEncoding.GetString(Byte[] bytes, Int32 index, Int32 count)
   at SamplesUnicodeEncoding.PrintDecodedString(Byte[] bytes, Encoding enc)

Decoding without error detection:
   Decoded string:

*/


