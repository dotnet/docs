    class Division
    {
        static void Main()
        {        
            Console.WriteLine("\nDividing 7 by 3.");
            // Integer quotient is 2, remainder is 1.
            Console.WriteLine("Integer quotient:           {0}", 7 / 3);
            Console.WriteLine("Negative integer quotient:  {0}", -7 / 3);
            Console.WriteLine("Remainder:                  {0}", 7 % 3);
            // Force a floating point quotient.
            float dividend = 7;
            Console.WriteLine("Floating point quotient:    {0}", dividend / 3);

            Console.WriteLine("\nDividing 8 by 5.");
            // Integer quotient is 1, remainder is 3.
            Console.WriteLine("Integer quotient:           {0}", 8 / 5);
            Console.WriteLine("Negative integer quotient:  {0}", 8 / -5);
            Console.WriteLine("Remainder:                  {0}", 8 % 5);
            // Force a floating point quotient.
            Console.WriteLine("Floating point quotient:    {0}", 8 / 5.0);
        }
    }
    // Output:
    //Dividing 7 by 3.
    //Integer quotient:           2
    //Negative integer quotient:  -2
    //Remainder:                  1
    //Floating point quotient:    2.33333333333333

    //Dividing 8 by 5.
    //Integer quotient:           1
    //Negative integer quotient:  -1
    //Remainder:                  3
    //Floating point quotient:    1.6