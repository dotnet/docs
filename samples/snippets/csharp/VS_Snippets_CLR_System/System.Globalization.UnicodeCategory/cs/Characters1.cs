// <Snippet1>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      int ctr = 0;
      UnicodeCategory category = UnicodeCategory.UppercaseLetter;
      
      for (ushort codePoint = 0; codePoint < ushort.MaxValue; codePoint++) {
         Char ch = Convert.ToChar(codePoint);

         if (CharUnicodeInfo.GetUnicodeCategory(ch) == category) {
            if (ctr % 5 == 0)
               Console.WriteLine();
            Console.Write("{0} (U+{1:X4})     ", ch, codePoint);
            ctr++;
         } 
      }
      Console.WriteLine();
      Console.WriteLine("\n{0} characters are in the {1:G} category", 
                        ctr, category);   
   }
}
// </Snippet1>

