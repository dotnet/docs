// <Snippet6>
using System;
using System.Threading.Tasks;

public class Example
{
   public static async Task Main()
   {
      await Task.Run( () => {
                                  // Just loop.
                                  int ctr = 0;
                                  for (ctr = 0; ctr <= 1000000; ctr++)
                                  {}
                                  Console.WriteLine($"Finished {ctr} loop iterations");
                               } );
   }
}
// The example displays the following output:
//        Finished 1000001 loop iterations
// </Snippet6>
