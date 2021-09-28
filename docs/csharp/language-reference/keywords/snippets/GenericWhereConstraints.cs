using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using static keywords.UnmanagedExtensions;

namespace keywords
{
    // <Snippet1>
    public class AGenericClass<T> where T : IComparable<T> { }
    // </Snippet1>

    // <SNippet2>
    public class UsingEnum<T> where T : System.Enum { }

    public class UsingDelegate<T> where T : System.Delegate { }

    public class Multicaster<T> where T : System.MulticastDelegate { }
    // </Snippet2>

    // <Snippet3>
    class MyClass<T, U>
        where T : class
        where U : struct
    { }
    // </Snippet3>

    // <Snippet4>
    class UnManagedWrapper<T>
        where T : unmanaged
    { }
    // </Snippet4>

    // <SnippetNotNull>
#nullable enable
    class NotNullContainer<T>
        where T : notnull
    {
    }
#nullable restore
    // </SnippetNotNull>

    // <Snippet5>
    public class MyGenericClass<T> where T : IComparable<T>, new()
    {
        // The following line is not possible without new() constraint:
        T item = new T();
    }
    // </Snippet5>

    // <Snippet6>
    public interface IMyInterface { }

    namespace CodeExample
    {
        class Dictionary<TKey, TVal>
            where TKey : IComparable<TKey>
            where TVal : IMyInterface
        {
            public void Add(TKey key, TVal val) { }
        }
    }
    // </Snippet6>
    public class Container
    {
        // <Snippet7>
        public void MyMethod<T>(T t) where T : IMyInterface { }
        // </Snippet7>

        // <Snippet8>
        delegate T MyDelegate<T>() where T : new();
        // </Snippet8>
    }

    // <Snippet9>
    public class Employee
    {
        public Employee(string s, int i) => (Name, ID) = (s, i);
        public string Name { get; set; }
        public int ID { get; set; }
    }

    public class GenericList<T> where T : Employee
    {
        private class Node
        {
            public Node(T t) => (Next, Data) = (null, t);

            public Node Next { get; set; }
            public T Data { get; set; }
        }

        private Node head;

        public void AddHead(T t)
        {
            Node n = new Node(t) { Next = head };
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
    // </Snippet9>

    public interface IEmployee
    {
    }

    // <Snippet10>
    class EmployeeList<T> where T : Employee, IEmployee, System.IComparable<T>, new()
    {
        // ...
    }
    // </Snippet10>

    // <Snippet12>
    class Base { }
    class Test<T, U>
        where U : struct
        where T : Base, new()
    { }
    // </Snippet12>

    namespace ListExample
    {
        // <Snippet13>
        public class List<T>
        {
            public void Add<U>(List<U> items) where U : T {/*...*/}
        }
        // </Snippet13>
    }

    // <Snippet14>
    //Type parameter V is used as a type constraint.
    public class SampleClass<T, U, V> where T : V { }
    // </Snippet14>

    public static class UnmanagedExtensions
    {
        // <Snippet15>
        unsafe public static byte[] ToByteArray<T>(this T argument) where T : unmanaged
        {
            var size = sizeof(T);
            var result = new Byte[size];
            Byte* p = (byte*)&argument;
            for (var i = 0; i < size; i++)
                result[i] = *p++;
            return result;
        }
        // </Snippet15>

        // <Snippet16>
        public static TDelegate TypeSafeCombine<TDelegate>(this TDelegate source, TDelegate target)
            where TDelegate : System.Delegate
            => Delegate.Combine(source, target) as TDelegate;
        // </Snippet16>

        // <Snippet18>
        public static Dictionary<int, string> EnumNamedValues<T>() where T : System.Enum
        {
            var result = new Dictionary<int, string>();
            var values = Enum.GetValues(typeof(T));

            foreach (int item in values)
                result.Add(item, Enum.GetName(typeof(T), item));
            return result;
        }
        // </Snippet18>
    }
    public static class GenericWhereConstraints
    {
        public static void Examples()
        {
            TestStringEquality();
            TestUnmanaged();
            TestDelegateCombination();
            TestEnumValues();
        }

        // <Snippet11>
        public static void OpEqualsTest<T>(T s, T t) where T : class
        {
            System.Console.WriteLine(s == t);
        }
        private static void TestStringEquality()
        {
            string s1 = "target";
            System.Text.StringBuilder sb = new System.Text.StringBuilder("target");
            string s2 = sb.ToString();
            OpEqualsTest<string>(s1, s2);
        }
        // </Snippet11>

        public struct Point3D
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double Z { get; set; }
        }
        private static void TestUnmanaged()
        {
            var thing = new Point3D { X = 1, Y = 2, Z = 3 };

            var storage = thing.ToByteArray();

            for (int i = 0; i < storage.Length; i++)
                Console.Write($"{storage[i]:X2}, ");
            Console.WriteLine();
        }

        private static void TestDelegateCombination()
        {
            // <Snippet17>
            Action first = () => Console.WriteLine("this");
            Action second = () => Console.WriteLine("that");

            var combined = first.TypeSafeCombine(second);
            combined();

            Func<bool> test = () => true;
            // Combine signature ensures combined delegates must
            // have the same type.
            //var badCombined = first.TypeSafeCombine(test);
            // </Snippet17>
        }

        // <Snippet19>
        enum Rainbow
        {
            Red,
            Orange,
            Yellow,
            Green,
            Blue,
            Indigo,
            Violet
        }
        // </Snippet19>
        private static void TestEnumValues()
        {
            // <Snippet20>
            var map = EnumNamedValues<Rainbow>();

            foreach (var pair in map)
                Console.WriteLine($"{pair.Key}:\t{pair.Value}");

            // </Snippet20>
        }
    }

    // <BaseClass>
    public abstract class B
    {
        public void M<T>(T? item) where T : struct { }
        public abstract void M<T>(T? item);

    }
    // </BaseClass>

    // <DerivedClass>
    public class D : B
    {
        // Without the "default" constraint, the compiler tries to override the first method in B
        public override void M<T>(T? item) where T : default { }
    }
    // </DerivedClass>
}
