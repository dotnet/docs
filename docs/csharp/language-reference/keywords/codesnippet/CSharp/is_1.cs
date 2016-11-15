    class Class1 {}
    class Class2 {}
    class Class3 : Class2 { }

    class IsTest
    {
        static void Test(object o)
        {
            Class1 a;
            Class2 b;

            if (o is Class1)
            {
                Console.WriteLine("o is Class1");
                a = (Class1)o;
                // Do something with "a."
            }
            else if (o is Class2)
            {
                Console.WriteLine("o is Class2");
                b = (Class2)o;
                // Do something with "b."
            }
            
            else
            {
                Console.WriteLine("o is neither Class1 nor Class2.");
            }
        }
        static void Main()
        {
            Class1 c1 = new Class1();
            Class2 c2 = new Class2();
            Class3 c3 = new Class3();
            Test(c1);
            Test(c2);
            Test(c3);
            Test("a string");
        }
    }
    /*
    Output:
    o is Class1
    o is Class2
    o is Class2
    o is neither Class1 nor Class2.
    */