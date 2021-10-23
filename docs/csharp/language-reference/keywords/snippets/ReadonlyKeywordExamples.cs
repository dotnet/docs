using System;
using System.Collections.Generic;
using System.Text;

namespace keywords
{
    // <SnippetReadonlyField>
    class Age
    {
        private readonly int _year;
        Age(int year)
        {
            _year = year;
        }
        void ChangeYear()
        {
            //_year = 1967; // Compile error if uncommented.
        }
    }
    // </SnippetReadonlyField>

    // <SnippetInitReadonlyField>
    public class SamplePoint
    {
        public int x;
        // Initialize a readonly field
        public readonly int y = 25;
        public readonly int z;

        public SamplePoint()
        {
            // Initialize a readonly instance field
            z = 24;
        }

        public SamplePoint(int p1, int p2, int p3)
        {
            x = p1;
            y = p2;
            z = p3;
        }

        public static void Main()
        {
            SamplePoint p1 = new SamplePoint(11, 21, 32);   // OK
            Console.WriteLine($"p1: x={p1.x}, y={p1.y}, z={p1.z}");
            SamplePoint p2 = new SamplePoint();
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

    public static class ReadonlyKeywordExamples
    {
        public static void Examples()
        {
            SamplePoint.Main();
            ReadonlyRefReturns();
        }

        // <SnippetReadonlyReturn>
        private static readonly SamplePoint s_origin = new SamplePoint(0, 0, 0);
        public static ref readonly SamplePoint Origin => ref s_origin;
        // </SnippetReadonlyReturn>

        private static void ReadonlyRefReturns()
        {
            Console.WriteLine(Origin);
        }
    }
}
