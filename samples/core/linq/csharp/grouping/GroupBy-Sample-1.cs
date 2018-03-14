using System.Linq;
using System;

namespace Grouping
{
    public class GroupBy1
    {
        //This sample uses group by to partition a list of numbers by their
        // remainder when divided by 5. 
        //Outputs the following to Console: 
        // Numbers with a remainder of 0 when divided by 5:
        //   5
        //   0
        //   Numbers with a remainder of 4 when divided by 5:
        //   4
        //   9
        //   Numbers with a remainder of 1 when divided by 5:
        //   1
        //   6
        //   Numbers with a remainder of 3 when divided by 5:
        //   3
        //   8
        //   Numbers with a remainder of 2 when divided by 5:
        //   7
        //   2
        public static void QuerySyntaxExample() 
        { 
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 }; 

            var numberGroups = 
                from n in numbers 
                group n by n % 5 into g 
                select new { Remainder = g.Key, Numbers = g }; 

            foreach (var g in numberGroups) 
            { 
                Console.WriteLine("Numbers with a remainder of {0} when divided by 5:", g.Remainder); 
                foreach (var n in g.Numbers) 
                {
                  Console.WriteLine(n); 
                }
            }
        }        
        //This sample uses group by to partition a list of numbers by their
        // remainder when divided by 5. 
        //Outputs the following to Console: 
        // Numbers with a remainder of 0 when divided by 5:
        //   5
        //   0
        //   Numbers with a remainder of 4 when divided by 5:
        //   4
        //   9
        //   Numbers with a remainder of 1 when divided by 5:
        //   1
        //   6
        //   Numbers with a remainder of 3 when divided by 5:
        //   3
        //   8
        //   Numbers with a remainder of 2 when divided by 5:
        //   7
        //   2
        public static void MethodSyntaxExample() 
        { 
         
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 }; 

            var numberGroups = numbers.GroupBy(n => n % 5, 
                 (Key, g) => new { Remainder = Key, Numbers = g });

            foreach (var g in numberGroups) 
            { 
                Console.WriteLine("Numbers with a remainder of {0} when divided by 5:", g.Remainder); 
                foreach (var n in g.Numbers) 
                {
                Console.WriteLine(n); 
                }
            }
        }
    }
}
