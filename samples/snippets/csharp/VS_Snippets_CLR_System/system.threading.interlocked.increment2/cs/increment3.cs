// <Snippet3>
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
   static int midpointCount = 0;

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
            Interlocked.Increment(ref midpointCount);
            midpt++;
         }
         total++;    
      } while (midpointCount < 10000);
      
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
//          Random Numbers: 2,776,674
//          Midpoint values: 2,773 (0.100 %)
//       Thread Thread1:
//          Random Numbers: 4,876,100
//          Midpoint values: 4,873 (0.100 %)
//       Thread Thread0:
//          Random Numbers: 2,312,310
//          Midpoint values: 2,354 (0.102 %)
//       
//       Total midpoint values:      10,000 (0.100 %)
//       Total number of values:  9,965,084
// </Snippet3>
