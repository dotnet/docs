using System;
using System.Collections.Generic;
using System.Linq;

namespace Patterns
{
    public static class VarPattern
    {
        public static void Examples()
        {
            TestTransform();
        }

        private static void KeepInterimResult()
        {
            // <KeepInterimResult>
            static bool IsAcceptable(int id, int absLimit) =>
                SimulateDataFetch(id) is var results 
                && results.Min() >= -absLimit 
                && results.Max() <= absLimit;

            static int[] SimulateDataFetch(int id)
            {
                var rand = new Random();
                return Enumerable
                           .Range(start: 0, count: 5)
                           .Select(s => rand.Next(minValue: -10, maxValue: 11))
                           .ToArray();
            } 
            // </KeepInterimResult>
        }

        // <WithCaseGuards>
        public record Point(int X, int Y);

        static Point Transform(Point point) => point switch
        {
            var (x, y) when x < y => new Point(-x, y),
            var (x, y) when x > y => new Point(x, -y),
            var (x, y) => new Point(x, y),
        };

        static void TestTransform()
        {
            Console.WriteLine(Transform(new Point(1, 2)));  // output: Point { X = -1, Y = 2 }
            Console.WriteLine(Transform(new Point(5, 2)));  // output: Point { X = 5, Y = -2 }
        }
        // </WithCaseGuards>
    }
}
