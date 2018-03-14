// <Snippet1>
using System;

class Example 
{
   public static void Main() 
   {
      string source = "[stop]ONE[stop][stop]TWO[stop][stop][stop]THREE[stop][stop]";
      string[] stringSeparators = new string[] {"[stop]"};
      string[] result;
      
      // Display the original string and delimiter string.
      Console.WriteLine("Splitting the string:\n   \"{0}\".", source);
      Console.WriteLine();
      Console.WriteLine("Using the delimiter string:\n   \"{0}\"", 
                        stringSeparators[0]);
      Console.WriteLine();                           
         
      // Split a string delimited by another string and return all elements.
      result = source.Split(stringSeparators, StringSplitOptions.None);
      Console.WriteLine("Result including all elements ({0} elements):", 
                        result.Length);
      Console.Write("   ");
      foreach (string s in result)
      {
         Console.Write("'{0}' ", String.IsNullOrEmpty(s) ? "<>" : s);                   
      }
      Console.WriteLine();
      Console.WriteLine();

      // Split delimited by another string and return all non-empty elements.
      result = source.Split(stringSeparators, 
                            StringSplitOptions.RemoveEmptyEntries);
      Console.WriteLine("Result including non-empty elements ({0} elements):", 
                        result.Length);
      Console.Write("   ");
      foreach (string s in result)
      {
         Console.Write("'{0}' ", String.IsNullOrEmpty(s) ? "<>" : s);                   
      }
      Console.WriteLine();
   }
}
// The example displays the following output:
//    Splitting the string:
//       "[stop]ONE[stop][stop]TWO[stop][stop][stop]THREE[stop][stop]".
//    
//    Using the delimiter string:
//       "[stop]"
//    
//    Result including all elements (9 elements):
//       '<>' 'ONE' '<>' 'TWO' '<>' '<>' 'THREE' '<>' '<>'
//    
//    Result including non-empty elements (3 elements):
//       'ONE' 'TWO' 'THREE'
// </Snippet1>

