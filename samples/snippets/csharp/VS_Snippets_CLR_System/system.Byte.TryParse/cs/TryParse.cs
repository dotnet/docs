// <Snippet1>
using System;

public class ByteConversion
{
   public static void Main()
   {
      string byteString = null;
      CallTryParse(byteString);
      
      byteString = String.Empty;
      CallTryParse(byteString);
      
      byteString = "1024";
      CallTryParse(byteString);
      
      byteString = "100.1";
      CallTryParse(byteString);
      
      byteString = "100";
      CallTryParse(byteString);
      
      byteString = "+100";
      CallTryParse(byteString);
      
      byteString = "-100";
      CallTryParse(byteString);
      
      byteString = "000000000000000100";
      CallTryParse(byteString);
      
      byteString = "00,100";
      CallTryParse(byteString);
      
      byteString = "   20   ";
      CallTryParse(byteString);
      
      byteString = "FF";
      CallTryParse(byteString);
      
      byteString = "0x1F";
      CallTryParse(byteString);
   }

   private static void CallTryParse(string stringToConvert)
   {  
      byte byteValue; 
      bool result = Byte.TryParse(stringToConvert, out byteValue);
      if (result)
      {
         Console.WriteLine("Converted '{0}' to {1}", 
                        stringToConvert, byteValue);
      }
      else
      {
         if (stringToConvert == null) stringToConvert = "";
         Console.WriteLine("Attempted conversion of '{0}' failed.", 
                           stringToConvert.ToString());
      }
   }    
}
// The example displays the following output to the console:
//       Attempted conversion of '' failed.
//       Attempted conversion of '' failed.
//       Attempted conversion of '1024' failed.
//       Attempted conversion of '100.1' failed.
//       Converted '100' to 100
//       Converted '+100' to 100
//       Attempted conversion of '-100' failed.
//       Converted '000000000000000100' to 100
//       Attempted conversion of '00,100' failed.
//       Converted '   20   ' to 20
//       Attempted conversion of 'FF' failed.
//       Attempted conversion of '0x1F' failed.
// </Snippet1>
