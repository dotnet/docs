// <Snippet2>
using System;
using System.Text;

public class Example
{
   public static void Main()
   {
      byte[] bytes = { 0x00, 0x20, 0xd8, 0x01, 0x00, 0x68, 0xA7, 0x00 };
      Encoding enc = new UnicodeEncoding(true, true, true);
      
      try {
         string value = enc.GetString(bytes);
         Console.WriteLine();
         Console.WriteLine("'{0}'", value);
      }
      catch (DecoderFallbackException e) {      
         Console.WriteLine("Unable to decode {0} at index {1}", 
                           ShowBytes(e.BytesUnknown), e.Index);
      }
   }

   private static string ShowBytes(byte[] bytes) 
   {
      string returnString = null;
      foreach (var byteValue in bytes)
         returnString += String.Format("0x{0:X2} ", byteValue);

      return returnString.Trim();
   }
}
// The example displays the following output:
//        Unable to decode 0xD8 0x01 at index 4
// </Snippet2>
