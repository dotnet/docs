// <Snippet1>
using System;
using System.Text;

public class Example
{
   public static void Main()
   {
      StringBuilder sb = new StringBuilder(15, 15);
      sb.Append("Substring #1 ");
      try {
         sb.Insert(0, "Substring #2 ", 1);
      }
      catch (OutOfMemoryException e) {
         Console.WriteLine("Out of Memory: {0}", e.Message);
      }
   }
}
// The example displays the following output:
//    Out of Memory: Insufficient memory to continue the execution of the program.
// </Snippet1>
