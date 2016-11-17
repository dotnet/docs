    public class TestDecimalFormat
    {
        static void Main()
        {
            decimal x = 0.999m;
            decimal y = 9999999999999999999999999999m;
            Console.WriteLine("My amount = {0:C}", x);
            Console.WriteLine("Your amount = {0:C}", y);
        }
    }
    /* Output:
        My amount = $1.00
        Your amount = $9,999,999,999,999,999,999,999,999,999.00
    */