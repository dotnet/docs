using System;
using System.Collections.Generic;
using System.Linq;

namespace Grouping
{
    class Program
    {
        static void Main(string[] args)
        {
            Group();
        }

        static void Group()
        {
            // <Snippet1>

            List<int> numbers = new List<int>() { 35, 44, 200, 84, 3987, 4, 199, 329, 446, 208 };

            IEnumerable<IGrouping<int, int>> query = from number in numbers
                                                     group number by number % 2;

            foreach (var group in query)
            {
                Console.WriteLine(group.Key == 0 ? "\nEven numbers:" : "\nOdd numbers:");
                foreach (int i in group)
                    Console.WriteLine(i);
            }

            /* This code produces the following output:
              
                Odd numbers:
                35
                3987
                199
                329

                Even numbers:
                44
                200
                84
                4
                446
                208
            */

            // </Snippet1>
        }
    }
}
