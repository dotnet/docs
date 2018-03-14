// <Snippet2>
using System;

public class GenericFunc
{
   public static void Main()
   {
      // Instantiate delegate to reference UppercaseString method
      Func<string, string> convertMethod = UppercaseString;
      string name = "Dakota";
      // Use delegate instance to call UppercaseString method
      Console.WriteLine(convertMethod(name));
   }

   private static string UppercaseString(string inputString)
   {
      return inputString.ToUpper();
   }
}
// </Snippet2>
