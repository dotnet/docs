    //++ operator
    class MainClass
    {
        static void Main()
        {
            double x;
            x = 1.5;
            Console.WriteLine(++x);
            x = 1.5;
            Console.WriteLine(x++);
            Console.WriteLine(x);
        }
    }
    /*
    Output
    2.5
    1.5
    2.5
    */