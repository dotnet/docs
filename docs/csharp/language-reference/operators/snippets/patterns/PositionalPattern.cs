using System;

namespace Patterns
{
    public static class PositionalPattern
    {
        public static void Examples()
        {
            Console.WriteLine("No example output");
        }

        // <BasicExample>
        public readonly struct Point
        {
            public int X { get; }
            public int Y { get; }

            public Point(int x, int y) => (X, Y) = (x, y);

            public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
        }

        static string Classify(Point point) => point switch
        {
            (0, 0) => "Origin",
            (1, 0) => "positive X basis end",
            (0, 1) => "positive Y basis end",
            _ => "Just a point",
        };
        // </BasicExample>

        // <MatchTuple>
        static decimal GetGroupTicketPriceDiscount(int groupSize, DateTime visitDate)
            => (groupSize, visitDate.DayOfWeek) switch
            {
                (<= 0, _) => throw new ArgumentException("Group size must be positive."),
                (_, DayOfWeek.Saturday or DayOfWeek.Sunday) => 0.0m,
                (>= 5 and < 10, DayOfWeek.Monday) => 20.0m,
                (>= 10, DayOfWeek.Monday) => 30.0m,
                (>= 5 and < 10, _) => 12.0m,
                (>= 10, _) => 15.0m,
                _ => 0.0m,
            };
        // </MatchTuple>

        // <WithTypeCheck>
        public record Point2D(int X, int Y);
        public record Point3D(int X, int Y, int Z);

        static string PrintIfAllCoordinatesArePositive(object point) => point switch
        {
            Point2D (> 0, > 0) p => p.ToString(),
            Point3D (> 0, > 0, > 0) p => p.ToString(),
            _ => string.Empty,
        };
        // </WithTypeCheck>

        // <WithPropertyPattern>
        public record WeightedPoint(int X, int Y)
        {
            public double Weight { get; set; }
        }

        static bool IsInDomain(WeightedPoint point) => point is (>= 0, >= 0) { Weight: >= 0.0 };
        // </WithPropertyPattern>

        static void CompletePositionPattern(object input)
        {
            // <CompletePositionalPattern>
            if (input is WeightedPoint (> 0, > 0) { Weight: > 0.0 } p)
            {
                // ..
            }
            // </CompletePositionalPattern>
        }
    }
}
