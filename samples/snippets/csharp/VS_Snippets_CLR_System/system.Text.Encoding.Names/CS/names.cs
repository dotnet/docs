// The following code example retrieves the different names for each encoding
// and displays the encodings with one or more names that are different from EncodingInfo.Name.
// It displays EncodingName but does not compare against it.

// <Snippet1>
using System;
using System.Text;

public class SamplesEncoding  {

   public static void Main()  {

      // Print the header.
      Console.Write( "Name               " );
      Console.Write( "CodePage  " );
      Console.Write( "BodyName           " );
      Console.Write( "HeaderName         " );
      Console.Write( "WebName            " );
      Console.WriteLine( "Encoding.EncodingName" );

      // For every encoding, compare the name properties with EncodingInfo.Name.
      // Display only the encodings that have one or more different names.
      foreach( EncodingInfo ei in Encoding.GetEncodings() )  {
         Encoding e = ei.GetEncoding();

         if (( ei.Name != e.BodyName ) || ( ei.Name != e.HeaderName ) || ( ei.Name != e.WebName ))  {
            Console.Write( "{0,-18} ", ei.Name );
            Console.Write( "{0,-9} ",  e.CodePage );
            Console.Write( "{0,-18} ", e.BodyName );
            Console.Write( "{0,-18} ", e.HeaderName );
            Console.Write( "{0,-18} ", e.WebName );
            Console.WriteLine( "{0} ", e.EncodingName );
         }

      }

   }

}


/* 
This code produces the following output.

Name               CodePage  BodyName           HeaderName         WebName            Encoding.EncodingName
shift_jis          932       iso-2022-jp        iso-2022-jp        shift_jis          Japanese (Shift-JIS)
windows-1250       1250      iso-8859-2         windows-1250       windows-1250       Central European (Windows)
windows-1251       1251      koi8-r             windows-1251       windows-1251       Cyrillic (Windows)
Windows-1252       1252      iso-8859-1         Windows-1252       Windows-1252       Western European (Windows)
windows-1253       1253      iso-8859-7         windows-1253       windows-1253       Greek (Windows)
windows-1254       1254      iso-8859-9         windows-1254       windows-1254       Turkish (Windows)
csISO2022JP        50221     iso-2022-jp        iso-2022-jp        csISO2022JP        Japanese (JIS-Allow 1 byte Kana)
iso-2022-kr        50225     iso-2022-kr        euc-kr             iso-2022-kr        Korean (ISO)

*/

// </Snippet1>

