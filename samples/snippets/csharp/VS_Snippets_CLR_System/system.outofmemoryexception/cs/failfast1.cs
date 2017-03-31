// <Snippet2>
using System;

public class Example
{
   public static void Main()
   {
      try {
         // Outer block to handle any unexpected exceptions.
         try {
            string s = "This";
            s = s.Insert(2, "is ");

            // Throw an OutOfMemoryException exception.
            throw new OutOfMemoryException();
         }
         catch (ArgumentException) {
            Console.WriteLine("ArgumentException in String.Insert");
         }

         // Execute program logic.
      }
      catch (OutOfMemoryException e) {
         Console.WriteLine("Terminating application unexpectedly...");
         Environment.FailFast(String.Format("Out of Memory: {0}",
                                            e.Message));
      }
   }
}
// The example displays the following output:
//        Terminating application unexpectedly...
// </Snippet2>
