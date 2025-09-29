using System;
using System.Drawing;
using System.Windows.Forms;

namespace Inheritance_ProgGuide
{
    class TestPaint : Form
    {
        //<Snippet35>
        protected override void OnPaint(PaintEventArgs e)
        {
            // Perform custom drawing
            System.Drawing.Graphics gfx = e.Graphics;
            gfx.DrawString("Hello, World!",
              new System.Drawing.Font("Arial", 16),
              new System.Drawing.SolidBrush(System.Drawing.Color.Blue),
              new System.Drawing.Point(10, 10));
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            //
            // TestPaint
            //
            ClientSize = new Size(284, 264);
            Name = "TestPaint";
            Load += new EventHandler(TestPaint_Load);
            ResumeLayout(false);
        }

        private void TestPaint_Load(object sender, EventArgs e)
        {
        }
        //</Snippet35>
    }

    //<Snippet1>
    // compile with: csc -target:library abstractshape.cs
    public abstract class Shape
    {
        public Shape(string s)
        {
            // calling the set accessor of the Id property.
            Id = s;
        }

        public string Id { get; set; }

        // Area is a read-only property - only a get accessor is needed:
        public abstract double Area
        {
            get;
        }

        public override string ToString()
        {
            return $"{Id} Area = {Area:F2}";
        }
    }
    //</Snippet1>

    //<Snippet2>
    // compile with: csc -target:library -reference:abstractshape.dll shapes.cs
    public class Square : Shape
    {
        private int _side;

        public Square(int side, string id)
            : base(id)
        {
            _side = side;
        }

        public override double Area
        {
            get
            {
                // Given the side, return the area of a square:
                return _side * _side;
            }
        }
    }

    public class Circle : Shape
    {
        private int _radius;

        public Circle(int radius, string id)
            : base(id)
        {
            _radius = radius;
        }

        public override double Area
        {
            get
            {
                // Given the radius, return the area of a circle:
                return _radius * _radius * Math.PI;
            }
        }
    }

    public class Rectangle : Shape
    {
        private int _width;
        private int _height;

        public Rectangle(int width, int height, string id)
            : base(id)
        {
            _width = width;
            _height = height;
        }

        public override double Area
        {
            get
            {
                // Given the width and height, return the area of a rectangle:
                return _width * _height;
            }
        }
    }
    //</Snippet2>

    //<Snippet3>
    // compile with: csc -reference:abstractshape.dll;shapes.dll shapetest.cs
    class TestClass
    {
        static void Main()
        {
            Shape[] shapes =
            [
                new Square(5, "Square #1"),
                new Circle(3, "Circle #1"),
                new Rectangle( 4, 5, "Rectangle #1")
            ];

            Console.WriteLine("Shapes Collection");
            foreach (Shape s in shapes)
            {
                Console.WriteLine(s);
            }
        }
    }
    /* Output:
        Shapes Collection
        Square #1 Area = 25.00
        Circle #1 Area = 28.27
        Rectangle #1 Area = 20.00
    */
    //</Snippet3>

    class CarStuff
    {
        //<Snippet4>
        // Define the base class
        class Car
        {
            public virtual void DescribeCar()
            {
                Console.WriteLine("Four wheels and an engine.");
            }
        }

        // Define the derived classes
        class ConvertibleCar : Car
        {
            public new virtual void DescribeCar()
            {
                base.DescribeCar();
                Console.WriteLine("A roof that opens up.");
            }
        }

        class Minivan : Car
        {
            public override void DescribeCar()
            {
                base.DescribeCar();
                Console.WriteLine("Carries seven people.");
            }
        }
        //</Snippet4>

        //<Snippet5>
        public static void TestCars1()
        {
            Car car1 = new();
            car1.DescribeCar();
            Console.WriteLine("----------");

            ConvertibleCar car2 = new();
            car2.DescribeCar();
            Console.WriteLine("----------");

            Minivan car3 = new();
            car3.DescribeCar();
            Console.WriteLine("----------");
        }
        //</Snippet5>

        //<Snippet6>
        public static void TestCars2()
        {
            Car[] cars = [new Car(), new ConvertibleCar(), new Minivan()];
        }
        //</Snippet6>

        public static void TestCars3()
        {
            Car[] cars = new Car[3];

            //<Snippet7>
            foreach (Car vehicle in cars)
            {
                Console.WriteLine("Car object: " + vehicle.GetType());
                vehicle.DescribeCar();
                Console.WriteLine("----------");
            }
            //</Snippet7>
        }
    }

    //<Snippet8>
    interface IDimensions
    {
        float GetLength();
        float GetWidth();
    }

    class Box : IDimensions
    {
        float _lengthInches;
        float _widthInches;

        Box(float length, float width)
        {
            _lengthInches = length;
            _widthInches = width;
        }
        // Explicit interface member implementation:
        float IDimensions.GetLength()
        {
            return _lengthInches;
        }
        // Explicit interface member implementation:
        float IDimensions.GetWidth()
        {
            return _widthInches;
        }

        static void Main()
        {
            // Declare a class instance box1:
            Box box1 = new(30.0f, 20.0f);

            // Declare an interface instance dimensions:
            IDimensions dimensions = box1;

            // The following commented lines would produce compilation
            // errors because they try to access an explicitly implemented
            // interface member from a class instance:
            //<Snippet45>
            //Console.WriteLine($"Length: {box1.GetLength()}");
            //Console.WriteLine($"Width: {box1.GetWidth()}");
            //</Snippet45>

            // Print out the dimensions of the box by calling the methods
            // from an instance of the interface:
            //<Snippet46>
            Console.WriteLine($"Length: {dimensions.GetLength()}");
            Console.WriteLine($"Width: {dimensions.GetWidth()}");
            //</Snippet46>
        }
    }
    /* Output:
        Length: 30
        Width: 20
    */
    //</Snippet8>

    namespace WrapBox
    {
        //<Snippet9>
        // Declare the English units interface:
        interface IEnglishDimensions
        {
            float Length();
            float Width();
        }

        // Declare the metric units interface:
        interface IMetricDimensions
        {
            float Length();
            float Width();
        }

        // Declare the Box class that implements the two interfaces:
        // IEnglishDimensions and IMetricDimensions:
        class Box : IEnglishDimensions, IMetricDimensions
        {
            float _lengthInches;
            float _widthInches;

            public Box(float lengthInches, float widthInches)
            {
                _lengthInches = lengthInches;
                _widthInches = widthInches;
            }

            // Explicitly implement the members of IEnglishDimensions:
            float IEnglishDimensions.Length() => _lengthInches;

            float IEnglishDimensions.Width() => _widthInches;

            // Explicitly implement the members of IMetricDimensions:
            float IMetricDimensions.Length() => _lengthInches * 2.54f;

            float IMetricDimensions.Width() => _widthInches * 2.54f;

            static void Main()
            {
                // Declare a class instance box1:
                Box box1 = new(30.0f, 20.0f);

                // Declare an instance of the English units interface:
                IEnglishDimensions eDimensions = box1;

                // Declare an instance of the metric units interface:
                IMetricDimensions mDimensions = box1;

                // Print dimensions in English units:
                Console.WriteLine($"Length(in): {eDimensions.Length()}");
                Console.WriteLine($"Width (in): {eDimensions.Width()}");

                // Print dimensions in metric units:
                Console.WriteLine($"Length(cm): {mDimensions.Length()}");
                Console.WriteLine($"Width (cm): {mDimensions.Width()}");
            }
        }
        /* Output:
            Length(in): 30
            Width (in): 20
            Length(cm): 76.2
            Width (cm): 50.8
        */
        //</Snippet9>
    }

    class Test
    {
        interface IMetricDimensions
        {
            float Length();
            float Width();
        }

        class Box : IMetricDimensions
        {
            float _lengthInches;
            float _widthInches;

            public Box(float length, float width)
            {
                _lengthInches = length;
                _widthInches = width;
            }

            //<Snippet10>
            // Normal implementation:
            public float Length() => _lengthInches;
            public float Width() => _widthInches;

            // Explicit implementation:
            float IMetricDimensions.Length() => _lengthInches * 2.54f;
            float IMetricDimensions.Width() => _widthInches * 2.54f;
            //</Snippet10>

            //<Snippet11>
            public static void Test()
            {
                Box box1 = new(30.0f, 20.0f);
                IMetricDimensions mDimensions = box1;

                Console.WriteLine($"Length(in): {box1.Length()}");
                Console.WriteLine($"Width (in): {box1.Width()}");
                Console.WriteLine($"Length(cm): {mDimensions.Length()}");
                Console.WriteLine($"Width (cm): {mDimensions.Width()}");
            }
            //</Snippet11>
        }
    }
}

namespace WrapExample
{
    // Inheritance (C# Programming Guide)
    //<Snippet12>
    public class A { }
    public class B : A { }

    //</Snippet12>
    class Program
    {
        static void Main()
        {
            A a = new();
            B b = new();
            b = (B)a;
        }
    }
}

namespace WrapA
{
    //<Snippet13>
    public abstract class A
    {
        // Class members here.
    }
    //</Snippet13>
}

//<Snippet14>
public abstract class A
{
    public abstract void DoWork(int i);
}
//</Snippet14>

namespace WrapD
{
    //<Snippet15>
    // compile with: -target:library
    public class D
    {
        public virtual void DoWork(int i)
        {
            // Original implementation.
        }
    }

    public abstract class E : D
    {
        public abstract override void DoWork(int i);
    }

    public class F : E
    {
        public override void DoWork(int i)
        {
            // New implementation.
        }
    }
    //</Snippet15>
}

namespace WrapD2
{
    //<Snippet16>
    public sealed class D
    {
        // Class members here.
    }
    //</Snippet16>
}

public abstract class C
{
    public virtual void DoWork() { }
}

//<Snippet17>
public class D : C
{
    public sealed override void DoWork() { }
}
//</Snippet17>

namespace WrapClasses
{
    //<Snippet22>
    public class A
    {
        public virtual void DoWork() { }
    }
    public class B : A
    {
        public override void DoWork() { }
    }
    //</Snippet22>

    //<Snippet23>
    public class C : B
    {
        public override void DoWork() { }
    }
    //</Snippet23>
}

class TestGraphics
{
    //<Snippet27>
    class GraphicsClass
    {
        public virtual void DrawLine() { }
        public virtual void DrawPoint() { }
    }
    //</Snippet27>

    //<Snippet28>
    class YourDerivedGraphicsClass : GraphicsClass
    {
        public void DrawRectangle() { }
    }
    //</Snippet28>
}

class TestGraphics2
{
    //<Snippet29>
    class GraphicsClass
    {
        public virtual void DrawLine() { }
        public virtual void DrawPoint() { }
        public virtual void DrawRectangle() { }
    }
    //</Snippet29>

    //<Snippet30>
    class YourDerivedGraphicsClass : GraphicsClass
    {
        public override void DrawRectangle() { }
    }
    //</Snippet30>
}

class TestGraphics3
{
    class GraphicsClass
    {
        public virtual void DrawLine() { }
        public virtual void DrawPoint() { }
        public virtual void DrawRectangle() { }
    }

    //<Snippet31>
    class YourDerivedGraphicsClass : GraphicsClass
    {
        public new void DrawRectangle() { }
    }
    //</Snippet31>

    class X : YourDerivedGraphicsClass
    {
        public new void DrawRectangle()
        {
            //<Snippet44>
            base.DrawRectangle();
            //</Snippet44>
        }
    }
}

class TestSelection
{
    public class Base
    {
        public virtual void DoWork(int param) { }
    }

    //<Snippet32>
    public class Derived : Base
    {
        public override void DoWork(int param) { }
        public void DoWork(double param) { }
    }
    //</Snippet32>

    void Test()
    {
        //<Snippet33>
        int val = 5;
        Derived d = new();
        d.DoWork(val);  // Calls DoWork(double).
        //</Snippet33>

        //<Snippet34>
        ((Base)d).DoWork(val);  // Calls DoWork(int) on Derived.
        //</Snippet34>
    }
}

class OverrideToString
{
    //<Snippet36>
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return "Person: " + Name + " " + Age;
        }
    }
    //</Snippet36>

    void test()
    {
        //<Snippet37>
        int x = 42;
        string strx = x.ToString();
        Console.WriteLine(strx);
        // Output:
        // 42
        //</Snippet37>

        //<Snippet38>
        Person person = new() { Name = "John", Age = 12 };
        Console.WriteLine(person);
        // Output:
        // Person: John 12
        //</Snippet38>
    }
}

namespace ExplicitConversion
{
    //<Snippet51>
    class Test
    {
        public static void M()
        { Console.WriteLine("I'm just a Test"); }
    }
    class Program2
    {
        static void Main()
        {
            System.Collections.ArrayList list = [new Test(), new Test(), new Test()];

            foreach (object o in list)
            {
                if (o is Test t)
                {
                    Test.M();
                }
            }
        }
    }

    /* Output:
      I'm just a Test
      I'm just a Test
      I'm just a Test
     */
    //</Snippet51>
}

namespace RainyDay
{
    class JustInCase
    {
        static void Main()
        {
            //<Snippet52>
            Console.WriteLine("Saving for a rainy day.");
            //</Snippet52>

            //<Snippet53>
            Console.WriteLine("Saving for a rainy day.");
            //</Snippet53>
            //<Snippet54>
            Console.WriteLine("Saving for a rainy day.");
            //</Snippet54>
            //<Snippet55>
            Console.WriteLine("Saving for a rainy day.");
            //</Snippet55>
            //<Snippet56>
            Console.WriteLine("Saving for a rainy day.");
            //</Snippet56>
        }
    }
}

//<snippet70>
namespace OverrideAndNew
{
    using System;
    class Program
    {
        static void Main(string[] args)
        {
            BaseClass bc = new();
            DerivedClass dc = new();
            BaseClass bcdc = new DerivedClass();

            // The following two calls do what you would expect. They call
            // the methods that are defined in BaseClass.
            bc.Method1();
            bc.Method2();
            // Output:
            // Base - Method1
            // Base - Method2

            // The following two calls do what you would expect. They call
            // the methods that are defined in DerivedClass.
            dc.Method1();
            dc.Method2();
            // Output:
            // Derived - Method1
            // Derived - Method2

            // The following two calls produce different results for the
            // method defined by using override (Method1) and the
            // method defined by using new (Method2).
            bcdc.Method1();
            bcdc.Method2();
            // Output:
            // Derived - Method1
            // Base - Method2
        }
    }

    class BaseClass
    {
        //<snippet68>
        public virtual void Method1()
        {
            Console.WriteLine("Base - Method1");
        }
        //</snippet68>

        public virtual void Method2()
        {
            Console.WriteLine("Base - Method2");
        }
    }

    class DerivedClass : BaseClass
    {
        //<snippet67>
        public override void Method1()
        {
            Console.WriteLine("Derived - Method1");
        }
        //</snippet67>

        //<snippet66>
        public new void Method2()
        {
            Console.WriteLine("Derived - Method2");
        }
        //</snippet66>
    }
}
//</snippet70>

//<snippet69>
// Output:
// Base - Method1
// Base - Method2
// Derived - Method1
// Derived - Method2
// Derived - Method1
// Base - Method2
//</snippet69>

namespace pieces
{
    using System;

    //<snippet61>
    class BaseClass
    {
        public void Method1()
        {
            Console.WriteLine("Base - Method1");
        }
    }

    class DerivedClass : BaseClass
    {
        public void Method2()
        {
            Console.WriteLine("Derived - Method2");
        }
    }
    //</snippet61>

    //<snippet62>
    class Program
    {
        static void Main(string[] args)
        {
            BaseClass bc = new();
            DerivedClass dc = new();
            BaseClass bcdc = new DerivedClass();

            bc.Method1();
            dc.Method1();
            dc.Method2();
            bcdc.Method1();
        }
        // Output:
        // Base - Method1
        // Base - Method1
        // Derived - Method2
        // Base - Method1
    }
    //</snippet62>

    class morePieces
    {
        public void callers()
        {
            BaseClass bc = new();
            DerivedClass dc = new();
            BaseClass bcdc = new DerivedClass();
            //<snippet64>
            bc.Method1();
            bc.Method2();
            dc.Method1();
            dc.Method2();
            bcdc.Method1();
            bcdc.Method2();
            //</snippet64>

            //<snippet65>
            // Output:
            // Base - Method1
            // Base - Method2
            // Base - Method1
            // Derived - Method2
            // Base - Method1
            // Base - Method2
            //</snippet65>
        }

        public class BaseClass
        {
            public void Method1()
            {
                Console.WriteLine("Base - Method1");
            }

            //<snippet63>
            public void Method2()
            {
                Console.WriteLine("Base - Method2");
            }
            //</snippet63>
        }

        class DerivedClass : BaseClass
        {
            public new void Method2()
            {
                Console.WriteLine("Derived - Method2");
            }
        }
    }
}

//<snippet78>
namespace OverrideAndNew2
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            // Declare objects of the derived classes and test which version
            // of ShowDetails is run, base or derived.
            TestCars1();

            // Declare objects of the base class, instantiated with the
            // derived classes, and repeat the tests.
            TestCars2();

            // Declare objects of the derived classes and call ShowDetails
            // directly.
            TestCars3();

            // Declare objects of the base class, instantiated with the
            // derived classes, and repeat the tests.
            TestCars4();
        }

        //<snippet72>
        public static void TestCars1()
        {
            Console.WriteLine("\nTestCars1");
            Console.WriteLine("----------");

            Car car1 = new();
            car1.DescribeCar();
            Console.WriteLine("----------");

            // Note the output from this test case. The ShowDetails method is
            // declared with the new modifier.
            ConvertibleCar car2 = new();
            car2.DescribeCar();
            Console.WriteLine("----------");

            Minivan car3 = new();
            car3.DescribeCar();
            Console.WriteLine("----------");
        }
        //</snippet72>

        //<snippet73>
        // Output:

        // TestCars1
        // ----------
        // Four wheels and an engine.
        // Standard transportation.
        // ----------
        // Four wheels and an engine.
        // Standard transportation.
        // ----------
        // Four wheels and an engine.
        // Carries seven people.
        // ----------
        //</snippet73>

        //<snippet74>
        public static void TestCars2()
        {
            Console.WriteLine("\nTestCars2");
            Console.WriteLine("----------");

            var cars = new List<Car> { new(), new ConvertibleCar(),
                new Minivan() };

            foreach (Car car in cars)
            {
                car.DescribeCar();
                Console.WriteLine("----------");
            }
        }
        //</snippet74>

        //<snippet75>
        // Output:

        // TestCars2
        // ----------
        // Four wheels and an engine.
        // Standard transportation.
        // ----------
        // Four wheels and an engine.
        // Standard transportation.
        // ----------
        // Four wheels and an engine.
        // Carries seven people.
        // ----------
        //</snippet75>

        //<snippet76>
        public static void TestCars3()
        {
            Console.WriteLine("\nTestCars3");
            Console.WriteLine("----------");
            ConvertibleCar car2 = new();
            Minivan car3 = new();
            car2.ShowDetails();
            car3.ShowDetails();
        }

        public static void TestCars4()
        {
            Console.WriteLine("\nTestCars4");
            Console.WriteLine("----------");
            Car car2 = new ConvertibleCar();
            Car car3 = new Minivan();
            car2.ShowDetails();
            car3.ShowDetails();
        }
        //</snippet76>

        //<snippet77>
        // Output:

        // TestCars3
        // ----------
        // A roof that opens up.
        // Carries seven people.

        // TestCars4
        // ----------
        // Standard transportation.
        // Carries seven people.
        //</snippet77>
    }

    //<snippet71>
    // Define the base class, Car. The class defines two methods, DescribeCar
    // and ShowDetails. DescribeCar calls ShowDetails, and each derived class
    // also defines a ShowDetails method. The example tests which version of
    // ShowDetails is selected, the base class method or the derived class method.
    class Car
    {
        public void DescribeCar()
        {
            Console.WriteLine("Four wheels and an engine.");
            ShowDetails();
        }

        public virtual void ShowDetails()
        {
            Console.WriteLine("Standard transportation.");
        }
    }

    // Define the derived classes.

    // Class ConvertibleCar uses the new modifier to acknowledge that ShowDetails
    // hides the base class method.
    class ConvertibleCar : Car
    {
        public new void ShowDetails()
        {
            Console.WriteLine("A roof that opens up.");
        }
    }

    // Class Minivan uses the override modifier to specify that ShowDetails
    // extends the base class method.
    class Minivan : Car
    {
        public override void ShowDetails()
        {
            Console.WriteLine("Carries seven people.");
        }
    }
    //</snippet71>
}
//</snippet78>
