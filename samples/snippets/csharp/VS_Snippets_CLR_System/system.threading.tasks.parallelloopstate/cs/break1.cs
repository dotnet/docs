// <Snippet2>
using System;
using System.Threading;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      var rnd = new Random();
      int breakIndex = rnd.Next(1, 11);
      Nullable<long> lowest = new Nullable<long>();

      Console.WriteLine("Will call Break at iteration {0}\n",
                        breakIndex);

      var result = Parallel.For(1, 101, (i, state) => {
                                            Console.WriteLine("Beginning iteration {0}", i);
                                            int delay;
                                            Monitor.Enter(rnd);
                                               delay = rnd.Next(1, 1001);
                                            Monitor.Exit(rnd);
                                            Thread.Sleep(delay);
                                            
                                            if (state.ShouldExitCurrentIteration) {
                                               if (state.LowestBreakIteration < i)
                                                  return;
                                            }

                                            if (i == breakIndex) {
                                               Console.WriteLine("Break in iteration {0}", i);
                                               state.Break();
                                               if (state.LowestBreakIteration.HasValue)
                                                  if (lowest < state.LowestBreakIteration)
                                                     lowest = state.LowestBreakIteration;
                                                  else
                                                     lowest = state.LowestBreakIteration;
                                            }

                                            Console.WriteLine("Completed iteration {0}", i);
                                       });
         if (lowest.HasValue)
            Console.WriteLine("\nLowest Break Iteration: {0}", lowest);
         else
            Console.WriteLine("\nNo lowest break iteration.");
   }
}
// The example displays output like the following:
//       Will call Break at iteration 8
//
//       Beginning iteration 1
//       Beginning iteration 13
//       Beginning iteration 97
//       Beginning iteration 25
//       Beginning iteration 49
//       Beginning iteration 37
//       Beginning iteration 85
//       Beginning iteration 73
//       Beginning iteration 61
//       Completed iteration 85
//       Beginning iteration 86
//       Completed iteration 61
//       Beginning iteration 62
//       Completed iteration 86
//       Beginning iteration 87
//       Completed iteration 37
//       Beginning iteration 38
//       Completed iteration 38
//       Beginning iteration 39
//       Completed iteration 25
//       Beginning iteration 26
//       Completed iteration 26
//       Beginning iteration 27
//       Completed iteration 73
//       Beginning iteration 74
//       Completed iteration 62
//       Beginning iteration 63
//       Completed iteration 39
//       Beginning iteration 40
//       Completed iteration 40
//       Beginning iteration 41
//       Completed iteration 13
//       Beginning iteration 14
//       Completed iteration 1
//       Beginning iteration 2
//       Completed iteration 97
//       Beginning iteration 98
//       Completed iteration 49
//       Beginning iteration 50
//       Completed iteration 87
//       Completed iteration 27
//       Beginning iteration 28
//       Completed iteration 50
//       Beginning iteration 51
//       Beginning iteration 88
//       Completed iteration 14
//       Beginning iteration 15
//       Completed iteration 15
//       Completed iteration 2
//       Beginning iteration 3
//       Beginning iteration 16
//       Completed iteration 63
//       Beginning iteration 64
//       Completed iteration 74
//       Beginning iteration 75
//       Completed iteration 41
//       Beginning iteration 42
//       Completed iteration 28
//       Beginning iteration 29
//       Completed iteration 29
//       Beginning iteration 30
//       Completed iteration 98
//       Beginning iteration 99
//       Completed iteration 64
//       Beginning iteration 65
//       Completed iteration 42
//       Beginning iteration 43
//       Completed iteration 88
//       Beginning iteration 89
//       Completed iteration 51
//       Beginning iteration 52
//       Completed iteration 16
//       Beginning iteration 17
//       Completed iteration 43
//       Beginning iteration 44
//       Completed iteration 44
//       Beginning iteration 45
//       Completed iteration 99
//       Beginning iteration 4
//       Completed iteration 3
//       Beginning iteration 8
//       Completed iteration 4
//       Beginning iteration 5
//       Completed iteration 52
//       Beginning iteration 53
//       Completed iteration 75
//       Beginning iteration 76
//       Completed iteration 76
//       Beginning iteration 77
//       Completed iteration 65
//       Beginning iteration 66
//       Completed iteration 5
//       Beginning iteration 6
//       Completed iteration 89
//       Beginning iteration 90
//       Completed iteration 30
//       Beginning iteration 31
//       Break in iteration 8
//       Completed iteration 8
//       Completed iteration 6
//       Beginning iteration 7
//       Completed iteration 7
//
//       Lowest Break Iteration: 8
// </Snippet2>

