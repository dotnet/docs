//<snippet1>
using System;

namespace GenericsExample1
{
    //<snippet2>
    public class SimpleGenericClass<T>
    {
        public T Field;
    }
    //</snippet2>

    public class GenTest
    {
        //<snippet3>
        public static void Main()
        {
            SimpleGenericClass<string> g = new SimpleGenericClass<string>();
            g.Field = "A string";
            //...
            Console.WriteLine($"SimpleGenericClass.Field           = \"{g.Field}\"");
            Console.WriteLine("SimpleGenericClass.Field.GetType() = {0}", g.Field.GetType().FullName);
        }
        //</snippet3>

       //<snippet4>
        T MyGenericMethod<T>(T arg)
        {
            T temp = arg;
            //...
            return temp;
        }
        //</snippet4>
    }
}  // GenericsExample1

namespace GenericsExample2
{
    //<snippet5>
    class A
    {
        T G<T>(T arg)
        {
            T temp = arg;
            //...
            return temp;
        }
    }
    class MyGenericClass<T>
    {
        T M(T arg)
        {
            T temp = arg;
            //...
            return temp;
        }
    }
   //</snippet5>
} // GenericsExample2
//</snippet1>
