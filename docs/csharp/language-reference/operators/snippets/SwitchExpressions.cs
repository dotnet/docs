using System;
using System.Collections.Generic;
using System.Linq;

namespace operators
{
    public enum Directions
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

    public static class SwitchExpressions
    {
        public static void Examples()
        {
            // <SnippetBasicStructure>
            var direction = Directions.Right;
            Console.WriteLine($"Map view direction is {direction}");

            var orientation = direction switch
            {
                Directions.Up    => Orientation.North,
                Directions.Right => Orientation.East,
                Directions.Down  => Orientation.South,
                Directions.Left  => Orientation.West,
            };
            Console.WriteLine($"Cardinal orientation is {orientation}");
            // </SnippetBasicStructure>
        }
    }
}


