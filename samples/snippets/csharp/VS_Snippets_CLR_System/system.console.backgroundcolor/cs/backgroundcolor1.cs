// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      WriteCharacterStrings(1, 26, true);
      Console.MoveBufferArea(0, Console.CursorTop - 10, 30, 1, 
                             Console.CursorLeft, Console.CursorTop + 1);
      Console.CursorTop = Console.CursorTop + 3;
      Console.WriteLine("Press any key..."); 
      Console.ReadKey();

      Console.Clear();
      WriteCharacterStrings(1, 26, false);
   }

   private static void WriteCharacterStrings(int start, int end, 
                                             bool changeColor)
   {                                             
      for (int ctr = start; ctr <= end; ctr++) {
         if (changeColor)
            Console.BackgroundColor = (ConsoleColor) ((ctr - 1) % 16);

         Console.WriteLine(new String(Convert.ToChar(ctr + 64), 30));
      }   
   }
}
// </Snippet1>
