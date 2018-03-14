// <Snippet2>
using System;
using System.Threading;

public class RandomNumbers
{
   public static void Main()
   {
      Random rand1 = new Random();
      Random rand2 = new Random();
      Thread.Sleep(2000);
      Random rand3 = new Random();
      ShowRandomNumbers(rand1);
      ShowRandomNumbers(rand2);
      ShowRandomNumbers(rand3);
   }

   private static void ShowRandomNumbers(Random rand)
   {
      Console.WriteLine();
      byte[] values = new byte[5];
      rand.NextBytes(values);
      foreach (byte value in values)
         Console.Write("{0, 5}", value);
      Console.WriteLine();   
   }
}
// The example displays the following output to the console:
//       28   35  133  224   58
//    
//       28   35  133  224   58
//    
//       32  222   43  251   49
// </Snippet2>
