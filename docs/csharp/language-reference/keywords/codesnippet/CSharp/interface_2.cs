    interface IPoint
    {
       // Property signatures:
       int x
       {
          get;
          set;
       }

       int y
       {
          get;
          set;
       }
    }

    class Point : IPoint
    {
       // Fields:
       private int _x;
       private int _y;

       // Constructor:
       public Point(int x, int y)
       {
          _x = x;
          _y = y;
       }

       // Property implementation:
       public int x
       {
          get
          {
             return _x;
          }

          set
          {
             _x = value;
          }
       }

       public int y
       {
          get
          {
             return _y;
          }
          set
          {
             _y = value;
          }
       }
    }

    class MainClass
    {
       static void PrintPoint(IPoint p)
       {
          Console.WriteLine("x={0}, y={1}", p.x, p.y);
       }

       static void Main()
       {
          Point p = new Point(2, 3);
          Console.Write("My Point: ");
          PrintPoint(p);
       }
    }
    // Output: My Point: x=2, y=3