//<Snippet1>
using System;

namespace ApplicationTester
{
    public class MainHolder
    {
        public static void Main()
        {
            Test t1 = new Test();
            Console.WriteLine(t1.ToString());

            GoodSpace.Test t2 = new GoodSpace.Test();
            Console.WriteLine(t2.ToString());
        }
    }
}
//</Snippet1>
namespace GoodSpace
{
    public class Test
    {
        public override string ToString()
        {
            return "Test lives in a namespace!";
        }
    }
}

namespace ApplicationTester
{
    public class Test
    {
    }
}