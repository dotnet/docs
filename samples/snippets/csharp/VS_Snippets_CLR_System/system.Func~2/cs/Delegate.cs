// <Snippet1>
using System;

delegate string ConvertMethod(string inString);

public class DelegateExample
{
   public static void Main()
   {
      // Instantiate delegate to reference UppercaseString method
      ConvertMethod convertMeth = UppercaseString;
      string name = "Dakota";
      // Use delegate instance to call UppercaseString method
      Console.WriteLine(convertMeth(name));
   }

   private static string UppercaseString(string inputString)
   {
      return inputString.ToUpper();
   }
}
// </Snippet1>
