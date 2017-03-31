// <Snippet2>
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

public struct OperationTime
{
   public OperationTime(int ctr, TimeSpan elapsed)
   {
      Operations = ctr;
      ElapsedTime = elapsed;
   }
   
   public int Operations;
   public TimeSpan ElapsedTime;
}

public class Example
{
   public static void Main()
   {
      List<OperationTime> stringTimes = new List<OperationTime>();
      List<OperationTime> builderTimes = new List<OperationTime>();
       
      // Begin the time for a string
      Stopwatch sTimer = new Stopwatch();
      Stopwatch sbTimer = new Stopwatch();
      
      // We want to include object instantiation in the timer.
      sTimer.Start();
      string baseS1 = "Beginning";
      sTimer.Stop();
      
      sbTimer.Start();
      StringBuilder baseS2 = new StringBuilder("Beginning");
      sbTimer.Stop();
      
      // Record time for every 10 operations for a 100 operation string concatenation.
      sTimer.Start();
      for (int ctr = 1; ctr <= 100; ctr++) {
         baseS1 += "a";
         if (ctr % 10 == 0) {
            sTimer.Stop();
            stringTimes.Add(new OperationTime(ctr, sTimer.Elapsed));
            sTimer.Start();
         }
      };
      sTimer.Stop();
      
      sbTimer.Start();
      for (int ctr = 1; ctr <= 100; ctr++) {
         baseS2.Append("a");
         if (ctr % 10 == 0) {
            sbTimer.Stop();
            builderTimes.Add(new OperationTime(ctr, sbTimer.Elapsed));
            sbTimer.Start();
         }
      }
      sbTimer.Stop();

      // Display performance information
      Console.WriteLine("{0,10} {1,20} {2,20}", 
                        "Operations", "String Time", "StringBuilder Time");

      for (int ctr = 0; ctr < stringTimes.Count; ctr++) 
         Console.WriteLine("{0,10} {1,20} {2,20}", stringTimes[ctr].Operations,
                           stringTimes[ctr].ElapsedTime, builderTimes[ctr].ElapsedTime);      
   }
}
// The example displays the following output:
//    Operations          String Time   StringBuilder Time
//            10     00:00:00.0000019     00:00:00.0000087
//            20     00:00:00.0000025     00:00:00.0000087
//            30     00:00:00.0000032     00:00:00.0000090
//            40     00:00:00.0000038     00:00:00.0000090
//            50     00:00:00.0000090     00:00:00.0000094
//            60     00:00:00.0000097     00:00:00.0000097
//            70     00:00:00.0000103     00:00:00.0000097
//            80     00:00:00.0000110     00:00:00.0000100
//            90     00:00:00.0000181     00:00:00.0000100
//           100     00:00:00.0000188     00:00:00.0000103
// </Snippet2>
