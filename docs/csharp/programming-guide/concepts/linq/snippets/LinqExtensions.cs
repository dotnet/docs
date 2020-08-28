using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq
{
    // <LinqExtensionClass>
    public static class LINQExtension
    {
        public static double Median(this IEnumerable<double>? source)
        {
            if (!(source?.Any() ?? false))
            {
                throw new InvalidOperationException("Cannot compute median for a null or empty set.");
            }

            var sortedList = (from number in source
                              orderby number
                              select number).ToList();

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
        //int overload
        public static double Median(this IEnumerable<int> source) =>
            (from num in source select (double)num).Median();
        // </IntOverload>

        // <GenericOverload>
        // Generic overload.
        public static double Median<T>(this IEnumerable<T> numbers,
                               Func<T, double> selector) =>
            (from num in numbers select selector(num)).Median();
        // </GenericOverload>

        // <SequenceElement>
        // Extension method for the IEnumerable<T> interface.
        // The method returns every other element of a sequence.
        public static IEnumerable<T> AlternateElements<T>(this IEnumerable<T> source)
        {
            int i = 0;
            foreach (var element in source)
            {
                if (i % 2 == 0)
                {
                    yield return element;
                }
                i++;
            }
        }
        // </SequenceElement>


    }
}
