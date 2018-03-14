using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

//<snippet1>

namespace SampleNamespace
{
    class SampleClass { }

    interface SampleInterface { }

    struct SampleStruct { }

    enum SampleEnum { a, b }

    delegate void SampleDelegate(int i);

    namespace SampleNamespace.Nested
    {
        class SampleClass2 { }
    }
}
//</snippet1>

//<snippet2>
namespace MyCompany.Proj1
{
    class MyClass
    {
    }
}

namespace MyCompany.Proj1
{
    class MyClass1
    {
    }
}
//</snippet2>

//<snippet3>
namespace SomeNameSpace
{
    public class MyClass 
    {
        static void Main() 
        {
            Nested.NestedNameSpaceClass.SayHello();
        }
    }

    // a nested namespace
    namespace Nested   
    {
        public class NestedNameSpaceClass 
        {
            public static void SayHello() 
            {
                Console.WriteLine("Hello");
            }
        }
    }
}
// Output: Hello
//</snippet3>

namespace usingstatement
{
    class usingTest
    {

        void TestMethod()
        {
        //<snippet4>
        using (Font font1 = new Font("Arial", 10.0f)) 
        {
            byte charset = font1.GdiCharSet;
        }
        //</snippet4>

        //<snippet5>    
            {
              Font font1 = new Font("Arial", 10.0f);
              try
              {
                byte charset = font1.GdiCharSet;
              }
              finally
              {
                if (font1 != null)
                  ((IDisposable)font1).Dispose();
              }
            }
        //</snippet5>

            //<snippet6>
            using (Font font3 = new Font("Arial", 10.0f),
                        font4 = new Font("Arial", 10.0f))
            {
                // Use font3 and font4.
            }
            //</snippet6>

            //<snippet7>
            Font font2 = new Font("Arial", 10.0f);
            using (font2) // not recommended
            {
                // use font2
            }
            // font2 is still in scope
            // but the method call throws an exception
            float f = font2.GetHeight(); 


            //</snippet7>
    }
}


}
