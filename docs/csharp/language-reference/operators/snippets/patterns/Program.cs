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
        }
    }
}
