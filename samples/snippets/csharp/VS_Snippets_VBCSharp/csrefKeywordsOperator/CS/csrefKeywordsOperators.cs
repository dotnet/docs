using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeywordsUberProject
{
    //<snippet1>
    
    class csrefKeywordsOperators
    {
        class Base
        {
            public override string  ToString()
            {
 	             return "Base";
            }
        }
        class Derived : Base 
        { }

        class Program
        {
            static void Main()
            {

                Derived d = new Derived();

                Base b = d as Base;
                if (b != null)
                {
                    Console.WriteLine(b.ToString());
                }

            }
        }
    }
    //</snippet1>

    //<snippet2>
    class ClassA { }
    class ClassB { }

    class MainClass
    {
        static void Main()
        {
            object[] objArray = new object[6];
            objArray[0] = new ClassA();
            objArray[1] = new ClassB();
            objArray[2] = "hello";
            objArray[3] = 123;
            objArray[4] = 123.4;
            objArray[5] = null;

            for (int i = 0; i < objArray.Length; ++i)
            {
                string s = objArray[i] as string;
                Console.Write("{0}:", i);
                if (s != null)
                {
                    Console.WriteLine("'" + s + "'");
                }
                else
                {
                    Console.WriteLine("not a string");
                }
            }
        }
    }
    /*
    Output:
    0:not a string
    1:not a string
    2:'hello'
    3:not a string
    4:not a string
    5:not a string
    */
    //</snippet2>

    //<snippet3>
    
    class TestClass
    {
        static void Main() 
        {
            bool a = false;
            Console.WriteLine( a ? "yes" : "no" );
        }
    }
    // Output: no

    //</snippet3>

    //<snippet4>
    class Class1 {}
    class Class2 {}
    class Class3 : Class2 { }

    class IsTest
    {
        static void Test(object o)
        {
            Class1 a;
            Class2 b;

            if (o is Class1)
            {
                Console.WriteLine("o is Class1");
                a = (Class1)o;
                // Do something with "a."
            }
            else if (o is Class2)
            {
                Console.WriteLine("o is Class2");
                b = (Class2)o;
                // Do something with "b."
            }
            
            else
            {
                Console.WriteLine("o is neither Class1 nor Class2.");
            }
        }
        static void Main()
        {
            Class1 c1 = new Class1();
            Class2 c2 = new Class2();
            Class3 c3 = new Class3();
            Test(c1);
            Test(c2);
            Test(c3);
            Test("a string");
        }
    }
    /*
    Output:
    o is Class1
    o is Class2
    o is Class2
    o is neither Class1 nor Class2.
    */
    //</snippet4>

    //<snippet5>
    class ItemFactory<T> where T : new()
    {
        public T GetNewItem()
        {
            return new T();
        }
    }

   //</snippet5>

    //<snippet6>
    public class ItemFactory2<T>
        where T : IComparable, new()
    {
    }

    //</snippet6>

    //<snippet7>
    struct SampleStruct
    {
       public int x;
       public int y;

       public SampleStruct(int x, int y)
       {
          this.x = x;
          this.y = y;
       }
    }

    class SampleClass
    {
       public string name;
       public int id;

       public SampleClass() {}

       public SampleClass(int id, string name)
       {
          this.id = id;
          this.name = name;
       }
    }

    class ProgramClass
    {
       static void Main()
       {
          // Create objects using default constructors:
          SampleStruct Location1 = new SampleStruct();
          SampleClass Employee1 = new SampleClass();

          // Display values:
          Console.WriteLine("Default values:");
          Console.WriteLine("   Struct members: {0}, {1}",
                 Location1.x, Location1.y);
          Console.WriteLine("   Class members: {0}, {1}",
                 Employee1.name, Employee1.id);

          // Create objects using parameterized constructors:
          SampleStruct Location2 = new SampleStruct(10, 20);
          SampleClass Employee2 = new SampleClass(1234, "Cristina Potra");

          // Display values:
          Console.WriteLine("Assigned values:");
          Console.WriteLine("   Struct members: {0}, {1}",
                 Location2.x, Location2.y);
          Console.WriteLine("   Class members: {0}, {1}",
                 Employee2.name, Employee2.id);
       }
    }
    /*
    Output:
    Default values:
       Struct members: 0, 0
       Class members: , 0
    Assigned values:
       Struct members: 10, 20
       Class members: Cristina Potra, 1234
    */
    //</snippet7>

    //<snippet8>
    public class BaseC
    {
        public int x;
        public void Invoke() { }
    }
    public class DerivedC : BaseC
    {
        new public void Invoke() { }
    }
    //</snippet8>

    namespace newModifier //to allow resuse of BaseC and DerivedC
    {
        //<snippet9>
        public class BaseC
        {
            public static int x = 55;
            public static int y = 22;
        }

        public class DerivedC : BaseC
        {
            // Hide field 'x'.
            new public static int x = 100;

            static void Main()
            {
                // Display the new value of x:
                Console.WriteLine(x);

                // Display the hidden value of x:
                Console.WriteLine(BaseC.x);

                // Display the unhidden member y:
                Console.WriteLine(y);
            }
        }
        /*
        Output:
        100
        55
        22
        */
        //</snippet9> 

    namespace newModifier2
    {
    //<snippet10>
    public class BaseC 
    {
        public class NestedC 
        {
            public int x = 200;
            public int y;
        }
    }

    public class DerivedC : BaseC 
    {
        // Nested type hiding the base type members.
        new public class NestedC   
        {
            public int x = 100;
            public int y; 
            public int z;
        }

        static void Main() 
        {
            // Creating an object from the overlapping class:
            NestedC c1  = new NestedC();

            // Creating an object from the hidden class:
            BaseC.NestedC c2 = new BaseC.NestedC();

            Console.WriteLine(c1.x);
            Console.WriteLine(c2.x);   
        }
    }
    /*
    Output:
    100
    200
    */
     //</snippet10>
        }

    //<snippet11>
    class MainClass
    {
        // unsafe not required for primitive types
        static void Main()
        {
            Console.WriteLine("The size of short is {0}.", sizeof(short));
            Console.WriteLine("The size of int is {0}.", sizeof(int));
            Console.WriteLine("The size of long is {0}.", sizeof(long));
        }
    }
    /*
    Output:
        The size of short is 2.
        The size of int is 4.
        The size of long is 8.
    */

    //</snippet11>
    }

    //<snippet12>
    public class ExampleClass
    {
       public int sampleMember;
       public void SampleMethod() {}

       static void Main()
       {
          Type t = typeof(ExampleClass);
          // Alternatively, you could use
          // ExampleClass obj = new ExampleClass();
          // Type t = obj.GetType();

          Console.WriteLine("Methods:");
          System.Reflection.MethodInfo[] methodInfo = t.GetMethods();

          foreach (System.Reflection.MethodInfo mInfo in methodInfo)
             Console.WriteLine(mInfo.ToString());

          Console.WriteLine("Members:");
          System.Reflection.MemberInfo[] memberInfo = t.GetMembers();

          foreach (System.Reflection.MemberInfo mInfo in memberInfo)
             Console.WriteLine(mInfo.ToString());
       }
    }
    /*
     Output:
        Methods:
        Void SampleMethod()
        System.String ToString()
        Boolean Equals(System.Object)
        Int32 GetHashCode()
        System.Type GetType()
        Members:
        Void SampleMethod()
        System.String ToString()
        Boolean Equals(System.Object)
        Int32 GetHashCode()
        System.Type GetType()
        Void .ctor()
        Int32 sampleMember
    */
    //</snippet12>

    //<snippet13>
    class GetTypeTest
    {
        static void Main()
        {
            int radius = 3;
            Console.WriteLine("Area = {0}", radius * radius * Math.PI);
            Console.WriteLine("The type is {0}",
                              (radius * radius * Math.PI).GetType()
            );
        }
    }
    /*
    Output:
    Area = 28.2743338823081
    The type is System.Double
    */
    //</snippet13>

    //<snippet14>    
    class TrueTest
    {
        static void Main() 
        {
            bool a = true;
            Console.WriteLine( a ? "yes" : "no" );
        }
    }
    /*
    Output:
    yes
    */
    //</snippet14>

    //<snippet15>    
    class Test
    {
        static unsafe void Main()
        {
            const int arraySize = 20;
            int* fib = stackalloc int[arraySize];
            int* p = fib;
            // The sequence begins with 1, 1.
            *p++ = *p++ = 1;
            for (int i = 2; i < arraySize; ++i, ++p)
            {
                // Sum the previous two numbers.
                *p = p[-1] + p[-2];
            }
            for (int i = 0; i < arraySize; ++i)
            {
                Console.WriteLine(fib[i]);
            }

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
    /*
    Output
    1
    1
    2
    3
    5
    8
    13
    21
    34
    55
    89
    144
    233
    377
    610
    987
    1597
    2584
    4181
    6765
    */
    //</snippet15>

    //<snippet16>
    // For example purposes only. Use the built-in nullable bool 
    // type (bool?) whenever possible.
    public struct DBBool
    {
        // The three possible DBBool values.
        public static readonly DBBool Null = new DBBool(0);
        public static readonly DBBool False = new DBBool(-1);
        public static readonly DBBool True = new DBBool(1);
        // Private field that stores –1, 0, 1 for False, Null, True.
        sbyte value;
        // Private instance constructor. The value parameter must be –1, 0, or 1.
        DBBool(int value)
        {
            this.value = (sbyte)value;
        }
        // Properties to examine the value of a DBBool. Return true if this
        // DBBool has the given value, false otherwise.
        public bool IsNull { get { return value == 0; } }
        public bool IsFalse { get { return value < 0; } }
        public bool IsTrue { get { return value > 0; } }
        // Implicit conversion from bool to DBBool. Maps true to DBBool.True and
        // false to DBBool.False.
        public static implicit operator DBBool(bool x)
        {
            return x ? True : False;
        }
        // Explicit conversion from DBBool to bool. Throws an exception if the
        // given DBBool is Null; otherwise returns true or false.
        public static explicit operator bool(DBBool x)
        {
            if (x.value == 0) throw new InvalidOperationException();
            return x.value > 0;
        }
        // Equality operator. Returns Null if either operand is Null; otherwise
        // returns True or False.
        public static DBBool operator ==(DBBool x, DBBool y)
        {
            if (x.value == 0 || y.value == 0) return Null;
            return x.value == y.value ? True : False;
        }
        // Inequality operator. Returns Null if either operand is Null; otherwise
        // returns True or False.
        public static DBBool operator !=(DBBool x, DBBool y)
        {
            if (x.value == 0 || y.value == 0) return Null;
            return x.value != y.value ? True : False;
        }
        // Logical negation operator. Returns True if the operand is False, Null
        // if the operand is Null, or False if the operand is True.
        public static DBBool operator !(DBBool x)
        {
            return new DBBool(-x.value);
        }
        // Logical AND operator. Returns False if either operand is False,
        // Null if either operand is Null, otherwise True.
        public static DBBool operator &(DBBool x, DBBool y)
        {
            return new DBBool(x.value < y.value ? x.value : y.value);
        }
        // Logical OR operator. Returns True if either operand is True, 
        // Null if either operand is Null, otherwise False.
        public static DBBool operator |(DBBool x, DBBool y)
        {
            return new DBBool(x.value > y.value ? x.value : y.value);
        }
        // Definitely true operator. Returns true if the operand is True, false
        // otherwise.
        public static bool operator true(DBBool x)
        {
            return x.value > 0;
        }
        // Definitely false operator. Returns true if the operand is False, false
        // otherwise.
        public static bool operator false(DBBool x)
        {
            return x.value < 0;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is DBBool)) return false;
            return value == ((DBBool)obj).value;
        }
        public override int GetHashCode()
        {
            return value;
        }
        public override string ToString()
        {
            if (value > 0) return "DBBool.True";
            if (value < 0) return "DBBool.False";
            return "DBBool.Null";
        }
    }
    //</snippet16>
}
