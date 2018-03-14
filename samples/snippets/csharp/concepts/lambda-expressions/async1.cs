// <Snippet1>
using System;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      Begin().Wait();
   }

   private static async Task Begin()
   {
      for (int ctr = 2; ctr <= 5; ctr++) {
         var result = await ShowSquares(ctr);
         Console.WriteLine("{0} * {0} = {1}", ctr, result);
      }
   }

   private static async Task<int>  ShowSquares(int number)
   {
         return await Task.Factory.StartNew( x => (int)x * (int)x, number);
   } 
}
// </Snippet1>

