using System;
using System.Collections.Generic;
using System.Linq;

namespace operators
{
    // <SnippetBasicStructure>
    public static class SwitchExample
    {
        public enum Direction
        {
            Up,
            Down,
            Right,
            Left
        }

        public enum Orientation
        {
            North,
            South,
            East,
            West
        }

        public static Orientation ToOrientation(Direction direction) => direction switch
        {
            Direction.Up    => Orientation.North,
            Direction.Right => Orientation.East,
            Direction.Down  => Orientation.South,
            Direction.Left  => Orientation.West,
            _ => throw new ArgumentOutOfRangeException(nameof(direction), $"Not expected direction value: {direction}"),
        };

        public static void Main()
        {
            var direction = Direction.Right;
            Console.WriteLine($"Map view direction is {direction}");
            Console.WriteLine($"Cardinal orientation is {ToOrientation(direction)}");
            // Output:
            // Map view direction is Right
            // Cardinal orientation is East
        }
    }
    // </SnippetBasicStructure>

    public static class SwitchExpressions
    {
        public static void Examples()
        {
            SwitchExample.Main();
        }

        // <CaseGuardExample>
        public readonly struct Point
        {
            public Point(int x, int y) => (X, Y) = (x, y);
            
            public int X { get; }
            public int Y { get; }
        }

        static Point Transform(Point point) => point switch
        {
            { X: 0, Y: 0 }                    => new Point(0, 0),
            { X: var x, Y: var y } when x < y => new Point(x + y, y),
            { X: var x, Y: var y } when x > y => new Point(x - y, y),
            { X: var x, Y: var y }            => new Point(2 * x, 2 * y),
        };
        // </CaseGuardExample>
    }
}

