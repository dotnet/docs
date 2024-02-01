// <Snippet2>
using System;

public class Example4
{
   public static unsafe void Main()
   {
      char[] characters = { 'H', 'e', 'l', 'l', 'o', ' ', 
                            'w', 'o', 'r', 'l', 'd', '!', '\u0000' };
      string value;
      
      fixed (char* charPtr = characters) {
         value = new String(charPtr);
      }                            
      Console.WriteLine(value);
   }
}
// The example displays the following output:
//        Hello world!
// </Snippet2>
