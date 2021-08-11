using System;
using System.Collections.Generic;
using System.Linq;

namespace patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            NullCheck();

            NullReferenceCheck();

            var sequence = new List<int> {1,2,3,4,5,6,7};
            var middle = MidPoint(sequence);
            Console.WriteLine(middle);
        }

        // <MidPoint>
        public static T MidPoint<T>(IEnumerable<T> sequence)
        {
            if (sequence is IList<T> list)
            {
                return list[list.Count / 2];
            }
            else if (sequence is null)
            {
                throw new ArgumentNullException(nameof(sequence), "Sequence can't be null.");
            }
            else
            {
                int halfLength = sequence.Count() / 2 - 1;
                if (halfLength < 0) halfLength = 0;
                return sequence.Skip(halfLength).First();
            }
        }
        // </MidPoint>

        private static void NullReferenceCheck()
        {
            // <NullReferenceCheck>
            string? message = "This is not the null string";

            if (message is not null)
            {
                Console.WriteLine(message);
            }
            // </NullReferenceCheck>
        }


        private static void NullCheck()
        {
            // <NullableCheck>
            int? maybe = 12;

            if (maybe is int number)
            {
                Console.WriteLine($"The nullable int 'maybe' has the value {number}");
            }
            else
            {
                Console.WriteLine("The nullable int 'maybe' doesn't hold a value");
            }
            // </NullableCheck>
        }
    }
}
