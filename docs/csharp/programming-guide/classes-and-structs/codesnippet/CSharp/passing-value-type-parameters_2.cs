        class PassingValByRef
        {
            static void SquareIt(ref int x)
            // The parameter x is passed by reference.
            // Changes to x will affect the original value of x.
            {
                x *= x;
                System.Console.WriteLine("The value inside the method: {0}", x);
            }
            static void Main()
            {
                int n = 5;
                System.Console.WriteLine("The value before calling the method: {0}", n);

                SquareIt(ref n);  // Passing the variable by reference.
                System.Console.WriteLine("The value after calling the method: {0}", n);

                // Keep the console window open in debug mode.
                System.Console.WriteLine("Press any key to exit.");
                System.Console.ReadKey();
            }
        }
        /* Output:
            The value before calling the method: 5
            The value inside the method: 25
            The value after calling the method: 25
        */