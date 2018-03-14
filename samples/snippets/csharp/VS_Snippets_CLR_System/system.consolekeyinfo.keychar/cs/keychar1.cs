// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      // Configure console.
      Console.BufferWidth = 80;
      Console.WindowWidth = Console.BufferWidth;
      Console.TreatControlCAsInput = true;
      
      string inputString = String.Empty;
      ConsoleKeyInfo keyInfo;

      Console.WriteLine("Enter a string. Press <Enter> or Esc to exit.");
      do {
         keyInfo = Console.ReadKey(true);
         // Ignore if Alt or Ctrl is pressed.
         if ((keyInfo.Modifiers & ConsoleModifiers.Alt) == ConsoleModifiers.Alt) 
            continue;
         if ((keyInfo.Modifiers & ConsoleModifiers.Control) == ConsoleModifiers.Control)
            continue; 
         // Ignore if KeyChar value is \u0000.
         if (keyInfo.KeyChar == '\u0000') continue;
         // Ignore tab key.
         if (keyInfo.Key == ConsoleKey.Tab) continue;
         // Handle backspace.
         if (keyInfo.Key == ConsoleKey.Backspace) {
            // Are there any characters to erase?
            if (inputString.Length >= 1) { 
               // Determine where we are in the console buffer.
               int cursorCol = Console.CursorLeft - 1;
               int oldLength = inputString.Length;
               int extraRows = oldLength / 80;

               inputString = inputString.Substring(0, oldLength - 1);
               Console.CursorLeft = 0;
               Console.CursorTop = Console.CursorTop - extraRows;
               Console.Write(inputString + new String(' ', oldLength - inputString.Length));
               Console.CursorLeft = cursorCol;
            }
            continue;
         }
         // Handle Escape key.
         if (keyInfo.Key == ConsoleKey.Escape) break;
         // Handle key by adding it to input string.
         Console.Write(keyInfo.KeyChar);
         inputString += keyInfo.KeyChar;
      } while (keyInfo.Key != ConsoleKey.Enter);
      Console.WriteLine("\n\nYou entered:\n    {0}", 
                        String.IsNullOrEmpty(inputString) ? "<nothing>" : inputString);
   }
}
// </Snippet1>
