// <Snippet1>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      // Define names.
      String[] names= { "Adam", "Ignatius", "Batholomew", "Gregory", 
                        "Clement", "Frances", "Harold", "Dalmatius", 
                        "Edgar", "John", "Benedict", "Paul", "George" }; 
      SortKey[] sortKeys = new SortKey[names.Length];
      CompareInfo ci = CultureInfo.CurrentCulture.CompareInfo;

      for (int ctr = 0; ctr < names.Length; ctr++)
         sortKeys[ctr] = ci.GetSortKey(names[ctr], CompareOptions.IgnoreCase);         
      
      // Sort array based on value of sort keys.
      Array.Sort(names, sortKeys);
      
      Console.WriteLine("Sorted array: ");
      foreach (var name in names)
         Console.WriteLine(name);

      Console.WriteLine();
      
      String[] namesToFind = { "Paul", "PAUL", "Wilberforce" };
      
      Console.WriteLine("Searching an array:");
      foreach (var nameToFind in namesToFind) {
         SortKey searchKey = ci.GetSortKey(nameToFind, CompareOptions.IgnoreCase);
         int index = Array.FindIndex(sortKeys, (x) => x.Equals(searchKey)); 
         if (index >= 0)
            Console.WriteLine("{0} found at index {1}: {2}", nameToFind,
                              index, names[index]);
         else
            Console.WriteLine("{0} not found", nameToFind);
      } 
   }
}
// The example displays the following output:
//       Sorted array:
//       Adam
//       Batholomew
//       Benedict
//       Clement
//       Dalmatius
//       Edgar
//       Frances
//       George
//       Gregory
//       Harold
//       Ignatius
//       John
//       Paul
//       
//       Searching an array:
//       Paul found at index 12: Paul
//       PAUL found at index 12: Paul
//       Wilberforce not found
// </Snippet1>