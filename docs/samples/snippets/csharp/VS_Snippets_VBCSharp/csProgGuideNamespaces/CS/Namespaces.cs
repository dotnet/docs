using System;

//<Snippet14>
using Alias = System;
//</Snippet14>

//<Snippet16>
using M = System.Messaging;
//</Snippet16>


//-----------------------------------------------------------------------------
//<Snippet5>
using colAlias = System.Collections;
namespace System
{
    class TestClass
    {
        static void Main()
        {
            // Searching the alias:
            colAlias::Hashtable test = new colAlias::Hashtable();

            // Add items to the table.
            test.Add("A", "1");
            test.Add("B", "2");
            test.Add("C", "3");

            foreach (string name in test.Keys)
            {
                // Searching the global namespace:
                global::System.Console.WriteLine(name + " " + test[name]);
            }
        }
    }
}
//</Snippet5>


//-----------------------------------------------------------------------------
//<Snippet1>
class TestApp
{
    // Define a new class called 'System' to cause problems.
    public class System { }

    // Define a constant called 'Console' to cause more problems.
    const int Console = 7;
    const int number = 66;

    static void Main()
    {
        // The following line causes an error. It accesses TestApp.Console,
        // which is a constant.
        //Console.WriteLine(number);
    }
}
//</Snippet1>


//-----------------------------------------------------------------------------
class TestApp2
{
    const int number = 66;

    static void Main()
    {
        //<Snippet2>
        // The following line causes an error. It accesses TestApp.System,
        // which does not have a Console.WriteLine method.
        System.Console.WriteLine(number);
        //</Snippet2>

        //<Snippet3>
        // OK
        global::System.Console.WriteLine(number);
        //</Snippet3>
    }
}


//-----------------------------------------------------------------------------
//<Snippet4>
class TestClass : global::TestApp
//</Snippet4>
{
}


//-----------------------------------------------------------------------------
namespace WrapSampleNamespace
{
    //<Snippet6>
    namespace SampleNamespace
    {
        class SampleClass
        {
            public void SampleMethod()
            {
                System.Console.WriteLine(
                  "SampleMethod inside SampleNamespace");
            }
        }
    }
    //</Snippet6>
}


//-----------------------------------------------------------------------------
//<Snippet8>
namespace SampleNamespace
{
    class SampleClass
    {
        public void SampleMethod()
        {
            System.Console.WriteLine(
              "SampleMethod inside SampleNamespace");
        }
    }

    // Create a nested namespace, and define another class.
    namespace NestedNamespace
    {
        class SampleClass
        {
            public void SampleMethod()
            {
                System.Console.WriteLine(
                  "SampleMethod inside NestedNamespace");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Displays "SampleMethod inside SampleNamespace."
            SampleClass outer = new SampleClass();
            outer.SampleMethod();

            // Displays "SampleMethod inside SampleNamespace."
            SampleNamespace.SampleClass outer2 = new SampleNamespace.SampleClass();
            outer2.SampleMethod();

            // Displays "SampleMethod inside NestedNamespace."
            NestedNamespace.SampleClass inner = new NestedNamespace.SampleClass();
            inner.SampleMethod();
        }
    }
}
//</Snippet8>


//-----------------------------------------------------------------------------
//<Snippet9>
namespace N1     // N1
{
    class C1      // N1.C1
    {
        class C2   // N1.C1.C2
        {
        }
    }
    namespace N2  // N1.N2
    {
        class C2   // N1.N2.C2
        {
        }
    }
}
//</Snippet9>


//-----------------------------------------------------------------------------
//<Snippet10>
namespace N1.N2
{
    class C3   // N1.N2.C3
    {
    }
}
//</Snippet10>


//-----------------------------------------------------------------------------
//<Snippet15>
namespace Library
{
    public class C : Alias.Exception { }
}
//</Snippet15>


//-----------------------------------------------------------------------------
class Wrap17
{
    //<Snippet17>
    class TestClass
    {
        public void TestMethod(object M)
        {
            // To reference the alias M, use M::AccessControlList
            // instead of M.AccessControlList. 
            M::AccessControlList test = M as M::AccessControlList;
        }
    }
    //</Snippet17>
}