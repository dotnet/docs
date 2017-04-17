// <Snippet1>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      string string1 = "brother";
      string string2 = "Brother";
      string relation;
      int result;
      
      // Cultural (linguistic) comparison.
      result = String.Compare(string1, string2, new CultureInfo("en-US"), 
                              CompareOptions.None);
      if (result > 0)
         relation = "comes after";
      else if (result == 0)
         relation = "is the same as";
      else
         relation = "comes before";

      Console.WriteLine("'{0}' {1} '{2}'.", 
                        string1, relation, string2);

      // Cultural (linguistic) case-insensitive comparison.
      result = String.Compare(string1, string2, new CultureInfo("en-US"), 
                              CompareOptions.IgnoreCase);
      if (result > 0)
         relation = "comes after";
      else if (result == 0)
         relation = "is the same as";
      else
         relation = "comes before";

      Console.WriteLine("'{0}' {1} '{2}'.", 
                        string1, relation, string2);
 
       // Culture-insensitive ordinal comparison.
      result = String.CompareOrdinal(string1, string2);
      if (result > 0)
         relation = "comes after";
      else if (result == 0)
         relation = "is the same as";
      else
         relation = "comes before";

      Console.WriteLine("'{0}' {1} '{2}'.", 
                        string1, relation, string2);
   }
}
// The example produces the following output:
//    'brother' comes before 'Brother'.   
//    'brother' is the same as 'Brother'.
//    'brother' comes after 'Brother'.
// </Snippet1>
