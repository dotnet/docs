using System;
using System.Collections.Generic;
using System.Linq;

namespace Custom.Linq.Extensions
{
    // <LinqExtensionClass>
    public static class EnumerableExtension
    {
        public static double Median(this IEnumerable<double>? source)
        {
            if (source is null || !source.Any())
            {
                throw new InvalidOperationException("Cannot compute median for a null or empty set.");
            }

            var sortedList =
                source.OrderBy(number => number).ToList();

            int itemIndex = sortedList.Count / 2;

            if (sortedList.Count % 2 == 0)
            {
                // Even number of items.
                return (sortedList[itemIndex] + sortedList[itemIndex - 1]) / 2;
            }
            else
            {
                // Odd number of items.
                return sortedList[itemIndex];
            }
        }
    }
    // </LinqExtensionClass>

    public static class OtherExtensions
    {
        // <IntOverload>
        // int overload
        public static double Median(this IEnumerable<int> source) =>
            (from number in source select (double)number).Median();
        // </IntOverload>

        // <GenericOverload>
        // generic overload
        public static double Median<T>(
            this IEnumerable<T> numbers, Func<T, double> selector) =>
            (from num in numbers select selector(num)).Median();
        // </GenericOverload>

        // <SequenceElement>
        // Extension method for the IEnumerable<T> interface.
        // The method returns every other element of a sequence.
        public static IEnumerable<T> AlternateElements<T>(this IEnumerable<T> source)
        {
            int index = 0;
            foreach (T element in source)
            {
                if (index % 2 == 0)
                {
                    yield return element;
                }

                index++;
            }
        }
        // </SequenceElement>
    }
}
