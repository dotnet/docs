using System;

public class GenericFunc
{
   public static void Main()
   {
      // <Snippet2>
      // Instantiate delegate to reference UppercaseString method
      Func<string, string> convertMethod = UppercaseString;
      string name = "Dakota";
      // Use delegate instance to call UppercaseString method
      Console.WriteLine(convertMethod(name));

      string UppercaseString(string inputString)
      {
         return inputString.ToUpper();
      }

      // This code example produces the following output:
      //
      //    DAKOTA      
      // </Snippet2>
   }
}
