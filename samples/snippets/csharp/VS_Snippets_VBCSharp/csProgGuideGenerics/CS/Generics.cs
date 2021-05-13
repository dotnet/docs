using System.Collections.Generic;

namespace CsCsrefProgrammingGenerics
{
    public class GenericList<T>
    {
        // The nested class is also generic on T.
        private class Node
        {
            // T used in non-generic constructor.
            public Node(T t)
            {
                next = null;
                data = t;
            }

            private Node next;
            public Node Next
            {
                get { return next; }
                set { next = value; }
            }

            // T as private member data type.
            private T data;

            // T as return type of property.
            public T Data
            {
                get { return data; }
                set { data = value; }
            }
        }

        private Node head;

        // constructor
        public GenericList()
        {
            head = null;
        }

        // T as method parameter type:
        public void AddHead(T t)
        {
            Node n = new Node(t);
            n.Next = head;
            head = n;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
    //</Snippet2>

    class TestGenericList2
    {
        private class ExampleClass { }
        private struct ExampleStruct { }
        static void Main()
        {
            //<Snippet7>
            GenericList<float> list1 = new GenericList<float>();
            GenericList<ExampleClass> list2 = new GenericList<ExampleClass>();
            GenericList<ExampleStruct> list3 = new GenericList<ExampleStruct>();
            //</Snippet7>
        }
    }

    //---------------------------------------------------------------------------
    public class WrapBenefits
    {
        public static void Test1()
        {
            //<Snippet4>
            // The .NET Framework 1.1 way to create a list:
            System.Collections.ArrayList list1 = new System.Collections.ArrayList();
            list1.Add(3);
            list1.Add(105);

            System.Collections.ArrayList list2 = new System.Collections.ArrayList();
            list2.Add("It is raining in Redmond.");
            list2.Add("It is snowing in the mountains.");
            //</Snippet4>
        }

        public static void Test2()
        {
            //<Snippet5>
            System.Collections.ArrayList list = new System.Collections.ArrayList();
            // Add an integer to the list.
            list.Add(3);
            // Add a string to the list. This will compile, but may cause an error later.
            list.Add("It is raining in Redmond.");

            int t = 0;
            // This causes an InvalidCastException to be returned.
            foreach (int x in list)
            {
                t += x;
            }
            //</Snippet5>
        }

        public static void Test3()
        {
            //<Snippet6>
            // The .NET Framework 2.0 way to create a list
            List<int> list1 = new List<int>();

            // No boxing, no casting:
            list1.Add(3);

            // Compile-time error:
            // list1.Add("It is raining in Redmond.");
            //</Snippet6>
        }
    }

    //---------------------------------------------------------------------------
    public class WrapParameters
    {
        //<Snippet8>
        public interface ISessionChannel<TSession> { /*...*/ }
        public delegate TOutput Converter<TInput, TOutput>(TInput from);
        public class List<T> { /*...*/ }
        //</Snippet8>

        //<Snippet9>
        public int IComparer<T>() { return 0; }
        public delegate bool Predicate<T>(T item);
        public struct Nullable<T> where T : struct { /*...*/ }
        //</Snippet9>

        class wrap
        {
            //<Snippet10>
            public interface ISessionChannel<TSession>
            {
                TSession Session { get; }
            }
            //</Snippet10>
        }
    }//WrapParameters

    //---------------------------------------------------------------------------
    public class WrapConstraints
    {
        //<Snippet11>
        public class Employee
        {
            private string name;
            private int id;

            public Employee(string s, int i)
            {
                name = s;
                id = i;
            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public int ID
            {
                get { return id; }
                set { id = value; }
            }
        }

        public class GenericList<T> where T : Employee
        {
            private class Node
            {
                private Node next;
                private T data;

                public Node(T t)
                {
                    next = null;
                    data = t;
                }

                public Node Next
                {
                    get { return next; }
                    set { next = value; }
                }

                public T Data
                {
                    get { return data; }
                    set { data = value; }
                }
            }

            private Node head;

            public GenericList() //constructor
            {
                head = null;
            }

            public void AddHead(T t)
            {
                Node n = new Node(t);
                n.Next = head;
                head = n;
            }

            public IEnumerator<T> GetEnumerator()
            {
                Node current = head;

                while (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }

            public T FindFirstOccurrence(string s)
            {
                Node current = head;
                T t = null;

                while (current != null)
                {
                    //The constraint enables access to the Name property.
                    if (current.Data.Name == s)
                    {
                        t = current.Data;
                        break;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }
                return t;
            }
        }
        //</Snippet11>

        interface IEmployee { }

        //<Snippet12>
        class EmployeeList<T> where T : Employee, IEmployee, System.IComparable<T>, new()
        {
            // ...
        }
        //</Snippet12>

        //<Snippet13>
        public static void OpTest<T>(T s, T t) where T : class
        {
            System.Console.WriteLine(s == t);
        }
        static void Main()
        {
            string s1 = "target";
            System.Text.StringBuilder sb = new System.Text.StringBuilder("target");
            string s2 = sb.ToString();
            OpTest<string>(s1, s2);
        }
        //</Snippet13>

        //<Snippet14>
        class List<T>
        {
            void Add<U>(List<U> items) where U : T {/*...*/}
        }
        //</Snippet14>

        //<Snippet15>
        //Type parameter V is used as a type constraint.
        public class SampleClass<T, U, V> where T : V { }
        //</Snippet15>
    }

    //---------------------------------------------------------------------------
    namespace WrapClasses
    {
        //<Snippet16>
        class BaseNode { }
        class BaseNodeGeneric<T> { }

        // concrete type
        class NodeConcrete<T> : BaseNode { }

        //closed constructed type
        class NodeClosed<T> : BaseNodeGeneric<int> { }

        //open constructed type
        class NodeOpen<T> : BaseNodeGeneric<T> { }
        //</Snippet16>

        //<Snippet17>
        //No error
        class Node1 : BaseNodeGeneric<int> { }

        //Generates an error
        //class Node2 : BaseNodeGeneric<T> {}

        //Generates an error
        //class Node3 : T {}
        //</Snippet17>

        //<Snippet18>
        class BaseNodeMultiple<T, U> { }

        //No error
        class Node4<T> : BaseNodeMultiple<T, int> { }

        //No error
        class Node5<T, U> : BaseNodeMultiple<T, U> { }

        //Generates an error
        //class Node6<T> : BaseNodeMultiple<T, U> {}
        //</Snippet18>

        //<Snippet19>
        class NodeItem<T> where T : System.IComparable<T>, new() { }
        class SpecialNodeItem<T> : NodeItem<T> where T : System.IComparable<T>, new() { }
        //</Snippet19>

        //<Snippet20>
        class SuperKeyType<K, V, U>
            where U : System.IComparable<U>
            where V : new()
        { }
        //</Snippet20>

        class Test
        {
            //<Snippet21>
            void Swap<T>(List<T> list1, List<T> list2)
            {
                //code to swap items
            }

            void Swap(List<int> list1, List<int> list2)
            {
                //code to swap items
            }
            //</Snippet21>
        }
    }

    //---------------------------------------------------------------------------
    class WrapInterfaces
    {
        //<Snippet30>
        class Stack<T> where T : System.IComparable<T>, IEnumerable<T>
        {
        }
        //</Snippet30>

        //<Snippet31>
        interface IDictionary<K, V>
        {
        }
        //</Snippet31>

        //<Snippet32>
        interface IMonth<T> { }

        interface IJanuary     : IMonth<int> { }  //No error
        interface IFebruary<T> : IMonth<int> { }  //No error
        interface IMarch<T>    : IMonth<T> { }    //No error
        //interface IApril<T>  : IMonth<T, U> {}  //Error
        //</Snippet32>

        //<Snippet33>
        interface IBaseInterface<T> { }

        class SampleClass : IBaseInterface<string> { }
        //</Snippet33>

        //<Snippet34>
        interface IBaseInterface1<T> { }
        interface IBaseInterface2<T, U> { }

        class SampleClass1<T> : IBaseInterface1<T> { }          //No error
        class SampleClass2<T> : IBaseInterface2<T, string> { }  //No error
        //</Snippet34>
    }

    //---------------------------------------------------------------------------
    namespace WrapMethods
    {
        public class Test
        {
            //<Snippet22>
            static void Swap<T>(ref T lhs, ref T rhs)
            {
                T temp;
                temp = lhs;
                lhs = rhs;
                rhs = temp;
            }
            //</Snippet22>

            //<Snippet23>
            public static void TestSwap()
            {
                int a = 1;
                int b = 2;

                Swap<int>(ref a, ref b);
                System.Console.WriteLine(a + " " + b);
            }
            //</Snippet23>

            public static void TestSwapInfer()
            {
                int a = 1;
                int b = 2;

                //<Snippet24>
                Swap(ref a, ref b);
                //</Snippet24>
                System.Console.WriteLine(a + " " + b);
            }
        }

        //<Snippet25>
        class SampleClass<T>
        {
            void Swap(ref T lhs, ref T rhs) { }
        }
        //</Snippet25>

        //<Snippet26>
        class GenericList<T>
        {
            // CS0693
            void SampleMethod<T>() { }
        }

        class GenericList2<T>
        {
            //No warning
            void SampleMethod<U>() { }
        }
        //</Snippet26>

        class Test2
        {
            //<Snippet27>
            void SwapIfGreater<T>(ref T lhs, ref T rhs) where T : System.IComparable<T>
            {
                T temp;
                if (lhs.CompareTo(rhs) > 0)
                {
                    temp = lhs;
                    lhs = rhs;
                    rhs = temp;
                }
            }
            //</Snippet27>

            //<Snippet28>
            void DoWork() { }
            void DoWork<T>() { }
            void DoWork<T, U>() { }
            //</Snippet28>
        }
    }

    //---------------------------------------------------------------------------
    namespace WrapArrays
    {
        //<Snippet35>
        class Program
        {
            static void Main()
            {
                int[] arr = { 0, 1, 2, 3, 4 };
                List<int> list = new List<int>();

                for (int x = 5; x < 10; x++)
                {
                    list.Add(x);
                }

                ProcessItems<int>(arr);
                ProcessItems<int>(list);
            }

            static void ProcessItems<T>(IList<T> coll)
            {
                // IsReadOnly returns True for the array and False for the List.
                System.Console.WriteLine
                    ("IsReadOnly returns {0} for this collection.",
                    coll.IsReadOnly);

                // The following statement causes a run-time exception for the
                // array, but not for the List.
                //coll.RemoveAt(4);

                foreach (T item in coll)
                {
                    System.Console.Write(item.ToString() + " ");
                }
                System.Console.WriteLine();
            }
        }
        //</Snippet35>
    }

    //---------------------------------------------------------------------------
    class WrapDelegates
    {
        //<Snippet36>
        public delegate void Del<T>(T item);
        public static void Notify(int i) { }

        Del<int> m1 = new Del<int>(Notify);
        //</Snippet36>

        //<Snippet37>
        Del<int> m2 = Notify;
        //</Snippet37>

        //<Snippet38>
        class Stack<T>
        {
            T[] items;
            int index;

            public delegate void StackDelegate(T[] items);
        }
        //</Snippet38>

        //<Snippet39>
        private static void DoWork(float[] items) { }

        public static void TestStack()
        {
            Stack<float> s = new Stack<float>();
            Stack<float>.StackDelegate d = DoWork;
        }
        //</Snippet39>
    }

    //---------------------------------------------------------------------------
    class WrapDelegates2
    {
        //<Snippet40>
        delegate void StackEventHandler<T, U>(T sender, U eventArgs);

        class Stack<T>
        {
            public class StackEventArgs : System.EventArgs { }
            public event StackEventHandler<Stack<T>, StackEventArgs> stackEvent;

            protected virtual void OnStackChanged(StackEventArgs a)
            {
                stackEvent(this, a);
            }
        }

        class SampleClass
        {
            public void HandleStackChange<T>(Stack<T> stack, Stack<T>.StackEventArgs args) { }
        }

        public static void Test()
        {
            Stack<double> s = new Stack<double>();
            SampleClass o = new SampleClass();
            s.stackEvent += o.HandleStackChange;
        }
        //</Snippet40>
    }

    //---------------------------------------------------------------------------
    //<Snippet41>
    namespace ConsoleApplication1
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                // Test with a non-empty list of integers.
                GenericList<int> gll = new GenericList<int>();
                gll.AddNode(5);
                gll.AddNode(4);
                gll.AddNode(3);
                int intVal = gll.GetLast();
                // The following line displays 5.
                System.Console.WriteLine(intVal);

                // Test with an empty list of integers.
                GenericList<int> gll2 = new GenericList<int>();
                intVal = gll2.GetLast();
                // The following line displays 0.
                System.Console.WriteLine(intVal);

                // Test with a non-empty list of strings.
                GenericList<string> gll3 = new GenericList<string>();
                gll3.AddNode("five");
                gll3.AddNode("four");
                string sVal = gll3.GetLast();
                // The following line displays five.
                System.Console.WriteLine(sVal);

                // Test with an empty list of strings.
                GenericList<string> gll4 = new GenericList<string>();
                sVal = gll4.GetLast();
                // The following line displays a blank line.
                System.Console.WriteLine(sVal);
            }
        }

        // T is the type of data stored in a particular instance of GenericList.
        public class GenericList<T>
        {
            private class Node
            {
                // Each node has a reference to the next node in the list.
                public Node Next;
                // Each node holds a value of type T.
                public T Data;
            }

            // The list is initially empty.
            private Node head = null;

            // Add a node at the beginning of the list with t as its data value.
            public void AddNode(T t)
            {
                Node newNode = new Node();
                newNode.Next = head;
                newNode.Data = t;
                head = newNode;
            }

            // The following method returns the data value stored in the last node in
            // the list. If the list is empty, the default value for type T is
            // returned.
            public T GetLast()
            {
                // The value of temp is returned as the value of the method.
                // The following declaration initializes temp to the appropriate
                // default value for type T. The default value is returned if the
                // list is empty.
                T temp = default(T);

                Node current = head;
                while (current != null)
                {
                    temp = current.Data;
                    current = current.Next;
                }
                return temp;
            }
        }
    }
    //</Snippet41>

    //---------------------------------------------------------------------------
    class WrapRuntime
    {
        //<Snippet42>
        Stack<int> stack;
        //</Snippet42>

        //<Snippet43>
        Stack<int> stackOne = new Stack<int>();
        Stack<int> stackTwo = new Stack<int>();
        //</Snippet43>

        //<Snippet47>
        class Customer { }
        class Order { }
        //</Snippet47>

        public static void Test()
        {
            //<Snippet44>
            Stack<Customer> customers;
            //</Snippet44>

            //<Snippet45>
            Stack<Order> orders = new Stack<Order>();
            //</Snippet45>

            //<Snippet46>
            customers = new Stack<Customer>();
            //</Snippet46>
        }
    }

    //---------------------------------------------------------------------------
    class WrapAttributes
    {
        //-----------------------------------------------------
        //<Snippet48>
        class CustomAttribute : System.Attribute
        {
            public System.Object info;
        }
        //</Snippet48>

        //-----------------------------------------------------
        //<Snippet49>
        public class GenericClass1<T> { }

        [CustomAttribute(info = typeof(GenericClass1<>))]
        class ClassA { }
        //</Snippet49>

        //-----------------------------------------------------
        //<Snippet50>
        public class GenericClass2<T, U> { }

        [CustomAttribute(info = typeof(GenericClass2<,>))]
        class ClassB { }
        //</Snippet50>

        //-----------------------------------------------------
        //<Snippet51>
        public class GenericClass3<T, U, V> { }

        [CustomAttribute(info = typeof(GenericClass3<int, double, string>))]
        class ClassC { }
        //</Snippet51>

        //-----------------------------------------------------
        //<Snippet52>
        //[CustomAttribute(info = typeof(GenericClass3<int, T, string>))]  //Error
        class ClassD<T> { }
        //</Snippet52>

        //-----------------------------------------------------
        //<Snippet53>
        //public class CustomAtt<T> : System.Attribute {}  //Error
        //</Snippet53>
    }
}
