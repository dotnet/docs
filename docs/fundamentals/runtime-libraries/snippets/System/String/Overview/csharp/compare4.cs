// <Snippet21>
using System;
using System.Globalization;
using System.Threading;

public class CompareStringSample
{
   public static void Main()
   {
      string str1 = "Apple";
      string str2 = "Æble"; 
      string str3 = "AEble";
      
      // Set the current culture to Danish in Denmark.
      Thread.CurrentThread.CurrentCulture = new CultureInfo("da-DK");
      Console.WriteLine($"Current culture: {CultureInfo.CurrentCulture.Name}");
      Console.WriteLine($"Comparison of {str1} with {str2}: {String.Compare(str1, str2)}");
      Console.WriteLine($"Comparison of {str2} with {str3}: {String.Compare(str2, str3)}\n");
      
      // Set the current culture to English in the U.S.
      Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
      Console.WriteLine($"Current culture: {CultureInfo.CurrentCulture.Name}");
      Console.WriteLine($"Comparison of {str1} with {str2}: {String.Compare(str1, str2)}");
      Console.WriteLine($"Comparison of {str2} with {str3}: {String.Compare(str2, str3)}\n");
      
      // Perform an ordinal comparison.
      Console.WriteLine("Ordinal comparison");
      Console.WriteLine($"Comparison of {str1} with {str2}: {String.Compare(str1, str2, StringComparison.Ordinal)}");
      Console.WriteLine($"Comparison of {str2} with {str3}: {String.Compare(str2, str3, StringComparison.Ordinal)}");
   }
}
// The example displays the following output:
//       Current culture: da-DK
//       Comparison of Apple with Æble: -1
//       Comparison of Æble with AEble: 1
//       
//       Current culture: en-US
//       Comparison of Apple with Æble: 1
//       Comparison of Æble with AEble: 0
//       
//       Ordinal comparison
//       Comparison of Apple with Æble: -133
//       Comparison of Æble with AEble: 133
// </Snippet21>
