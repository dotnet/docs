using System;

namespace Structs
{
    public class PointExample
    {
        public static void Main() 
        {
            Point[] points = new Point[100];
            for (int i = 0; i < 100; i++)
                points[i] = new Point(i, i);
        }
    }

    public class StructAssignment
    {
        public static void Assignment()
        {
            Point a = new Point(10, 10);
            Point b = a;
            a.x = 20;
            Console.WriteLine(b.x);
        }
    }
}
