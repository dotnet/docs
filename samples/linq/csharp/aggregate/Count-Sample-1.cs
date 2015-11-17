using System.Linq;
using System;

namespace Aggregate
{
    public static class CountSample1
    {
        //This sample uses Count to get the number of unique factors of 300 using method syntax. 
        // 
        //Output: 
        // There are 3 unique factors of 300.
        public static void MethodSyntaxExample()
        {
            int[] factorsOf300 = {2, 2, 3, 5, 5};

            int uniqueFactors = factorsOf300.Distinct().Count();

            Console.WriteLine($"There are {uniqueFactors} unique factors of 300.");
        }

        //This sample uses Count to get the number of unique factors of 300 using query syntax. 
        // 
        //Output:
        // There are 3 unique factors of 300. 
        public static void QuerySyntaxExample()
        {
            int[] factorsOf300 = {2, 2, 3, 5, 5};

            int uniqueFactors =
                (from f in factorsOf300 select f).Distinct().Count();

            Console.WriteLine($"There are {uniqueFactors} unique factors of 300.");
        }
    }
}