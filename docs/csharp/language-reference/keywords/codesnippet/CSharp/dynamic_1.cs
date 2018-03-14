    class Program
    {
        static void Main(string[] args)
        {
            dynamic dyn = 1;
            object obj = 1;

            // Rest the mouse pointer over dyn and obj to see their
            // types at compile time.
            System.Console.WriteLine(dyn.GetType());
            System.Console.WriteLine(obj.GetType());
        }
    }