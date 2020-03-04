using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Iterators
{
    public static class IteratorMethods
    {
        public static IEnumerable<int> GetSingleDigitNumbers()
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

        public static IEnumerable<int> GetSingleDigitNumbersV2()
        {
            int index = 0;
            while (index++ < 10)
                yield return index;
        }

        public static IEnumerable<int> GetSingleDigitNumbersAndNumbersOver100()
        {
            int index = 0;
            while (index++ < 10)
                yield return index;

            yield return 50;

            index = 100;
            while (index++ < 110)
                yield return index;
        }

        public static IEnumerable<int> GetSingleDigitNumbersAndOver100V2()
        {
            int index = 0;
            while (index++ < 10)
                yield return index;

            yield return 50;

            var items = new int[] { 100, 101, 102, 103, 104, 105, 106, 107, 108, 109 };
            foreach (var item in items)
                yield return item;
        }

        public static IEnumerable<int> GetSingleDigitOddNumbers(bool getCollection)
        {
            if (getCollection == false)
                return new int[0];
            else
                return IteratorMethod();
        }

        private static IEnumerable<int> IteratorMethod()
        {
            int index = 0;
            while (index++ < 10)
                if (index % 2 == 1)
                    yield return index;
        }
    }
}
