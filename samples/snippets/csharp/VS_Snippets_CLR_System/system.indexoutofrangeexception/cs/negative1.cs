// <Snippet5>
using System;
using System.Collections.Generic;

public class Example
{
   static List<int> numbers = new List<int>();

   public static void Main()
   {
      int startValue; 
      string[] args = Environment.GetCommandLineArgs();
      if (args.Length < 2) 
         startValue = 2;
      else 
         if (! Int32.TryParse(args[1], out startValue))
            startValue = 2;

      ShowValues(startValue);
   }
   
   private static void ShowValues(int startValue)
   {   
      // Create a collection with numeric values.
      if (numbers.Count == 0)  
         numbers.AddRange( new int[] { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22} );

      // Get the index of a startValue.
      Console.WriteLine("Displaying values greater than or equal to {0}:",
                        startValue);
      int startIndex = numbers.IndexOf(startValue);
      // Display all numbers from startIndex on.
      for (int ctr = startIndex; ctr < numbers.Count; ctr++)
         Console.Write("    {0}", numbers[ctr]);
   }
}
// The example displays the following output if the user supplies
// 7 as a command-line parameter:
//    Displaying values greater than or equal to 7:
//    
//    Unhandled Exception: System.ArgumentOutOfRangeException: 
//    Index was out of range. Must be non-negative and less than the size of the collection.
//    Parameter name: index
//       at System.Collections.Generic.List`1.get_Item(Int32 index)
//       at Example.ShowValues(Int32 startValue)
//       at Example.Main()
// </Snippet5>
