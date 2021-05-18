using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace csrefLINQExamples
{

    class CommonMethods
    {
        public static List<Student> CreateStudentList()
        {
            List<string> names = GetLines(@"../../../names.csv");
            List<string> scores = GetLines(@"../../../scores.csv");

            IEnumerable<Student> queryNamesWithIDs =
                from name in names
                let x = name.Split(',')
                from score in scores
                let s = score.Split(',')
                where x[2] == s[0]
                select new Student()
                {
                    FirstName = x[0],
                    LastName = x[1],
                    ID = Convert.ToInt32(x[2]),
                    Year = (GradeLevel)Convert.ToInt32(x[3]),
                    ExamScores = (from scoreAsText in s.Skip(1)
                                  select Convert.ToInt32(scoreAsText)).
                                  ToList()
                };

            return queryNamesWithIDs.ToList();
        }

        // Returns a structured text file as a list of text lines
        public static List<string> GetLines(string filename)
        {
            List<string> lines = new List<string>();
            using (System.IO.StreamReader sr = new System.IO.StreamReader(filename))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    // Do not add empty lines
                    if (s.Length > 0)
                        lines.Add(s);
                }
            }
            return lines;
        }
    }

    public enum GradeLevel { FirstYear = 1, SecondYear, ThirdYear, FourthYear };
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public GradeLevel Year;
        public List<int> ExamScores;
    }

    // <snippet1>
    class SimpleLambda
    {
        static void Main()
        {

            // Data source.
            int[] scores = { 90, 71, 82, 93, 75, 82 };

            // The call to Count forces iteration of the source
            int highScoreCount = scores.Where(n => n > 80).Count();

            Console.WriteLine("{0} scores are greater than 80", highScoreCount);

            // Outputs: 4 scores are greater than 80
        }
    }
    //</snippet1>

    //<snippet2>
    class SumWithLambdas
    {
        static void Main()
        {
            // Create a data source using a collection initializer
            List<Student> students = CommonMethods.CreateStudentList();

            // This query retrieves the total scores for First Year and the total for SecondYears.
            // The outer Sum method requires a lambda in order to specify which numbers to add together.
            var categories =
            from student in students
            group student by student.Year into studentGroup
            select new { GradeLevel = studentGroup.Key, TotalScore = studentGroup.Sum(s => s.ExamScores.Sum()) };

            // Execute the query.
            foreach (var cat in categories)
            {
                Console.WriteLine("Key = {0} Sum = {1}", cat.GradeLevel, cat.TotalScore);
            }

            //Keep the console window open in debug mode
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
        /*
             Outputs:
             Key = SecondYear Sum = 1014
             Key = ThirdYear Sum = 964
             Key = FirstYear Sum = 1058
             Key = FourthYear Sum = 974
        */
    }
    //</snippet2>

    // var

//varTest removed to csrefKeywordsTypes

    //<snippet4>
    class GroupByExample1
    {
        static void Main()
        {
            //  Create a data source
            List<Student> students = CommonMethods.CreateStudentList();

            // Implicit typing is convenient but not required
            // for queries that produce groups
            var query = from student in students
                        group student by student.LastName[0];

            foreach (var item in query)
            {
                Console.WriteLine(item.Key);
                foreach (var i2 in item)
                {
                    Console.WriteLine(i2.LastName + " " + i2.FirstName);
                }
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
    /*  Outputs:
        T
        Terry Adams
        F
        Fadi Fakhouri
        H
        Hanying Feng
        Hugo Garcia
        C
        Cesar Garcia
        Claire O'Donnell
        D
        Debra Garcia
        S
        Sven Mortensen
        Svetlana Omelchenko
        L
        Lance Tucker
        M
        Michael Tucker
        E
        Eugene Zabokritski
   */
    //</snippet4>

    //#5 moved to csrefKeywordsContextual#9

    //auto-impl props
    //<snippet28>
    class LightweightCustomer
    {
        public double TotalPurchases { get; set; }
        public string Name { get; private set; } // read-only
        public int CustomerID { get; private set; } // read-only
    }
    //</snippet28>

    //lightweight class
    //<snippet30>
    public class Contact
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int ContactNumber { get; set; }
        public int ID { get; private set; } // readonly
    }
    //</snippet30>

    //Return Subsets of Element Properties

        //<snippet31>
        class AnonymousTypes
        {
            static void Main(string[] args)
            {
                // Create a data source.
                List<Student> students = CommonMethods.CreateStudentList();

                // Create the query. var is required because
                // the query produces a sequence of anonymous types.
                var queryHighScores =
                    from student in students
                    where student.ExamScores[0] > 95
                    select new { student.FirstName, student.LastName };

                // Execute the query.
                foreach (var student in queryHighScores)
                {
                    // The anonymous type's properties were not named. Therefore
                    // they have the same names as the Student properties.
                    Console.WriteLine(student.FirstName + ", " + student.LastName);
                }
            }
        }
        /* Output:
            Adams, Terry
            Fakhouri, Fadi
            Garcia, Cesar
            Omelchenko, Svetlana
            Zabokritski, Eugene
       */
        //</snippet31>

    class ImplicitTyping
    {   // How to use implicitly typed locals
        //<snippet32>

        static void Main(string[] args)
        {
            // Create the data source
            List<Student> students = CommonMethods.CreateStudentList();

            // Create the query. var is required because
            // the query produces a sequence of anonymous types.
            var studentQuery =
                from student in students
                where student.FirstName[0] == 'S'
                select new { student.FirstName, student.LastName };

            // Execute the query.
            foreach (var student in studentQuery)
            {
                Console.WriteLine("First = {0}, Last = {1}", student.FirstName, student.LastName);
            }
        }
        //</snippet32>

        static void QueryMethod(List<Student> students)
        {
            //how to use implicitly typed locals #2
            //<snippet33>
            var queryID =
                from student in students
                where student.ID > 111
                select student.LastName;

            foreach (string str in queryID)
            {
                Console.WriteLine(str);
            }
            //</snippet33>
        }
    }

    class StudentName
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
    }

    class CollInit
    {
        //how to init a dictionary with coll initializer
        //<snippet34>
        Dictionary<int, StudentName> students = new Dictionary<int, StudentName>()
        {
            { 111, new StudentName {FirstName="Sachin", LastName="Karnik", ID=211}},
            { 112, new StudentName {FirstName="Dina", LastName="Salimzianova", ID=317, }},
            { 113, new StudentName {FirstName="Andy", LastName="Ruth", ID=198, }}
        };
        //</snippet34>
    }

    class ObjInit
    {
        //How to: Initialize Objects without Calling a Constructor (C# Programming Guide)
        //<snippet35>

        StudentName student = new StudentName
        {
            FirstName = "Craig",
            LastName = "Playstead",
            ID = 116
        };
        //</snippet35>

        //How to: Initialize Objects without Calling a Constructor #2 (C# Programming Guide)
        //<snippet36>
        List<StudentName> students = new List<StudentName>()
        {
          new StudentName {FirstName="Craig", LastName="Playstead", ID=116},
          new StudentName {FirstName="Shu", LastName="Ito", ID=112, },
          new StudentName {FirstName="Stefan", LastName="Rißling", ID=113, },
          new StudentName {FirstName="Rajesh", LastName="Rotti", ID=114, }
        };
        //</snippet36>
    }

    // Implicitly Typed Arrays example 1
    //<snippet37>
    class ImplicitlyTypedArraySample
    {
        static void Main()
        {
            var a = new[] { 1, 10, 100, 1000 }; // int[]
            var b = new[] { "hello", null, "world" }; // string[]

            // single-dimension jagged array
            var c = new[]
            {
                new[]{1,2,3,4},
                new[]{5,6,7,8}
            };

            // jagged array of strings
            var d = new[]
            {
                new[]{"Luca", "Mads", "Luke", "Dinesh"},
                new[]{"Karen", "Suma", "Frances"}
            };
        }
    }
    //</snippet37>

    // Implicitly Typed Arrays examples 2
    class ImplicitArraySample2
    {
        static void Method()
        {
            //<snippet38>
            var contacts = new[]
            {
                new {
                        Name = " Eugene Zabokritski",
                        PhoneNumbers = new[] { "206-555-0108", "425-555-0001" }
                    },
                new {
                        Name = " Hanying Feng",
                        PhoneNumbers = new[] { "650-555-0199" }
                    }
            };
            //</snippet38>
        }
    }

    //Object and collection intializers
    class ObjCollInitializers
    {
        //<snippet39>
        private class Cat
        {
            // Auto-implemented properties
            public int Age { get; set; }
            public string Name { get; set; }
        }

        static void MethodA()
        {
            // Object initializer
            Cat cat = new Cat { Age = 10, Name = "Sylvester" };
        }
        //</snippet39>

        class Product
        {
            public string ProductName { get; set; }
            public decimal UnitPrice { get; set; }
        }

        void MethodB()
        {
            List<Product> products = new List<Product>();

            //<snippet40>
            var productInfos =
                from p in products
                select new { p.ProductName, p.UnitPrice };
            //</snippet40>

            //<snippet41>
            List<Cat> cats = new List<Cat>
            {
                new Cat(){ Name="Sylvester", Age=8 },
                new Cat(){ Name="Whiskers", Age=2},
                new Cat() { Name="Sasha", Age=14}
            };
            //</snippet41>

            //<snippet42>
            List<Cat> moreCats = new List<Cat>
            {
                new Cat(){ Name="Furrytail", Age=5 },
                new Cat(){ Name="Peaches", Age=4},
                null
            };
            //</snippet42>
        }
    }

    //Implicitly Typed Local Variables Conceptual Topic
    class ImplicitlyTypedLocals
    {
        // compilation hack
        class Customer
        {
            public string City { get; set; }
        }
        static List<Customer> customers = new List<Customer>();

        //<snippet43>
        static void Main()
        {
            // i is compiled as an int
            var i = 5;

            // s is compiled as a string
            var s = "Hello";

            // a is compiled as int[]
            var a = new[] { 0, 1, 2 };

            // expr is compiled as IEnumerable<Customer>
            var expr =
                from c in customers
                where c.City == "London"
                select c;

            // anon is compiled as an anonymous type
            var anon = new { Name = "Terry", Age = 34 };

            // list is compiled as List<int>
            var list = new List<int>();
        }
        //</snippet43>
    }

    //<snippet44>
    class ImplicitlyTypedLocals2
    {
        static void Main()
        {
            string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

            // If a query variable has been initialized with var,
            // then you must also use var in the foreach statement.
            var upperLowerWords =
                 from w in words
                 select new { Upper = w.ToUpper(), Lower = w.ToLower() };

            // Execute the query
            foreach (var ul in upperLowerWords)
            {
                Console.WriteLine("Uppercase: {0}, Lowercase: {1}", ul.Upper, ul.Lower);
            }
        }
    }
    /* Outputs:
        Uppercase: APPLE, Lowercase: apple
        Uppercase: BLUEBERRY, Lowercase: blueberry
        Uppercase: CHERRY, Lowercase: cherry
     */
    //</snippet44>

    //<snippet65>
    class AnonymousMethodTest
    {
        delegate void testDelegate(string s);
        static void M(string s)
        {
            Console.WriteLine(s);
        }

        static void Main(string[] args)
        {
            // Original delegate syntax required
            // initialization with a named method.
            testDelegate testdelA = new testDelegate(M);

            // C# 2.0: A delegate can be initialized with
            // inline code, called an "anonymous method."
            testDelegate testDelB = delegate(string s) { Console.WriteLine(s); };

            // C# 3.0. A delegate can be initialized with
            // a lambda expression.
            testDelegate testDelC = (x) => { Console.WriteLine(x); };

            // Invoke the delegates.
            testdelA("Hello. My name is M and I write lines.");
            testDelC("That's nothing. I'm anonymous and ");
            testDelC("I'm a famous author.");

            // Keep console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    /* Output:
        Hello. My name is M and I write lines.
        That's nothing. I'm anonymous and
        I'm a famous author.
        Press any key to exit.
     */
    //</snippet65>

    //<snippet 66>
    class Test2
    {
        Func<int, bool> f;

        bool M(Func<double,bool> func, int i)
        {

            int local = i;
            Console.WriteLine(func(local));
            Thread.Sleep(5300);
            return func(local);
        }
        static void Main()
        {
            Test2 app = new Test2();
            bool b = app.M(x => x % 2 == 0, DateTime.Now.Second);

            //bool b2 = app.M(x => x +

            Console.WriteLine(b.ToString());

            Console.ReadKey();
        }
    }
    //</snippet 66>

    //reserving numbers 67-79 for anonymous methods

    //<snippet80>
    class MQ
    {
        IEnumerable<string> QueryMethod1(ref int[] ints)
        {
            var intsToStrings = from i in ints
                          where i > 4
                          select i.ToString();
            return intsToStrings;
        }

        static void Main()
        {
            MQ app = new MQ();

            int[] nums = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var myQuery = app.QueryMethod1(ref nums);

            //execute myQuery
            foreach (string s in myQuery)
            {
                Console.WriteLine(s);
            }

            //modify myQuery
            myQuery = (from str in myQuery
                       orderby str descending
                       select str).
                      Take(3);

            // Executing myQuery after more
            // composition
            Console.WriteLine("After modification:");
            foreach (string s in myQuery)
            {
                Console.WriteLine(s);
            }

            // Keep console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    //</snippet80>

    class CSHarp30
    {

        //<snippet82>
        class Product2
        {
            public string Color { get; set; }
            public string Price { get; set; }
        }

        //</snippet82>
        //<snippet83>
        class Product3
        {
            public string Color { get; set; }
            public string Price { get; set; }
        }
        //</snippet83>
        //<snippet84>
        class Product4
        {
            public string Color { get; set; }
            public string Price { get; set; }
        }
        //</snippet84>
        //<snippet85>
        class Product5
        {
            public string Color { get; set; }
            public string Price { get; set; }
        }
        //</snippet85>
        //<snippet86>
        class Product6
        {
            public string Color { get; set; }
            public string Price { get; set; }
        }
        //</snippet86>
        //<snippet87>
        class Product7
        {
            public string Color { get; set; }
            public string Price { get; set; }
        }
        //</snippet87>
    }
}
