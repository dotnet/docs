// <Snippet19>
using System;

public class Example
{
   public static void Main()
   {
      String s1, s2;
      
      s1 = "car"; s2 = "Car";
      Console.WriteLine("'{0}' and '{1}': {2}", s1, s2, 
                        String.Compare(s1, s2));
                        
      s1 = "fork"; s2 = "forks";                  
      Console.WriteLine("'{0}' and '{1}': {2}", s1, s2, 
                        String.Compare(s1, s2));

      s1 = "mammal"; s2 = "fish";
      Console.WriteLine("'{0}' and '{1}': {2}", s1, s2,  
                        String.Compare(s1, s2));
   }
}
// The example displays the following output:
//       car' and 'Car': -1
//       fork' and 'forks': -1
//       mammal' and 'fish': 1
// </Snippet19>

