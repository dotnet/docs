using System;
using System.Collections.Generic;
using System.Text;

namespace keywords
{
    // <SnippetReadonlyField>
    class Age
    {
        readonly int year;
        Age(int year)
        {
            this.year = year;
        }
        void ChangeYear()
        {
            //year = 1967; // Compile error if uncommented.
        }
    }
    // </SnippetReadonlyField>

    // <SnippetInitReadonlyField>
    class SampleClass
    {
        public int x;
        // Initialize a readonly field
        public readonly int y = 25;
        public readonly int z;

        public SampleClass()
        {
            // Initialize a readonly instance field
            z = 24;
        }

        public SampleClass(int p1, int p2, int p3)
        {
            x = p1;
            y = p2;
            z = p3;
        }

        public static void Main()
        {
            SampleClass p1 = new SampleClass(11, 21, 32);   // OK
            Console.WriteLine($"p1: x={p1.x}, y={p1.y}, z={p1.z}");
            SampleClass p2 = new SampleClass();
            p2.x = 55;   // OK
            Console.WriteLine($"p2: x={p2.x}, y={p2.y}, z={p2.z}");
        }
        /*
         Output:
            p1: x=11, y=21, z=32
            p2: x=55, y=25, z=24
        */
    }
    // </SnippetInitReadonlyField>

    // <SnippetReadonlyStruct>
    public readonly struct Point
    {
        public double X { get; }
        public double Y { get; }

        public Point(double x, double y) => (X, Y) = (x, y);

        public override string ToString() => $"({X}, {Y})";
    }
    // </SnippetReadonlyStruct>

    public static class ReadonlyKeywordExamples
    {
        public static void Examples()
        {
            SampleClass.Main();
            ReadonlyRefReturns();
        }

        // <SnippetReadonlyReturn>
        private static readonly Point origin = new Point(0, 0);
        public static ref readonly Point Origin => ref origin;
        // </SnippetReadonlyReturn>

        private static void ReadonlyRefReturns()
        {
            Console.WriteLine(Origin);
        }
    }
}
