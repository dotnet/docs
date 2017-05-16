// <Snippet2>
using System;

public class Example
{
   public static void Main()
   {
      if (Console.BackgroundColor == ConsoleColor.Black) {
         Console.BackgroundColor = ConsoleColor.Red;
         Console.ForegroundColor = ConsoleColor.Black;
         Console.Clear();
      }
   }
}
// </Snippet2>