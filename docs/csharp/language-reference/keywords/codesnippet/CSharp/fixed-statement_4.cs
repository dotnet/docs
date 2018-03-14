    class Point
    { 
        public int x, y; 
    }

    class FixedTest2 
    {
        // Unsafe method: takes a pointer to an int.
        unsafe static void SquarePtrParam (int* p) 
        {
            *p *= *p;
        }

        unsafe static void Main() 
        {
            Point pt = new Point();
            pt.x = 5;
            pt.y = 6;
            // Pin pt in place:
            fixed (int* p = &pt.x) 
            {
                SquarePtrParam (p);
            }
            // pt now unpinned.
            Console.WriteLine ("{0} {1}", pt.x, pt.y);
        }
    }
    /*
    Output:
    25 6
     */
