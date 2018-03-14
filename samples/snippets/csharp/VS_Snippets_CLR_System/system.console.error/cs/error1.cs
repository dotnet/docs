// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      int increment = 0;
      bool exitFlag = false;

      while (! exitFlag) {
         if (Console.IsOutputRedirected)
            Console.Error.WriteLine("Generating multiples of numbers from {0} to {1}",
                                    increment + 1, increment + 10);

         Console.WriteLine("Generating multiples of numbers from {0} to {1}",
                           increment + 1, increment + 10);
         for (int ctr = increment + 1; ctr <= increment + 10; ctr++) {
            Console.Write("Multiples of {0}: ", ctr);
            for (int ctr2 = 1; ctr2 <= 10; ctr2++)
               Console.Write("{0}{1}", ctr * ctr2, ctr2 == 10 ? "" : ", ");

            Console.WriteLine();
         }
         Console.WriteLine();

         increment += 10;
         Console.Error.Write("Display multiples of {0} through {1} (y/n)? ",
                             increment + 1, increment + 10);
         Char response = Console.ReadKey(true).KeyChar;
         Console.Error.WriteLine(response);
         if (! Console.IsOutputRedirected)
            Console.CursorTop--;

         if (Char.ToUpperInvariant(response) == 'N')
            exitFlag = true;
      }
   }
}
// </Snippet1>
