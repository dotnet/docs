//-----------------------------------------------------------------------------
namespace Wrap1
{
    //<Snippet1>
    // compile with: /doc:DocFileName.xml 

    /// text for class TestClass
    public class TestClass
    {
        // Single parameter.
        /// <param name="Int1">Used to indicate status.</param>
        public static void DoWork(int Int1)
        {
        }

        // Multiple parameters.
        /// <param name="Int1">Used to indicate status.</param>
        /// <param name="Float1">Used to specify context.</param>
        public static void DoWork(int Int1, float Float1)
        {
        }

        /// text for Main
        static void Main()
        {
        }
    }
    //</Snippet1>
}


//-----------------------------------------------------------------------------
namespace Wrap2
{
    //<Snippet2>
    // compile with: /doc:DocFileName.xml 

    /// text for class TestClass
    public class TestClass
    {
        /// <summary><c>DoWork</c> is a method in the <c>TestClass</c> class.
        /// </summary>
        public static void DoWork(int Int1)
        {
        }

        /// text for Main
        static void Main()
        {
        }
    }
    //</Snippet2>
}


//-----------------------------------------------------------------------------
//<Snippet3>
// Save this file as CRefTest.cs
// Compile with: csc CRefTest.cs /doc:Results.xml 

namespace TestNamespace
{
    /// <summary>
    /// TestClass contains several cref examples.
    /// </summary>
    public class TestClass
    {
        /// <summary>
        /// This sample shows how to specify the <see cref="TestClass"/> constructor as a cref attribute. 
        /// </summary>
        public TestClass()
        { }

        /// <summary>
        /// This sample shows how to specify the <see cref="TestClass(int)"/> constructor as a cref attribute. 
        /// </summary>
        public TestClass(int value)
        { }

        /// <summary>
        /// The GetZero method.
        /// </summary>
        /// <example> 
        /// This sample shows how to call the <see cref="GetZero"/> method.
        /// <code>
        /// class TestClass 
        /// {
        ///     static int Main() 
        ///     {
        ///         return GetZero();
        ///     }
        /// }
        /// </code>
        /// </example>
        public static int GetZero()
        {
            return 0;
        }

        /// <summary>
        /// The GetGenericValue method.
        /// </summary>
        /// <remarks> 
        /// This sample shows how to specify the <see cref="GetGenericValue"/> method as a cref attribute.
        /// </remarks>

        public static T GetGenericValue<T>(T para)
        {
            return para;
        }
    }

    /// <summary>
    /// GenericClass.
    /// </summary>
    /// <remarks> 
    /// This example shows how to specify the <see cref="GenericClass{T}"/> type as a cref attribute.
    /// </remarks>
    class GenericClass<T>
    {
        // Fields and members.
    }

    class Program
    {
        static int Main()
        {
            return TestClass.GetZero();
        }
    }
}
//</Snippet3>



namespace Wrap3
{
    // compile with: /doc:DocFileName.xml 

    /// text for class TestClass
    public class TestClass
    {
        /// <summary>
        /// The GetZero method.
        /// </summary>
        /// <example> This sample shows how to call the <see cref="TestClass.GetZero"/> method.
        /// <code>
        /// class TestClass 
        /// {
        ///     static int Main() 
        ///     {
        ///         return GetZero();
        ///     }
        /// }
        /// </code>
        /// </example>
        public static int GetZero()
        {
            return 0;
        }

        /// text for Main
        static void Main()
        {
        }
    }
}


//-----------------------------------------------------------------------------
namespace Wrap4
{
    //<Snippet4>
    // compile with: /doc:DocFileName.xml 

    /// Comment for class
    public class EClass : System.Exception
    {
        // class definition...
    }

    /// Comment for class
    class TestClass
    {
        /// <exception cref="System.Exception">Thrown when...</exception>
        public void DoSomething()
        {
            try
            {
            }
            catch (EClass)
            {
            }
        }
    }
    //</Snippet4>
}


//-----------------------------------------------------------------------------
namespace Wrap5
{
    //<Snippet5>
    // compile with: /doc:DocFileName.xml 

    /// <include file='xml_include_tag.doc' path='MyDocs/MyMembers[@name="test"]/*' />
    class Test
    {
        static void Main()
        {
        }
    }

    /// <include file='xml_include_tag.doc' path='MyDocs/MyMembers[@name="test2"]/*' />
    class Test2
    {
        public void Test()
        {
        }
    }
    //</Snippet5>
    // Following line is a trick to try to fix a problem in the msdn build.
    /**/
}


//-----------------------------------------------------------------------------
namespace Wrap6
{
    //<Snippet6>
    // compile with: /doc:DocFileName.xml 

    /// text for class TestClass
    public class TestClass
    {
        /// <summary>Here is an example of a bulleted list:
        /// <list type="bullet">
        /// <item>
        /// <description>Item 1.</description>
        /// </item>
        /// <item>
        /// <description>Item 2.</description>
        /// </item>
        /// </list>
        /// </summary>
        static void Main()
        {
        }
    }
    //</Snippet6>
}


//-----------------------------------------------------------------------------
namespace Wrap7
{
    //<Snippet7>
    // compile with: /doc:DocFileName.xml 

    /// text for class TestClass
    public class TestClass
    {
        /// <summary>DoWork is a method in the TestClass class.  
        /// The <paramref name="Int1"/> parameter takes a number.
        /// </summary>
        public static void DoWork(int Int1)
        {
        }

        /// text for Main
        static void Main()
        {
        }
    }
    //</Snippet7>
}


//-----------------------------------------------------------------------------
namespace Wrap8
{
    //<Snippet8>
    // compile with: /doc:DocFileName.xml 

    class TestClass
    {
        /// <permission cref="System.Security.PermissionSet">Everyone can access this method.</permission>
        public static void Test()
        {
        }

        static void Main()
        {
        }
    }
    //</Snippet8>
}


//-----------------------------------------------------------------------------
namespace Wrap9
{
    //<Snippet9>
    // compile with: /doc:DocFileName.xml 

    /// <summary>
    /// You may have some primary information about this class.
    /// </summary>
    /// <remarks>
    /// You may have some additional information about this class.
    /// </remarks>
    public class TestClass
    {
        /// text for Main
        static void Main()
        {
        }
    }
    //</Snippet9>
}


//-----------------------------------------------------------------------------
namespace Wrap10
{
    //<Snippet10>
    // compile with: /doc:DocFileName.xml 

    /// text for class TestClass
    public class TestClass
    {
        /// <returns>Returns zero.</returns>
        public static int GetZero()
        {
            return 0;
        }

        /// text for Main
        static void Main()
        {
        }
    }
    //</Snippet10>
}


//-----------------------------------------------------------------------------
namespace Wrap11
{
    //<Snippet11>
    // compile with: /doc:DocFileName.xml 

    // the following cref shows how to specify the reference, such that,
    // the compiler will resolve the reference
    /// <summary cref="C{T}">
    /// </summary>
    class A { }

    // the following cref shows another way to specify the reference, 
    // such that, the compiler will resolve the reference
    // <summary cref="C &lt; T &gt;">

    // the following cref shows how to hard-code the reference
    /// <summary cref="T:C`1">
    /// </summary>
    class B { }

    /// <summary cref="A">
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class C<T> { }
    //</Snippet11>
}


//-----------------------------------------------------------------------------
namespace Wrap12
{
    //<Snippet12>
    // compile with: /doc:DocFileName.xml 

    /// text for class TestClass
    public class TestClass
    {
        /// <summary>DoWork is a method in the TestClass class.
        /// <para>Here's how you could make a second paragraph in a description. <see cref="System.Console.WriteLine(System.String)"/> for information about output statements.</para>
        /// <seealso cref="TestClass.Main"/>
        /// </summary>
        public static void DoWork(int Int1)
        {
        }

        /// text for Main
        static void Main()
        {
        }
    }
    //</Snippet12>
}


//-----------------------------------------------------------------------------
namespace Wrap13
{
    //<Snippet13>
    // compile with: /doc:DocFileName.xml 

    /// comment for class
    public class TestClass
    {
        /// <summary>
        /// Creates a new array of arbitrary type <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">The element type of the array</typeparam>
        public static T[] mkArray<T>(int n)
        {
            return new T[n];
        }
    }
    //</Snippet13>
}


//-----------------------------------------------------------------------------
namespace Wrap14
{
    //<Snippet14>
    // compile with: /doc:DocFileName.xml 

    /// text for class Employee
    public class Employee
    {
        private string _name;

        /// <summary>The Name property represents the employee's name.</summary>
        /// <value>The Name property gets/sets the value of the string field, _name.</value>

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
    }

    /// text for class MainClass
    public class MainClass
    {
        /// text for Main
        static void Main()
        {
        }
    }
    //</Snippet14>
}


//-----------------------------------------------------------------------------
namespace Wrap15
{
    //<Snippet15>
    // If compiling from the command line, compile with: /doc:YourFileName.xml

    /// <summary>
    /// Class level summary documentation goes here.</summary>
    /// <remarks>
    /// Longer comments can be associated with a type or member through
    /// the remarks tag.</remarks>
    public class TestClass : TestInterface
    {
        /// <summary>
        /// Store for the name property.</summary>
        private string _name = null;

        /// <summary>
        /// The class constructor. </summary>
        public TestClass()
        {
            // TODO: Add Constructor Logic here.
        }

        /// <summary>
        /// Name property. </summary>
        /// <value>
        /// A value tag is used to describe the property value.</value>
        public string Name
        {
            get
            {
                if (_name == null)
                {
                    throw new System.Exception("Name is null");
                }
                return _name;
            }
        }

        /// <summary>
        /// Description for SomeMethod.</summary>
        /// <param name="s"> Parameter description for s goes here.</param>
        /// <seealso cref="System.String">
        /// You can use the cref attribute on any tag to reference a type or member 
        /// and the compiler will check that the reference exists. </seealso>
        public void SomeMethod(string s)
        {
        }

        /// <summary>
        /// Some other method. </summary>
        /// <returns>
        /// Return results are described through the returns tag.</returns>
        /// <seealso cref="SomeMethod(string)">
        /// Notice the use of the cref attribute to reference a specific method. </seealso>
        public int SomeOtherMethod()
        {
            return 0;
        }

        public int InterfaceMethod(int n)
        {
            return n * n;
        }

        /// <summary>
        /// The entry point for the application.
        /// </summary>
        /// <param name="args"> A list of command line arguments.</param>
        static int Main(System.String[] args)
        {
            // TODO: Add code to start application here.
            return 0;
        }
    }

    /// <summary>
    /// Documentation that describes the interface goes here.
    /// </summary>
    /// <remarks>
    /// Details about the interface go here.
    /// </remarks>
    interface TestInterface
    {
        /// <summary>
        /// Documentation that describes the method goes here.
        /// </summary>
        /// <param name="n">
        /// Parameter n requires an integer argument.
        /// </param>
        /// <returns>
        /// The method returns an integer.
        /// </returns>
        int InterfaceMethod(int n);
    }
    //</Snippet15>
}
