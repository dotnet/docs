// <Snippet2>
using System;
using System.Collections;
using System.Collections.Generic;

public class YardsGained<T1, T2, T3, T4, T5> : IComparer
{
   public int Compare(object x, object y)
   {
      Tuple<T1, T2, T3, T4, T5> tX = x as Tuple<T1, T2, T3, T4, T5>;
      if (tX == null)
      { 
         return 0;
      }   
      else
      {
         Tuple<T1, T2, T3, T4, T5> tY = y as Tuple<T1, T2, T3, T4, T5>;
         return -1 * Comparer<T4>.Default.Compare(tX.Item4, tY.Item4);             
      }
   }
}

public class Example
{
   public static void Main()
   {
      // Organization of runningBacks 5-tuple:
      //    Component 1: Player name
      //    Component 2: Number of games played
      //    Component 3: Number of attempts (carries)
      //    Component 4: Number of yards gained 
      //    Component 5: Number of touchdowns   
      Tuple<string, int, int, int, int>[] runningBacks =
           { Tuple.Create("Payton, Walter", 190, 3838, 16726, 110),  
             Tuple.Create("Sanders, Barry", 153, 3062, 15269, 99),            
             Tuple.Create("Brown, Jim", 118, 2359, 12312, 106),            
             Tuple.Create("Dickerson, Eric", 144, 2996, 13259, 90),            
             Tuple.Create("Faulk, Marshall", 176, 2836, 12279, 100) }; 

      // Display the array in unsorted order.
      Console.WriteLine("The values in unsorted order:");
      foreach (var runningBack in runningBacks)
         Console.WriteLine(runningBack.ToString());
      Console.WriteLine();
      
      // Sort the array
      Array.Sort(runningBacks, new YardsGained<string, int, int, int, int>());
      
      // Display the array in sorted order.
      Console.WriteLine("The values in sorted order:");
      foreach (var runningBack in runningBacks)
         Console.WriteLine(runningBack.ToString());
   }
}
// The example displays the following output:
//       The values in unsorted order:
//       (Payton, Walter, 190, 3838, 16726, 110)
//       (Sanders, Barry, 153, 3062, 15269, 99)
//       (Brown, Jim, 118, 2359, 12312, 106)
//       (Dickerson, Eric, 144, 2996, 13259, 90)
//       (Faulk, Marshall, 176, 2836, 12279, 100)
//       
//       The values in sorted order:
//       (Brown, Jim, 118, 2359, 12312, 106)
//       (Dickerson, Eric, 144, 2996, 13259, 90)
//       (Faulk, Marshall, 176, 2836, 12279, 100)
//       (Payton, Walter, 190, 3838, 16726, 110)
//       (Sanders, Barry, 153, 3062, 15269, 99)
// </Snippet2>