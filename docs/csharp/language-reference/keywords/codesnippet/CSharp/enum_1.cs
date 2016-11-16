
    public class EnumTest
    {
        enum Days { Sun, Mon, Tue, Wed, Thu, Fri, Sat };

        static void Main()
        {
            int x = (int)Days.Sun;
            int y = (int)Days.Fri;
            Console.WriteLine("Sun = {0}", x);
            Console.WriteLine("Fri = {0}", y);
        }
    }
    /* Output:
       Sun = 0
       Fri = 5
    */