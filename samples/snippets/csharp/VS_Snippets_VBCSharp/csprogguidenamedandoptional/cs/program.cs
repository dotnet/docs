using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NamedAndOptionalSnippets
{
    //<Snippet1>
    class NamedExample
    {
        static void Main(string[] args)
        {
            // The method can be called in the normal way, by using positional arguments.
            Console.WriteLine(CalculateBMI(123, 64));

            // Named arguments can be supplied for the parameters in either order.
            Console.WriteLine(CalculateBMI(weight: 123, height: 64));
            Console.WriteLine(CalculateBMI(height: 64, weight: 123));

            // Positional arguments cannot follow named arguments.
            // The following statement causes a compiler error.
            //Console.WriteLine(CalculateBMI(weight: 123, 64));

            // Named arguments can follow positional arguments.
            Console.WriteLine(CalculateBMI(123, height: 64));
        }

        static int CalculateBMI(int weight, int height)
        {
            return (weight * 703) / (height * height);
        }
    }
//</Snippet1>

}
