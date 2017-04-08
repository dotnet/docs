// <Snippet2>
using System;
using System.Collections;
using System.Collections.Generic;

public class PitcherComparer<T1, T2, T3, T4> : IComparer
{
   public int Compare(object x, object y)
   {
      Tuple<T1, T2, T3, T4> tX = x as Tuple<T1, T2, T3, T4>;
      if (tX == null)
      { 
         return 0;
      }   
      else
      {
         Tuple<T1, T2, T3, T4> tY = y as Tuple<T1, T2, T3, T4>;
         return Comparer<T3>.Default.Compare(tX.Item3, tY.Item3);             
      }
   }
}

public class Example
{
   public static void Main()
   {
      Tuple<string, double, double, int>[] pitchers = 
                    { Tuple.Create("McHale, Joe", 240.1, 3.60, 221),
                      Tuple.Create("Paul, Dave", 233.1, 3.24, 231), 
                      Tuple.Create("Williams, Mike", 193.2, 4.00, 183),
                      Tuple.Create("Blair, Jack", 168.1, 3.48, 146), 
                      Tuple.Create("Henry, Walt", 140.1, 1.92, 96),
                      Tuple.Create("Lee, Adam", 137.2, 2.94, 109),
                      Tuple.Create("Rohr, Don", 101.0, 3.74, 110) };

      Console.WriteLine("The values in unsorted order:");
      foreach (var pitcher in pitchers)
         Console.WriteLine(pitcher.ToString());

      Console.WriteLine();

      Array.Sort(pitchers, new PitcherComparer<string, double, double, int>());

      Console.WriteLine("The values sorted by earned run average (component 3):");
      foreach (var pitcher in pitchers)
         Console.WriteLine(pitcher.ToString());
   }
}
// The example displays the following output;
//       The values in unsorted order:
//       (McHale, Joe, 240.1, 3.6, 221)
//       (Paul, Dave, 233.1, 3.24, 231)
//       (Williams, Mike, 193.2, 4, 183)
//       (Blair, Jack, 168.1, 3.48, 146)
//       (Henry, Walt, 140.1, 1.92, 96)
//       (Lee, Adam, 137.2, 2.94, 109)
//       (Rohr, Don, 101, 3.74, 110)
//       
//       The values sorted by earned run average (component 3):
//       (Henry, Walt, 140.1, 1.92, 96)
//       (Lee, Adam, 137.2, 2.94, 109)
//       (Rohr, Don, 101, 3.74, 110)
//       (Blair, Jack, 168.1, 3.48, 146)
//       (McHale, Joe, 240.1, 3.6, 221)
//       (Paul, Dave, 233.1, 3.24, 231)
//       (Williams, Mike, 193.2, 4, 183)
// </Snippet2>
