// <Snippet2>
using System;
using System.Globalization;
using System.IO;

public class Example5
{
   public static void Main()
   {
      StreamWriter sw = new StreamWriter(@".\graphemes.txt");
      string grapheme = "\u0061\u0308";
      sw.WriteLine(grapheme);
      
      string singleChar = "\u00e4";
      sw.WriteLine(singleChar);
            
      sw.WriteLine("{0} = {1} (Culture-sensitive): {2}", grapheme, singleChar, 
                   String.Equals(grapheme, singleChar, 
                                 StringComparison.CurrentCulture));
      sw.WriteLine("{0} = {1} (Ordinal): {2}", grapheme, singleChar, 
                   String.Equals(grapheme, singleChar, 
                                 StringComparison.Ordinal));
      sw.WriteLine("{0} = {1} (Normalized Ordinal): {2}", grapheme, singleChar, 
                   String.Equals(grapheme.Normalize(), 
                                 singleChar.Normalize(), 
                                 StringComparison.Ordinal));
      sw.Close(); 
   }
}
// The example produces the following output:
//       ä
//       ä
//       ä = ä (Culture-sensitive): True
//       ä = ä (Ordinal): False
//       ä = ä (Normalized Ordinal): True
// </Snippet2>
