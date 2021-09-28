using System;
using System.Collections.Generic;

namespace new_in_7
{
    public static class Iterator
    {
        public static void IteratorTest()
        {
            // <SnippetIteratorMethod>
            IEnumerable<char> AlphabetSubset(char start, char end)
            {
                if (start < 'a' || start > 'z')
                    throw new ArgumentOutOfRangeException(paramName: nameof(start), message: "start must be a letter");
                if (end < 'a' || end > 'z')
                    throw new ArgumentOutOfRangeException(paramName: nameof(end), message: "end must be a letter");

                if (end <= start)
                    throw new ArgumentException($"{nameof(end)} must be greater than {nameof(start)}");
                for (var c = start; c < end; c++)
                    yield return c;
            }

            try
            {
                var resultSet1 = AlphabetSubset('d', 'r');
                var resultSet2 = AlphabetSubset('f', 'a');
                Console.WriteLine("iterators created");
                foreach (var thing1 in resultSet1)
                    Console.Write($"{thing1}, ");
                Console.WriteLine();
                foreach (var thing2 in resultSet2)
                    Console.Write($"{thing2}, ");
                Console.WriteLine();
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Caught an argument exception");
            }
            // </SnippetIteratorMethod>
        }

        public static void IteratorTestLocal()
        {
            // <SnippetIteratorMethodLocalInteractive>
            IEnumerable<char> AlphabetSubset(char start, char end)
            {
                if (start < 'a' || start > 'z')
                    throw new ArgumentOutOfRangeException(paramName: nameof(start), message: "start must be a letter");
                if (end < 'a' || end > 'z')
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

            try
            {
                var resultSet1 = AlphabetSubset('d', 'r');
                var resultSet2 = AlphabetSubset('f', 'a');
                Console.WriteLine("iterators created");
                foreach (var thing1 in resultSet1)
                    Console.Write($"{thing1}, ");
                Console.WriteLine();
                foreach (var thing2 in resultSet2)
                    Console.Write($"{thing2}, ");
                Console.WriteLine();
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Caught an argument exception");
            }
            // </SnippetIteratorMethodLocalInteractive>
        }

        // <SnippetIteratorMethodLocal>
        public static IEnumerable<char> AlphabetSubset3(char start, char end)
        {
            if (start < 'a' || start > 'z')
                throw new ArgumentOutOfRangeException(paramName: nameof(start), message: "start must be a letter");
            if (end < 'a' || end > 'z')
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
        // </SnippetIteratorMethodLocal>
    }
}
