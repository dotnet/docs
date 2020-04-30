using System;

namespace HowToStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============================  String.Split examples =================================================");
            Console.WriteLine();
            ParseStringsUsingSplit.Examples();
            Console.WriteLine("============================  String concatenation examples =================================================");
            Console.WriteLine();
            Concatenate.Examples();
            Console.WriteLine("============================  String Searching examples =================================================");
            Console.WriteLine();
            SearchStrings.Examples();
            Console.WriteLine("============================  Modify string examples =================================================");
            Console.WriteLine();
            ModifyStrings.Examples();
            Console.WriteLine("============================  Compare string examples =================================================");
            Console.WriteLine();
            CompareStrings.Examples();
        }
    }
}
