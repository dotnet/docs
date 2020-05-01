//<Snippet1>
using System;

class ExceptionTestClass
{
   public static void Main()
   {
      int x = 0;
      try
      {
         int y = 100 / x;
      }
      catch (ArithmeticException e)
      {
         Console.WriteLine($"ArithmeticException Handler: {e}");
      }
      catch (Exception e)
      {
         Console.WriteLine($"Generic Exception Handler: {e}");
      }
   }	
}
/*
This code example produces the following results:

ArithmeticException Handler: System.DivideByZeroException: Attempted to divide by zero.
   at ExceptionTestClass.Main()

*/
//</Snippet1>
