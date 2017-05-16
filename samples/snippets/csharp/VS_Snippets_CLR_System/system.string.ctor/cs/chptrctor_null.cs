// <Snippet5>
using System;

public class Example
{
   public unsafe static void Main()
   {
      char[] chars = { 'a', 'b', 'c', 'd', '\0', 'A', 'B', 'C', 'D', '\0' };
      string s = null;
      
      fixed(char* chPtr = chars) {
         s = new string(chPtr, 0, chars.Length);            
      } 

      foreach (var ch in s)
         Console.Write("{0:X4} ", Convert.ToUInt16(ch));
      Console.WriteLine();
      
      fixed(char* chPtr = chars) {
         s = new string(chPtr);         
      }
      
      foreach (var ch in s)
         Console.Write("{0:X4} ", Convert.ToUInt16(ch));
      Console.WriteLine();    
   }
}
// The example displays the following output:
//       0061 0062 0063 0064 0000 0041 0042 0043 0044 0000
//       0061 0062 0063 0064
// </Snippet5>
