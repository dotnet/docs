        class CoOrds
        {
            public int x, y;

            // Default constructor:
            public CoOrds()
            {
                x = 0;
                y = 0;
            }

            // A constructor with two arguments:
            public CoOrds(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            // Override the ToString method:
            public override string ToString()
            {
                return (String.Format("({0},{1})", x, y));
            }
        }

        class MainClass
        {
            static void Main()
            {
                CoOrds p1 = new CoOrds();
                CoOrds p2 = new CoOrds(5, 3);

                // Display the results using the overriden ToString method:
                Console.WriteLine("CoOrds #1 at {0}", p1);
                Console.WriteLine("CoOrds #2 at {0}", p2);
                Console.ReadKey();
            }
        }
        /* Output:
         CoOrds #1 at (0,0)
         CoOrds #2 at (5,3)        
        */