        public partial class CoOrds
        {
            private int x;
            private int y;

            public CoOrds(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public partial class CoOrds
        {
            public void PrintCoOrds()
            {
                Console.WriteLine("CoOrds: {0},{1}", x, y);
            }

        }

        class TestCoOrds
        {
            static void Main()
            {
                CoOrds myCoOrds = new CoOrds(10, 15);
                myCoOrds.PrintCoOrds();

                // Keep the console window open in debug mode.
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
        // Output: CoOrds: 10,15