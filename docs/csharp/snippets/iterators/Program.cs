using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iterators
{
    class Program
    {
        static async Task Main(string[] args)
        {
            firstExample(new int[] {1,2,3,4,5});
            await firstAsyncExample(asyncCollection());

            var gen = new Generators();
            foreach(var item in gen.GetSetsOfNumbers())
                Console.WriteLine(item);

            await foreach(var item in gen.GetSetsOfNumbersAsync())
                Console.WriteLine(item);
            

            async IAsyncEnumerable<int> asyncCollection()
            {
                yield return 1;
                yield return 2;
                await Task.Delay(1000);
                yield return 3;
                yield return 4;
                yield return 5;
            }
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

        public static async Task firstAsyncExample<T>(IAsyncEnumerable<T> asyncSequence)
        {
            // <AwaitForeachExample>
            await foreach (var item in asyncSequence)
            {
            Console.WriteLine(item.ToString());
            }
            // </AwaitForeachExample>
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
