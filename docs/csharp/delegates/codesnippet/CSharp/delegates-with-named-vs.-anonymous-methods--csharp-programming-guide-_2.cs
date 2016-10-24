    // Declare a delegate
    delegate void Del(int i, double j);

    class MathClass
    {
        static void Main()
        {
            MathClass m = new MathClass();

            // Delegate instantiation using "MultiplyNumbers"
            Del d = m.MultiplyNumbers;

            // Invoke the delegate object.
            System.Console.WriteLine("Invoking the delegate using 'MultiplyNumbers':");
            for (int i = 1; i <= 5; i++)
            {
                d(i, 2);
            }

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }

        // Declare the associated method.
        void MultiplyNumbers(int m, double n)
        {
            System.Console.Write(m * n + " ");
        }
    }
    /* Output:
        Invoking the delegate using 'MultiplyNumbers':
        2 4 6 8 10
    */