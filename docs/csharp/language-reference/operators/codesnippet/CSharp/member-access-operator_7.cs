    namespace Example2
    {
        class Console
        {
            public static void WriteLine(string s){}
        }
    }
    namespace Example1
    {
        using System;
        using Example2;
        class C
        {
            void M()
            {                
                // Console.WriteLine("hello");   // Compiler error. Ambiguous reference.
                System.Console.WriteLine("hello"); //OK
                Example2.Console.WriteLine("hello"); //OK
            }
        }
    }