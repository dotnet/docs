using System;

namespace builtin_types
{
    public static class StructType
    {
        public static void Examples()
        {
            without_new.StructWithoutNew.Main();
            parameterless_constructor.Example.Main();
            field_initializer.Example.Main();
            field_initializer_no_constructor.Example.Main();
            with_expression.Example.Main();
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

            public double X { get; init; }
            public double Y { get; init; }

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

            // <ReadonlyWithInit>
            public readonly double X { get; init; }
            // </ReadonlyWithInit>
            public readonly double Y { get; init; }

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

    namespace parameterless_constructor
    {
        public static class Example
        {
            // <ParameterlessConstructor>
            public readonly struct Measurement
            {
                public Measurement()
                {
                    Value = double.NaN;
                    Description = "Undefined";
                }

                public Measurement(double value, string description)
                {
                    Value = value;
                    Description = description;
                }
            
                public double Value { get; init; }
                public string Description { get; init; }
            
                public override string ToString() => $"{Value} ({Description})";
            }

            public static void Main()
            {
                var m1 = new Measurement();
                Console.WriteLine(m1);  // output: NaN (Undefined)

                var m2 = default(Measurement);
                Console.WriteLine(m2);  // output: 0 ()

                var ms = new Measurement[2];
                Console.WriteLine(string.Join(", ", ms));  // output: 0 (), 0 ()
            }
            // </ParameterlessConstructor>
        }
    }

    namespace field_initializer
    {
        public static class Example
        {
            // <FieldInitializer>
            public readonly struct Measurement
            {
                public Measurement(double value)
                {
                    Value = value;
                }

                public Measurement(double value, string description)
                {
                    Value = value;
                    Description = description;
                }
            
                public double Value { get; init; }
                public string Description { get; init; } = "Ordinary measurement";
            
                public override string ToString() => $"{Value} ({Description})";
            }

            public static void Main()
            {
                var m1 = new Measurement(5);
                Console.WriteLine(m1);  // output: 5 (Ordinary measurement)

                var m2 = new Measurement();
                Console.WriteLine(m2);  // output: 0 ()

                var m3 = default(Measurement);
                Console.WriteLine(m3);  // output: 0 ()
}
            // </FieldInitializer>
        }
    }

    namespace field_initializer_no_constructor
    {
        public static class Example
        {
            // <FieldInitializerNoConstructor>
            public struct Coords
            {
                public double X = double.NaN;
                public double Y = double.NaN;
            
                public override string ToString() => $"({X}, {Y})";
            }

            public static void Main()
            {
                var p1 = new Coords();
                Console.WriteLine(p1);  // output: (NaN, NaN)

                var p2 = default(Coords);
                Console.WriteLine(p2);  // output: (0, 0)

                var ps = new Coords[3];
                Console.WriteLine(string.Join(", ", ps));  // output: (0, 0), (0, 0), (0, 0)
            }
            // </FieldInitializerNoConstructor>
        }
    }

    namespace with_expression
    {
        public static class Example
        {
            // <WithExpression>
            public readonly struct Coords
            {
                public Coords(double x, double y)
                {
                    X = x;
                    Y = y;
                }

                public double X { get; init; }
                public double Y { get; init; }

                public override string ToString() => $"({X}, {Y})";
            }

            public static void Main()
            {
                var p1 = new Coords(0, 0);
                Console.WriteLine(p1);  // output: (0, 0)

                var p2 = p1 with { X = 3 };
                Console.WriteLine(p2);  // output: (3, 0)

                var p3 = p1 with { X = 1, Y = 4 };
                Console.WriteLine(p3);  // output: (1, 4)
            }
            // </WithExpression>
        }
    }
}