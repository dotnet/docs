namespace ValueEqualityStruct
{
    struct TwoDPoint : IEquatable<TwoDPoint>
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public TwoDPoint(int x, int y)
            : this()
        {
            if (x is (< 1 or > 2000) || y is (< 1 or > 2000))
            {
                throw new ArgumentException("Point must be in range 1 - 2000");
            }
            X = x;
            Y = y;
        }

        public override bool Equals(object? obj) => obj is TwoDPoint other && this.Equals(other);

        public bool Equals(TwoDPoint p) => X == p.X && Y == p.Y;

        public override int GetHashCode() => (X, Y).GetHashCode();

        public static bool operator ==(TwoDPoint lhs, TwoDPoint rhs) => lhs.Equals(rhs);

        public static bool operator !=(TwoDPoint lhs, TwoDPoint rhs) => !(lhs == rhs);
    }

    class Program
    {
        static void Main(string[] args)
        {
            TwoDPoint pointA = new TwoDPoint(3, 4);
            TwoDPoint pointB = new TwoDPoint(3, 4);
            int i = 5;

            // True:
            Console.WriteLine($"pointA.Equals(pointB) = {pointA.Equals(pointB)}");
            // True:
            Console.WriteLine($"pointA == pointB = {pointA == pointB}");
            // True:
            Console.WriteLine($"object.Equals(pointA, pointB) = {object.Equals(pointA, pointB)}");
            // False:
            Console.WriteLine($"pointA.Equals(null) = {pointA.Equals(null)}");
            // False:
            Console.WriteLine($"(pointA == null) = {pointA == null}");
            // True:
            Console.WriteLine($"(pointA != null) = {pointA != null}");
            // False:
            Console.WriteLine($"pointA.Equals(i) = {pointA.Equals(i)}");
            // CS0019:
            // Console.WriteLine($"pointA == i = {pointA == i}");

            // Compare unboxed to boxed.
            System.Collections.ArrayList list = new System.Collections.ArrayList();
            list.Add(new TwoDPoint(3, 4));
            // True:
            Console.WriteLine($"pointA.Equals(list[0]): {pointA.Equals(list[0])}");

            // Compare nullable to nullable and to non-nullable.
            TwoDPoint? pointC = null;
            TwoDPoint? pointD = null;
            // False:
            Console.WriteLine($"pointA == (pointC = null) = {pointA == pointC}");
            // True:
            Console.WriteLine($"pointC == pointD = {pointC == pointD}");

            TwoDPoint temp = new TwoDPoint(3, 4);
            pointC = temp;
            // True:
            Console.WriteLine($"pointA == (pointC = 3,4) = {pointA == pointC}");

            pointD = temp;
            // True:
            Console.WriteLine($"pointD == (pointC = 3,4) = {pointD == pointC}");

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }

    /* Output:
        pointA.Equals(pointB) = True
        pointA == pointB = True
        Object.Equals(pointA, pointB) = True
        pointA.Equals(null) = False
        (pointA == null) = False
        (pointA != null) = True
        pointA.Equals(i) = False
        pointE.Equals(list[0]): True
        pointA == (pointC = null) = False
        pointC == pointD = True
        pointA == (pointC = 3,4) = True
        pointD == (pointC = 3,4) = True
    */
}
