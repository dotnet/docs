//<snippet1>
using System;

namespace GenericsExample1
{
    //<snippet2>
    public class Generic<T>
    {
        public T Field;
    }
    //</snippet2>

    public class GenTest
    {
        //<snippet3>
        public static void Main()
        {
            Generic<string> g = new Generic<string>();
            g.Field = "A string";
            //...
            Console.WriteLine("Generic.Field           = \"{0}\"", g.Field);
            Console.WriteLine("Generic.Field.GetType() = {0}", g.Field.GetType().FullName);
        }
        //</snippet3>

       //<snippet4>
        T Generic<T>(T arg)
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
    class Generic<T>
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
