    class ExceptionTest
    {
        static double SafeDivision(double x, double y)
        {
            if (y == 0)
                throw new System.DivideByZeroException();
            return x / y;
        }
        static void Main()
        {
            // Input for test purposes. Change the values to see
            // exception handling behavior.
            double a = 98, b = 0;
            double result = 0;

            try
            {
                result = SafeDivision(a, b);
                Console.WriteLine("{0} divided by {1} = {2}", a, b, result);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Attempted divide by zero.");
            }
        }
    }