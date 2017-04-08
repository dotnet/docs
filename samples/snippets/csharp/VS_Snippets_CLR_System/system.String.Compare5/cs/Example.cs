// <Snippet1>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      string name1 = "Jack Smith";
      string name2 = "John Doe";
      
      // Get position of space character.
      int index1 = name1.IndexOf(" ");
      index1 = index1 < 0 ? 0 : index1--;
      
      int index2 = name2.IndexOf(" ");
      index1 = index1 < 0 ? 0 : index1--;
      
      int length = Math.Max(name1.Length, name2.Length);
      
      Console.WriteLine("Sorted alphabetically by last name:");
      if (String.Compare(name1, index1, name2, index2, length, 
                         new CultureInfo("en-US"), CompareOptions.IgnoreCase) < 0)
         Console.WriteLine("{0}\n{1}", name1, name2); 
      else
         Console.WriteLine("{0}\n{1}", name2, name1); 
   }
}
// The example displays the following output:
//       Sorted alphabetically by last name:
//       John Doe
//       Jack Smith
// </Snippet1>
