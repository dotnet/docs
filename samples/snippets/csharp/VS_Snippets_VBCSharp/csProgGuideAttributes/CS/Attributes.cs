
//<Snippet18>
#define DEBUG
//</Snippet18>

//<Snippet50>
using System.Runtime.InteropServices;
//</Snippet50>

//<Snippet14>
using Conditional = System.Diagnostics.ConditionalAttribute;
//</Snippet14>

//<snippet30>
using System;
using System.Reflection;
[assembly: AssemblyTitleAttribute("Production assembly 4")]
[module: CLSCompliant(true)]
//</snippet30>

//<Snippet21>
[assembly: System.CLSCompliant(true)]
//</Snippet21>

namespace CsCsrefProgrammingAttributes
{
    //---------------------------------------------------------------------------
    namespace WrapAttributes
    {
        //<Snippet1>
        [System.Serializable]
        public class SampleClass
        {
            // Objects of this type can be serialized.
        }
        //</Snippet1>
    }


    //---------------------------------------------------------------------------
    class WrapCustomAttributes
    {
        //<Snippet2>
        [System.AttributeUsage(System.AttributeTargets.Class |
                               System.AttributeTargets.Struct)
        ]
        public class Author : System.Attribute
        {
            private string name;
            public double version;

            public Author(string name)
            {
                this.name = name;
                version = 1.0;
            }
        }
        //</Snippet2>

        //<Snippet3>
        //<Snippet9>
        [Author("P. Ackerman", version = 1.1)]
        class SampleClass
        //</Snippet9>
        {
            // P. Ackerman's code goes here...
        }
        //</Snippet3>

        static void Test()
        {
            //<Snippet10>
            Author anonymousAuthorObject = new Author("P. Ackerman");
            anonymousAuthorObject.version = 1.1;
            //</Snippet10>
        }

    }


    //---------------------------------------------------------------------------
    namespace WrapCustomAttributes2
    {
        //<Snippet4>
        [System.AttributeUsage(System.AttributeTargets.Class |
                               System.AttributeTargets.Struct,
                               AllowMultiple = true)  // multiuse attribute
        ]
        public class Author : System.Attribute
        //</Snippet4>
        {
            private string name;
            public double version;

            public Author(string name)
            {
                this.name = name;
                version = 1.0;
            }
        }

        //<Snippet5>
        [Author("P. Ackerman", version = 1.1)]
        [Author("R. Koch", version = 1.2)]
        class SampleClass
        {
            // P. Ackerman's code goes here...
            // R. Koch's code goes here...
        }
        //</Snippet5>
    }


    //---------------------------------------------------------------------------
    class WrapDisambiguating
    {
        //<Snippet6>
        public class SomeAttr : System.Attribute { }

        [SomeAttr]
        int Method()
        {
            return 0;
        }
        //</Snippet6>


        //<Snippet7>
        // default: applies to method
        [SomeAttr]
        int Method1() { return 0; }

        // applies to method
        [method: SomeAttr]
        int Method2() { return 0; }

        // applies to return value
        [return: SomeAttr]
        int Method3() { return 0; }
        //</Snippet7>


        //<Snippet8>
        [Guid("12345678-1234-1234-1234-123456789abc"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        interface ISampleInterface
        {
            [DispId(17)]  // set the DISPID of the method
            [return: MarshalAs(UnmanagedType.Interface)]  // set the marshaling on the return type
            object DoWork();
        }
        //</Snippet8>
    }


    //---------------------------------------------------------------------------

    //<Snippet11>
    // Multiuse attribute.
    [System.AttributeUsage(System.AttributeTargets.Class |
                           System.AttributeTargets.Struct,
                           AllowMultiple = true)  // Multiuse attribute.
    ]
    public class Author : System.Attribute
    {
        string name;
        public double version;

        public Author(string name)
        {
            this.name = name;

            // Default value.
            version = 1.0;
        }

        public string GetName()
        {
            return name;
        }
    }

    // Class with the Author attribute.
    [Author("P. Ackerman")]
    public class FirstClass
    {
        // ...
    }

    // Class without the Author attribute.
    public class SecondClass
    {
        // ...
    }

    // Class with multiple Author attributes.
    [Author("P. Ackerman"), Author("R. Koch", version = 2.0)]
    public class ThirdClass
    {
        // ...
    }

    class TestAuthorAttribute
    {
        static void Test()
        {
            PrintAuthorInfo(typeof(FirstClass));
            PrintAuthorInfo(typeof(SecondClass));
            PrintAuthorInfo(typeof(ThirdClass));
        }

        private static void PrintAuthorInfo(System.Type t)
        {
            System.Console.WriteLine("Author information for {0}", t);

            // Using reflection.
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(t);  // Reflection.

            // Displaying output.
            foreach (System.Attribute attr in attrs)
            {
                if (attr is Author)
                {
                    Author a = (Author)attr;
                    System.Console.WriteLine("   {0}, version {1:f}", a.GetName(), a.version);
                }
            }
        }
    }
    /* Output:
        Author information for FirstClass
           P. Ackerman, version 1.00
        Author information for SecondClass
        Author information for ThirdClass
           R. Koch, version 2.00
           P. Ackerman, version 1.00
    */
    //</Snippet11>



    //---------------------------------------------------------------------------
    namespace WrapUnion
    {
        //<Snippet12>
	// Add a using directive for System.Runtime.InteropServices.

        [System.Runtime.InteropServices.StructLayout(LayoutKind.Explicit)]
        struct TestUnion
        {
            [System.Runtime.InteropServices.FieldOffset(0)]
            public int i;

            [System.Runtime.InteropServices.FieldOffset(0)]
            public double d;

            [System.Runtime.InteropServices.FieldOffset(0)]
            public char c;

            [System.Runtime.InteropServices.FieldOffset(0)]
            public byte b;
        }
        //</Snippet12>


        //<Snippet13>
	// Add a using directive for System.Runtime.InteropServices.

        [System.Runtime.InteropServices.StructLayout(LayoutKind.Explicit)]
        struct TestExplicit
        {
            [System.Runtime.InteropServices.FieldOffset(0)]
            public long lg;

            [System.Runtime.InteropServices.FieldOffset(0)]
            public int i1;

            [System.Runtime.InteropServices.FieldOffset(4)]
            public int i2;

            [System.Runtime.InteropServices.FieldOffset(8)]
            public double d;

            [System.Runtime.InteropServices.FieldOffset(12)]
            public char c;

            [System.Runtime.InteropServices.FieldOffset(14)]
            public byte b;
        }
        //</Snippet13>
    }


    //---------------------------------------------------------------------------
    class WrapConditional
    {
        //<Snippet15>
        [Conditional("A"), Conditional("B")]
        static void DoIfAorB()
        {
            // ...
        }
        //</Snippet15>


        //<Snippet16>
        [Conditional("A")]
        static void DoIfA()
        {
            DoIfAandB();
        }

        [Conditional("B")]
        static void DoIfAandB()
        {
            // Code to execute when both A and B are defined...
        }
        //</Snippet16>


        //<Snippet17>
        [Conditional("DEBUG")]
        public class Documentation : System.Attribute
        {
            string text;

            public Documentation(string text)
            {
                this.text = text;
            }
        }

        class SampleClass
        {
            // This attribute will only be included if DEBUG is defined.
            [Documentation("This method displays an integer.")]
            static void DoWork(int i)
            {
                System.Console.WriteLine(i.ToString());
            }
        }
        //</Snippet17>


        //<Snippet19>
        class Trace
        {
            [Conditional("DEBUG")]
            public static void Msg(string msg)
            {
                System.Console.WriteLine(msg);
            }
        }

        class TestTrace
        {
            static void Test()
            {
                Trace.Msg("Now in Main.");
                A();
                System.Console.WriteLine("Done.");
            }

            private static void A()
            {
                Trace.Msg("Now in A.");
                B();
            }

            private static void B()
            {
                Trace.Msg("Now in B.");
            }
        }
        //</Snippet19>
    }


    //---------------------------------------------------------------------------
    namespace WrapObsolete
    {
        //<Snippet20>
        class TestObsolete
        {
            [System.Obsolete("Don't use OldWay; use NewWay instead", true)]
            static void OldWay()
            {
                System.Console.WriteLine("Hello, World!");
            }

            static void NewWay()
            {
                System.Console.WriteLine("Hello, Brave New World!");
            }

            static void Test()
            {
                // Compilation error:
                // OldWay();

                // No error:
                NewWay();
            }
        }
        //</Snippet20>
    }


    //---------------------------------------------------------------------------
    namespace WrapAttributeUsage
    {
        //<Snippet22>
        [System.AttributeUsage(System.AttributeTargets.All, Inherited = true)]
        class Attribute1 : System.Attribute { }

        [System.AttributeUsage(System.AttributeTargets.All, Inherited = false)]
        class Attribute2 : System.Attribute { }

        //Inherited not specified, it will default to true
        class Attribute3 : System.Attribute { }

        [Attribute1]
        [Attribute2]
        [Attribute3]
        class BaseClass { }

        class DerivedClass : BaseClass { }

        class TestAttributeUsage
        {
            static void Test()
            {
                // I get Attributes 1, 2, and 3.
                BaseClass b = new BaseClass();

                // I inherit Attributes 1 and 3, but not 2.
                DerivedClass d = new DerivedClass();

                System.Console.WriteLine("Attributes on Base Class:");
                object[] attrs = b.GetType().GetCustomAttributes(true);

                foreach (System.Attribute attr in attrs)
                {
                    System.Console.WriteLine(attr.ToString());
                }
                System.Console.WriteLine();

                System.Console.WriteLine("Attributes on Derived Class:");
                attrs = d.GetType().GetCustomAttributes(true);

                foreach (System.Attribute attr in attrs)
                {
                    System.Console.WriteLine(attr.ToString());
                }
            }
        }
        //</Snippet22>
    }


    //---------------------------------------------------------------------------
    class WrapUsingAttributes
    {
        //<Snippet23>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        extern static void SampleMethod();
        //</Snippet23>

        //<Snippet24>
        void MethodA([In][Out] ref double x) { }
        void MethodB([Out][In] ref double x) { }
        void MethodC([In, Out] ref double x) { }
        //</Snippet24>

        //<Snippet25>
        [Conditional("DEBUG"), Conditional("TEST1")]
        void TraceMethod()
        {
            // ...
        }
        //</Snippet25>    
    }

}
namespace WrapObsolete
{
    //<Snippet34>
    [System.Obsolete("use class B")]
    class A
    {
        public void Method() { }
    }
    class B
    {
        [System.Obsolete("use NewMethod", true)]
        public void OldMethod() { }
        public void NewMethod() { }
    }
    //</Snippet34>
    class Test
    {
        void SampleMethod()
        {
            //<Snippet35>
            // Generates 2 warnings:
            // A a = new A();

            // Generate no errors or warnings:
            B b = new B();
            b.NewMethod();

            // Generates an error, terminating compilation:
            // b.OldMethod();
            //</Snippet35>
        }
    }

}