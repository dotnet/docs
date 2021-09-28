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

     //<snippet5>
    public class PowersOf2
    {
        static void Main()
        {
            // Display powers of 2 up to the exponent of 8:
            foreach (int i in Power(2, 8))
            {
                Console.Write("{0} ", i);
            }
        }

        public static System.Collections.Generic.IEnumerable<int> Power(int number, int exponent)
        {
            int result = 1;

            for (int i = 0; i < exponent; i++)
            {
                result = result * number;
                yield return result;
            }
        }

        // Output: 2 4 8 16 32 64 128 256
    }
    //</snippet5>

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

// yield (C# Reference)
// 1089194f-9e53-46a2-8642-53ccbe9d414d

//<Snippet21>
public static class GalaxyClass
{
    public static void ShowGalaxies()
    {
        var theGalaxies = new Galaxies();
        foreach (Galaxy theGalaxy in theGalaxies.NextGalaxy)
        {
            Debug.WriteLine(theGalaxy.Name + " " + theGalaxy.MegaLightYears.ToString());
        }
    }

    public class Galaxies
    {

        public System.Collections.Generic.IEnumerable<Galaxy> NextGalaxy
        {
            get
            {
                yield return new Galaxy { Name = "Tadpole", MegaLightYears = 400 };
                yield return new Galaxy { Name = "Pinwheel", MegaLightYears = 25 };
                yield return new Galaxy { Name = "Milky Way", MegaLightYears = 0 };
                yield return new Galaxy { Name = "Andromeda", MegaLightYears = 3 };
            }
        }
    }

    public class Galaxy
    {
        public String Name { get; set; }
        public int MegaLightYears { get; set; }
    }
}
    //</Snippet21>
