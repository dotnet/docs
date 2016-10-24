        struct TwoDPoint : IEquatable<TwoDPoint>
        {
            // Read/write auto-implemented properties.
            public int X { get; private set; }
            public int Y { get; private set; }

            public TwoDPoint(int x, int y)
                : this()
            {
                X = x;
                Y = x;
            }

            public override bool Equals(object obj)
            {
                if (obj is TwoDPoint)
                {
                    return this.Equals((TwoDPoint)obj);
                }
                return false;
            }

            public bool Equals(TwoDPoint p)
            {
                return (X == p.X) && (Y == p.Y);
            }

            public override int GetHashCode()
            {
                return X ^ Y;
            }

            public static bool operator ==(TwoDPoint lhs, TwoDPoint rhs)
            {
                return lhs.Equals(rhs);
            }

            public static bool operator !=(TwoDPoint lhs, TwoDPoint rhs)
            {
                return !(lhs.Equals(rhs));
            }
        }


        class Program
        {
            static void Main(string[] args)
            {
                TwoDPoint pointA = new TwoDPoint(3, 4);
                TwoDPoint pointB = new TwoDPoint(3, 4);
                int i = 5;

                // Compare using virtual Equals, static Equals, and == and != operators.
                // True:
                Console.WriteLine("pointA.Equals(pointB) = {0}", pointA.Equals(pointB));
                // True:
                Console.WriteLine("pointA == pointB = {0}", pointA == pointB);
                // True:
                Console.WriteLine("Object.Equals(pointA, pointB) = {0}", Object.Equals(pointA, pointB));
                // False:
                Console.WriteLine("pointA.Equals(null) = {0}", pointA.Equals(null));
                // False:
                Console.WriteLine("(pointA == null) = {0}", pointA == null);
                // True:
                Console.WriteLine("(pointA != null) = {0}", pointA != null);
                // False:
                Console.WriteLine("pointA.Equals(i) = {0}", pointA.Equals(i));
                // CS0019:
                // Console.WriteLine("pointA == i = {0}", pointA == i); 

                // Compare unboxed to boxed.
                System.Collections.ArrayList list = new System.Collections.ArrayList();
                list.Add(new TwoDPoint(3, 4));
                // True:
                Console.WriteLine("pointE.Equals(list[0]): {0}", pointA.Equals(list[0]));


                // Compare nullable to nullable and to non-nullable.
                TwoDPoint? pointC = null;
                TwoDPoint? pointD = null;
                // False:
                Console.WriteLine("pointA == (pointC = null) = {0}", pointA == pointC);
                // True:
                Console.WriteLine("pointC == pointD = {0}", pointC == pointD);

                TwoDPoint temp = new TwoDPoint(3, 4);
                pointC = temp;
                // True:
                Console.WriteLine("pointA == (pointC = 3,4) = {0}", pointA == pointC);

                pointD = temp;
                // True:
                Console.WriteLine("pointD == (pointC = 3,4) = {0}", pointD == pointC);

                // Keep the console window open in debug mode.
                System.Console.WriteLine("Press any key to exit.");
                System.Console.ReadKey();
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