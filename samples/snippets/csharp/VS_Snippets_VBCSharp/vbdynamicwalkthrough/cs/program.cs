using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicWalkthrough
{
    class Program
    {
        static void Main(string[] args)
        {
            //<Snippet8>
            dynamic rFile = new ReadOnlyFile(@"..\..\..\TextFile1.txt");
            foreach (string line in rFile.Customer)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("----------------------------");
            foreach (string line in rFile.Customer(StringSearchOption.Contains, true))
            {
                Console.WriteLine(line);
            }
            //</Snippet8>
        }
    }
}
