using System;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Declaration and type pattern examples ---");
            DeclarationAndTypePattern.Examples();
            Console.WriteLine();

            Console.WriteLine("--- Constant pattern ------------------------");
            ConstantPattern.Examples();
            Console.WriteLine();

            Console.WriteLine("--- Discard pattern -------------------------");
            DiscardPattern.Examples();
            Console.WriteLine();

            Console.WriteLine("--- Relational patterns ---------------------");
            RelationalPatterns.Examples();
            Console.WriteLine();

            Console.WriteLine("--- Pattern combinators ---------------------");
            PatternCombinators.Examples();
            Console.WriteLine();

            Console.WriteLine("--- Property pattern ------------------------");
            PropertyPattern.Examples();
            Console.WriteLine();

            Console.WriteLine("--- Positional pattern ----------------------");
            PositionalPattern.Examples();
            Console.WriteLine();
        }
    }
}
