// Code compiled and run on DDUESRV4
//
using System;

public class LambdaExpression
{
   public static void Main()
   {
      // <Snippet4>
      Func<string, string> convert = s => s.ToUpper();
         
      string name = "Dakota";
      Console.WriteLine(convert(name));   

      // This code example produces the following output:
      //
      //    DAKOTA      
      // </Snippet4>
   }
}
