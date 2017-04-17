// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      string line;
      Console.WriteLine("Enter one or more lines of text (press CTRL+Z to exit):");
      Console.WriteLine();
      do { 
         Console.Write("   ");
         line = Console.ReadLine();
         if (line != null) 
            Console.WriteLine("      " + line);
      } while (line != null);   
   }
}
// The following displays possible output from this example:
//       Enter one or more lines of text (press CTRL+Z to exit):
//       
//          This is line #1.
//             This is line #1.
//          This is line #2
//             This is line #2
//          ^Z
//       
//       >
// </Snippet1>
