using System;

class Example
{
   static void Main()
   {
      U();
      UL();
   }
   
   private static void U()
   {
      // <Snippet1>
      object value1 = 4000000000u;
      Console.WriteLine($"{value1} ({4000000000u.GetType().Name})");
      object value2 = 6000000000u;
      Console.WriteLine($"{value2} ({6000000000u.GetType().Name})");
      // </Snippet1>
   }

   private static void UL()
   {
      // <Snippet2>
      object value1 = 700000000000ul;
      Console.WriteLine($"{value1} ({700000000000ul.GetType().Name})");
      // </Snippet2>
   }

}


