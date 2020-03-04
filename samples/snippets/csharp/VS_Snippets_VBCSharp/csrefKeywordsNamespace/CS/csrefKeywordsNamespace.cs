using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

//<snippet1>
namespace SampleNamespace
{
    class SampleClass { }

    interface ISampleInterface { }

    struct SampleStruct { }

    enum SampleEnum { a, b }

    delegate void SampleDelegate(int i);

    namespace Nested
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
        void UpdatedTestMethod()
        {
            // <SnippetModernUsing>
            using var font1 = new Font("Arial", 10.0f);
            byte charset = font1.GdiCharSet;
            // </SnippetModernUsing>

            // <SnippetMultipleUsing>
            using Font font3 = new Font("Arial", 10.0f), 
                font4 = new Font("Arial", 10.0f);
            // Use font3 and font4.
            // </SnippetMultipleUsing>
        }
        void TestMethod()
        {
        //<snippet4>
        using (var font1 = new Font("Arial", 10.0f)) 
        {
            byte charset = font1.GdiCharSet;
        }
        //</snippet4>

        //<snippet5>    
            {
              var font1 = new Font("Arial", 10.0f);
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
            var font2 = new Font("Arial", 10.0f);
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
