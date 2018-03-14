//<Snippet1>
using System;

class ExceptionTestClass 
{
   public static void Main() 
   {
      int x = 0;
      try 
      {
         int y = 100/x;
      }
         catch (ArithmeticException e) 
         {
            Console.WriteLine("ArithmeticException Handler: {0}", e.ToString());
         }
         catch (Exception e) 
         {
            Console.WriteLine("Generic Exception Handler: {0}", e.ToString());
         }
   }	
}
/*
This code example produces the following results:

ArithmeticException Handler: System.DivideByZeroException: Attempted to divide by zero.
   at ExceptionTestClass.Main()

*/
//</Snippet1>
