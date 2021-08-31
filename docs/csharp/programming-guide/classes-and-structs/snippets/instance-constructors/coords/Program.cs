using System;

namespace CoordsWithParameterlessConstructorOnly
{
    //<Snippet1>
    class Coords
    {
        public int x, y;
    
        // constructor
        public Coords()
        {
            x = 0;
            y = 0;
        }
    }
    //</Snippet1>
}

namespace CoordsWithTwoArgumentsConstructorAndToString
{
    //<Snippet4>
    class Coords
    {
        public int x, y;

        // Parameterless constructor.
        public Coords()
        {
            x = 0;
            y = 0;
        }

        //<Snippet2>
        // A constructor with two parameters.
        public Coords(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        //</Snippet2>

        public override string ToString()
        {
            return $"({x},{y})";
        }
    }

    class MainClass
    {
        static void Main()
        {
            //<Snippet3>
            var p1 = new Coords();
            var p2 = new Coords(5, 3);
            //</Snippet3>

            Console.WriteLine($"Coords #1 at {p1}");
            Console.WriteLine($"Coords #2 at {p2}");
            Console.ReadKey();
        }
    }
    /* Output:
     Coords #1 at (0,0)
     Coords #2 at (5,3)
    */
    //</Snippet4>
}
