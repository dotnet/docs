// <Snippet1>
using System;
using System.Threading;

public class Example
{
   const int LOWERBOUND = 0;
   const int UPPERBOUND = 1001;
   
   static Object lockObj = new Object();
   static Random rnd = new Random();
   static CountdownEvent cte;
   
   static int totalCount = 0;
   static int totalMidpoint = 0;
   static int midpointCount = 10000;

   public static void Main()
   {
      cte = new CountdownEvent(1);
      // Start three threads. 
      for (int ctr = 0; ctr <= 2; ctr++) {
         cte.AddCount();
         Thread th = new Thread(GenerateNumbers);
         th.Name = "Thread" + ctr.ToString();
         th.Start();
      }
      cte.Signal();
      cte.Wait();
      Console.WriteLine();
      Console.WriteLine("Total midpoint values:  {0,10:N0} ({1:P3})",
                        totalMidpoint, totalMidpoint/((double)totalCount));
      Console.WriteLine("Total number of values: {0,10:N0}", 
                        totalCount);                  
   }

   private static void GenerateNumbers()
   {
      int midpoint = (UPPERBOUND - LOWERBOUND) / 2;
      int value = 0;
      int total = 0;
      int midpt = 0;
      
      do {
         lock (lockObj) {
            value = rnd.Next(LOWERBOUND, UPPERBOUND);
         }
         if (value == midpoint) { 
            Interlocked.Decrement(ref midpointCount);
            midpt++;
         }
         total++;    
      } while (midpointCount > 0);
      
      Interlocked.Add(ref totalCount, total);
      Interlocked.Add(ref totalMidpoint, midpt);
      
      string s = String.Format("Thread {0}:\n", Thread.CurrentThread.Name) +
                 String.Format("   Random Numbers: {0:N0}\n", total) + 
                 String.Format("   Midpoint values: {0:N0} ({1:P3})", midpt, 
                               ((double) midpt)/total);
      Console.WriteLine(s);
      cte.Signal();
   }
}
// The example displays output like the following:
//       Thread Thread2:
//          Random Numbers: 3,204,021
//          Midpoint values: 3,156 (0.099 %)
//       Thread Thread0:
//          Random Numbers: 4,073,592
//          Midpoint values: 4,015 (0.099 %)
//       Thread Thread1:
//          Random Numbers: 2,828,192
//          Midpoint values: 2,829 (0.100 %)
//       
//       Total midpoint values:      10,000 (0.099 %)
//       Total number of values: 10,105,805
// </Snippet1>