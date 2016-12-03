using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new_in_7
{
    public static class Iterator
    {
        #region 25_IteratorMethod
        public static IEnumerable<char> AlphabetSubset(char start, char end)
        {
            if ((start < 'a') || (start > 'z'))
                throw new ArgumentOutOfRangeException(paramName: nameof(start), message: "start must be a letter");
            if ((end < 'a') || (end > 'z'))
                throw new ArgumentOutOfRangeException(paramName: nameof(end), message: "end must be a letter");

            if (end <= start)
                throw new ArgumentException($"{nameof(end)} must be greater than {nameof(start)}");
            for (var c = start; c < end; c++)
                yield return c;
        }
        #endregion

        #region 27_IteratorMethodRefactored
        public static IEnumerable<char> AlphabetSubset2(char start, char end)
        {
            if ((start < 'a') || (start > 'z'))
                throw new ArgumentOutOfRangeException(paramName: nameof(start), message: "start must be a letter");
            if ((end < 'a') || (end > 'z'))
                throw new ArgumentOutOfRangeException(paramName: nameof(end), message: "end must be a letter");

            if (end <= start)
                throw new ArgumentException($"{nameof(end)} must be greater than {nameof(start)}");
            return alphabetSubsetImplementation(start, end);
        }

        private static IEnumerable<char> alphabetSubsetImplementation(char start, char end)
        { 
            for (var c = start; c < end; c++)
                yield return c;
        }
        #endregion

        #region 28_IteratorMethodLocal
        public static IEnumerable<char> AlphabetSubset3(char start, char end)
        {
            if ((start < 'a') || (start > 'z'))
                throw new ArgumentOutOfRangeException(paramName: nameof(start), message: "start must be a letter");
            if ((end < 'a') || (end > 'z'))
                throw new ArgumentOutOfRangeException(paramName: nameof(end), message: "end must be a letter");

            if (end <= start)
                throw new ArgumentException($"{nameof(end)} must be greater than {nameof(start)}");

            return alphabetSubsetImplementation();

            IEnumerable<char> alphabetSubsetImplementation()
            {
                for (var c = start; c < end; c++)
                    yield return c;
            }
        }
        #endregion

    }
}
