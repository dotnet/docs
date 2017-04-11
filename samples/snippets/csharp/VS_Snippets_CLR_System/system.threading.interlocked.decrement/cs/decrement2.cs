// <Snippet2>
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class Example
{
   const int LOWERBOUND = 0;
   const int UPPERBOUND = 1001;
   
   static Object lockObj = new Object();
   static Random rnd = new Random();
   
   static int totalCount = 0;
   static int totalMidpoint = 0;
   static int midpointCount = 50000;

   public static void Main()
   {
      List<Task> tasks = new List<Task>();

      // Start three tasks. 
      for (int ctr = 0; ctr <= 2; ctr++) 
         tasks.Add(Task.Run( () => { int midpoint = (UPPERBOUND - LOWERBOUND) / 2;
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
                                     } while (midpointCount > 0 );
                                          
                                     Interlocked.Add(ref totalCount, total);
                                     Interlocked.Add(ref totalMidpoint, midpt);
                                          
                                     string s = String.Format("Task {0}:\n", Task.CurrentId) +
                                                String.Format("   Random Numbers: {0:N0}\n", total) + 
                                                String.Format("   Midpoint values: {0:N0} ({1:P3})", midpt, 
                                                              ((double) midpt)/total);
                                     Console.WriteLine(s); 
                                   } ));

      Task.WaitAll(tasks.ToArray());

      Console.WriteLine();
      Console.WriteLine("Total midpoint values:  {0,10:N0} ({1:P3})",
                        totalMidpoint, totalMidpoint/((double)totalCount));
      Console.WriteLine("Total number of values: {0,10:N0}", 
                        totalCount);                  
   }
}
// The example displays output like the following:
//       Task 1:
//          Random Numbers: 24,530,624
//          Midpoint values: 24,675 (0.101 %)
//       Task 2:
//          Random Numbers: 7,079,718
//          Midpoint values: 7,093 (0.100 %)
//       Task 3:
//          Random Numbers: 18,284,617
//          Midpoint values: 18,232 (0.100 %)
//       
//       Total midpoint values:      50,000 (0.100 %)
//       Total number of values: 49,894,959
// </Snippet2>