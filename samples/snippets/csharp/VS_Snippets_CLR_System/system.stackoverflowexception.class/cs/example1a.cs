// <Snippet1>
using System;

public class Example
{
   private const int MAX_RECURSIVE_CALLS = 1000;
   static int ctr = 0;
   
   public static void Main()
   {
      Example ex = new Example();
      ex.Execute();
      Console.WriteLine("\nThe call counter: {0}", ctr);
   }

   private void Execute()
   {
      ctr++;
      if (ctr % 50 == 0)
         Console.WriteLine("Call number {0} to the Execute method", ctr);
         
      if (ctr <= MAX_RECURSIVE_CALLS)
         Execute();
         
      ctr--;
   }
}
// The example displays the following output:
//       Call number 50 to the Execute method
//       Call number 100 to the Execute method
//       Call number 150 to the Execute method
//       Call number 200 to the Execute method
//       Call number 250 to the Execute method
//       Call number 300 to the Execute method
//       Call number 350 to the Execute method
//       Call number 400 to the Execute method
//       Call number 450 to the Execute method
//       Call number 500 to the Execute method
//       Call number 550 to the Execute method
//       Call number 600 to the Execute method
//       Call number 650 to the Execute method
//       Call number 700 to the Execute method
//       Call number 750 to the Execute method
//       Call number 800 to the Execute method
//       Call number 850 to the Execute method
//       Call number 900 to the Execute method
//       Call number 950 to the Execute method
//       Call number 1000 to the Execute method
//
//       The call counter: 0
// </Snippet1>

