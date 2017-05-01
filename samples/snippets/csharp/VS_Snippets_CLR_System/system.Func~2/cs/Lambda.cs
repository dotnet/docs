// Code compiled and run on DDUESRV4
//
// <Snippet4>
using System;

public class LambdaExpression
{
   public static void Main()
   {
      Func<string, string> convert = s => s.ToUpper();
         
      string name = "Dakota";
      Console.WriteLine(convert(name));   
   }
}
// </Snippet4>
