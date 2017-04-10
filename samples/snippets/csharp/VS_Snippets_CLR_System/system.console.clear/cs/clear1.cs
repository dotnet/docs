// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      // Save colors so they can be restored when use finishes input.
      ConsoleColor dftForeColor = Console.ForegroundColor;
      ConsoleColor dftBackColor = Console.BackgroundColor;
      bool continueFlag = true;
      Console.Clear();
            
      do { 
         ConsoleColor newForeColor = ConsoleColor.White;
         ConsoleColor newBackColor = ConsoleColor.Black;
                  
         Char foreColorSelection = GetKeyPress("Select Text Color (B for Blue, R for Red, Y for Yellow): ", 
                                              new Char[] { 'B', 'R', 'Y' } );
         switch (foreColorSelection) {
            case 'B':
            case 'b':
               newForeColor = ConsoleColor.DarkBlue;
               break;
            case 'R':
            case 'r':
               newForeColor = ConsoleColor.DarkRed;
               break;
            case 'Y':
            case 'y':
               newForeColor = ConsoleColor.DarkYellow;
               break;   
         }
         Char backColorSelection = GetKeyPress("Select Background Color (W for White, G for Green, M for Magenta): ",
                                              new Char[] { 'W', 'G', 'M' });
         switch (backColorSelection) {
            case 'W':
            case 'w':
               newBackColor = ConsoleColor.White;
               break;
            case 'G':
            case 'g':
               newBackColor = ConsoleColor.Green;
               break;
            case 'M':
            case 'm':
               newBackColor = ConsoleColor.Magenta;
               break;   
         }
         
         Console.WriteLine();
         Console.Write("Enter a message to display: ");
         String textToDisplay = Console.ReadLine();
         Console.WriteLine();
         Console.ForegroundColor = newForeColor;
         Console.BackgroundColor = newBackColor;
         Console.WriteLine(textToDisplay);
         Console.WriteLine();
         if (Char.ToUpper(GetKeyPress("Display another message (Y/N): ", new Char[] { 'Y', 'N' } )) == 'N')
            continueFlag = false;

         // Restore the default settings and clear the screen.
         Console.ForegroundColor = dftForeColor;
         Console.BackgroundColor = dftBackColor;
         Console.Clear();
      } while (continueFlag);
   }

   private static Char GetKeyPress(String msg, Char[] validChars) 
   {
      ConsoleKeyInfo keyPressed;
      bool valid = false;
      
      Console.WriteLine();
      do {
         Console.Write(msg);
         keyPressed = Console.ReadKey();
         Console.WriteLine();
         if (Array.Exists(validChars, ch => ch.Equals(Char.ToUpper(keyPressed.KeyChar))))           
            valid = true;

      } while (! valid);
      return keyPressed.KeyChar; 
   }
}
// </Snippet1>