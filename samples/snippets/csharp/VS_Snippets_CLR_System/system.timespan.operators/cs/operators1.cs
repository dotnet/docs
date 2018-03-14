using System;

public class Class1
{
   public static void Main()
   {
      // <Snippet1>
      TimeSpan time1 = new TimeSpan(1, 0, 0, 0);   // TimeSpan equivalent to 1 day.
      TimeSpan time2 = new TimeSpan(12, 0, 0);     // TimeSpan equivalent to 1/2 day.
      TimeSpan time3 = time1 + time2;              // Add the two time spans.
      
      Console.WriteLine("  {0,12}\n +  {1,10}\n   {3}\n    {2,10}", 
                        time1, time2, time3, new String('_', 10));
      // The example displays the following output:
      //           1.00:00:00
      //        +    12:00:00
      //          __________
      //           1.12:00:00
      // </Snippet1>
   }
}
