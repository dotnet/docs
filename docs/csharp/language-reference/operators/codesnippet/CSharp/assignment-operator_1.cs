    class Assignment
    {
        static void Main()
        {
            double x;
            int i;
            i = 5; // int to int assignment
            x = i; // implicit conversion from int to double
            i = (int)x; // needs cast
            Console.WriteLine("i is {0}, x is {1}", i, x);
            object obj = i;
            Console.WriteLine("boxed value = {0}, type is {1}",
                      obj, obj.GetType());
            i = (int)obj;
            Console.WriteLine("unboxed: {0}", i);
        }
    }
    /*
    Output:
    i is 5, x is 5
    boxed value = 5, type is System.Int32
    unboxed: 5
     */