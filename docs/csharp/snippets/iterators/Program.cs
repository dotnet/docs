using System;
using System.Collections.Generic;

namespace iterators
{
    class Program
    {
        static void Main(string[] args)
        {
            firstExample(new int[] {1,2,3,4,5});
        }

        public static void firstExample<T>(IEnumerable<T> collection)
        {
            // <ForeachExample>
            foreach (var item in collection)
            {
            Console.WriteLine(item.ToString());
            }
            // </ForeachExample>
        }

        public static void InsideForeach(IEnumerable<int> collection)
        {
            // <InsideForeach>
            IEnumerator<int> enumerator = collection.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                Console.WriteLine(item.ToString());
            }
            // </InsideForeach>
        }
    }
}
