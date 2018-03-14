    class MainClass
    {
        // unsafe not required for primitive types
        static void Main()
        {
            Console.WriteLine("The size of short is {0}.", sizeof(short));
            Console.WriteLine("The size of int is {0}.", sizeof(int));
            Console.WriteLine("The size of long is {0}.", sizeof(long));
        }
    }
    /*
    Output:
        The size of short is 2.
        The size of int is 4.
        The size of long is 8.
    */
