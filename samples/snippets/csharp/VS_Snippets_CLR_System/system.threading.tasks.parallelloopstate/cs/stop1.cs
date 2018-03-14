// <Snippet1>
using System;
using System.Threading;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      var rnd = new Random();
      long stopIndex = rnd.Next(1, 11);

      Console.WriteLine("Will call Stop in iteration {0}\n", stopIndex);

      var result = Parallel.For(1, 10000, (i, state) => {
                                            Console.WriteLine("Beginning iteration {0}", i);
                                            int delay;
                                            Monitor.Enter(rnd);
                                               delay = rnd.Next(1, 1001);
                                            Monitor.Exit(rnd);
                                            Thread.Sleep(delay);
                                            
                                            if (i == stopIndex) {
                                               Console.WriteLine("Stop in iteration {0}", i);
                                               state.Stop();
                                               return;
                                            }

                                            if (state.IsStopped) {
                                               return;
                                            }

                                            Console.WriteLine("Completed iteration {0}", i);
                                       });
   }
}
// The example displays output like the following:
//       Will call Stop in iteration 5
//
//       Beginning iteration 1
//       Beginning iteration 9993
//       Beginning iteration 8744
//       Beginning iteration 6246
//       Beginning iteration 7495
//       Beginning iteration 3748
//       Beginning iteration 4997
//       Beginning iteration 2499
//       Beginning iteration 1250
//       Completed iteration 6246
//       Beginning iteration 6247
//       Completed iteration 3748
//       Beginning iteration 3749
//       Completed iteration 8744
//       Beginning iteration 8745
//       Completed iteration 7495
//       Beginning iteration 7496
//       Completed iteration 1250
//       Beginning iteration 1251
//       Completed iteration 2499
//       Beginning iteration 2500
//       Completed iteration 1
//       Beginning iteration 2
//       Completed iteration 2500
//       Beginning iteration 2501
//       Completed iteration 3749
//       Beginning iteration 3750
//       Completed iteration 6247
//       Beginning iteration 6248
//       Completed iteration 7496
//       Beginning iteration 7497
//       Completed iteration 3750
//       Beginning iteration 3751
//       Completed iteration 2
//       Beginning iteration 3
//       Completed iteration 9993
//       Beginning iteration 9994
//       Completed iteration 8745
//       Beginning iteration 8746
//       Completed iteration 4997
//       Completed iteration 9994
//       Beginning iteration 9995
//       Beginning iteration 4998
//       Completed iteration 6248
//       Beginning iteration 6249
//       Completed iteration 7497
//       Beginning iteration 7498
//       Completed iteration 1251
//       Beginning iteration 1252
//       Completed iteration 2501
//       Beginning iteration 2502
//       Completed iteration 9995
//       Beginning iteration 9996
//       Completed iteration 4998
//       Beginning iteration 4999
//       Completed iteration 2502
//       Beginning iteration 2503
//       Completed iteration 1252
//       Beginning iteration 1253
//       Completed iteration 7498
//       Beginning iteration 7499
//       Completed iteration 3751
//       Beginning iteration 3752
//       Completed iteration 9996
//       Beginning iteration 9997
//       Completed iteration 1253
//       Beginning iteration 1254
//       Completed iteration 9997
//       Beginning iteration 9998
//       Completed iteration 1254
//       Beginning iteration 1255
//       Completed iteration 6249
//       Beginning iteration 6250
//       Completed iteration 3
//       Beginning iteration 4
//       Completed iteration 4
//       Beginning iteration 5
//       Completed iteration 4999
//       Beginning iteration 5000
//       Completed iteration 8746
//       Beginning iteration 8747
//       Stop in iteration 5
// </Snippet1>