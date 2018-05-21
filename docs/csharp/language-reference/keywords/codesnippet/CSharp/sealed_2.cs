    sealed class SealedClass
    {
        public int x;
        public int y;
    }

    class SealedTest2
    {
        static void Main()
        {
            SealedClass sc = new SealedClass();
            sc.x = 110;
            sc.y = 150;
            Console.WriteLine("x = {0}, y = {1}", sc.x, sc.y);
        }
    }
    // Output: x = 110, y = 150
