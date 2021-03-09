using System;

TestClass.TestMethod();
TestNamespace.TestClass.TestMethod();

public class TestClass
{
    public static void TestMethod()
    {
        Console.WriteLine("Hello World!");
    }

}

namespace TestNamespace
{
    class TestClass
    {
        public static void TestMethod()
        {
            Console.WriteLine("Hello World from TestNamespace!");
        }
    }
}
