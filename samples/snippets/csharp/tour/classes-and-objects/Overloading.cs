namespace ClassesAndObjects
{
    using System;
    class OverloadingExample
    {
        static void F() 
        {
            Console.WriteLine("F()");
        }
        static void F(object x) 
        {
            Console.WriteLine("F(object)");
        }
        static void F(int x) 
        {
            Console.WriteLine("F(int)");
        }
        static void F(double x) 
        {
            Console.WriteLine("F(double)");
        }
        static void F<T>(T x) 
        {
            Console.WriteLine("F<T>(T)");
        }
        static void F(double x, double y) 
        {
            Console.WriteLine("F(double, double)");
        }
        public static void UsageExample()
        {
            F();            // Invokes F()
            F(1);           // Invokes F(int)
            F(1.0);         // Invokes F(double)
            F("abc");       // Invokes F<string>(string)
            F((double)1);   // Invokes F(double)
            F((object)1);   // Invokes F(object)
            F<int>(1);      // Invokes F<int>(int)
            F(1, 1);        // Invokes F(double, double)
        }
    }
    
}