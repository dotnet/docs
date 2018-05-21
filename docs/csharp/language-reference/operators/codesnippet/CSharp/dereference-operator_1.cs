    // compile with: /unsafe

    struct Point
    {
        public int x, y;
    }

    class MainClass12
    {
        unsafe static void Main()
        {
            Point pt = new Point();
            Point* pp = &pt;
            pp->x = 123;
            pp->y = 456;
            Console.WriteLine("{0} {1}", pt.x, pt.y);
        }
    }
    /*
    Output:
    123 456
    */