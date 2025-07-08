// <Snippet6>
using System;

public class Example5
{
   public unsafe static void Main()
   {
      sbyte[] bytes = { 0x61, 0x62, 0x063, 0x064, 0x00, 0x41, 0x42, 0x43, 0x44, 0x00 };
      
      string s = null;
      fixed (sbyte* bytePtr = bytes) {
         s = new string(bytePtr, 0, bytes.Length);
      }
      
      foreach (var ch in s)
         Console.Write($"{(ushort)ch:X4} ");
      
      Console.WriteLine();    

      fixed(sbyte* bytePtr = bytes) {
         s = new string(bytePtr);         
      }
      
      foreach (var ch in s)
         Console.Write($"{(ushort)ch:X4} ");
      Console.WriteLine();    
   }
}
// The example displays the following output:
//       0061 0062 0063 0064 0000 0041 0042 0043 0044 0000
//       0061 0062 0063 0064
// </Snippet6>
