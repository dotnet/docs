// <Snippet3>
using System;
using System.Threading;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      var cts = new CancellationTokenSource();
      var token = cts.Token;

      // Get an integer to generate a list of its exponents.
      var rnd = new Random();
      var number = rnd.Next(2, 21);
      
      var t = Task.Factory.StartNew( (value) => { int n = (int) value;
                                                  long[] values = new long[10];
                                                  for (int ctr = 1; ctr <= 10; ctr++)
                                                     values[ctr - 1] = (long) Math.Pow(n, ctr);
                                                     
                                                  return values;
                                                }, number);
      var continuation = t.ContinueWith( (antecedent, value) => { Console.WriteLine("Exponents of {0}:", value);
                                                                  for (int ctr = 0; ctr <= 9; ctr++)
                                                                     Console.WriteLine("   {0} {1} {2} = {3:N0}",
                                                                                       value, "\u02C6", ctr + 1,
                                                                                       antecedent.Result[ctr]);
                                                                  Console.WriteLine();
                                                                }, number);
      continuation.Wait();
      cts.Dispose();
   }
}
// The example displays output like the following:
//       Exponents of 2:
//          2 ^ 1 = 2
//          2 ^ 2 = 4
//          2 ^ 3 = 8
//          2 ^ 4 = 16
//          2 ^ 5 = 32
//          2 ^ 6 = 64
//          2 ^ 7 = 128
//          2 ^ 8 = 256
//          2 ^ 9 = 512
//          2 ^ 10 = 1,024
// </Snippet3>