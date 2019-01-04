        public partial class Coords
        {
            private int x;
            private int y;

            public Coords(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public partial class Coords
        {
            public void PrintCoords()
            {
                Console.WriteLine("Coords: {0},{1}", x, y);
            }

        }

        class TestCoords
        {
            static void Main()
            {
                Coords myCoords = new Coords(10, 15);
                myCoords.PrintCoords();

                // Keep the console window open in debug mode.
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
        // Output: Coords: 10,15