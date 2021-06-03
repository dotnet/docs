using System;

namespace Conditional
{
class Program
{
   static void Main(string[] args)
   {
      try
      {
         DisplayFirstNumber(args);
      }
      catch (ArgumentException e)
      {
         Console.WriteLine(e.Message);
      }
   }

// <Snippet1>
   private static void DisplayFirstNumber(string[] args)
   {
      string arg = args.Length >= 1 ? args[0] :
                                 throw new ArgumentException("You must supply an argument");
      if (Int64.TryParse(arg, out var number))
         Console.WriteLine($"You entered {number:F0}");
      else
         Console.WriteLine($"{arg} is not a number.");
   }
// </Snippet1>
}
}
