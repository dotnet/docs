using System;

public enum ArrivalStatus { Unknown=-3, Late=-1, OnTime=0, Early=1 };

public class Example
{
   public static void Main()
   {
      // <Snippet8>
      ArrivalStatus status = ArrivalStatus.Early;
      var number = Convert.ChangeType(status, Enum.GetUnderlyingType(typeof(ArrivalStatus)));
      Console.WriteLine("Converted {0} to {1}", status, number);
      // The example displays the following output:
      //       Converted Early to 1
      // </Snippet8>
   }
}
