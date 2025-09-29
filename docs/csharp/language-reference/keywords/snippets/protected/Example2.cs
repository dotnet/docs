//<snippet1>
namespace Example2
{
    class Point
    {
        protected int x;
        protected int y;
    }

    class DerivedPoint: Point
    {
        static void Main()
        {
            var dpoint = new DerivedPoint();

            // Direct access to protected members.
            dpoint.x = 10;
            dpoint.y = 15;
            Console.WriteLine($"x = {dpoint.x}, y = {dpoint.y}");
        }
    }
    // Output: x = 10, y = 15
}
//</snippet1>