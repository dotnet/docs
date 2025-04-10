using System;

// <Snippet1>
public enum ArrivalStatus { Unknown=-3, Late=-1, OnTime=0, Early=1 };
// </Snippet1>

// <Snippet2>
public class Example
{
   public static void Main()
   {
      ArrivalStatus status = ArrivalStatus.OnTime;
      Console.WriteLine($"Arrival Status: {status} ({status:D})");
   }
}
// The example displays the following output:
//       Arrival Status: OnTime (0)
// </Snippet2>
