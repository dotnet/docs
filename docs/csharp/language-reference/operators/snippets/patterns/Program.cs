using System;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Declaration and type patterns -----------");
            DeclarationAndTypePatterns.Examples();
            Console.WriteLine();

            Console.WriteLine("--- Constant pattern ------------------------");
            ConstantPattern.Examples();
            Console.WriteLine();

            Console.WriteLine("--- Relational patterns ---------------------");
            RelationalPatterns.Examples();
            Console.WriteLine();

            Console.WriteLine("--- Logical patterns ------------------------");
            LogicalPatterns.Examples();
            Console.WriteLine();

            Console.WriteLine("--- Property pattern ------------------------");
            PropertyPattern.Examples();
            Console.WriteLine();

            Console.WriteLine("--- Positional pattern ----------------------");
            PositionalPattern.Examples();
            Console.WriteLine();

            Console.WriteLine("--- var pattern -----------------------------");
            VarPattern.Examples();
            Console.WriteLine();

            Console.WriteLine("--- Discard pattern -------------------------");
            DiscardPattern.Examples();
            Console.WriteLine();
        }
    }
}
