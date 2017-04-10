using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Coding_Conventions_Examples
{
    class Program
    {
        //<snippet14>
        // First, in class Program, define the delegate type and a method that  
        // has a matching signature.

        // Define the type.
        public delegate void Del(string message);

        // Define a method that has a matching signature.
        public static void DelMethod(string str)
        {
            Console.WriteLine("DelMethod argument: {0}", str);
        }
        //</snippet14>

        static void Main(string[] args)
        {

            //<snippet1>
            var currentPerformanceCounterCategory = new System.Diagnostics.
                PerformanceCounterCategory();
            //</snippet1>


            int val1 = 1;
            int val2 = 2;
            int val3 = 3;
            //<snippet2>
            if ((val1 > val2) && (val1 > val3))
            {
                // Take appropriate action.
            }
            //</snippet2>

            //<snippet3>
            // The following declaration creates a query. It does not run
            // the query.
            //</snippet3>


            // Save snippet 4 and 5 for possible additions in program structure.

            Name[] nameList = {new Name { FirstName = "Anderson", LastName = "Redmond" },
                                 new Name { FirstName = "Jones", LastName = "Seattle" },
                                  new Name { FirstName = "Anderson", LastName = "Redmond" }};
            int n = 0;

            //<snippet6>
            string displayName = nameList[n].LastName + ", " + nameList[n].FirstName;
            //</snippet6>

            Console.WriteLine("{0}, {1}", nameList[n].LastName, nameList[n].FirstName);
            Console.WriteLine(nameList[n].LastName + ", " + nameList[n].FirstName);

            //<snippet7>
            var phrase = "lalalalalalalalalalalalalalalalalalalalalalalalalalalalalala";
            var manyPhrases = new StringBuilder();
            for (var i = 0; i < 10000; i++)
            {
                manyPhrases.Append(phrase);
            }
            //Console.WriteLine("tra" + manyPhrases);
            //</snippet7>

            //<snippet8>
            // When the type of a variable is clear from the context, use var 
            // in the declaration.
            var var1 = "This is clearly a string.";
            var var2 = 27;
            var var3 = Convert.ToInt32(Console.ReadLine());
            //</snippet8>

            //<snippet9>
            // When the type of a variable is not clear from the context, use an
            // explicit type.
            int var4 = ExampleClass.ResultSoFar();
            //</snippet9>

            //<snippet10>
            // Naming the following variable inputInt is misleading. 
            // It is a string.
            var inputInt = Console.ReadLine();
            Console.WriteLine(inputInt);
            //</snippet10>

            //<snippet11>
            var syllable = "ha";
            var laugh = "";
            for (var i = 0; i < 10; i++)
            {
                laugh += syllable;
                Console.WriteLine(laugh);
            }
            //</snippet11>

            //<snippet12>
            foreach (var ch in laugh)
            {
                if (ch == 'h')
                    Console.Write("H");
                else
                    Console.Write(ch);
            }
            Console.WriteLine();
            //</snippet12>

            //<snippet13>
            // Preferred syntax. Note that you cannot use var here instead of string[].
            string[] vowels1 = { "a", "e", "i", "o", "u" };


            // If you use explicit instantiation, you can use var.
            var vowels2 = new string[] { "a", "e", "i", "o", "u" };

            // If you specify an array size, you must initialize the elements one at a time.
            var vowels3 = new string[5];
            vowels3[0] = "a";
            vowels3[1] = "e";
            // And so on.
            //</snippet13>


            //<snippet15>
            // In the Main method, create an instance of Del.

            // Preferred: Create an instance of Del by using condensed syntax.
            Del exampleDel2 = DelMethod;

            // The following declaration uses the full syntax.
            Del exampleDel1 = new Del(DelMethod);
            //</snippet15>

            exampleDel1("Hey");
            exampleDel2(" hey");

            // #16 is below Main.
            Console.WriteLine(GetValueFromArray(vowels1, 1));

            // 17 requires System.Drawing
            //<snippet17>
            // This try-finally statement only calls Dispose in the finally block.
            Font font1 = new Font("Arial", 10.0f);
            try
            {
                byte charset = font1.GdiCharSet;
            }
            finally
            {
                if (font1 != null)
                {
                    ((IDisposable)font1).Dispose();
                }
            }


            // You can do the same thing with a using statement.
            using (Font font2 = new Font("Arial", 10.0f))
            {
                byte charset = font2.GdiCharSet;
            }
            //</snippet17>


            //<snippet18>
            Console.Write("Enter a dividend: ");
            var dividend = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter a divisor: ");
            var divisor = Convert.ToInt32(Console.ReadLine());

            // If the divisor is 0, the second clause in the following condition
            // causes a run-time error. The && operator short circuits when the
            // first expression is false. That is, it does not evaluate the
            // second expression. The & operator evaluates both, and causes 
            // a run-time error when divisor is 0.
            if ((divisor != 0) && (dividend / divisor > 0))
            {
                Console.WriteLine("Quotient: {0}", dividend / divisor);
            }
            else
            {
                Console.WriteLine("Attempted division by 0 ends up here.");
            }
            //</snippet18>

            //<snippet19>
            var instance1 = new ExampleClass();
            //</snippet19>

            //<snippet20>
            ExampleClass instance2 = new ExampleClass();
            //</snippet20>

            //<snippet21>
            // Object initializer.
            var instance3 = new ExampleClass { Name = "Desktop", ID = 37414, 
                Location = "Redmond", Age = 2.3 };

            // Default constructor and assignment statements.
            var instance4 = new ExampleClass();
            instance4.Name = "Desktop";
            instance4.ID = 37414;
            instance4.Location = "Redmond";
            instance4.Age = 2.3;
            //</snippet21>

            // #22 and #23 are in Coding_Conventions_WF, below.

            // Save 24 in case we add an exxample to Static Members.

            ExampleClass.totalInstances = 1;
            

            var customers = new List<Customer> 
            {
              new Customer { Name = "Jones", ID = 432, City = "Redmond" }
            };

            // Check shop name to use this.
            var distributors = new List<Distributor> 
            {
              new Distributor { Name = "ShopSmart", ID = 11302, City = "Redmond" }
            };

            //<snippet25>
            //<snippet28>
            var seattleCustomers = from cust in customers
                                   //</snippet28>
                                   where cust.City == "Seattle"
                                   select cust.Name;
            //</snippet25>

            //<snippet26>
            var localDistributors =
                from customer in customers
                join distributor in distributors on customer.City equals distributor.City
                select new { Customer = customer, Distributor = distributor };
            //</snippet26>

            //<snippet27>
            var localDistributors2 =
                from cust in customers
                join dist in distributors on cust.City equals dist.City
                select new { CustomerName = cust.Name, DistributorID = dist.ID };
            //</snippet27>

            //<snippet29>
            var seattleCustomers2 = from cust in customers
                                    where cust.City == "Seattle"
                                    orderby cust.Name
                                    select cust;
            //</snippet29>

            // #30 is in class CompoundFrom


            var customerDistributorNames =
                from cust in customers
                join dist in distributors on cust.City equals dist.City
                select new { CustomerName = cust.Name, DistributorID = dist.ID };

            var customerDistributorNames2 =
                from cust in customers
                from dist in distributors
                where cust.City == dist.City
                select new { CustomerName = cust.Name, DistributorID = dist.ID };

            foreach (var c in customerDistributorNames)
            {
                Console.WriteLine(c);
            }

            // Could use in Static Members.
            Console.WriteLine(BaseClass.IncrementTotal());
            // Do not do access the static member of the base class through
            // a derived class.
            Console.WriteLine(DerivedClass.IncrementTotal());

            //// Error
            //var instance = new ExampleClass();
            //Console.WriteLine(instance.IncrementTotal());
        }

        //<snippet16>
        static string GetValueFromArray(string[] array, int index)
        {
            try
            {
                return array[index];
            }
            catch (System.IndexOutOfRangeException ex)
            {
                Console.WriteLine("Index is out of range: {0}", index);
                throw;
            }
        }
        //</snippet16>
    }


    class Name
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    class Distributor
    {
        public static int total;
        public string Name { get; set; }
        public int ID { get; set; }
        public string City { get; set; }

    }

    class Customer
    {
        public static int total;
        public string Name { get; set; }
        public int ID { get; set; }
        public string City { get; set; }

    }

    class ExampleClass
    {
        public static int totalInstances;
        public string Name { get; set; }
        public int ID { get; set; }
        public string Location { get; set; }
        public double Age { get; set; }

        public static int IncrementTotal()
        {
            totalInstances += 1;
            return totalInstances;
        }

        public static int ResultSoFar()
        {
            return 0;
        }
    }

    class BaseClass
    {
        protected static int totalInstances;

        static BaseClass()
        {
            totalInstances = 0;
        }

        public static int IncrementTotal()
        {
            totalInstances += 1;
            return totalInstances;
        }
    }

    class DerivedClass : BaseClass
    {

    }

    class CompoundFrom
    {
        // The element type of the data source.
        public class Student
        {
            public string LastName { get; set; }
            public List<int> Scores { get; set; }
        }

        static void Main()
        {

            // Use a collection initializer to create the data source. Note that 
            // each element in the list contains an inner sequence of scores.
            List<Student> students = new List<Student>
        {
           new Student {LastName="Omelchenko", Scores= new List<int> {97, 72, 81, 60}},
           new Student {LastName="O'Donnell", Scores= new List<int> {75, 84, 91, 39}},
           new Student {LastName="Mortensen", Scores= new List<int> {88, 94, 65, 85}},
           new Student {LastName="Garcia", Scores= new List<int> {97, 89, 85, 82}},
           new Student {LastName="Beebe", Scores= new List<int> {35, 72, 91, 70}} 
        };

            //<snippet30>
            // Use a compound from to access the inner sequence within each element.
            var scoreQuery = from student in students
                             from score in student.Scores
                             where score > 90
                             select new { Last = student.LastName, score };
            //</snippet30>

            // Execute the queries.
            Console.WriteLine("scoreQuery:");
            foreach (var student in scoreQuery)
            {
                Console.WriteLine("{0} Score: {1}", student.Last, student.score);
            }

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }

}

namespace Coding_Conventions_WF2
{
    public partial class Form2 : Form
    {
        //<snippet22>
        public Form2()
        {
            // You can use a lambda expression to define an event handler.
            this.Click += (s, e) =>
                {
                    MessageBox.Show(
                        ((MouseEventArgs)e).Location.ToString());
                };
        }
        //</snippet22>

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}


namespace Coding_Conventions_WF2
{
    public partial class Form1 : Form
    {
        //<snippet23>
        // Using a lambda expression shortens the following traditional definition.
        public Form1()
        {
            this.Click += new EventHandler(Form1_Click);
        }

        void Form1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(((MouseEventArgs)e).Location.ToString());
        }
        //</snippet23>

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}