    class TestBoxing
    {
        static void Main()
        {
            int i = 123;

            // Boxing copies the value of i into object o.
            object o = i;  

            // Change the value of i.
            i = 456;  

            // The change in i doesn't affect the value stored in o.
            System.Console.WriteLine("The value-type value = {0}", i);
            System.Console.WriteLine("The object-type value = {0}", o);
        }
    }
    /* Output:
        The value-type value = 456
        The object-type value = 123
    */
