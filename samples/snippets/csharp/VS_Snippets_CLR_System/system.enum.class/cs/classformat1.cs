using System;

public enum ArrivalStatus { Unknown=-3, Late=-1, OnTime=0, Early=1 };

public class Example
{
   public static void Main()
   {
      // <Snippet10>
      string[] formats= { "G", "F", "D", "X"};
      ArrivalStatus status = ArrivalStatus.Late;
      foreach (var fmt in formats)
         Console.WriteLine(status.ToString(fmt));

      // The example displays the following output:
      //       Late
      //       Late
      //       -1
      //       FFFFFFFF
      // </Snippet10>
   }
}
