    class PointTest
    {
        public int x; 
        public int y;
    }

    class MainClass4
    {
        static void Main() 
        {
            PointTest p = new PointTest();
            // Direct access to public members:
            p.x = 10;
            p.y = 15;
            Console.WriteLine("x = {0}, y = {1}", p.x, p.y); 
        }
    }
    // Output: x = 10, y = 15