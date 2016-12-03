    public class EnumTest2
    {
        enum Range : long { Max = 2147483648L, Min = 255L };
        static void Main()
        {
            long x = (long)Range.Max;
            long y = (long)Range.Min;
            Console.WriteLine("Max = {0}", x);
            Console.WriteLine("Min = {0}", y);
        }
    }
    /* Output:
       Max = 2147483648
       Min = 255
    */