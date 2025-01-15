using System.Text;

namespace Coding_Conventions_Examples
{
    class Program
    {
        public static void DelegateExamples()
        {
            //<snippet14a>
            Action<string> actionExample1 = x => Console.WriteLine($"x is: {x}");

            Action<string, string> actionExample2 = (x, y) =>
                Console.WriteLine($"x is: {x}, y is {y}");

            Func<string, int> funcExample1 = x => Convert.ToInt32(x);

            Func<int, int, int> funcExample2 = (x, y) => x + y;
            //</snippet14a>

            //<snippet15a>
            actionExample1("string for x");

            actionExample2("string for x", "string for y");

            Console.WriteLine($"The value is {funcExample1("1")}");

            Console.WriteLine($"The sum is {funcExample2(1, 2)}");
            //</snippet15a>
        }
        //<snippet14b>
        public delegate void Del(string message);

        public static void DelMethod(string str)
        {
            Console.WriteLine("DelMethod argument: {0}", str);
        }
        //</snippet14b>

        static void Main(string[] args)
        {

            //<snippet1>
            var currentPerformanceCounterCategory = new System.Diagnostics.
                PerformanceCounterCategory();
            //</snippet1>

            int startX = 1;
            int endX = 2;
            int previousX = 3;
            //<snippet2>
            if ((startX > endX) && (startX > previousX))
            {
                // Take appropriate action.
            }
            //</snippet2>

            //<snippet3>
            // The following declaration creates a query. It does not run
            // the query.
            //</snippet3>

            // Save snippet 4 and 5 for possible additions in program structure.

            Name[] nameList = [
                new Name { FirstName = "Anderson", LastName = "Redmond" },
                new Name { FirstName = "Jones", LastName = "Seattle" },
                new Name { FirstName = "Anderson", LastName = "Redmond" }
            ];
            int n = 0;

            //<snippet6>
            string displayName = $"{nameList[n].LastName}, {nameList[n].FirstName}";
            //</snippet6>

            Console.WriteLine($"{nameList[n].LastName}, {nameList[n].FirstName}");
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
            var message = "This is clearly a string.";
            var currentTemperature = 27;
            //</snippet8>

            //<snippet9>
            int numberOfIterations = Convert.ToInt32(Console.ReadLine());
            int currentMaximum = ExampleClass.ResultSoFar();
            //</snippet9>

            //<snippet10>
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
            foreach (char ch in laugh)
            {
                if (ch == 'h')
                {
                    Console.Write("H");
                }
                else
                {
                    Console.Write(ch);
                }
            }
            Console.WriteLine();
            //</snippet12>

            //<snippet13>
            string[] vowels = [ "a", "e", "i", "o", "u" ];
            //</snippet13>

            //<snippet15b>
            Del exampleDel2 = DelMethod;
            exampleDel2("Hey");
            //</snippet15b>
            //<snippet15c>
            Del exampleDel1 = new Del(DelMethod);
            exampleDel1("Hey");
            //</snippet15c>


            // #16 is below Main.
            Console.WriteLine(ComputeDistance(1,2,3,4));

            // 17 requires System.Drawing
            //<snippet17a>
            Font bodyStyle = new Font("Arial", 10.0f);
            try
            {
                byte charset = bodyStyle.GdiCharSet;
            }
            finally
            {
                bodyStyle?.Dispose();
            }
            //</snippet17a>
            //<snippet17b>
            using (Font arial = new Font("Arial", 10.0f))
            {
                byte charset2 = arial.GdiCharSet;
            }
            //</snippet17b>
            //<snippet17c>
            using Font normalStyle = new Font("Arial", 10.0f);
            byte charset3 = normalStyle.GdiCharSet;
            //</snippet17c>

            //<snippet18>
            Console.Write("Enter a dividend: ");
            int dividend = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter a divisor: ");
            int divisor = Convert.ToInt32(Console.ReadLine());

            if ((divisor != 0) && (dividend / divisor) is var result)
            {
                Console.WriteLine("Quotient: {0}", result);
            }
            else
            {
                Console.WriteLine("Attempted division by 0 ends up here.");
            }
            //</snippet18>


            //<snippet19>
            var firstExample = new ExampleClass();
            //</snippet19>
            // Can't show `ExampleClass instance1 = new()` because this project targets net48.

            //<snippet20>
            ExampleClass secondExample = new ExampleClass();
            //</snippet20>

            //<snippet21a>
            var thirdExample = new ExampleClass { Name = "Desktop", ID = 37414,
                Location = "Redmond", Age = 2.3 };
            //</snippet21a>
            //<snippet21b>
            var fourthExample = new ExampleClass();
            fourthExample.Name = "Desktop";
            fourthExample.ID = 37414;
            fourthExample.Location = "Redmond";
            fourthExample.Age = 2.3;
            //</snippet21b>

            // #22 and #23 are in Coding_Conventions_WF, below.

            // Save 24 in case we add an example to Static Members.

            ExampleClass.totalInstances = 1;

            List<Customer> Customers = [ new Customer { Name = "Jones", ID = 432, City = "Redmond" } ];

            // Check shop name to use this.
            List<Distributor> Distributors = [ new Distributor { Name = "ShopSmart", ID = 11302, City = "Redmond" } ];

            //<snippet25>
            //<snippet28>
            var seattleCustomers = from customer in Customers
                                   //</snippet28>
                                   where customer.City == "Seattle"
                                   select customer.Name;
            //</snippet25>

            //<snippet26>
            var localDistributors =
                from customer in Customers
                join distributor in Distributors on customer.City equals distributor.City
                select new { Customer = customer, Distributor = distributor };
            //</snippet26>

            //<snippet27>
            var localDistributors2 =
                from customer in Customers
                join distributor in Distributors on customer.City equals distributor.City
                select new { CustomerName = customer.Name, DistributorName = distributor.Name };
            //</snippet27>

            //<snippet29>
            var seattleCustomers2 = from customer in Customers
                                    where customer.City == "Seattle"
                                    orderby customer.Name
                                    select customer;
            //</snippet29>

            // #30 is in class CompoundFrom

            var customerDistributorNames =
                from customer in Customers
                join distributor in Distributors on customer.City equals distributor.City
                select new { CustomerName = customer.Name, DistributorID = distributor.ID };

            var customerDistributorNames2 =
                from customer in Customers
                from distributor in Distributors
                where customer.City == distributor.City
                select new { CustomerName = customer.Name, DistributorID = distributor.ID };

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
        static double ComputeDistance(double x1, double y1, double x2, double y2)
        {
            try
            {
                return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
            }
            catch (System.ArithmeticException ex)
            {
                Console.WriteLine($"Arithmetic overflow or underflow: {ex}");
                throw;
            }
        }
        //</snippet16>
    }

    class Name
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }

    class Distributor
    {
        public static int total;
        public string? Name { get; set; }
        public int ID { get; set; }
        public string? City { get; set; }
    }

    class Customer
    {
        public static int total;
        public string? Name { get; set; }
        public int ID { get; set; }
        public string? City { get; set; }
    }

    class ExampleClass
    {
        public static int totalInstances;
        public string? Name { get; set; }
        public int ID { get; set; }
        public string? Location { get; set; }
        public double Age { get; set; }

        public static int IncrementTotal()
        {
            totalInstances += 1;
            return totalInstances;
        }

        public static int ResultSoFar() => 0;
    }

    class BaseClass
    {
        protected static int totalInstances;

        static BaseClass() => totalInstances = 0;

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
            public string? LastName { get; set; }
            public ICollection<int> Scores { get; set; } = default!;
        }

        static void Main()
        {

            // Use a collection initializer to create the data source. Note that
            // each element in the list contains an inner sequence of scores.
            List<Student> students = [
                new Student {LastName="Omelchenko", Scores = [97, 72, 81, 60]},
                new Student {LastName="O'Donnell", Scores = [75, 84, 91, 39]},
                new Student {LastName="Mortensen", Scores = [88, 94, 65, 85]},
                new Student {LastName="Garcia", Scores = [97, 89, 85, 82]},
                new Student {LastName="Beebe", Scores = [35, 72, 91, 70]}
            ];

            //<snippet30>
            var scoreQuery = from student in students
                             from score in student.Scores
                             where score > 90
                             select new { Last = student.LastName, score };
            //</snippet30>

            // <interpolatedStrings>
            // Execute the queries.
            Console.WriteLine("scoreQuery:");
            foreach (var student in scoreQuery)
            {
                Console.WriteLine($"{student.Last} Score: {student.score}");
            }
            // </interpolatedStrings>

            // <rawStringLiterals>
            var message = """
                This is a long message that spans across multiple lines.
                It uses raw string literals. This means we can 
                also include characters like \n and \t without escaping them.
                """;
            // </rawStringLiterals>
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
        public Form1()
        {
            this.Click += new EventHandler(Form1_Click);
        }

        void Form1_Click(object? sender, EventArgs e)
        {
            MessageBox.Show(((MouseEventArgs)e).Location.ToString());
        }
        //</snippet23>

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}

namespace GenericTypeParameters
{
    public class WrapParameters
    {
        //<TypeParametersOne>
        public interface ISessionChannel<TSession> { /*...*/ }
        public delegate TOutput Converter<TInput, TOutput>(TInput from);
        public class List<T> { /*...*/ }
        //</TypeParametersOne>

        //<TypeParametersTwo>
        public int IComparer<T>() => 0;
        public delegate bool Predicate<T>(T item);
        public struct Nullable<T> where T : struct { /*...*/ }
        //</TypeParametersTwo>

        class wrap
        {
            //<TypeParametersThree>
            public interface ISessionChannel<TSession>
            {
                TSession Session { get; }
            }
            //</TypeParametersThree>
        }
    }//WrapParameters
}

namespace Constructors
{
    // <PrimaryRecord>
    public record Person(string FirstName, string LastName);
    // </PrimaryRecord>

    // <PrimaryClass>
    public class LabelledContainer<T>(string label)
    {
        public string Label { get; } = label;
        public required T Contents 
        { 
            get;
            init;
        }
    }
    // </PrimaryClass>
}
