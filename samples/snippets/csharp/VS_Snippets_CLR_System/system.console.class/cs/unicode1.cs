// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      // Create a Char array for the modern Cyrillic alphabet, 
      // from U+0410 to U+044F.
      int nChars = 0x044F - 0x0410 + 1;
      char[] chars = new char[nChars];
      ushort codePoint = 0x0410;
      for (int ctr = 0; ctr < chars.Length; ctr++) {
        chars[ctr] = Convert.ToChar(codePoint);
        codePoint++;
      }   
         
      Console.WriteLine("Current code page: {0}\n", 
                        Console.OutputEncoding.CodePage);
      // Display the characters.
      foreach (var ch in chars) {
         Console.Write("{0}  ", ch);
         if (Console.CursorLeft >= 70) 
            Console.WriteLine();
      }
   }
}
// The example displays the following output:
//    Current code page: 437
//    
//    ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?
//    ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?
//    ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?  ?
// </Snippet1>
