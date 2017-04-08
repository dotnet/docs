// <Snippet2>
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Example
{
   private const int segmentSize = 10;
   
   public static void Main()
   {
      List<Task> tasks = new List<Task>();

      // Create array.
      int[] arr = new int[50];
      for (int ctr = 0; ctr <= arr.GetUpperBound(0); ctr++)
         arr[ctr] = ctr + 1;

      // Handle array in segments of 10.
      for (int ctr = 1; ctr <= Math.Ceiling(((double)arr.Length)/segmentSize); ctr++) {
         int multiplier = ctr;
         int elements = (multiplier - 1) * 10 + segmentSize > arr.Length ?
                         arr.Length - (multiplier - 1) * 10 : segmentSize;
         ArraySegment<int> segment = new ArraySegment<int>(arr, (ctr - 1) * 10, elements);
         tasks.Add(Task.Run( () => { IList<int> list = (IList<int>) segment;
                                     for (int index = 0; index < list.Count; index++)
                                        list[index] = list[index] * multiplier;
                                   } ));
      }
      try {
         Task.WaitAll(tasks.ToArray());
         int elementsShown = 0;
         foreach (var value in arr) {
            Console.Write("{0,3} ", value);
            elementsShown++;
            if (elementsShown % 18 == 0)
               Console.WriteLine();
         }
      }
      catch (AggregateException e) {
         Console.WriteLine("Errors occurred when working with the array:");
         foreach (var inner in e.InnerExceptions)
            Console.WriteLine("{0}: {1}", inner.GetType().Name, inner.Message);
      }
   }
}
// The example displays the following output:
//      1   2   3   4   5   6   7   8   9  10  22  24  26  28  30  32  34  36
//     38  40  63  66  69  72  75  78  81  84  87  90 124 128 132 136 140 144
//    148 152 156 160 205 210 215 220 225 230 235 240 245 250
// </Snippet2>
