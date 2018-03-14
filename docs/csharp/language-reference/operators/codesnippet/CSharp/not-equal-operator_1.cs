
    class InequalityTest
    {
        static void Main()
        {
            // Numeric inequality:
            Console.WriteLine((2 + 2) != 4);

            // Reference equality: two objects, same boxed value
            object s = 1;
            object t = 1;
            Console.WriteLine(s != t);

            // String equality: same string value, same string objects
            string a = "hello";
            string b = "hello";

            // compare string values
            Console.WriteLine(a != b);

            // compare string references
            Console.WriteLine((object)a != (object)b);
        }
    }
    /*
    Output:
    False
    True
    False
    False
    */