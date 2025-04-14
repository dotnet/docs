using System;

public class Example
{
   public static void Main()
   {
      // <Snippet20>
      TimeSpan ts = new TimeSpan(1003498765432);
      string fmt;
      Console.WriteLine(ts.ToString("c"));
      Console.WriteLine();

      for (int ctr = 1; ctr <= 7; ctr++) {
         fmt = new String('f', ctr);
         if (fmt.Length == 1) fmt = "%" + fmt;
         Console.WriteLine($"{fmt,10}: {ts.ToString(fmt)}");
      }
      Console.WriteLine();

      for (int ctr = 1; ctr <= 7; ctr++) {
         fmt = new String('f', ctr);
         Console.WriteLine($"{"s\\." + fmt,10}: {ts.ToString("s\\." + fmt)}");
      }
      // The example displays the following output:
      //               %f: 8
      //               ff: 87
      //              fff: 876
      //             ffff: 8765
      //            fffff: 87654
      //           ffffff: 876543
      //          fffffff: 8765432
      //
      //              s\.f: 29.8
      //             s\.ff: 29.87
      //            s\.fff: 29.876
      //           s\.ffff: 29.8765
      //          s\.fffff: 29.87654
      //         s\.ffffff: 29.876543
      //        s\.fffffff: 29.8765432
      // </Snippet20>
   }
}
