// <Snippet1>
using System;

class NumberStore
{
   int[] numbers = { 1, 3, 7, 15, 31, 63, 127, 255, 511, 1023 };

   public ref int FindNumber(int target)
   {
      for (int ctr = 0; ctr < numbers.Length; ctr++) {
         if (target == numbers[ctr]) {
            return ref numbers[ctr];
         }   
         else if (ctr == numbers.Length - 1) {
            return ref numbers[ctr];
         }      
         else if (target < numbers[ctr]) {
            if (ctr > 0 && target > numbers[ctr - 1])
               return ref numbers[ctr];
            else if (ctr == 0)
               return ref numbers[0];      
         }
      }
      return ref numbers[0];
   }

   public override string ToString()
   {
      string retval = "";
      for (int ctr = 0; ctr < numbers.Length; ctr++) {
         retval += $"{numbers[ctr]} ";   
      }
      return retval.Trim();   
   }
}
// </Snippet1>

namespace UseRefReturns
{
// <Snippet2>                      
using System;

public class Example
{   
   static void Main(string[] args)
   {
      var store = new NumberStore();
      Console.WriteLine($"Original sequence: {store.ToString()}");
      int number = 16;
      ref var value = ref store.FindNumber(number);
      value*=2;
      Console.WriteLine($"New sequence:      {store.ToString()}");
   }
}
// The example displays the following output:
//       Original sequence: 1 3 7 15 31 63 127 255 511 1023
//       New sequence:      1 3 7 15 62 63 127 255 511 1023
// </Snippet2>
}
