// <Snippet4>
using System;
using System.Threading;

public class Example
{
   public static void Main()
   {
      Random rand1 = new Random((int) DateTime.Now.Ticks & 0x0000FFFF);
      Random rand2 = new Random((int) DateTime.Now.Ticks & 0x0000FFFF);
      Thread.Sleep(20);
      Random rand3 = new Random((int) DateTime.Now.Ticks & 0x0000FFFF);
      ShowRandomNumbers(rand1);
      ShowRandomNumbers(rand2);
      ShowRandomNumbers(rand3);
   }

   private static void ShowRandomNumbers(Random rand)
   {
      Console.WriteLine();
      byte[] values = new byte[4];
      rand.NextBytes(values);
      foreach (var value in values)
         Console.Write("{0, 5}", value);

      Console.WriteLine(); 
   }
}
// The example displays output similar to the following:
//   145  214  177  134  173
// 
//   145  214  177  134  173
// 
//   126  185  175  249  157
// </Snippet4>
