//<snippet1>
// Violates rule: DeclareTypesInNamespaces.
using System;

public class Test
{
    public override string ToString()
    {
        return "Test does not live in a namespace!";
    }
}

namespace ca1050
{
    public class Test
    {
        public override string ToString()
        {
            return "Test lives in a namespace!";
        }
    }
}
//</snippet1>


namespace ca1050
{
    //<snippet2>
    public class MainHolder
    {
        public static void Main1050()
        {
            Test t1 = new Test();
            Console.WriteLine(t1.ToString());

            ca1050.Test t2 = new ca1050.Test();
            Console.WriteLine(t2.ToString());
        }
    }
    //</snippet2>
}


