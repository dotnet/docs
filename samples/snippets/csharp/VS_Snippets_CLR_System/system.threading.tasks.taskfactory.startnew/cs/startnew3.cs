// <Snippet3>
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      var tasks = new List<Task>();
      Random rnd = new Random();
      Object lockObj = new Object();
      String[] words6 = { "reason", "editor", "rioter", "rental",
                          "senior", "regain", "ordain", "rained" };

      foreach (var word6 in words6)
         tasks.Add(Task.Factory.StartNew( (word) => { Char[] chars = word.ToString().ToCharArray();
                                                      double[] order = new double[chars.Length];
                                                      lock (lockObj) {
                                                         for (int ctr = 0; ctr < order.Length; ctr++)
                                                             order[ctr] = rnd.NextDouble();
                                                      }
                                                      Array.Sort(order, chars);
                                                      Console.WriteLine("{0} --> {1}", word,
                                                                        new String(chars));
                                                    }, word6));

      Task.WaitAll(tasks.ToArray());
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
// </Snippet3>
