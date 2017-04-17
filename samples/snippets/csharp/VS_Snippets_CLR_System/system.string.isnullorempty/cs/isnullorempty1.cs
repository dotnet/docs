using System;

public class Example
{
   public static void Main()
   {
      string s1 = null;
      string s2 = "";
      Console.WriteLine(TestForNullOrEmpty(s1));
      Console.WriteLine(TestForNullOrEmpty(s2));
   }

   private static bool TestForNullOrEmpty(string s)
   {
      bool result;
      // <Snippet1>
      result = s == null || s == String.Empty;
      // </Snippet1>
      return result;
   }
}
