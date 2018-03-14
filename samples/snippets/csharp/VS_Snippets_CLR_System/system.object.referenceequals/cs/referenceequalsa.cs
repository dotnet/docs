// <Snippet2>
using System;

public class Example
{
   public static void Main()
   {
      String s1 = "String1";
      String s2 = "String1";
      Console.WriteLine("s1 = s2: {0}", Object.ReferenceEquals(s1, s2));
      Console.WriteLine("{0} interned: {1}", s1, 
                        String.IsNullOrEmpty(String.IsInterned(s1)) ? "No" : "Yes");

      String suffix = "A";
      String s3 = "String" + suffix;
      String s4 = "String" + suffix;
      Console.WriteLine("s3 = s4: {0}", Object.ReferenceEquals(s3, s4));
      Console.WriteLine("{0} interned: {1}", s3, 
                        String.IsNullOrEmpty(String.IsInterned(s3)) ? "No" : "Yes");
   }
}
// The example displays the following output:
//       s1 = s2: True
//       String1 interned: Yes
//       s3 = s4: False
//       StringA interned: No
// </Snippet2>
