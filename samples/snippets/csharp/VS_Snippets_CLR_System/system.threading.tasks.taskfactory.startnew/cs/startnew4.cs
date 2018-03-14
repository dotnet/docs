// <Snippet4>
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      CancellationTokenSource cts = new CancellationTokenSource();
      CancellationToken token = cts.Token;
      var tasks = new List<Task>();
      Random rnd = new Random();
      Object lockObj = new Object();
      String[] words6 = { "reason", "editor", "rioter", "rental",
                          "senior", "regain", "ordain", "rained" };

      foreach (var word6 in words6)
         tasks.Add(Task.Factory.StartNew( (word) => { Char[] chars = word.ToString().ToCharArray();
                                                      double[] order = new double[chars.Length];
                                                      token.ThrowIfCancellationRequested();
                                                      bool wasZero = false;
                                                      lock (lockObj) {
                                                         for (int ctr = 0; ctr < order.Length; ctr++) {
                                                             order[ctr] = rnd.NextDouble();
                                                             if (order[ctr] == 0) {
                                                                if (! wasZero) {
                                                                   wasZero = true;
                                                                }
                                                                else {
                                                                   cts.Cancel();
                                                                }
                                                             }
                                                         }
                                                      }
                                                      token.ThrowIfCancellationRequested();
                                                      Array.Sort(order, chars);
                                                      Console.WriteLine("{0} --> {1}", word,
                                                                        new String(chars));
                                                    }, word6, token));

      try {
         Task.WaitAll(tasks.ToArray());
      }
      catch (AggregateException e) {
         foreach (var ie in e.InnerExceptions) {
            if (ie is OperationCanceledException) {
               Console.WriteLine("The word scrambling operation has been cancelled.");
               break;
            }
            else {
               Console.WriteLine(ie.GetType().Name + ": " + ie.Message);
            }
         }
      }
      finally {
         cts.Dispose();
      }
   }
}
// The example displays output like the following:
//    regain --> irnaeg
//    ordain --> rioadn
//    reason --> soearn
//    rained --> rinade
//    rioter --> itrore
//    senior --> norise
//    rental --> atnerl
//    editor --> oteird
// </Snippet4>
