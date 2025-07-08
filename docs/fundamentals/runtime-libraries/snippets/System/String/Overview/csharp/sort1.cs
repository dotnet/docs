// <Snippet3>
using System;
using System.Globalization;
using System.Threading;

public class ArraySort
{
   public static void Main(String[] args)
   {
      // Create and initialize a new array to store the strings.
      string[] stringArray = { "Apple", "Æble", "Zebra"};

      // Display the values of the array.
      Console.WriteLine( "The original string array:");
      PrintIndexAndValues(stringArray);

      // Set the CurrentCulture to "en-US".
      Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
      // Sort the values of the array.
      Array.Sort(stringArray);

      // Display the values of the array.
      Console.WriteLine("After sorting for the culture \"en-US\":");
      PrintIndexAndValues(stringArray);

      // Set the CurrentCulture to "da-DK".
      Thread.CurrentThread.CurrentCulture = new CultureInfo("da-DK");
      // Sort the values of the Array.
      Array.Sort(stringArray);

      // Display the values of the array.
      Console.WriteLine("After sorting for the culture \"da-DK\":");
      PrintIndexAndValues(stringArray);
   }
   public static void PrintIndexAndValues(string[] myArray)
   {
      for (int i = myArray.GetLowerBound(0); i <=
            myArray.GetUpperBound(0); i++ )
         Console.WriteLine($"[{i}]: {myArray[i]}");
      Console.WriteLine();
   }
}
// The example displays the following output:
//       The original string array:
//       [0]: Apple
//       [1]: Æble
//       [2]: Zebra
//
//       After sorting for the "en-US" culture:
//       [0]: Æble
//       [1]: Apple
//       [2]: Zebra
//
//       After sorting for the culture "da-DK":
//       [0]: Apple
//       [1]: Zebra
//       [2]: Æble
// </Snippet3>