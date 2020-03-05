using System;

namespace builtin_types
{
    public static class StructType
    {
        public static void Examples()
        {
            without_new.StructWithoutNew.Main();
        }

        // <SnippetStructExample>
        public struct Coords
        {
            public Coords(double x, double y)
            {
                X = x;
                Y = y;
            }

            public double X { get; }
            public double Y { get; }

            public override string ToString() => $"({X}, {Y})";
        }
        // </SnippetStructExample>
    }

    namespace without_new
    {
        // <SnippetWithoutNew>
        public static class StructWithoutNew
        {
            public struct Coords
            {
                public double x;
                public double y;
            }

            public static void Main()
            {
                Coords p;
                p.x = 3;
                p.y = 4;
                Console.WriteLine($"({p.x}, {p.y})");  // output: (3, 4)
            }
        }
        // </SnippetWithoutNew>
    }
}