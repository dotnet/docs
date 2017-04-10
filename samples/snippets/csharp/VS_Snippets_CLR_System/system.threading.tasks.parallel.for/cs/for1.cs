// <Snippet1>
using System;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      ParallelLoopResult result = Parallel.For(0, 100, ctr => { Random rnd = new Random(ctr * 100000);
                                                                Byte[] bytes = new Byte[100];
                                                                rnd.NextBytes(bytes);
                                                                int sum = 0;
                                                                foreach(var byt in bytes)
                                                                    sum += byt;
                                                                Console.WriteLine("Iteration {0,2}: {1:N0}", ctr, sum);
                                                              });
      Console.WriteLine("Result: {0}", result.IsCompleted ? "Completed Normally" : 
                                                             String.Format("Completed to {0}", result.LowestBreakIteration));
   }
}
// The following is a portion of the output displayed by the example:
//       Iteration  0: 12,509
//       Iteration 50: 12,823
//       Iteration 51: 11,275
//       Iteration 52: 12,531
//       Iteration  1: 13,007
//       Iteration 53: 13,799
//       Iteration  4: 12,945
//       Iteration  2: 13,246
//       Iteration 54: 13,008
//       Iteration 55: 12,727
//       Iteration 56: 13,223
//       Iteration 57: 13,717
//       Iteration  5: 12,679
//       Iteration  3: 12,455
//       Iteration 58: 12,669
//       Iteration 59: 11,882
//       Iteration  6: 13,167
//       ...
//       Iteration 92: 12,275
//       Iteration 93: 13,282
//       Iteration 94: 12,745
//       Iteration 95: 11,957
//       Iteration 96: 12,455
//       Result: Completed Normally
// </Snippet1>
