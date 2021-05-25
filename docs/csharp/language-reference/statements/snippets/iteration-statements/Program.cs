using System;

namespace IterationStatements
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------ for examples ---------------");
            ForStatement.Examples();

            Console.WriteLine("------------ foreach examples -----------");
            ForeachStatement.Examples();

            Console.WriteLine("------------ do examples ----------------");
            DoStatement.Examples();

            Console.WriteLine("------------ while examples -------------");
            WhileStatement.Examples();
        }
    }
}
