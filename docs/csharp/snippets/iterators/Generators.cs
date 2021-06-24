using System.Collections.Generic;
using System.Threading.Tasks;

namespace iterators
{

    public class Generators
    {
        // <GetNumbers>
        public IEnumerable<int> GetSingleDigitNumbers()
        {
            yield return 0;
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
            yield return 5;
            yield return 6;
            yield return 7;
            yield return 8;
            yield return 9;
        }
        // </GetNumbers>

        // <GetNumbersLoop>
        public IEnumerable<int> GetSingleDigitNumbersLoop()
        {
            int index = 0;
            while (index < 10)
                yield return index++;
        }
        // </GetNumbersLoop>

        // <GetMultipleLoops>
        public IEnumerable<int> GetSetsOfNumbers()
        {
            int index = 0;
            while (index < 10)
                yield return index++;

            yield return 50;

            index = 100;
            while (index < 110)
                yield return index++;
        }
        // </GetMultipleLoops>

        // <GetMultipleAsyncLoops>
        public async IAsyncEnumerable<int> GetSetsOfNumbersAsync()
        {
            int index = 0;
            while (index < 10)
                yield return index++;

            await Task.Delay(500);

            yield return 50;

            await Task.Delay(500);

            index = 100;
            while (index < 110)
                yield return index++;
        }
        // </GetMultipleAsyncLoops>

        // <SequenceAndCollection>
        public IEnumerable<int> GetFirstDecile()
        {
            int index = 0;
            while (index < 10)
                yield return index++;

            yield return 50;

            var items = new int[] {100, 101, 102, 103, 104, 105, 106, 107, 108, 109 };
            foreach (var item in items)
                yield return item;
        }
        // </SequenceAndCollection>

        // <ReturnAndYieldReturn>
        public IEnumerable<int> GetSingleDigitOddNumbers(bool getCollection)
        {
            if (getCollection == false)
                return new int[0];
            else
                return IteratorMethod();
        }

        private IEnumerable<int> IteratorMethod()
        {
            int index = 0;
            while (index < 10)
            {
                if (index % 2 == 1)
                    yield return index;
                index++;
            }
        }
        // </ReturnAndYieldReturn>
    }

    public static class Extensions
    {
        // <SampleSequence>
        public static IEnumerable<T> Sample<T>(this IEnumerable<T> sourceSequence, int interval)
        {
            int index = 0;
            foreach (T item in sourceSequence)
            {
                if (index++ % interval == 0)
                    yield return item;
            }
        }
        // </SampleSequence>

        // <SampleSequenceAsync>
        public static async IAsyncEnumerable<T> Sample<T>(this IAsyncEnumerable<T> sourceSequence, int interval)
        {
            int index = 0;
            await foreach (T item in sourceSequence)
            {
                if (index++ % interval == 0)
                    yield return item;
            }
        }
        // </SampleSequenceAsync>
    }
}