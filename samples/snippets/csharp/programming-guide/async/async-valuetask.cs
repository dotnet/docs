using System;
using System.Threading.Tasks;

class Program
{
   static Random rnd;
   
   static void Main()
   {
      Console.WriteLine($"You rolled {GetDiceRoll().Result}");
   }
   
   private static async ValueTask<int> GetDiceRoll()
   {
      Console.WriteLine("...Shaking the dice...");
      int roll1 = await Roll();
      int roll2 = await Roll();
      return roll1 + roll2; 
   } 
   
   private static async ValueTask<int> Roll()
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
