using System;

public class StringComparerTest
{
   public static void Main()
   {
      StringComparerTest test = new StringComparerTest();
      test.CompareCurrentCultureStringComparer();
      test.CompareCurrentCultureInsensitiveStringComparer();
   }

   // <Snippet1>
   private void CompareCurrentCultureStringComparer()
   {
      StringComparer stringComparer1 = StringComparer.CurrentCulture;
      StringComparer stringComparer2 = StringComparer.CurrentCulture;
      // Displays false
      Console.WriteLine(StringComparer.ReferenceEquals(stringComparer1, 
                                                       stringComparer2));
   }
   // </Snippet1>

   // <Snippet2>
   private void CompareCurrentCultureInsensitiveStringComparer()
   {
      StringComparer stringComparer1, stringComparer2;
      stringComparer1 = StringComparer.CurrentCultureIgnoreCase;
      stringComparer2 = StringComparer.CurrentCultureIgnoreCase;
      // Displays false
      Console.WriteLine(StringComparer.ReferenceEquals(stringComparer1, 
                                                       stringComparer2));
   }
   // </Snippet2>
}
