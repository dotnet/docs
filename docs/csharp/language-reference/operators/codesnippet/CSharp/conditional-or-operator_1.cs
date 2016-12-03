    class ConditionalOr
    {
        // Method1 returns true.
        static bool Method1()
        {
            Console.WriteLine("Method1 called.");
            return true;
        }

        // Method2 returns false.
        static bool Method2()
        {
            Console.WriteLine("Method2 called.");
            return false;
        }


        static bool Divisible(int number, int divisor)
        {
            // If the OR expression uses ||, the division is not attempted
            // when the divisor equals 0.
            return !(divisor == 0 || number % divisor != 0);

            // If the OR expression uses |, the division is attempted when
            // the divisor equals 0, and causes a divide-by-zero exception.
            // Replace the return statement with the following line to
            // see the exception.
            //return !(divisor == 0 | number % divisor != 0);
        }

        static void Main()
        {
            // Example #1 uses Method1 and Method2 to demonstrate 
            // short-circuit evaluation.

            Console.WriteLine("Regular OR:");
            // The | operator evaluates both operands, even though after 
            // Method1 returns true, you know that the OR expression is
            // true.
            Console.WriteLine("Result is {0}.\n", Method1() | Method2());

            Console.WriteLine("Short-circuit OR:");
            // Method2 is not called, because Method1 returns true.
            Console.WriteLine("Result is {0}.\n", Method1() || Method2());


            // In Example #2, method Divisible returns True if the
            // first argument is evenly divisible by the second, and False
            // otherwise. Using the | operator instead of the || operator
            // causes a divide-by-zero exception.

            // The following line displays True, because 42 is evenly 
            // divisible by 7.
            Console.WriteLine("Divisible returns {0}.", Divisible(42, 7));

            // The following line displays False, because 42 is not evenly
            // divisible by 5.
            Console.WriteLine("Divisible returns {0}.", Divisible(42, 5));

            // The following line displays False when method Divisible 
            // uses ||, because you cannot divide by 0.
            // If method Divisible uses | instead of ||, this line
            // causes an exception.
            Console.WriteLine("Divisible returns {0}.", Divisible(42, 0));
        }
    }
    /*
    Output:
    Regular OR:
    Method1 called.
    Method2 called.
    Result is True.

    Short-circuit OR:
    Method1 called.
    Result is True.
 
    Divisible returns True.
    Divisible returns False.
    Divisible returns False.
    */