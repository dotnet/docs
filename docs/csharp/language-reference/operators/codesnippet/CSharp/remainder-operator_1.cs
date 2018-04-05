    class MainClass6
    {
        static void Main()
        {
            Console.WriteLine(5 % 2);       // int
            Console.WriteLine(-5 % 2);      // int
            Console.WriteLine(5.0 % 2.2);   // double
            Console.WriteLine(5.0m % 2.2m); // decimal
            Console.WriteLine(-5.2 % 2.0);  // double
        }
    }
    /*
    Output:
    1
    -1
    0.6
    0.6
    -1.2
    */
