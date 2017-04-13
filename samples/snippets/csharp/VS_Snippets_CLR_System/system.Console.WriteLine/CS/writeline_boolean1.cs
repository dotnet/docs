// <Snippet4>
using System;

public class Example
{
   public static void Main()
   {
      // Assign 10 random integers to an array.
      Random rnd = new Random();
      int[] numbers = new int[10]; 
      for (int ctr = 0; ctr <= numbers.GetUpperBound(0); ctr++)
         numbers[ctr] = rnd.Next();
      
      // Determine whether the numbers are even or odd.
      foreach (var number in numbers) {
         bool even = (number % 2 == 0);
         Console.WriteLine("Is {0} even:", number);
         Console.WriteLine(even);
         Console.WriteLine();      
      }
   }
}
// </Snippet4>