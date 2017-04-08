// <Snippet7>
using System;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      var t = Task<int>.Factory.StartNew( () => {
                                      // Just loop.
                                      int max = 1000000;
                                      int ctr = 0;
                                      for (ctr = 0; ctr <= max; ctr++) {
                                         if (ctr == max / 2 && DateTime.Now.Hour <= 12) {
                                            ctr++;
                                            break;
                                         }
                                      }
                                      return ctr;
                               } );
      Console.WriteLine("Finished {0:N0} iterations.", t.Result);
   }
}
// The example displays the following output:
//        Finished 1000001 loop iterations
// </Snippet7>
