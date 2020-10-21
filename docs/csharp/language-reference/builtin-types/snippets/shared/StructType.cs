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

    namespace readonly_struct
    {
        // <SnippetReadonlyStruct>
        public readonly struct Coords
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
        // </SnippetReadonlyStruct>
    }

    namespace readonly_members
    {
        public struct Example
        {
            // <SnippetReadonlyProperty>
            private int counter;
            public int Counter
            {
                readonly get => counter;
                set => counter = value;
            }
            // </SnippetReadonlyProperty>

            public double X { get; }
            public double Y { get; }

            // <SnippetReadonlyMethod>
            public readonly double Sum()
            {
                return X + Y;
            }
            // </SnippetReadonlyMethod>

            // <SnippetReadonlyOverride>
            public readonly override string ToString() => $"({X}, {Y})";
            // </SnippetReadonlyOverride>
        }
    }

    namespace ref_struct
    {
        // <SnippetRefStruct>
        public ref struct CustomRef
        {
            public bool IsValid;
            public Span<int> Inputs;
            public Span<int> Outputs;
        }
        // </SnippetRefStruct>

        // <SnippetReadonlyRef>
        public readonly ref struct ConversionRequest
        {
            public ConversionRequest(double rate, ReadOnlySpan<double> values)
            {
                Rate = rate;
                Values = values;
            }

            public double Rate { get; }
            public ReadOnlySpan<double> Values { get; }
        }
        // </SnippetReadonlyRef>
    }
}