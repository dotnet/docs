// <Snippet1>
using System;

class Example
{
   public static void Main() 
   {
      // Get an array with the values of ConsoleColor enumeration members.
      ConsoleColor[] colors = (ConsoleColor[]) ConsoleColor.GetValues(typeof(ConsoleColor));
      // Save the current background and foreground colors.
      ConsoleColor currentBackground = Console.BackgroundColor;
      ConsoleColor currentForeground = Console.ForegroundColor;

      // Display all foreground colors except the one that matches the background.
      Console.WriteLine("All the foreground colors except {0}, the background color:",
                        currentBackground);
      foreach (var color in colors) {
         if (color == currentBackground) continue;
         
         Console.ForegroundColor = color;
         Console.WriteLine("   The foreground color is {0}.", color);
      }
      Console.WriteLine();
      // Restore the foreground color.
      Console.ForegroundColor = currentForeground;
      
      // Display each background color except the one that matches the current foreground color.
      Console.WriteLine("All the background colors except {0}, the foreground color:",
                        currentForeground);
      foreach (var color in colors) {
         if (color == currentForeground) continue;
         
         Console.BackgroundColor = color;
         Console.WriteLine("   The background color is {0}.", color);
      }
      
      // Restore the original console colors.
      Console.ResetColor();
      Console.WriteLine("\nOriginal colors restored...");
   }
}
//The example displays output like the following:
//    All the foreground colors except DarkCyan, the background color:
//       The foreground color is Black.
//       The foreground color is DarkBlue.
//       The foreground color is DarkGreen.
//       The foreground color is DarkRed.
//       The foreground color is DarkMagenta.
//       The foreground color is DarkYellow.
//       The foreground color is Gray.
//       The foreground color is DarkGray.
//       The foreground color is Blue.
//       The foreground color is Green.
//       The foreground color is Cyan.
//       The foreground color is Red.
//       The foreground color is Magenta.
//       The foreground color is Yellow.
//       The foreground color is White.
//    
//    All the background colors except White, the foreground color:
//       The background color is Black.
//       The background color is DarkBlue.
//       The background color is DarkGreen.
//       The background color is DarkCyan.
//       The background color is DarkRed.
//       The background color is DarkMagenta.
//       The background color is DarkYellow.
//       The background color is Gray.
//       The background color is DarkGray.
//       The background color is Blue.
//       The background color is Green.
//       The background color is Cyan.
//       The background color is Red.
//       The background color is Magenta.
//       The background color is Yellow.
//    
//    Original colors restored...
//</snippet1>
