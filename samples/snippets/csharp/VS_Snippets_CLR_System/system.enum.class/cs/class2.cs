using System;

public enum ArrivalStatus { Late=-1, OnTime=0, Early=1 };

public class Example
{
   public static void Main()
   {
      // <Snippet3>
      ArrivalStatus status1 = new ArrivalStatus();
      Console.WriteLine("Arrival Status: {0} ({0:D})", status1);
      // The example displays the following output:
      //       Arrival Status: OnTime (0)
      // </Snippet3>

      // <Snippet4>
      ArrivalStatus status2 = (ArrivalStatus) 1;
      Console.WriteLine("Arrival Status: {0} ({0:D})", status2);
      // The example displays the following output:
      //       Arrival Status: Early (1)
      // </Snippet4>

      // <Snippet5>
      int value3 = 2;
      ArrivalStatus status3 = (ArrivalStatus) value3;
      
      int value4 = (int) status3;
      // </Snippet5>
      
      // <Snippet6>
      int number = -1;
      ArrivalStatus arrived = (ArrivalStatus) ArrivalStatus.ToObject(typeof(ArrivalStatus), number);
      // </Snippet6>
   }
}
