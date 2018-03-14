    class GetTypeTest
    {
        static void Main()
        {
            int radius = 3;
            Console.WriteLine("Area = {0}", radius * radius * Math.PI);
            Console.WriteLine("The type is {0}",
                              (radius * radius * Math.PI).GetType()
            );
        }
    }
    /*
    Output:
    Area = 28.2743338823081
    The type is System.Double
    */