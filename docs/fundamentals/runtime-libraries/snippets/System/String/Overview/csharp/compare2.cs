// <Snippet12>
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
 
public class Example3
{
   public static void Main()
   {
      string[] strings = { "coop", "co-op", "cooperative", 
                           "co\u00ADoperative", "cœur", "coeur" };

      // Perform a word sort using the current (en-US) culture.
      string[] current = new string[strings.Length]; 
      strings.CopyTo(current, 0); 
      Array.Sort(current, StringComparer.CurrentCulture);

      // Perform a word sort using the invariant culture.
      string[] invariant = new string[strings.Length];
      strings.CopyTo(invariant, 0); 
      Array.Sort(invariant, StringComparer.InvariantCulture);

      // Perform an ordinal sort.
      string[] ordinal = new string[strings.Length];
      strings.CopyTo(ordinal, 0); 
      Array.Sort(ordinal, StringComparer.Ordinal);

      // Perform a string sort using the current culture.
      string[] stringSort = new string[strings.Length];
      strings.CopyTo(stringSort, 0); 
      Array.Sort(stringSort, new SCompare());

      // Display array values
      Console.WriteLine("{0,13} {1,13} {2,15} {3,13} {4,13}\n", 
                        "Original", "Word Sort", "Invariant Word", 
                        "Ordinal Sort", "String Sort");
      for (int ctr = 0; ctr < strings.Length; ctr++)
         Console.WriteLine("{0,13} {1,13} {2,15} {3,13} {4,13}", 
                           strings[ctr], current[ctr], invariant[ctr], 
                           ordinal[ctr], stringSort[ctr] );          
   }
}

// IComparer<String> implementation to perform string sort.
internal class SCompare : IComparer<String>
{
   public int Compare(string x, string y)
   {
      return CultureInfo.CurrentCulture.CompareInfo.Compare(x, y, CompareOptions.StringSort);
   }
}
// The example displays the following output:
//         Original     Word Sort  Invariant Word  Ordinal Sort   String Sort
//    
//             coop          cœur            cœur         co-op         co-op
//            co-op         coeur           coeur         coeur          cœur
//      cooperative          coop            coop          coop         coeur
//     co­operative         co-op           co-op   cooperative          coop
//             cœur   cooperative     cooperative  co­operative   cooperative
//            coeur  co­operative    co­operative          cœur  co­operative
// </Snippet12>     
