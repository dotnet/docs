        abstract class Shape
        {
            public abstract double Area
            {
                get;
                set;
            }
        }

        class Square : Shape
        {
            public double side;

            public Square(double s)  //constructor
            {
                side = s;
            }

            public override double Area
            {
                get
                {
                    return side * side;
                }
                set
                {
                    side = System.Math.Sqrt(value);
                }
            }
        }

        class Cube : Shape
        {
            public double side;

            public Cube(double s)
            {
                side = s;
            }

            public override double Area
            {
                get
                {
                    return 6 * side * side;
                }
                set
                {
                    side = System.Math.Sqrt(value / 6);
                }
            }
        }

        class TestShapes
        {
            static void Main()
            {
                // Input the side:
                System.Console.Write("Enter the side: ");
                double side = double.Parse(System.Console.ReadLine());

                // Compute the areas:
                Square s = new Square(side);
                Cube c = new Cube(side);

                // Display the results:
                System.Console.WriteLine("Area of the square = {0:F2}", s.Area);
                System.Console.WriteLine("Area of the cube = {0:F2}", c.Area);
                System.Console.WriteLine();

                // Input the area:
                System.Console.Write("Enter the area: ");
                double area = double.Parse(System.Console.ReadLine());

                // Compute the sides:
                s.Area = area;
                c.Area = area;

                // Display the results:
                System.Console.WriteLine("Side of the square = {0:F2}", s.side);
                System.Console.WriteLine("Side of the cube = {0:F2}", c.side);
            }
        }
        /* Example Output:
            Enter the side: 4
            Area of the square = 16.00
            Area of the cube = 96.00

            Enter the area: 24
            Side of the square = 4.90
            Side of the cube = 2.00
        */