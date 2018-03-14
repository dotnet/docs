        unsafe static void TestMethod()
        {
            
            // Assume that the following class exists.
            //class Point 
            //{ 
            //    public int x;
            //    public int y; 
            //}

            // Variable pt is a managed variable, subject to garbage collection.
            Point pt = new Point();

            // Using fixed allows the address of pt members to be taken,
            // and "pins" pt so that it is not relocated.
            
            fixed (int* p = &pt.x)
            {
                *p = 1;
            }        
           
        }