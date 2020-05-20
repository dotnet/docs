using System;
using System.Threading.Tasks;

class Program
{
   static Random? rnd;

   static async Task Main()
   {
      Console.WriteLine($"You rolled {await GetDiceRollAsync()}");
   }

   private static async ValueTask<int> GetDiceRollAsync()
   {
      Console.WriteLine("...Shaking the dice...");
      int roll1 = await RollAsync();
      int roll2 = await RollAsync();
      return roll1 + roll2;
   }

   private static async ValueTask<int> RollAsync()
   {
      if (rnd == null)
         rnd = new Random();

      await Task.Delay(500);
      int diceRoll = rnd.Next(1, 7);
      return diceRoll;
   }
}
// The example displays output like the following:
//       ...Shaking the dice...
//       You rolled 8
