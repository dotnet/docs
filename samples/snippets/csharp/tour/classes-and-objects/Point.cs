namespace ClassesAndObjects
{
    public class Point
    {
        public int x, y;
        public Point(int x, int y) 
        {
            this.x = x;
            this.y = y;
        }
    }
    public class Point3D: Point
    {
        public int z;
        public Point3D(int x, int y, int z) : 
            base(x, y) 
        {
            this.z = z;
        }
    }
}