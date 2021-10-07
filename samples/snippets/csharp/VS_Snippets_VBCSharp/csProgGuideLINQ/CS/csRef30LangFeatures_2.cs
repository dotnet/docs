using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AutoImplMutable
{
    // Auto-impl props
    //<snippet28>
    // This class is mutable. Its data can be modified from
    // outside the class.
    class Customer
    {
        // Auto-implemented properties for trivial get and set
        public double TotalPurchases { get; set; }
        public string Name { get; set; }
        public int CustomerId { get; set; }

        // Constructor
        public Customer(double purchases, string name, int id)
        {
            TotalPurchases = purchases;
            Name = name;
            CustomerId = id;
        }

        // Methods
        public string GetContactInfo() { return "ContactInfo"; }
        public string GetTransactionHistory() { return "History"; }

        // .. Additional methods, events, etc.
    }

    class Program
    {
        static void Main()
        {
            // Intialize a new object.
            Customer cust1 = new Customer(4987.63, "Northwind", 90108);

            // Modify a property.
            cust1.TotalPurchases += 499.99;
        }
    }
    //</snippet28>
}

namespace Immutable
{

        //how to implement an immutable class
            //<snippet30>

        // This class is immutable. After an object is created,
        // it cannot be modified from outside the class. It uses a
        // constructor to initialize its properties.
        class Contact
        {
            // Read-only properties.
            public string Name { get; private set; }
            public string Address { get; private set; }

            // Public constructor.
            public Contact(string contactName, string contactAddress)
            {
                Name = contactName;
                Address = contactAddress;
            }
        }

        // This class is immutable. After an object is created,
        // it cannot be modified from outside the class. It uses a
        // static method and private constructor to initialize its properties.
        public class Contact2
        {
            // Read-only properties.
            public string Name { get; private set; }
            public string Address { get; private set; }

            // Private constructor.
            private Contact2(string contactName, string contactAddress)
            {
                Name = contactName;
                Address = contactAddress;
            }

            // Public factory method.
            public static Contact2 CreateContact(string name, string address)
            {
                return new Contact2(name, address);
            }
        }

        public class Program
        {
            static void Main()
            {
                // Some simple data sources.
                string[] names = {"Terry Adams","Fadi Fakhouri", "Hanying Feng",
                                  "Cesar Garcia", "Debra Garcia"};
                string[] addresses = {"123 Main St.", "345 Cypress Ave.", "678 1st Ave",
                                      "12 108th St.", "89 E. 42nd St."};

                // Simple query to demonstrate object creation in select clause.
                // Create Contact objects by using a constructor.
                var query1 = from i in Enumerable.Range(0, 5)
                            select new Contact(names[i], addresses[i]);

                // List elements cannot be modified by client code.
                var list = query1.ToList();
                foreach (var contact in list)
                {
                    Console.WriteLine("{0}, {1}", contact.Name, contact.Address);
                }

                // Create Contact2 objects by using a static factory method.
                var query2 = from i in Enumerable.Range(0, 5)
                             select Contact2.CreateContact(names[i], addresses[i]);

                // Console output is identical to query1.
                var list2 = query2.ToList();

                // List elements cannot be modified by client code.
                // CS0272:
                // list2[0].Name = "Eugene Zabokritski";

                // Keep the console open in debug mode.
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }

    /* Output:
        Terry Adams, 123 Main St.
        Fadi Fakhouri, 345 Cypress Ave.
        Hanying Feng, 678 1st Ave
        Cesar Garcia, 12 108th St.
        Debra Garcia, 89 E. 42nd St.
    */
        //</snippet30>
}

namespace csrefLINQExamples
{
            //Return Subsets of Element Properties

            class AnonymousTypes : StudentClass
            {
                static void Main(string[] args)
                {
                    QueryByScore();
                }
                //<snippet31>
                private static void QueryByScore()
                {
                    // Create the query. var is required because
                    // the query produces a sequence of anonymous types.
                    var queryHighScores =
                        from student in students
                        where student.ExamScores[0] > 95
                        select new { student.FirstName, student.LastName };

                    // Execute the query.
                    foreach (var obj in queryHighScores)
                    {
                        // The anonymous type's properties were not named. Therefore
                        // they have the same names as the Student properties.
                        Console.WriteLine(obj.FirstName + ", " + obj.LastName);
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
            }

            // How to use implicitly typed locals
            class ImplicitTyping : StudentClass
            {
                static void Main(string[] args)
                {
                    QueryNames('S');
                }

                //<snippet32>
                private static void QueryNames(char firstLetter)
                {
                    // Create the query. Use of var is required because
                    // the query produces a sequence of anonymous types:
                    // System.Collections.Generic.IEnumerable<????>.
                    var studentQuery =
                        from student in students
                        where student.FirstName[0] == firstLetter
                        select new { student.FirstName, student.LastName };

                    // Execute the query and display the results.
                    foreach (var anonType in studentQuery)
                    {
                        Console.WriteLine("First = {0}, Last = {1}", anonType.FirstName, anonType.LastName);
                    }
                }
                //</snippet32>

                static void QueryMethod(List<Student> students)
                {
                    //how to use implicitly typed locals #2
                    //<snippet33>
                    // Variable queryId could be declared by using
                    // System.Collections.Generic.IEnumerable<string>
                    // instead of var.
                    var queryId =
                        from student in students
                        where student.Id > 111
                        select student.LastName;

                    // Variable str could be declared by using var instead of string.
                    foreach (string str in queryId)
                    {
                        Console.WriteLine("Last name: {0}", str);
                    }
                    //</snippet33>
                }
            }

            //how to init a dictionary with coll initializer
            //<snippet34>
            class StudentName
            {
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public int Id { get; set; }
            }

            class CollInit
            {
                Dictionary<int, StudentName> students = new Dictionary<int, StudentName>()
                {
                    { 111, new StudentName { FirstName = "Sachin", LastName="Karnik", Id = 211 } },
                    { 112, new StudentName { FirstName = "Dina", LastName="Salimzianova", Id = 317 } },
                    { 113, new StudentName { FirstName = "Andy", LastName="Ruth", Id = 198 } }
                };
            }
            //</snippet34>

            class ObjInit
            {
                //How to: Initialize Objects without Calling a Constructor (C# Programming Guide)
                //<snippet35>
                public class Program
                {
                    public static void Main()
                    {

                        // Declare a StudentName by using the constructor that has two parameters.
                        StudentName student1 = new StudentName("Craig", "Playstead");

                        // Make the same declaration by using an object initializer and sending
                        // arguments for the first and last names. The default constructor is
                        // invoked in processing this declaration, not the constructor that has
                        // two parameters.
                        StudentName student2 = new StudentName
                        {
                            FirstName = "Craig",
                            LastName = "Playstead",
                        };

                        // Declare a StudentName by using an object initializer and sending
                        // an argument for only the Id property. No corresponding constructor is
                        // necessary. Only the default constructor is used to process object
                        // initializers.
                        StudentName student3 = new StudentName
                        {
                            Id = 183
                        };

                        // Declare a StudentName by using an object initializer and sending
                        // arguments for all three properties. No corresponding constructor is
                        // defined in the class.
                        StudentName student4 = new StudentName
                        {
                            FirstName = "Craig",
                            LastName = "Playstead",
                            Id = 116
                        };

                        System.Console.WriteLine(student1.ToString());
                        System.Console.WriteLine(student2.ToString());
                        System.Console.WriteLine(student3.ToString());
                        System.Console.WriteLine(student4.ToString());
                    }

                    // Output:
                    // Craig  0
                    // Craig  0
                    //   183
                    // Craig  116
                }

                public class StudentName
                {
                    // The default constructor has no parameters. The default constructor
                    // is invoked in the processing of object initializers.
                    // You can test this by changing the access modifier from public to
                    // private. The declarations in Main that use object initializers will
                    // fail.
                    public StudentName() { }

                    // The following constructor has parameters for two of the three
                    // properties.
                    public StudentName(string first, string last)
                    {
                        FirstName = first;
                        LastName = last;
                    }

                    // Properties.
                    public string FirstName { get; set; }
                    public string LastName { get; set; }
                    public int Id { get; set; }

                    public override string ToString()
                    {
                        return FirstName + "  " + Id;
                    }
                }
                //</snippet35>

                //How to: Initialize Objects without Calling a Constructor #2 (C# Programming Guide)
                //<snippet36>
                List<StudentName> students = new List<StudentName>()
                {
                  new StudentName { FirstName = "Craig", LastName = "Playstead", Id = 116 },
                  new StudentName { FirstName = "Shu", LastName="Ito", Id = 112 },
                  new StudentName { FirstName = "Gretchen", LastName="Rivas", Id = 113 },
                  new StudentName { FirstName = "Rajesh", LastName="Rotti", Id = 114 }
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

            //<snippet46>
            // The following code consolidates examples from the topic.
            class ObjInitializers
            {
                //<snippet39>
                class Cat
                {
                    // Auto-implemented properties.
                    public int Age { get; set; }
                    public string Name { get; set; }
                }
                //</snippet39>

                static void Main()
                {
                    //<snippet45>
                    Cat cat = new Cat { Age = 10, Name = "Fluffy" };
                    //</snippet45>

                    //<snippet41>
                    List<Cat> cats = new List<Cat>
                    {
                        new Cat(){ Name = "Sylvester", Age=8 },
                        new Cat(){ Name = "Whiskers", Age=2 },
                        new Cat(){ Name = "Sasha", Age=14 }
                    };
                    //</snippet41>

                    //<snippet42>
                    List<Cat> moreCats = new List<Cat>
                    {
                        new Cat(){ Name = "Furrytail", Age=5 },
                        new Cat(){ Name = "Peaches", Age=4 },
                        null
                    };
                    //</snippet42>

                    // Display results.
                    System.Console.WriteLine(cat.Name);

                    foreach (Cat c in cats)
                        System.Console.WriteLine(c.Name);

                    foreach (Cat c in moreCats)
                        if (c != null)
                            System.Console.WriteLine(c.Name);
                        else
                            System.Console.WriteLine("List element has null value.");
                }
                // Output:
                //Fluffy
                //Sylvester
                //Whiskers
                //Sasha
                //Furrytail
                //Peaches
                //List element has null value.
            }
            //</snippet46>

            class ObjCollInitializers
            {
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

                static void Main()
                {
                    //<snippet43>
                    // i is compiled as an int
                    var i = 5;

                    // s is compiled as a string
                    var s = "Hello";

                    // a is compiled as int[]
                    var a = new[] { 0, 1, 2 };

                    // expr is compiled as IEnumerable<Customer>
                    // or perhaps IQueryable<Customer>
                    var expr =
                        from c in customers
                        where c.City == "London"
                        select c;

                    // anon is compiled as an anonymous type
                    var anon = new { Name = "Terry", Age = 34 };

                    // list is compiled as List<int>
                    var list = new List<int>();
                    //</snippet43>

                    Console.WriteLine(s + i.ToString());
                }
            }

                //<snippet44>
            class ImplicitlyTypedLocals2
            {
                static void Main()
                {
                    string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

                    // If a query produces a sequence of anonymous types,
                    // then use var in the foreach statement to access the properties.
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

            // no snippets from this class yet.

            //<snippet64>
            class CustomJoins
            {

                #region Data

                class Product
                {
                    public string Name { get; set; }
                    public int CategoryId { get; set; }
                }

                class Category
                {
                    public string Name { get; set; }
                    public int Id { get; set; }
                }

                // Specify the first data source.
                List<Category> categories = new List<Category>()
                {
                    new Category() { Name = "Beverages", Id = 001 },
                    new Category() { Name = "Condiments", Id = 002 },
                    new Category() { Name = "Vegetables", Id = 003 },
                };

                // Specify the second data source.
                List<Product> products = new List<Product>()
                {
                    new Product { Name="Tea",  CategoryId = 001 },
                    new Product { Name="Mustard", CategoryId = 002 },
                    new Product { Name="Pickles", CategoryId = 002 },
                    new Product { Name="Carrots", CategoryId = 003 },
                    new Product { Name="Bok Choy", CategoryId = 003 },
                    new Product { Name="Peaches", CategoryId = 005 },
                    new Product { Name="Melons", CategoryId = 005 },
                    new Product { Name="Ice Cream", CategoryId = 007 },
                    new Product { Name="Mackerel", CategoryId = 012 },
                };
                #endregion

                static void Main()
                {
                    CustomJoins app = new CustomJoins();
                    app.CrossJoin();
                    app.NonEquijoin();

                    Console.WriteLine("Press any key to exit.");
                    Console.ReadKey();
                }

                void CrossJoin()
                {
                    var crossJoinQuery =
                        from c in categories
                        from p in products
                        select new { c.Id, p.Name };

                    Console.WriteLine("Cross Join Query:");
                    foreach (var v in crossJoinQuery)
                    {
                        Console.WriteLine("{0,-5}{1}", v.Id, v.Name);
                    }
                }

                void NonEquijoin()
                {
                    var nonEquijoinQuery =
                        from p in products
                        let catIds = from c in categories
                                     select c.Id
                        where catIds.Contains(p.CategoryId) == true
                        select new { Product = p.Name, CategoryId = p.CategoryId };

                    Console.WriteLine("Non-equijoin query:");
                    foreach (var v in nonEquijoinQuery)
                    {
                        Console.WriteLine("{0,-5}{1}", v.CategoryId, v.Product);
                    }
                }
            }
            /* Output:
        Cross Join Query:
        1    Tea
        1    Mustard
        1    Pickles
        1    Carrots
        1    Bok Choy
        1    Peaches
        1    Melons
        1    Ice Cream
        1    Mackerel
        2    Tea
        2    Mustard
        2    Pickles
        2    Carrots
        2    Bok Choy
        2    Peaches
        2    Melons
        2    Ice Cream
        2    Mackerel
        3    Tea
        3    Mustard
        3    Pickles
        3    Carrots
        3    Bok Choy
        3    Peaches
        3    Melons
        3    Ice Cream
        3    Mackerel
        Non-equijoin query:
        1    Tea
        2    Mustard
        2    Pickles
        3    Carrots
        3    Bok Choy
        Press any key to exit.
             */
            //</snippet64>

            //<snippet 66>
            class Test2
            {
                // Func<int, bool> f;

                bool M(Func<double, bool> func, int i)
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
                // QueryMethhod1 returns a query as its value.
                IEnumerable<string> QueryMethod1(ref int[] ints)
                {
                    var intsToStrings = from i in ints
                                        where i > 4
                                        select i.ToString();
                    return intsToStrings;
                }

                // QueryMethod2 returns a query as the value of parameter returnQ.
                void QueryMethod2(ref int[] ints, out IEnumerable<string> returnQ)
                {
                    var intsToStrings = from i in ints
                                        where i < 4
                                        select i.ToString();
                    returnQ = intsToStrings;
                }

                static void Main()
                {
                    MQ app = new MQ();

                    int[] nums = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

                    // QueryMethod1 returns a query as the value of the method.
                    var myQuery1 = app.QueryMethod1(ref nums);

                    // Query myQuery1 is executed in the following foreach loop.
                    Console.WriteLine("Results of executing myQuery1:");
                    // Rest the mouse pointer over myQuery1 to see its type.
                    foreach (string s in myQuery1)
                    {
                        Console.WriteLine(s);
                    }

                    // You also can execute the query returned from QueryMethod1
                    // directly, without using myQuery1.
                    Console.WriteLine("\nResults of executing myQuery1 directly:");
                    // Rest the mouse pointer over the call to QueryMethod1 to see its
                    // return type.
                    foreach (string s in app.QueryMethod1(ref nums))
                    {
                        Console.WriteLine(s);
                    }

                    IEnumerable<string> myQuery2;
                    // QueryMethod2 returns a query as the value of its out parameter.
                    app.QueryMethod2(ref nums, out myQuery2);

                    // Execute the returned query.
                    Console.WriteLine("\nResults of executing myQuery2:");
                    foreach (string s in myQuery2)
                    {
                        Console.WriteLine(s);
                    }

                    // You can modify a query by using query composition. A saved query
                    // is nested inside a new query definition that revises the results
                    // of the first query.
                    myQuery1 = from item in myQuery1
                               orderby item descending
                               select item;

                    // Execute the modified query.
                    Console.WriteLine("\nResults of executing modified myQuery1:");
                    foreach (string s in myQuery1)
                    {
                        Console.WriteLine(s);
                    }

                    // Keep console window open in debug mode.
                    Console.WriteLine("Press any key to exit.");
                    Console.ReadKey();
                }
            }
    //</snippet80>

            //<snippet81>
            class HowToOrderJoins
            {
                #region Data
                class Product
                {
                    public string Name { get; set; }
                    public int CategoryId { get; set; }
                }

                class Category
                {
                    public string Name { get; set; }
                    public int Id { get; set; }
                }

                // Specify the first data source.
                List<Category> categories = new List<Category>()
                {
                    new Category() { Name = "Beverages", Id = 001 },
                    new Category() { Name="Condiments", Id = 002 },
                    new Category() { Name="Vegetables", Id = 003 },
                    new Category() { Name="Grains", Id = 004 },
                    new Category() { Name="Fruit", Id = 005 }
                };

                // Specify the second data source.
                List<Product> products = new List<Product>()
                {
                    new Product{ Name = "Cola", CategoryId = 001 },
                    new Product{ Name = "Tea", CategoryId = 001 },
                    new Product{ Name = "Mustard", CategoryId = 002 },
                    new Product{ Name = "Pickles", CategoryId = 002 },
                    new Product{ Name = "Carrots", CategoryId = 003 },
                    new Product{ Name = "Bok Choy", CategoryId = 003 },
                    new Product{ Name = "Peaches", CategoryId = 005 },
                    new Product{ Name = "Melons", CategoryId = 005 },
                };
                #endregion
                static void Main()
                {
                    HowToOrderJoins app = new HowToOrderJoins();
                    app.OrderJoin1();

                    // Keep console window open in debug mode.
                    Console.WriteLine("Press any key to exit.");
                    Console.ReadKey();
                }

                void OrderJoin1()
                {
                    var groupJoinQuery2 =
                        from category in categories
                        join prod in products on category.Id equals prod.CategoryId into prodGroup
                        orderby category.Name
                        select new
                        {
                            Category = category.Name,
                            Products = from prod2 in prodGroup
                                       orderby prod2.Name
                                       select prod2
                        };

                    foreach (var productGroup in groupJoinQuery2)
                    {
                        Console.WriteLine(productGroup.Category);
                        foreach (var prodItem in productGroup.Products)
                        {
                            Console.WriteLine("  {0,-10} {1}", prodItem.Name, prodItem.CategoryId);
                        }
                    }
                }
                /* Output:
                    Beverages
                      Cola       1
                      Tea        1
                    Condiments
                      Mustard    2
                      Pickles    2
                    Fruit
                      Melons     5
                      Peaches    5
                    Grains
                    Vegetables
                      Bok Choy   3
                      Carrots    3
                 */
            }
            //</snippet81>

            class NullValuesInQueries
            {
                #region Data
                class Product
                {
                    public string Name { get; set; }
                    public int? CategoryId { get; set; }
                }

                class Category
                {
                    public string Name { get; set; }
                    public int? Id { get; set; }
                }

                // Specify the first data source.
                List<Category> categories = new List<Category>()
                {
                    new Category() { Name = "Beverages", Id = 001 },
                    new Category() { Name = "Condiments", Id = 002 },
                    new Category() { Name = "Vegetables", Id = 003 },
                    new Category() { Name = "Grains", Id = 004 },
                    new Category() { Name = "Fruit", Id = 005 }
                };

                // Specify the second data source.
                List<Product> products = new List<Product>()
                {
                    new Product{ Name = "Cola", CategoryId = 001 },
                    new Product{ Name = "Tea", CategoryId = 001 },
                    new Product{ Name = "Mustard", CategoryId = 002 },
                    new Product{ Name = "Pickles", CategoryId = 002 },
                    new Product{ Name = "Carrots", CategoryId = 003 },
                    new Product{ Name = "Bok Choy", CategoryId = 003 },
                    new Product{ Name = "Peaches", CategoryId = 005 },
                    new Product{ Name = "Melons", CategoryId = 005 },
                };
                #endregion

                static void Main()
                {
                    NullValuesInQueries app = new NullValuesInQueries();
                    Northwind db = new Northwind();
                    app.TestMethod(db);
                }

                void NullHandlingQuery()
                {
                    //<snippet82>
                    var query1 =
                        from c in categories
                        where c != null
                        join p in products on c.Id equals
                            (p == null ? null : p.CategoryId)
                        select new { Category = c.Name, Name = p.Name };
                    //</snippet82>
                }

                #region compilation only
                class Order
                {
                    public int? OrderId = 1;
                    public int? EmployeeId = 1;
                }
                class Employee
                {
                    public int EmployeeId = 1;
                    public string FirstName = string.Empty;
                }
                class Northwind
                {
                    public Order[] Orders = null;
                    public Employee[] Employees = null;
                }
                #endregion

                //<snippet83>
                void TestMethod(Northwind db)
                {
                    var query =
                        from o in db.Orders
                        join e in db.Employees
                            on o.EmployeeId equals (int?)e.EmployeeId
                        select new { o.OrderId, e.FirstName };
                }
                //</snippet83>
            }

            //<snippet 84 >
            class DynamicPreds2
            {
                #region Data

                class Product
                {
                    public string Name { get; set; }
                    public int CategoryId { get; set; }
                }

                class Category
                {
                    public string Name { get; set; }
                    public int Id { get; set; }
                }

                // Specify the first data source.
                List<Category> categories = new List<Category>()
                {
                    new Category(){ Name = "Beverages", Id = 001 },
                    new Category(){ Name = "Condiments", Id = 002 },
                    new Category(){ Name = "Vegetables", Id = 003 },
                };

                // Specify the second data source.
                List<Product> products = new List<Product>()
                {
                    new Product{ Name = "Tea", CategoryId = 001 },
                    new Product{ Name = "Mustard", CategoryId = 002 },
                    new Product{ Name = "Pickles", CategoryId = 002 },
                    new Product{ Name = "Carrots", CategoryId = 003 },
                    new Product{ Name = "Bok Choy", CategoryId = 003 },
                    new Product{ Name = "Peaches", CategoryId = 005 },
                    new Product{ Name = "Melons", CategoryId = 005 },
                    new Product{ Name = "Ice Cream", CategoryId = 007 },
                    new Product{ Name = "Mackerel", CategoryId = 012 },
                };
                #endregion

                static void Main()
                {
                    DynamicPreds2 app = new DynamicPreds2();
                    var q = from p in app.products
                            select p;

                    // Identity select
                    Console.WriteLine("First iteration");
                    //foreach(var v in query)
                    //    Console.WriteLine(v.Name);

                    // Mod 1
                    var q2 = from item in q
                             where item.Name[0] == 'M'
                             select item;

                    Console.WriteLine("2nd iteration");
                    foreach (var v in q2)
                        Console.WriteLine(v.Name);

                    //var q3 = from item in

                    // Keep console window open in debug mode.
                    Console.WriteLine("Press any key to exit.");
                    Console.ReadKey();
                }
            }
            //</snippet 84>
}
