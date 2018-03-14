    class ConditionalOp
    {
        static double sinc(double x)
        {
            return x != 0.0 ? Math.Sin(x) / x : 1.0;
        }

        static void Main()
        {
            Console.WriteLine(sinc(0.2));
            Console.WriteLine(sinc(0.1));
            Console.WriteLine(sinc(0.0));
        }
    }
    /*
    Output:
    0.993346653975306
    0.998334166468282
    1
    */