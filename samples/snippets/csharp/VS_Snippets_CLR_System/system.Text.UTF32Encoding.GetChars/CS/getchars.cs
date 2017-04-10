// The following code example encodes a string into an array of bytes, and then decodes the bytes into an array of characters.

// <Snippet1>
using System;
using System.Text;

public class SamplesUTF32Encoding  {

   public static void Main()  {

      // Create two instances of UTF32Encoding: one with little-endian byte order and one with big-endian byte order.
      UTF32Encoding u32LE = new UTF32Encoding( false, true, true );
      UTF32Encoding u32BE = new UTF32Encoding( true, true, true );


      // Create byte arrays from the same string containing the following characters:
      //    Latin Small Letter Z (U+007A)
      //    Latin Small Letter A (U+0061)
      //    Combining Breve (U+0306)
      //    Latin Small Letter AE With Acute (U+01FD)
      //    Greek Small Letter Beta (U+03B2)
      //    a high-surrogate value (U+D8FF)
      //    a low-surrogate value (U+DCFF)
      String myStr = "za\u0306\u01FD\u03B2\uD8FF\uDCFF";

      // barrBE uses the big-endian byte order.
      byte[] barrBE = new byte[u32BE.GetByteCount( myStr )];
      u32BE.GetBytes( myStr, 0, myStr.Length, barrBE, 0 );

      // barrLE uses the little-endian byte order.
      byte[] barrLE = new byte[u32LE.GetByteCount( myStr )];
      u32LE.GetBytes( myStr, 0, myStr.Length, barrLE, 0 );


      // Get the char counts and decode the byte arrays.
      Console.Write( "BE array with BE encoding : " );
      PrintCountsAndChars( barrBE, u32BE );
      Console.Write( "LE array with LE encoding : " );
      PrintCountsAndChars( barrLE, u32LE );


      // Decode the byte arrays using an encoding with a different byte order.
      Console.Write( "BE array with LE encoding : " );
      try  {
         PrintCountsAndChars( barrBE, u32LE );
      }
      catch ( System.ArgumentException e )  {
         Console.WriteLine( e.Message );
      }

      Console.Write( "LE array with BE encoding : " );
      try  {
         PrintCountsAndChars( barrLE, u32BE );
      }
      catch ( System.ArgumentException e )  {
         Console.WriteLine( e.Message );
      }

   }


   public static void PrintCountsAndChars( byte[] bytes, Encoding enc )  {

      // Display the name of the encoding used.
      Console.Write( "{0,-25} :", enc.ToString() );

      // Display the exact character count.
      int iCC  = enc.GetCharCount( bytes );
      Console.Write( " {0,-3}", iCC );

      // Display the maximum character count.
      int iMCC = enc.GetMaxCharCount( bytes.Length );
      Console.Write( " {0,-3} :", iMCC );

      // Decode the bytes and display the characters.
      char[] chars = new char[iCC];
      enc.GetChars( bytes, 0, bytes.Length, chars, 0 );
      Console.WriteLine( chars );

   }

}

// </Snippet1>



/* BUGBUG: Reproduce this output in retail build, then add to the snippet.
This code produces the following output.  The question marks take the place of characters that cannot be displayed at the console.

BE array with BE encoding : System.Text.UTF32Encoding : 7   14  :za??ß?
LE array with LE encoding : System.Text.UTF32Encoding : 7   14  :za??ß?
BE array with LE encoding : System.Text.UTF32Encoding :Invalid byte was found at byte index 3.
LE array with BE encoding : System.Text.UTF32Encoding :Invalid byte was found at byte index 3.

*/


