// <Snippet3>
using System;

public class Example1
{
   public static unsafe void Main()
   {
      char[] characters = { 'H', 'e', 'l', 'l', 'o', ' ', 
                            'w', 'o', 'r', 'l', 'd', '!', '\u0000' };
      String value;
      
      fixed (char* charPtr = characters) {
         int length = 0;
         Char* iterator = charPtr;
   
         while (*iterator != '\x0000')
         {
            if (*iterator == '!' || *iterator == '.')
               break;
            iterator++;
            length++;
         }
         value = new String(charPtr, 0, length);
      }
      Console.WriteLine(value);
   }
}
// The example displays the following output:
//      Hello World
// </Snippet3>
