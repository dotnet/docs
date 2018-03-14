// <Snippet9>
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      var rnd = new Random();
      var tasks = new List<Task<BigInteger[]>>();
      var source = new CancellationTokenSource();
      var token = source.Token;
      for (int ctr = 0; ctr <= 1; ctr++) {
         int start = ctr;
         tasks.Add(Task.Run( () => { BigInteger[] sequence = new BigInteger[100];
                                     sequence[0] = start;
                                     sequence[1] = 1;
                                     for (int index = 2; index <= sequence.GetUpperBound(0); index++) {
                                        token.ThrowIfCancellationRequested();
                                        sequence[index] = sequence[index - 1] + sequence[index - 2];
                                     }
                                     return sequence;
                                   }, token));
      }
      if (rnd.Next(0, 2) == 1)
         source.Cancel();
      try {
         Task.WaitAll(tasks.ToArray());
         foreach (var t in tasks)
            Console.WriteLine("{0}, {1}...{2:N0}", t.Result[0], t.Result[1],
                              t.Result[99]);
      }
      catch (AggregateException e) {
         foreach (var ex in e.InnerExceptions)
            Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);
      }
   }
}
// The example displays either the following output:
//    0, 1...218,922,995,834,555,169,026
//    1, 1...354,224,848,179,261,915,075
// or the following output:
//    TaskCanceledException: A task was canceled.
//    TaskCanceledException: A task was canceled.
// </Snippet9>
