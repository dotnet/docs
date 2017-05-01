// <Snippet1>
using System;
using System.Numerics;

public class Example
{
   private const int ERROR_BAD_ARGUMENTS = 0xA0;
   private const int ERROR_ARITHMETIC_OVERFLOW = 0x216;
   private const int ERROR_INVALID_COMMAND_LINE = 0x667;

   public static void Main()
   {
      string[] args = Environment.GetCommandLineArgs();
      if (args.Length == 1) {
         Environment.ExitCode = ERROR_INVALID_COMMAND_LINE;  
      }
      else {
         BigInteger value = 0;
         if (BigInteger.TryParse(args[1], out value))
            if (value <= Int32.MinValue || value >= Int32.MaxValue)
               Environment.ExitCode = ERROR_ARITHMETIC_OVERFLOW;
            else
               Console.WriteLine("Result: {0}", value * 2);

         else
            Environment.ExitCode = ERROR_BAD_ARGUMENTS;
      }
   }
}
// </Snippet1>
