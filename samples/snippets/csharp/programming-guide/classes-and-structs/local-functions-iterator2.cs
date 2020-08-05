using System;
using System.Collections.Generic;

class Example
{
   static void Main()
   {
      IEnumerable<int> ienum = OddSequence(50, 110); //Line 8
      Console.WriteLine("Retrieved enumerator...");

      foreach (var i in ienum)
      {
         Console.Write($"{i} ");
      }
   }

   public static IEnumerable<int> OddSequence(int start, int end)
   {
      if (start < 0 || start > 99)
         throw new ArgumentOutOfRangeException("start must be between 0 and 99.");
      if (end > 100)
         throw new ArgumentOutOfRangeException("end must be less than or equal to 100."); //Line 22
      if (start >= end)
         throw new ArgumentException("start must be less than end.");

      return GetOddSequenceEnumerator();

      IEnumerable<int> GetOddSequenceEnumerator()
      {
         for (int i = start; i <= end; i++)
         {
            if (i % 2 == 1)
               yield return i;
         }
      }
   }
}
// The example displays the following output:
//    Unhandled Exception: System.ArgumentOutOfRangeException: Specified argument was out of the range of valid values.
//    Parameter name: end must be less than or equal to 100.
//       at Sequence.<GetNumericRange>d__1.MoveNext() in Program.cs:line 8
//       at Example.Main() in Program.cs:line 22
