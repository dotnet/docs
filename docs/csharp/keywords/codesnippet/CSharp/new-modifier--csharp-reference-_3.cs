    public class BaseC 
    {
        public class NestedC 
        {
            public int x = 200;
            public int y;
        }
    }

    public class DerivedC : BaseC 
    {
        // Nested type hiding the base type members.
        new public class NestedC   
        {
            public int x = 100;
            public int y; 
            public int z;
        }

        static void Main() 
        {
            // Creating an object from the overlapping class:
            NestedC c1  = new NestedC();

            // Creating an object from the hidden class:
            BaseC.NestedC c2 = new BaseC.NestedC();

            Console.WriteLine(c1.x);
            Console.WriteLine(c2.x);   
        }
    }
    /*
    Output:
    100
    200
    */