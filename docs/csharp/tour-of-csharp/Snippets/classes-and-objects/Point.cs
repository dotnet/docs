namespace ClassesAndObjects
{
    // <PointClass>
    public class Point
    {
        public int x, y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    // </PointClass>
    // <Create3DPoint>
    public class Point3D: Point
    {
        public int z;
        public Point3D(int x, int y, int z) :
            base(x, y)
        {
            this.z = z;
        }
    }
    // </Create3DPoint>
}

namespace DeclareTypes
{
    // <PointStruct>
    public struct Point
    {
        public double X { get; }
        public double Y { get; }
        public Point(double x, double y) => (X, Y) = (x, y);
    }
    // </PointStruct>
}