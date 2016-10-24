    class ReturnTest
    {
        static double CalculateArea(int r)
        {
            double area = r * r * Math.PI;
            return area;
        }

        static void Main()
        {
            int radius = 5;
            double result = CalculateArea(radius);
            Console.WriteLine("The area is {0:0.00}", result);

            // Keep the console open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    // Output: The area is 78.54
