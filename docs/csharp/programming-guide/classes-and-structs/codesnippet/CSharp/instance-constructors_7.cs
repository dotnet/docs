    abstract class Shape
    {
        public const double pi = Math.PI;
        protected double x, y;

        public Shape(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public abstract double Area();
    }

    class Circle : Shape
    {
        public Circle(double radius)
            : base(radius, 0)
        {
        }
        public override double Area()
        {
            return pi * x * x;
        }
    }

    class Cylinder : Circle
    {
        public Cylinder(double radius, double height)
            : base(radius)
        {
            y = height;
        }

        public override double Area()
        {
            return (2 * base.Area()) + (2 * pi * x * y);
        }
    }

    class TestShapes
    {
        static void Main()
        {
            double radius = 2.5;
            double height = 3.0;

            Circle ring = new Circle(radius);
            Cylinder tube = new Cylinder(radius, height);

            Console.WriteLine("Area of the circle = {0:F2}", ring.Area());
            Console.WriteLine("Area of the cylinder = {0:F2}", tube.Area());

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    /* Output:
        Area of the circle = 19.63
        Area of the cylinder = 86.39
    */