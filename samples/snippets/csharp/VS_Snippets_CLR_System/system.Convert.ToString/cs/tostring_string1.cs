// <Snippet2>
using System;

public class Example
{
   public static void Main()
   {
      String article = "An";
      String noun = "apple";
      String str1 = String.Format("{0} {1}", article, noun);
      String str2 = Convert.ToString(str1);

      Console.WriteLine("str1 is interned: {0}",
                        ! (String.IsInterned(str1) == null));
      Console.WriteLine("str1 and str2 are the same reference: {0}",
                        Object.ReferenceEquals(str1, str2));
   }
}
// The example displays the following output:
//       str1 is interned: False
//       str1 and str2 are the same reference: True
// </Snippet2>

