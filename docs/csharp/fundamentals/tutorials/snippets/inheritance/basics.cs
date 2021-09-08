using System;

namespace Basic
{
    // <Snippet1>
    public class A
    {
        public void Method1()
        {
            // Method implementation.
        }
    }

    public class B : A
    { }

    public class Example
    {
        public static void Main()
        {
            B b = new B();
            b.Method1();
        }
    }
    // </Snippet1>
}
