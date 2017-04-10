using System;

public class Example
{
   public static void Main()
   {
      Console.WriteLine(ShowCode());
   }

   private static bool ShowCode()
   {
      string value = null;
      // <Snippet2>
      return String.IsNullOrEmpty(value) || value.Trim().Length == 0;
      // </Snippet2>
   }
}

