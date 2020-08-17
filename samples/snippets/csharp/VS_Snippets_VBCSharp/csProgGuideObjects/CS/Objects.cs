using System;
using System.Collections.Generic;
using System.Text;

namespace CsCsrefProgrammingObjects
{

    //-----------------------------------------------------------------------------
    //<Snippet1>
    public struct Coords
    {
        public int x, y;

        public Coords(int p1, int p2)
        {
            x = p1;
            y = p2;
        }
    }
    //</Snippet1>

    //-----------------------------------------------------------------------------
    namespace WrapCoords
    {
        //<Snippet4>
        class Coords
        {
            public int x, y;

            // Default constructor.
            public Coords()
            {
                x = 0;
                y = 0;
            }

            //<Snippet76>
            // A constructor with two arguments.
            public Coords(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            //</Snippet76>

            // Override the ToString method.
            public override string ToString()
            {
                return $"({x},{y})";
            }
        }

        class MainClass
        {
            static void Main()
            {
                //<Snippet77>
                var p1 = new Coords();
                var p2 = new Coords(5, 3);
                //</Snippet77>

                // Display the results using the overriden ToString method.
                Console.WriteLine($"Coords #1 at {p1}");
                Console.WriteLine($"Coords #2 at {p2}");
                Console.ReadKey();
            }
        }
        /* Output:
         Coords #1 at (0,0)
         Coords #2 at (5,3)
        */
        //</Snippet4>
    }

    //-----------------------------------------------------------------------------
    namespace WrapCoordsDefaultConstructorOnly
    {
        //<Snippet5>
        class Coords
        {
            public int x, y;

            // constructor
            public Coords()
            {
                x = 0;
                y = 0;
            }
        }
        //</Snippet5>
    }

    //-----------------------------------------------------------------------------
    namespace WrapConstructorCalls
    {
        public class X
        {
            public X(double x, double y)
            {
            }
        }

        class Cylinder : X
        {
            //<Snippet6>
            public Cylinder(double radius, double height)
                : base(radius, height)
            {
            }
            //</Snippet6>
        }
        class Coords
        {
            public Coords(int x, int y)
            {
            }
            //<Snippet7>
            public Coords()
                : this(0, 20)
            {
            }
            //</Snippet7>
        }
    }

    //-----------------------------------------------------------------------------
    namespace WrapPerson3
    {
        //<Snippet84>
    public class Person
    {
        // Field
        public string name;

        // Constructor that takes no arguments.
        public Person()
        {
            name = "unknown";
        }

        // Constructor that takes one argument.
        public Person(string nm)
        {
            name = nm;
        }

        // Method
        public void SetName(string newName)
        {
            name = newName;
        }
    }
    class TestPerson
    {
        static void Main()
        {
            // Call the constructor that has no parameters.
            Person person1 = new Person();
            Console.WriteLine(person1.name);

            person1.SetName("John Smith");
            Console.WriteLine(person1.name);

            // Call the constructor that has one parameter.
            Person person2 = new Person("Sarah Jones");
            Console.WriteLine(person2.name);

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    // Output:
    // unknown
    // John Smith
    // Sarah Jones
        //</Snippet84>
    }

    //-----------------------------------------------------------------------------
    namespace WrapPerson
    {
        //<Snippet8>
        public class Person
        {
            public int age;
            public string name;
        }

        class TestPerson
        {
            static void Main()
            {
                var person = new Person();

                Console.WriteLine("Name: {person.name}, Age: {person.age}");
                // Keep the console window open in debug mode.
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
        // Output:  Name: , Age: 0
        //</Snippet8>
    }

    //-----------------------------------------------------------------------------
    //<Snippet9>
    abstract class Shape
    {
        public const double pi = Math.PI;
        protected double x, y;

        public Shape(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public abstract double Area();
    }

    class Circle : Shape
    {
        public Circle(double radius)
            : base(radius, 0)
        {
        }
        public override double Area()
        {
            return pi * x * x;
        }
    }

    class Cylinder : Circle
    {
        public Cylinder(double radius, double height)
            : base(radius)
        {
            y = height;
        }

        public override double Area()
        {
            return (2 * base.Area()) + (2 * pi * x * y);
        }
    }

    class TestShapes
    {
        static void Main()
        {
            double radius = 2.5;
            double height = 3.0;

            Circle ring = new Circle(radius);
            Cylinder tube = new Cylinder(radius, height);

            Console.WriteLine("Area of the circle = {0:F2}", ring.Area());
            Console.WriteLine("Area of the cylinder = {0:F2}", tube.Area());

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    /* Output:
        Area of the circle = 19.63
        Area of the cylinder = 86.39
    */
    //</Snippet9>

    namespace WrapShapeAndCircle
    {
        abstract class Shape
        {
            protected double x, y;

            public Shape(double x, double y)
            {
                this.x = x;
                this.y = y;
            }
        }

        //<Snippet78>
        class Circle : Shape
        {
            public Circle(double radius)
                : base(radius, 0)
            {
            }
        }
        //</Snippet78>
    }

    //-----------------------------------------------------------------------------
    //This snippet used by more than one topic
    //<Snippet11>
    class NLog
    {
        // Private Constructor:
        private NLog() { }

        public static double e = Math.E;  //2.71828...
    }
    //</Snippet11>

    //-----------------------------------------------------------------------------
    //<Snippet12>
    public class Counter
    {
        private Counter() { }
        public static int currentCount;
        public static int IncrementCount()
        {
            return ++currentCount;
        }
    }

    class TestCounter
    {
        static void Main()
        {
            // If you uncomment the following statement, it will generate
            // an error because the constructor is inaccessible:
            //<Snippet13>
            // Counter aCounter = new Counter();   // Error
            //</Snippet13>

            Counter.currentCount = 100;
            Counter.IncrementCount();
            Console.WriteLine("New count: {0}", Counter.currentCount);

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    // Output: New count: 101
    //</Snippet12>

    //-----------------------------------------------------------------------------
    //<Snippet14>
    class SimpleClass
    {
        // Static variable that must be initialized at run time.
        static readonly long baseline;

        // Static constructor is called at most one time, before any
        // instance constructor is invoked or member is accessed.
        static SimpleClass()
        {
            baseline = DateTime.Now.Ticks;
        }
    }
    //</Snippet14>

    //-----------------------------------------------------------------------------
    //<Snippet15>
    public class Bus
    {
        // Static variable used by all Bus instances.
        // Represents the time the first bus of the day starts its route.
        protected static readonly DateTime globalStartTime;

        // Property for the number of each bus.
        protected int RouteNumber { get; set; }

        // Static constructor to initialize the static variable.
        // It is invoked before the first instance constructor is run.
        static Bus()
        {
            globalStartTime = DateTime.Now;

            // The following statement produces the first line of output,
            // and the line occurs only once.
            Console.WriteLine("Static constructor sets global start time to {0}",
                globalStartTime.ToLongTimeString());
        }

        // Instance constructor.
        public Bus(int routeNum)
        {
            RouteNumber = routeNum;
            Console.WriteLine("Bus #{0} is created.", RouteNumber);
        }

        // Instance method.
        public void Drive()
        {
            TimeSpan elapsedTime = DateTime.Now - globalStartTime;

            // For demonstration purposes we treat milliseconds as minutes to simulate
            // actual bus times. Do not do this in your actual bus schedule program!
            Console.WriteLine("{0} is starting its route {1:N2} minutes after global start time {2}.",
                                    this.RouteNumber,
                                    elapsedTime.Milliseconds,
                                    globalStartTime.ToShortTimeString());
        }
    }

    class TestBus
    {
        static void Main()
        {
            // The creation of this instance activates the static constructor.
            Bus bus1 = new Bus(71);

            // Create a second bus.
            Bus bus2 = new Bus(72);

            // Send bus1 on its way.
            bus1.Drive();

            // Wait for bus2 to warm up.
            System.Threading.Thread.Sleep(25);

            // Send bus2 on its way.
            bus2.Drive();

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
    /* Sample output:
        Static constructor sets global start time to 3:57:08 PM.
        Bus #71 is created.
        Bus #72 is created.
        71 is starting its route 6.00 minutes after global start time 3:57 PM.
        72 is starting its route 31.00 minutes after global start time 3:57 PM.
   */
    //</Snippet15>

    //-----------------------------------------------------------------------------
    //<Snippet16>
class Person
{
    // Copy constructor.
    public Person(Person previousPerson)
    {
        Name = previousPerson.Name;
        Age = previousPerson.Age;
    }

    //// Alternate copy constructor calls the instance constructor.
    //public Person(Person previousPerson)
    //    : this(previousPerson.Name, previousPerson.Age)
    //{
    //}

    // Instance constructor.
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public int Age { get; set; }

    public string Name { get; set; }

    public string Details()
    {
        return Name + " is " + Age.ToString();
    }
}

class TestPerson
{
    static void Main()
    {
        // Create a Person object by using the instance constructor.
        Person person1 = new Person("George", 40);

        // Create another Person object, copying person1.
        Person person2 = new Person(person1);

        // Change each person's age.
        person1.Age = 39;
        person2.Age = 41;

        // Change person2's name.
        person2.Name = "Charles";

        // Show details to verify that the name and age fields are distinct.
        Console.WriteLine(person1.Details());
        Console.WriteLine(person2.Details());

        // Keep the console window open in debug mode.
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}
// Output:
// George is 39
// Charles is 41
    //</Snippet16>

    //-----------------------------------------------------------------------------
    namespace WrapCoords2
    {
        //<Snippet17>
        public partial class Coords
        {
            private int x;
            private int y;

            public Coords(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public partial class Coords
        {
            public void PrintCoords()
            {
                Console.WriteLine("Coords: {0},{1}", x, y);
            }
        }

        class TestCoords
        {
            static void Main()
            {
                Coords myCoords = new Coords(10, 15);
                myCoords.PrintCoords();

                // Keep the console window open in debug mode.
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
        // Output: Coords: 10,15
        //</Snippet17>
    }

    //-----------------------------------------------------------------------------
    //<Snippet18>
    partial interface ITest
    {
        void Interface_Test();
    }

    partial interface ITest
    {
        void Interface_Test2();
    }

    partial struct S1
    {
        void Struct_Test() { }
    }

    partial struct S1
    {
        void Struct_Test2() { }
    }
    //</Snippet18>

    //-----------------------------------------------------------------------------
    //<Snippet19>
    partial class ClassWithNestedClass
    {
        partial class NestedClass { }
    }

    partial class ClassWithNestedClass
    {
        partial class NestedClass { }
    }
    //</Snippet19>

    //-----------------------------------------------------------------------------
    //<Snippet20>
    public partial class A { }
    //public class A { }  // Error, must also be marked partial
    //</Snippet20>

    //-----------------------------------------------------------------------------
    class Planet { }
    interface IRotate { }
    interface IRevolve { }

    //<Snippet21>
    partial class Earth : Planet, IRotate { }
    partial class Earth : IRevolve { }
    //</Snippet21>

    //<Snippet23>
    [SerializableAttribute]
    partial class Moon { }

    [ObsoleteAttribute]
    partial class Moon { }
    //</Snippet23>

    class WrapEquivs
    {
        //<Snippet22>
        class Earth : Planet, IRotate, IRevolve { }
        //</Snippet22>

        //<Snippet24>
        [SerializableAttribute]
        [ObsoleteAttribute]
        class Moon { }
        //</Snippet24>
    }

    //<Snippet25>
    class Container
    {
        partial class Nested
        {
            void Test() { }
        }
        partial class Nested
        {
            void Test2() { }
        }
    }
    //</Snippet25>

    //<Snippet26>
    public partial class Employee
    {
        public void DoWork()
        {
        }
    }

    public partial class Employee
    {
        public void GoToLunch()
        {
        }
    }
    //</Snippet26>

    //-----------------------------------------------------------------------------
    //<Snippet27>
    class CompanyInfo
    {
        public string GetCompanyName() { return "CompanyName"; }
        public string GetCompanyAddress() { return "CompanyAddress"; }
        //...
    }
    //</Snippet27>

    namespace WrapCompanyInfo
    {
        //<Snippet28>
        static class CompanyInfo
        {
            public static string GetCompanyName() { return "CompanyName"; }
            public static string GetCompanyAddress() { return "CompanyAddress"; }
            //...
        }
        //</Snippet28>	
    }

    //-----------------------------------------------------------------------------
    public delegate void EventType();

    //<Snippet29>
    public class Automobile
    {
        public static int NumberOfWheels = 4;
        public static int SizeOfGasTank
        {
            get
            {
                return 15;
            }
        }
        public static void Drive() { }
        public static event EventType RunOutOfGas;

        // Other non-static fields and properties...
    }
    //</Snippet29>

    class TestAutomobile
    {
        void Test()
        {
            //<Snippet30>
            Automobile.Drive();
            int i = Automobile.NumberOfWheels;
            //</Snippet30>
        }
    }

    //-----------------------------------------------------------------------------
    //<Snippet31>
    public static class TemperatureConverter
    {
        public static double CelsiusToFahrenheit(string temperatureCelsius)
        {
            // Convert argument to double for calculations.
            double celsius = Double.Parse(temperatureCelsius);

            // Convert Celsius to Fahrenheit.
            double fahrenheit = (celsius * 9 / 5) + 32;

            return fahrenheit;
        }

        public static double FahrenheitToCelsius(string temperatureFahrenheit)
        {
            // Convert argument to double for calculations.
            double fahrenheit = Double.Parse(temperatureFahrenheit);

            // Convert Fahrenheit to Celsius.
            double celsius = (fahrenheit - 32) * 5 / 9;

            return celsius;
        }
    }

    class TestTemperatureConverter
    {
        static void Main()
        {
            Console.WriteLine("Please select the convertor direction");
            Console.WriteLine("1. From Celsius to Fahrenheit.");
            Console.WriteLine("2. From Fahrenheit to Celsius.");
            Console.Write(":");

            string selection = Console.ReadLine();
            double F, C = 0;

            switch (selection)
            {
                case "1":
                    Console.Write("Please enter the Celsius temperature: ");
                    F = TemperatureConverter.CelsiusToFahrenheit(Console.ReadLine());
                    Console.WriteLine("Temperature in Fahrenheit: {0:F2}", F);
                    break;

                case "2":
                    Console.Write("Please enter the Fahrenheit temperature: ");
                    C = TemperatureConverter.FahrenheitToCelsius(Console.ReadLine());
                    Console.WriteLine("Temperature in Celsius: {0:F2}", C);
                    break;

                default:
                    Console.WriteLine("Please select a convertor.");
                    break;
            }

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    /* Example Output:
        Please select the convertor direction
        1. From Celsius to Fahrenheit.
        2. From Fahrenheit to Celsius.
        :2
        Please enter the Fahrenheit temperature: 20
        Temperature in Celsius: -6.67
        Press any key to exit.
     */
    //</Snippet31>

    //-----------------------------------------------------------------------------
    //<Snippet32>
    class TheClass
    {
        public string willIChange;
    }

    struct TheStruct
    {
        public string willIChange;
    }

    class TestClassAndStruct
    {
        static void ClassTaker(TheClass c)
        {
            c.willIChange = "Changed";
        }

        static void StructTaker(TheStruct s)
        {
            s.willIChange = "Changed";
        }

        static void Main()
        {
            TheClass testClass = new TheClass();
            TheStruct testStruct = new TheStruct();

            testClass.willIChange = "Not Changed";
            testStruct.willIChange = "Not Changed";

            ClassTaker(testClass);
            StructTaker(testStruct);

            Console.WriteLine("Class field = {0}", testClass.willIChange);
            Console.WriteLine("Struct field = {0}", testStruct.willIChange);

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    /* Output:
        Class field = Changed
        Struct field = Not Changed
    */
    //</Snippet32>

    //-----------------------------------------------------------------------------
    namespace WrapPerson2
    {
        //<Snippet33>
        class Person
        {
            private string _name = "N/A";
            private int _age = 0;

            // Declare a Name property of type string:
            //<Snippet34>
            public string Name
            {
                get
                {
                    return _name;
                }
                set
                {
                    //<Snippet36>
                    _name = value;
                    //</Snippet36>
                }
            }
            //</Snippet34>

            // Declare an Age property of type int:
            public int Age
            {
                get
                {
                    return _age;
                }

                set
                {
                    _age = value;
                }
            }

            //<Snippet38>
            public override string ToString()
            {
                return "Name = " + Name + ", Age = " + Age;
            }
            //</Snippet38>
        }

        class TestPerson
        {
            static void Main()
            {
                // Create a new Person object:
                Person person = new Person();

                // Print out the name and the age associated with the person:
                Console.WriteLine("Person details - {0}", person);

                // Set some values on the person object:
                //<Snippet35>
                person.Name = "Joe";
                person.Age = 99;
                //</Snippet35>
                Console.WriteLine("Person details - {0}", person);

                // Increment the Age property:
                //<Snippet37>
                person.Age += 1;
                //</Snippet37>
                Console.WriteLine("Person details - {0}", person);

                // Keep the console window open in debug mode.
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
        /* Output:
            Person details - Name = N/A, Age = 0
            Person details - Name = Joe, Age = 99
            Person details - Name = Joe, Age = 100
        */
        //</Snippet33>
    }

    //-----------------------------------------------------------------------------
    namespace WrapPerson4
    {
        class Person
        {
            private string _name = "N/A";

            //<Snippet87>
            public string Name
            {
                get
                {
                    return _name;
                }
            }
            //</Snippet87>
        }
    }

    //-----------------------------------------------------------------------------
    //<Snippet79>
    public class Customer
    {
        //Fields, properties, methods and events go here...
    }
    //</Snippet79>

    class Test
    {
        static void Main()
        {
            //<Snippet80>
            Customer object1 = new Customer();
            //</Snippet80>

            //<Snippet81>
            Customer object2;
            //</Snippet81>

            object2 = object1;

            //<Snippet82>
            Customer object3 = new Customer();
            Customer object4 = object3;
            //</Snippet82>
        }
    }

    //-----------------------------------------------------------------------------
    //<Snippet83>
    public class Manager : Employee
    {
        // Employee fields, properties, methods and events are inherited
        // New Manager fields, properties, methods and events go here...
    }
    //</Snippet83>

    //-----------------------------------------------------------------------------
    //<Snippet40>
    abstract class Motorcycle
    {
        // Anyone can call this.
        public void StartEngine() {/* Method statements here */ }

        // Only derived classes can call this.
        protected void AddGas(int gallons) { /* Method statements here */ }

        // Derived classes can override the base class implementation.
        public virtual int Drive(int miles, int speed) { /* Method statements here */ return 1; }

        // Derived classes must implement this.
        public abstract double GetTopSpeed();
    }
    //</Snippet40>

    //<Snippet41>
    class TestMotorcycle : Motorcycle
    {

        public override double GetTopSpeed()
        {
            return 108.4;
        }

        static void Main()
        {

            TestMotorcycle moto = new TestMotorcycle();

            moto.StartEngine();
            moto.AddGas(15);
            moto.Drive(5, 20);
            double speed = moto.GetTopSpeed();
            Console.WriteLine("My top speed is {0}", speed);
        }
    }
    //</Snippet41>

    public class ParameterClass
    {
        //<Snippet74>
        public void Caller()
        {
            int numA = 4;
            // Call with an int variable.
            int productA = Square(numA);

            int numB = 32;
            // Call with another int variable.
            int productB = Square(numB);

            // Call with an integer literal.
            int productC = Square(12);

            // Call with an expression that evaulates to int.
            productC = Square(productA * 3);
        }

        int Square(int i)
        {
            // Store input argument in a local variable.
            int input = i;
            return input * input;
        }
        //</Snippet74>
    }

    //-----------------------------------------------------------------------------
    //<Snippet42>
    public class SampleRefType
    {
        public int value;
    }
    //</Snippet42>

    public class TestRefTypeClass
    {
        //<Snippet75>
        public static void TestRefType()
        {
            SampleRefType rt = new SampleRefType();
            rt.value = 44;
            ModifyObject(rt);
            Console.WriteLine(rt.value);
        }
        static void ModifyObject(SampleRefType obj)
        {
            obj.value = 33;
        }
        //</Snippet75>
    }

    //<Snippet43>
    class ParameterDemo2
    {
        int number;
        void Method(int number)
        {
            this.number = number;
        }
    }
    //</Snippet43>

    //<Snippet44>
    class SimpleMath
    {
        public int AddTwoNumbers(int number1, int number2)
        {
            return number1 + number2;
        }

        public int SquareANumber(int number)
        {
            return number * number;
        }
    }
    //</Snippet44>

    class TestSimpleMath
    {
        static void test()
        {
            SimpleMath obj = new SimpleMath();

            //<Snippet45>
            int result = obj.AddTwoNumbers(1, 2);
            result = obj.SquareANumber(result);
            // The result is 9.
            Console.WriteLine(result);
            //</Snippet45>

            //<Snippet46>
            result = obj.SquareANumber(obj.AddTwoNumbers(1, 2));
            // The result is 9.
            Console.WriteLine(result);
            //</Snippet46>
        }
    }

    class TestParamKeywords
    {
        //<Snippet47>
        static void TestRef(ref char i) { }
        //</Snippet47>

        //<Snippet49>
        static void TestOut(out char i) { i = 'z'; }
        //</Snippet49>

        //<Snippet51>
        static void UseParams(params int[] list) { }
        //</Snippet51>

        void Test()
        {
            char i = 'a';

            //<Snippet48>
            TestRef(ref i);
            //</Snippet48>

            //<Snippet50>
            TestOut(out i);
            //</Snippet50>

            //<Snippet52>
            int[] myarray = new int[3] { 10, 11, 12 };

            UseParams(1, 2, 3);
            UseParams(myarray);
            UseParams();
            //</Snippet52>
        }
    }

    //-----------------------------------------------------------------------------
    //<Snippet53>
    public class Taxi
    {
        public bool IsInitialized;
        public Taxi()
        {
            IsInitialized = true;
        }
    }

    class TestTaxi
    {
        static void Main()
        {
            Taxi t = new Taxi();
            Console.WriteLine(t.IsInitialized);
        }
    }
    //</Snippet53>

    //-----------------------------------------------------------------------------
    namespace WrapEmployee
    {
        //<Snippet54>
        public class Employee
        {
            public int Salary;

            //<Snippet60>
            public Employee(int annualSalary)
            {
                Salary = annualSalary;
            }
            //</Snippet60>

            public Employee(int weeklySalary, int numberOfWeeks)
            {
                Salary = weeklySalary * numberOfWeeks;
            }
        }
        //</Snippet54>

        class TestEmployee
        {
            static void test()
            {
                //<Snippet55>
                Employee e1 = new Employee(30000);
                Employee e2 = new Employee(500, 52);
                //</Snippet55>
            }
        }

        //<Snippet56>
        public class Manager : Employee
        {
            public Manager(int annualSalary)
                : base(annualSalary)
            {
                //Add further instructions here.
            }
        }
        //</Snippet56>

        class WrapEmployeeAndManager
        {
            public class Employee
            {
                public Employee() { }
                public Employee(int annualSalary) { }

                //<Snippet59>
                public Employee(int weeklySalary, int numberOfWeeks)
                    : this(weeklySalary * numberOfWeeks)
                {
                }
                //</Snippet59>
            }

            public class Manager : Employee
            {
                //<Snippet58>
                public Manager(int initialData)
                {
                    //Add further instructions here.
                }
                //</Snippet58>
            }
        }

        class WrapEmployeeAndManagerAgain
        {
            public class Employee
            {
            }

            public class Manager : Employee
            {
                //<Snippet57>
                public Manager(int initialData)
                    : base()
                {
                    //Add further instructions here.
                }
                //</Snippet57>
            }
        }
    }

    //-----------------------------------------------------------------------------
    //<Snippet61>
    public class CalendarEntry
    {
        // private field
        private DateTime date;

        // public field (Generally not recommended.)
        public string day;

        // Public property exposes date field safely.
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                // Set some reasonable boundaries for likely birth dates.
                if (value.Year > 1900 && value.Year <= DateTime.Today.Year)
                {
                    date = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        // Public method also exposes date field safely.
        // Example call: birthday.SetDate("1975, 6, 30");
        public void SetDate(string dateString)
        {
            DateTime dt = Convert.ToDateTime(dateString);

            // Set some reasonable boundaries for likely birth dates.
            if (dt.Year > 1900 && dt.Year <= DateTime.Today.Year)
            {
                date = dt;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public TimeSpan GetTimeSpan(string dateString)
        {
            DateTime dt = Convert.ToDateTime(dateString);

            if (dt != null && dt.Ticks < date.Ticks)
            {
                return date - dt;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
    //</Snippet61>

    class TestCalendarDate
    {
        static void test()
        {
            //<Snippet62>
            CalendarEntry birthday = new CalendarEntry();
            birthday.day = "Saturday";
            //</Snippet62>
        }
    }

    //<Snippet63>
    public class CalendarDateWithInitialization
    {
        public string day = "Monday";
        //...
    }
    //</Snippet63>

    //<Snippet64>
    class Calendar1
    {
        public const int Months = 12;
    }
    //</Snippet64>

    //<Snippet65>
    class Calendar2
    {
        public const int Months = 12, Weeks = 52, Days = 365;
    }
    //</Snippet65>

    //<Snippet66>
    class Calendar3
    {
        public const int Months = 12;
        public const int Weeks = 52;
        public const int Days = 365;

        public const double DaysPerWeek = (double) Days / (double) Weeks;
        public const double DaysPerMonth = (double) Days / (double) Months;
    }
    //</Snippet66>

    class Calendar
    {
        public const int Months = 12;

        static void test()
        {
            //<Snippet67>
            int birthstones = Calendar.Months;
            //</Snippet67>

            Console.WriteLine(birthstones.ToString());
        }
    }

    //-----------------------------------------------------------------------------
    //<Snippet85>
    class First
    {
        ~First()
        {
            System.Diagnostics.Trace.WriteLine("First's destructor is called.");
        }
    }

    class Second : First
    {
        ~Second()
        {
            System.Diagnostics.Trace.WriteLine("Second's destructor is called.");
        }
    }

    class Third : Second
    {
        ~Third()
        {
            System.Diagnostics.Trace.WriteLine("Third's destructor is called.");
        }
    }

    class TestDestructors
    {
        static void Main()
        {
            Third t = new Third();
        }
    }
    /* Output (to VS Output Window):
        Third's destructor is called.
        Second's destructor is called.
        First's destructor is called.
    */
    //</Snippet85>

    //-----------------------------------------------------------------------------
    //<Snippet86>
    class Car
    {
        ~Car()  // finalizer
        {
            // cleanup statements...
        }
    }
    //</Snippet86>

    //<snippet88>
    namespace ProgrammingGuide
    {
        // Class definition.
        public class MyCustomClass
        {
            // Class members:
            // Property.
            public int Number { get; set; }

            // Method.
            public int Multiply(int num)
            {
                return num * Number;
            }

            // Instance Constructor.
            public MyCustomClass()
            {
                Number = 0;
            }
        }
        // Another class definition. This one contains
        // the Main method, the entry point for the program.
        class Program
        {
            static void Main(string[] args)
            {
                // Create an object of type MyCustomClass.
                MyCustomClass myClass = new MyCustomClass();

                // Set the value of a public property.
                myClass.Number = 27;

                // Call a public method.
                int result = myClass.Multiply(4);
            }
        }
    }

    //</snippet88>
}

namespace RainyDay
{
    using System;

    //<Snippet89>
    static class Constants
    {
        public const double Pi = 3.14159;
        public const int SpeedOfLight = 300000; // km per sec.
    }
    class Program
    {
        static void Main()
        {
            double radius = 5.3;
            double area = Constants.Pi * (radius * radius);
            int secsFromSun = 149476000 / Constants.SpeedOfLight; // in km
        }
    }
   //</Snippet89>

    //<Snippet90>
    namespace TestReferenceEquality
    {
        struct TestStruct
        {
            public int Num { get; private set; }
            public string Name { get; private set; }

            public TestStruct(int i, string s) : this()
            {
                Num = i;
                Name = s;
            }
        }

        class TestClass
        {
            public int Num { get; set; }
            public string Name { get; set; }
        }

        class Program
        {
            static void Main()
            {
                // Demonstrate reference equality with reference types.
                #region ReferenceTypes

                // Create two reference type instances that have identical values.
                TestClass tcA = new TestClass() { Num = 1, Name = "New TestClass" };
                TestClass tcB = new TestClass() { Num = 1, Name = "New TestClass" };

                Console.WriteLine("ReferenceEquals(tcA, tcB) = {0}",
                                    Object.ReferenceEquals(tcA, tcB)); // false

                // After assignment, tcB and tcA refer to the same object.
                // They now have reference equality.
                tcB = tcA;
                Console.WriteLine("After assignment: ReferenceEquals(tcA, tcB) = {0}",
                                    Object.ReferenceEquals(tcA, tcB)); // true

                // Changes made to tcA are reflected in tcB. Therefore, objects
                // that have reference equality also have value equality.
                tcA.Num = 42;
                tcA.Name = "TestClass 42";
                Console.WriteLine("tcB.Name = {0} tcB.Num: {1}", tcB.Name, tcB.Num);
                #endregion

                // Demonstrate that two value type instances never have reference equality.
                #region ValueTypes

                TestStruct tsC = new TestStruct( 1, "TestStruct 1");

                // Value types are copied on assignment. tsD and tsC have
                // the same values but are not the same object.
                TestStruct tsD = tsC;
                Console.WriteLine("After assignment: ReferenceEquals(tsC, tsD) = {0}",
                                    Object.ReferenceEquals(tsC, tsD)); // false
                #endregion

                #region stringRefEquality
                // Constant strings within the same assembly are always interned by the runtime.
                // This means they are stored in the same location in memory. Therefore,
                // the two strings have reference equality although no assignment takes place.
                string strA = "Hello world!";
                string strB = "Hello world!";
                Console.WriteLine("ReferenceEquals(strA, strB) = {0}",
                                 Object.ReferenceEquals(strA, strB)); // true

                // After a new string is assigned to strA, strA and strB
                // are no longer interned and no longer have reference equality.
                strA = "Goodbye world!";
                Console.WriteLine("strA = \"{0}\" strB = \"{1}\"", strA, strB);

                Console.WriteLine("After strA changes, ReferenceEquals(strA, strB) = {0}",
                                Object.ReferenceEquals(strA, strB)); // false

                // A string that is created at runtime cannot be interned.
                StringBuilder sb = new StringBuilder("Hello world!");
                string stringC = sb.ToString();
                // False:
                Console.WriteLine("ReferenceEquals(stringC, strB) = {0}",
                                Object.ReferenceEquals(stringC, strB));

                // The string class overloads the == operator to perform an equality comparison.
                Console.WriteLine("stringC == strB = {0}", stringC == strB); // true

                #endregion

                // Keep the console open in debug mode.
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
    }

    /* Output:
        ReferenceEquals(tcA, tcB) = False
        After assignment: ReferenceEquals(tcA, tcB) = True
        tcB.Name = TestClass 42 tcB.Num: 42
        After assignment: ReferenceEquals(tsC, tsD) = False
        ReferenceEquals(strA, strB) = True
        strA = "Goodbye world!" strB = "Hello world!"
        After strA changes, ReferenceEquals(strA, strB) = False
    */
    //</Snippet90>

    class RD
    {
        static void Main()
        {

            //<Snippet91>
            Console.WriteLine("Saving for a rainy day");
            //</Snippet91>
            //<Snippet92>
            Console.WriteLine("Saving for a rainy day");
            //</Snippet92>
            //<Snippet93>
            Console.WriteLine("Saving for a rainy day");
            //</Snippet93>
            //<Snippet94>
            Console.WriteLine("Saving for a rainy day");
            //</Snippet94>
            //<Snippet95>
            Console.WriteLine("Saving for a rainy day");
            //</Snippet95>
            //<Snippet96>
            Console.WriteLine("Saving for a rainy day");
            //</Snippet96>

            //<Snippet97>
            Console.WriteLine("Saving for a rainy day");
            //</Snippet97>
            //<Snippet98>
            Console.WriteLine("Saving for a rainy day");
            //</Snippet98>
        }
    }
}
