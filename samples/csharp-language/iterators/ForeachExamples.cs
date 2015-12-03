using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Iterators
{
    public static class ForeachExamples
    {
        public static void ExampleOne()
        {
            var collection = new List<string>
            {
                "Hello",
                "World",
                "Iterators",
                "are",
                "awesome"
            };
            foreach (var item in collection)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
