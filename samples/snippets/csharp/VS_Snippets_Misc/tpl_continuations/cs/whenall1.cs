// <Snippet5>
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      List<Task<int>> tasks = new List<Task<int>>();
      for (int ctr = 1; ctr <= 10; ctr++) {
         int baseValue = ctr;
         tasks.Add(Task.Factory.StartNew( (b) => { int i = (int) b;
                                                   return i * i; }, baseValue));
      }
      var continuation = Task.WhenAll(tasks);

      long sum = 0;
      for (int ctr = 0; ctr <= continuation.Result.Length - 1; ctr++) {
         Console.Write("{0} {1} ", continuation.Result[ctr],
                       ctr == continuation.Result.Length - 1 ? "=" : "+");
         sum += continuation.Result[ctr];
      }
      Console.WriteLine(sum);
   }
}
// The example displays the following output:
//    1 + 4 + 9 + 16 + 25 + 36 + 49 + 64 + 81 + 100 = 385
// </Snippet5>