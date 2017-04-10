
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//for #8
using System.Runtime.InteropServices;

namespace csrefKeywordsModifiers
{
    //<snippet1>
    
    abstract class ShapesClass
    {
        abstract public int Area();
    }
    class Square : ShapesClass
    {
        int side = 0;

        public Square(int n)
        {
            side = n;
        }
        // Area method is required to avoid
        // a compile-time error.
        public override int Area()
        {
            return side * side;
        }

        static void Main() 
        {
            Square sq = new Square(12);
            Console.WriteLine("Area of the square = {0}", sq.Area());
        }

        //<snippet2>        
        interface I
        {
            void M();
        }
        abstract class C : I
        {
            public abstract void M();
        }
        //</snippet2>

    }
    // Output: Area of the square = 144
    //</snippet1>

    //<snippet3>
    abstract class BaseClass   // Abstract class
    {
        protected int _x = 100;
        protected int _y = 150;
        public abstract void AbstractMethod();   // Abstract method
        public abstract int X    { get; }
        public abstract int Y    { get; }
    }

    class DerivedClass : BaseClass
    {
        public override void AbstractMethod()
        {
            _x++;
            _y++;
        }

        public override int X   // overriding property
        {
            get
            {
                return _x + 10;
            }
        }

        public override int Y   // overriding property
        {
            get
            {
                return _y + 10;
            }
        }

        static void Main()
        {
            DerivedClass o = new DerivedClass();
            o.AbstractMethod();
            Console.WriteLine("x = {0}, y = {1}", o.X, o.Y);
        }
    }
    // Output: x = 111, y = 161

    //</snippet3>

}

//<snippet4>

namespace AccessibilityDomainNamespace
{
    public class T1
    {
        public static int publicInt;
        internal static int internalInt;
        private static int privateInt = 0;
        static T1()
        {
            // T1 can access public or internal members
            // in a public or private (or internal) nested class
            M1.publicInt = 1;
            M1.internalInt = 2;
            M2.publicInt = 3;
            M2.internalInt = 4;

            // Cannot access the private member privateInt
            // in either class:
            // M1.privateInt = 2; //CS0122
        }

        public class M1
        {
            public static int publicInt;
            internal static int internalInt;
            private static int privateInt = 0;
        }

        private class M2
        {
            public static int publicInt = 0;
            internal static int internalInt = 0;
            private static int privateInt = 0;
        }
    }

    class MainClass
    {
        static void Main()
        {
            // Access is unlimited:
            T1.publicInt = 1;

            // Accessible only in current assembly:
            T1.internalInt = 2;

            // Error CS0122: inaccessible outside T1:
            // T1.privateInt = 3;  

            // Access is unlimited:
            T1.M1.publicInt = 1;

            // Accessible only in current assembly:
            T1.M1.internalInt = 2;

            // Error CS0122: inaccessible outside M1:
            //    T1.M1.privateInt = 3; 

            // Error CS0122: inaccessible outside T1:
            //    T1.M2.publicInt = 1;

            // Error CS0122: inaccessible outside T1:
            //    T1.M2.internalInt = 2;

            // Error CS0122: inaccessible outside M2:
            //    T1.M2.privateInt = 3;



            // Keep the console open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();

        }
    }
}
//</snippet4>

namespace csrefKeywordsModifiers
{
    //<snippet5>       
    public class ConstTest 
    {
        class SampleClass 
        {
            public int x;
            public int y;
            public const int c1 = 5;
            public const int c2 = c1 + 5;

            public SampleClass(int p1, int p2) 
            {
                x = p1; 
                y = p2;
            }
        }

        static void Main() 
        {
            SampleClass mC = new SampleClass(11, 22);   
            Console.WriteLine("x = {0}, y = {1}", mC.x, mC.y);
            Console.WriteLine("c1 = {0}, c2 = {1}", 
                              SampleClass.c1, SampleClass.c2 );
        }
    }
    /* Output
        x = 11, y = 22
        c1 = 5, c2 = 10
     */
     //</snippet5>

    //<snippet6>
    public class SealedTest
    {
        static void Main()
        {
            const int c = 707;
            Console.WriteLine("My local constant = {0}", c);
        }
    }
    // Output: My local constant = 707
    //</snippet6>

    //<snippet7>

    public class SampleEventArgs
    {
        public SampleEventArgs(string s) { Text = s; }
        public String Text {get; private set;} // readonly
    }
    public class Publisher
    {
        // Declare the delegate (if using non-generic pattern).
        public delegate void SampleEventHandler(object sender, SampleEventArgs e);

        // Declare the event.
        public event SampleEventHandler SampleEvent;

        // Wrap the event in a protected virtual method
        // to enable derived classes to raise the event.
        protected virtual void RaiseSampleEvent()
        {
            // Raise the event by using the () operator.
            if (SampleEvent != null)
                SampleEvent(this, new SampleEventArgs("Hello"));
        }
    }

    //</snippet7>

    //<snippet8>
    //using System.Runtime.InteropServices;
    class ExternTest
    {
        [DllImport("User32.dll", CharSet=CharSet.Unicode)] 
        public static extern int MessageBox(IntPtr h, string m, string c, int type);

        static int Main()
        {
            string myString;
            Console.Write("Enter your message: ");
            myString = Console.ReadLine();
            return MessageBox((IntPtr)0, myString, "My Message Box", 0);
        }

    }

    //</snippet8>

    //<snippet9>
    class TestOverride
    {
        public class Employee
        {
            public string name;

            // Basepay is defined as protected, so that it may be 
            // accessed only by this class and derrived classes.
            protected decimal basepay;

            // Constructor to set the name and basepay values.
            public Employee(string name, decimal basepay)
            {
                this.name = name;
                this.basepay = basepay;
            }

            // Declared virtual so it can be overridden.
            public virtual decimal CalculatePay()
            {
                return basepay;
            }
        }

        // Derive a new class from Employee.
        public class SalesEmployee : Employee
        {
            // New field that will affect the base pay.
            private decimal salesbonus;

            // The constructor calls the base-class version, and
            // initializes the salesbonus field.
            public SalesEmployee(string name, decimal basepay, 
                      decimal salesbonus) : base(name, basepay)
            {
                this.salesbonus = salesbonus;
            }

            // Override the CalculatePay method 
            // to take bonus into account.
            public override decimal CalculatePay()
            {
                return basepay + salesbonus;
            }
        }

        static void Main()
        {
            // Create some new employees.
            SalesEmployee employee1 = new SalesEmployee("Alice", 
                          1000, 500);
            Employee employee2 = new Employee("Bob", 1200);

            Console.WriteLine("Employee4 " + employee1.name + 
                      " earned: " + employee1.CalculatePay());
            Console.WriteLine("Employee4 " + employee2.name + 
                      " earned: " + employee2.CalculatePay());
        }
    }
    /*
        Output:
        Employee4 Alice earned: 1500
        Employee4 Bob earned: 1200
    */
    //</snippet9>

    //<snippet10>
    class Employee2
    {
        private string name = "FirstName, LastName";
        private double salary = 100.0;

        public string GetName()
        {
            return name;
        }

        public double Salary
        {
            get { return salary; }
        }
    }

    class PrivateTest
    {
        static void Main()
        {
            Employee2 e = new Employee2();

            // The data members are inaccessible (private), so
            // they can't be accessed like this:
            //    string n = e.name;
            //    double s = e.salary;

            // 'name' is indirectly accessed via method:
            string n = e.GetName();

            // 'salary' is indirectly accessed via property
            double s = e.Salary;
        }
    }
    //</snippet10>

    //<snippet11>
    class A
    {
        protected int x = 123;
    }

    class B : A
    {
        static void Main()
        {
            A a = new A();
            B b = new B();

            // Error CS1540, because x can only be accessed by
            // classes derived from A.
            // a.x = 10; 

            // OK, because this class derives from A.
            b.x = 10;
        }
    }
    //</snippet11>

    //<snippet12>
    class Point 
    {
        protected int x; 
        protected int y;
    }

    class DerivedPoint: Point 
    {
        static void Main() 
        {
            DerivedPoint dpoint = new DerivedPoint();

            // Direct access to protected members:
            dpoint.x = 10;
            dpoint.y = 15;
            Console.WriteLine("x = {0}, y = {1}", dpoint.x, dpoint.y); 
        }
    }
    // Output: x = 10, y = 15

    //</snippet12>

    //<snippet13>
    class PointTest
    {
        public int x; 
        public int y;
    }

    class MainClass4
    {
        static void Main() 
        {
            PointTest p = new PointTest();
            // Direct access to public members:
            p.x = 10;
            p.y = 15;
            Console.WriteLine("x = {0}, y = {1}", p.x, p.y); 
        }
    }
    // Output: x = 10, y = 15
    //</snippet13>

    //<snippet14>
    class Age
    {
        readonly int _year;
        Age(int year)
        {
            _year = year;
        }
        void ChangeYear()
        {
            //_year = 1967; // Compile error if uncommented.
        }
    }

    //</snippet14>

    //<snippet15>
    public class ReadOnlyTest
    {
       class SampleClass
       {
          public int x;
          // Initialize a readonly field
          public readonly int y = 25;
          public readonly int z;

          public SampleClass()
          {
             // Initialize a readonly instance field
             z = 24;
          }

          public SampleClass(int p1, int p2, int p3)
          {
             x = p1;
             y = p2;
             z = p3;
          }
       }

       static void Main()
       {
          SampleClass p1 = new SampleClass(11, 21, 32);   // OK
          Console.WriteLine("p1: x={0}, y={1}, z={2}", p1.x, p1.y, p1.z);
          SampleClass p2 = new SampleClass();
          p2.x = 55;   // OK
          Console.WriteLine("p2: x={0}, y={1}, z={2}", p2.x, p2.y, p2.z);
       }
    }
    /*
     Output:
        p1: x=11, y=21, z=32
        p2: x=55, y=25, z=24
    */

     //</snippet15>

    //<snippet16>
    class X
    {
        protected virtual void F() { Console.WriteLine("X.F"); }
        protected virtual void F2() { Console.WriteLine("X.F2"); }
    }
    class Y : X
    {
        sealed protected override void F() { Console.WriteLine("Y.F"); }
        protected override void F2() { Console.WriteLine("Y.F2"); }
    }
    class Z : Y
    {
        // Attempting to override F causes compiler error CS0239.
        // protected override void F() { Console.WriteLine("C.F"); }

        // Overriding F2 is allowed.
        protected override void F2() { Console.WriteLine("Z.F2"); }
    }

    //</snippet16>

    //<snippet17>
    sealed class SealedClass
    {
        public int x;
        public int y;
    }

    class SealedTest2
    {
        static void Main()
        {
            SealedClass sc = new SealedClass();
            sc.x = 110;
            sc.y = 150;
            Console.WriteLine("x = {0}, y = {1}", sc.x, sc.y);
        }
    }
    // Output: x = 110, y = 150

    //</snippet17>

    //<snippet18>
    static class CompanyEmployee
    {
        public static void DoSomething() { /*...*/ }
        public static void DoSomethingElse() { /*...*/  }
    }

    //</snippet18>

    //<snippet19>
    public class MyBaseC
    {
        public struct MyStruct
        {
            public static int x = 100;
        }
    }

    //</snippet19>

    //<snippet20>
    public class Employee4
{
    public string id;
    public string name;

    public Employee4()
    {
    }

    public Employee4(string name, string id)
    {
        this.name = name;
        this.id = id;
    }

    public static int employeeCounter;

    public static int AddEmployee()
    {
        return ++employeeCounter;
    }
}

class MainClass : Employee4
{
    static void Main()
    {
        Console.Write("Enter the employee's name: ");
        string name = Console.ReadLine();
        Console.Write("Enter the employee's ID: ");
        string id = Console.ReadLine();

        // Create and configure the employee object:
        Employee4 e = new Employee4(name, id);
        Console.Write("Enter the current number of employees: ");
        string n = Console.ReadLine();
        Employee4.employeeCounter = Int32.Parse(n);
        Employee4.AddEmployee();

        // Display the new information:
        Console.WriteLine("Name: {0}", e.name);
        Console.WriteLine("ID:   {0}", e.id);
        Console.WriteLine("New Number of Employees: {0}",
                      Employee4.employeeCounter);
    }
}
    /*
    Input:
    Matthias Berndt
    AF643G
    15
     * 
    Sample Output:
    Enter the employee's name: Matthias Berndt
    Enter the employee's ID: AF643G
    Enter the current number of employees: 15
    Name: Matthias Berndt
    ID:   AF643G
    New Number of Employees: 16
    */

    //</snippet20>

//<snippet21>
    class Test
    {
       static int x = y;
       static int y = 5;

       static void Main()
       {
          Console.WriteLine(Test.x);
          Console.WriteLine(Test.y);

          Test.x = 99;
          Console.WriteLine(Test.x);
       }
    }
    /*
    Output:
        0
        5
        99
    */
//</snippet21>

    //<snippet22>
    // compile with: /unsafe

    class UnsafeTest
    {
       // Unsafe method: takes pointer to int:
       unsafe static void SquarePtrParam(int* p)
       {
          *p *= *p;
       }

       unsafe static void Main()
       {
          int i = 5;
          // Unsafe method: uses address-of operator (&):
          SquarePtrParam(&i);
          Console.WriteLine(i);
       }
    }
    // Output: 25

    //</snippet22>

    //<snippet23>
    class TestClass
    {
        public class Shape
        {
            public const double PI = Math.PI;
            protected double x, y;
            public Shape()
            {
            }
            public Shape(double x, double y)
            {
                this.x = x;
                this.y = y;
            }

            public virtual double Area()
            {
                return x * y;
            }
        }

        public class Circle : Shape
        {
            public Circle(double r) : base(r, 0)
            {
            }

            public override double Area()
            {
                return PI * x * x;
            }
        }

        class Sphere : Shape
        {
            public Sphere(double r) : base(r, 0)
            {
            }

            public override double Area()
            {
                return 4 * PI * x * x;
            }
        }

        class Cylinder : Shape
        {
            public Cylinder(double r, double h) : base(r, h)
            {
            }

            public override double Area()
            {
                return 2 * PI * x * x + 2 * PI * x * y;
            }
        }

        static void Main()
        {
            double r = 3.0, h = 5.0;
            Shape c = new Circle(r);
            Shape s = new Sphere(r);
            Shape l = new Cylinder(r, h);
            // Display results:
            Console.WriteLine("Area of Circle   = {0:F2}", c.Area());
            Console.WriteLine("Area of Sphere   = {0:F2}", s.Area());
            Console.WriteLine("Area of Cylinder = {0:F2}", l.Area());
            }
        }
        /*
            Output:
            Area of Circle   = 28.27
            Area of Sphere   = 113.10
            Area of Cylinder = 150.80
        */
        //</snippet23>

    //<snippet24>
    class VolatileTest
    {
        public volatile int i;

        public void Test(int _i)
        {
            i = _i;
        }
    }

    //</snippet24>

    
    class UsingTest
    {
        static void Main()
        {
            //<snippet25>
            using (System.IO.StreamReader sr = new System.IO.StreamReader(@"C:\Users\Public\Documents\test.txt"))
            {
                string s = null;
                while((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
            //</snippet25>

            Console.ReadKey();
        }
    }

    //<snippet26>
    class MyBaseClass
    {
        // virtual auto-implemented property. Overrides can only
        // provide specialized behavior if they implement get and set accessors.
        public virtual string Name { get; set; }

        // ordinary virtual property with backing field
        private int num;
        public virtual int Number
        {
            get { return num; }
            set { num = value; }
        }
    }

   
    class MyDerivedClass : MyBaseClass
    {
        private string name;

       // Override auto-implemented property with ordinary property
       // to provide specialized accessor behavior.
        public override string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != String.Empty)
                {
                    name = value;
                }
                else
                {
                    name = "Unknown";
                }
            }
        }
 
    }
    //</snippet26>       
}
