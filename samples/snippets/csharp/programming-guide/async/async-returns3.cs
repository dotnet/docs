using System;
using System.Threading.Tasks;

public class Counter
{
   private int threshold = 0;
   private int iterations = 0;
   private int ctr = 0;

   event EventHandler<EventArgs> ThresholdReached;

   public Counter(int threshold)
   {
      this.threshold = threshold;
      ThresholdReached += thresholdReachedEvent;
   }

   public async Task<int> StartCounting(int limit)
   {
      iterations = 1;
      for (int index = 0; index <= limit; index++) {
         if (ctr == threshold)
            thresholdReachedEvent(this, EventArgs.Empty);
         ctr++;
         await Task.Delay(500);
      }
      int retval = ctr + (iterations - 1) * threshold;
      Console.WriteLine($"On iteration {iterations}, reached {limit}");
      return retval;    
   }

   async void thresholdReachedEvent(object sender, EventArgs e)
   {
       Console.WriteLine($"Reached {ctr}. Resetting...");
       await Task.Delay(1000);
       ctr = 0;
       iterations++;
   }
}

public class Example
{
   public static void Main()
   {
      RunCounter().Wait();
   }

   private static async Task RunCounter()
   {
      var count = new Counter(5);
      await count.StartCounting(8);
   }
}
