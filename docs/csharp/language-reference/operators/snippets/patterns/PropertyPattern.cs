using System;
using System.Collections.Generic;
using System.Linq;

namespace Patterns
{
    public static class PropertyPattern
    {
        public static void Examples()
        {
            WithTypeCheck();
        }

        // <BasicExample>
        static bool IsConferenceDay(DateTime date) => date is { Year: 2020, Month: 5, Day: 19 or 20 or 21 };
        // </BasicExample>

        private static void WithTypeCheck()
        {
            // <WithTypeCheck>
            Console.WriteLine(TakeFive("Hello, world!"));  // output: Hello
            Console.WriteLine(TakeFive("Hi!"));  // output: Hi!
            Console.WriteLine(TakeFive(new[] { '1', '2', '3', '4', '5', '6', '7' }));  // output: 12345
            Console.WriteLine(TakeFive(new[] { 'a', 'b', 'c' }));  // output: abc

            static string TakeFive(object input) => input switch
            {
                string { Length: >= 5 } s => s.Substring(0, 5),
                string s => s,

                ICollection<char> { Count: >= 5 } symbols => new string(symbols.Take(5).ToArray()),
                ICollection<char> symbols => new string(symbols.ToArray()),

                null => throw new ArgumentNullException(nameof(input)),
                _ => throw new ArgumentException("Not supported input type."),
            };
            // </WithTypeCheck>
        }

        // <RecursivePropertyPattern>
        public record Point(int X, int Y);
        public record Segment(Point Start, Point End);

        static bool IsAnyEndOnXAxis(Segment segment) =>
            segment is { Start: { Y: 0 } } or { End: { Y: 0 } };
        // </RecursivePropertyPattern>

        private static class Extended
        {
            // <ExtendedPropertyPattern>
            static bool IsAnyEndOnXAxis(Segment segment) =>
                segment is { Start.Y: 0 } or { End.Y: 0 };
            // </ExtendedPropertyPattern>
        }
    }
}