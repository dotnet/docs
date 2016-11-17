    // Mixing types in expressions
    class MixedTypes
    {
        static void Main()
        {
            int x = 3;
            float y = 4.5f;
            short z = 5;
            double w = 1.7E+3;
            // Result of the 2nd argument is a double:
            Console.WriteLine("The sum is {0}", x + y + z + w);
        }
    }
    // Output: The sum is 1712.5