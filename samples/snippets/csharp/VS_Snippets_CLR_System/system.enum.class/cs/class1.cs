using System;

// <Snippet1>
public enum ArrivalStatus { Late=-1, OnTime=0, Early=1 };
// </Snippet1>

// <Snippet2>
public class Example
{
   public static void Main()
   {
      ArrivalStatus status = ArrivalStatus.OnTime;
      Console.WriteLine("Arrival Status: {0} ({0:D})", status);
   }
}
// The example displays the following output:
//       Arrival Status: OnTime (0)
// </Snippet2>
