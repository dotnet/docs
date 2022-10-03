using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace csrefKeywordsContextual
{
    //<snippet1>
    class TimePeriod
    {
        private double _seconds;
        public double Seconds
        {
            get { return _seconds; }
            set { _seconds = value; }
        }
    }
    //</snippet1>

    //<snippet2>
    class TimePeriod2
    {
        public double Hours { get; set; }
    }
    //</snippet2>

    //<snippet3>
    namespace PC
    {
        partial class A
        {
            int num = 0;
            void MethodA() { }
            partial void MethodC();
        }
    }
    //</snippet3>

    //<snippet4>
    namespace PC
    {
        partial class A
        {
            void MethodB() { }
            partial void MethodC() { }
        }
    }
    //</snippet4>

    namespace PC
    {
        partial class A
        {
            void MethodD()
            {
                Console.WriteLine(num.ToString());
            }
        }
    }

    //<snippet6>
    class MyClass<T, U>
        where T : class
        where U : struct
    { }
    //</snippet6>

    //<snippet7>

    public class MyGenericClass<T> where T : IComparable, new()
    {
        // The following line is not possible without new() constraint:
        T item = new T();
    }
    //</snippet7>

    //<snippet8>
    interface IMyInterface
    {
    }

    class Dictionary<TKey, TVal>
        where TKey : IComparable, IEnumerable
        where TVal : IMyInterface
    {
        public void Add(TKey key, TVal val)
        {
        }
    }
    //</snippet8>

    // partial (method) 43f40242-17e0-4452-8573-090503ad3137
    //<snippet9>
    namespace PM
    {
        partial class A
        {
            partial void OnSomethingHappened(string s);
        }

        // This part can be in a separate file.
        partial class A
        {
            // Comment out this method and the program
            // will still compile.
            partial void OnSomethingHappened(String s)
            {
                Console.WriteLine("Something happened: {0}", s);
            }
        }
    }
    //</snippet9>

    class Test
    {
        class Student
        {
            public string LastName;
            public Student(string name)
            {
                LastName = name;
            }
        }

        class Category
        {
            public int ID;
            public string Name;

            public Category(int i, string n)
            {
                ID = i;
                Name = n;
            }
        }

        class Product
        {
            public string Name;
            public int ProdID;
            public int CategoryID;
            public Product(string n, int pid, int cid)
            {
                Name = n;
                ProdID = pid;
                CategoryID = cid;
            }
        }

        static string[] vegetables = { "carrot", "celery" };
        static void Main()
        {
            List<Student> students = new List<Student>();
            //<Snippet10>
            var query = from student in students
                        group student by student.LastName[0];
            //</Snippet10>

            //<Snippet11>
            IEnumerable<string> sortDescendingQuery =
                from vegetable in vegetables
                orderby vegetable descending
                select vegetable;
            //</Snippet11>

            //<Snippet14>
            IEnumerable<string> sortAscendingQuery =
                from vegetable in vegetables
                orderby vegetable ascending
                select vegetable;
            //</Snippet14>

            List<Category> categories = new List<Category>();
            List<Product> products = new List<Product>();

            //<Snippet12>
            var innerJoinQuery =
                from category in categories
                join prod in products on category.ID equals prod.CategoryID
                select new { ProductName = prod.Name, Category = category.Name };
            //</Snippet12>
        }

        //<Snippet13>
        class TestClass : global::TestApp { }
        //</Snippet13>
    }

    //<Snippet15>
    class Events : IDrawingObject
    {
        event EventHandler PreDrawEvent;

        event EventHandler IDrawingObject.OnDraw
        {
            add => PreDrawEvent += value;
            remove => PreDrawEvent -= value;
        }
    }
    //</Snippet15>
    interface IDrawingObject
    {
        event EventHandler OnDraw;
    }
}

class TestApp { } // for snippet13
