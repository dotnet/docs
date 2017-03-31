using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csrefKeywordsMethodParams
{

    //<snippet1>
    public class BoolTest
    {
        static void Main()
        {
            bool b = true;

            // WriteLine automatically converts the value of b to text.
            Console.WriteLine(b);

            int days = DateTime.Now.DayOfYear;


            // Assign the result of a boolean expression to b.
            b = (days % 2 == 0);

            // Branch depending on whether b is true or false.
            if (b)
            {
                Console.WriteLine("days is an even number");
            }
            else
            {
                Console.WriteLine("days is an odd number");
            }   
        }
    }
    /* Output:
      True
      days is an <even/odd> number
    */
    //</snippet1>


    class Test2
    {

        void TestMethod()
        {
            //<snippet2>
            int x = 123;

            // if (x)   // Error: "Cannot implicitly convert type 'int' to 'bool'"
            {
                Console.Write("The value of x is nonzero.");
            }
            //</snippet2>

            //<snippet3>

            if (x != 0)   // The C# way
            {
                Console.Write("The value of x is nonzero.");
            }
            //</snippet3>
        
        
        
        }
    
    }

    //<snippet4>
    public class BoolKeyTest
    {
        static void Main()
        {
            Console.Write("Enter a character: ");
            char c = (char)Console.Read();
            if (Char.IsLetter(c))
            {
                if (Char.IsLower(c))
                {
                    Console.WriteLine("The character is lowercase.");
                }
                else
                {
                    Console.WriteLine("The character is uppercase.");
                }
            }
            else
            {
                Console.WriteLine("Not an alphabetic character.");
            }
        }
    }
    /* Sample Output:
        Enter a character: X
        The character is uppercase.
     
        Enter a character: x
        The character is lowercase.

        Enter a character: 2
        The character is not an alphabetic character.
     */
    //</snippet4>

    //<snippet5>
    class Child
    {
        private int age;
        private string name;

        // Default constructor:
        public Child()
        {
            name = "N/A";
        }

        // Constructor:
        public Child(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        // Printing method:
        public void PrintChild()
        {
            Console.WriteLine("{0}, {1} years old.", name, age);
        }
    }

    class StringTest
    {
        static void Main()
        {
            // Create objects by using the new operator:
            Child child1 = new Child("Craig", 11);
            Child child2 = new Child("Sally", 10);

            // Create an object using the default constructor:
            Child child3 = new Child();

            // Display results:
            Console.Write("Child #1: ");
            child1.PrintChild();
            Console.Write("Child #2: ");
            child2.PrintChild();
            Console.Write("Child #3: ");
            child3.PrintChild();
        }
    }
    /* Output:
        Child #1: Craig, 11 years old.
        Child #2: Sally, 10 years old.
        Child #3: N/A, 0 years old.
    */
    //</snippet5>

    //<snippet6>
    public class TestDecimal
    {
        static void Main()
        {
            decimal d = 9.1m;
            int y = 3;
            Console.WriteLine(d + y);   // Result converted to decimal
        }
    }
    // Output: 12.1
    //</snippet6>

    //<snippet7>
    public class TestDecimalFormat
    {
        static void Main()
        {
            decimal x = 0.999m;
            decimal y = 9999999999999999999999999999m;
            Console.WriteLine("My amount = {0:C}", x);
            Console.WriteLine("Your amount = {0:C}", y);
        }
    }
    /* Output:
        My amount = $1.00
        Your amount = $9,999,999,999,999,999,999,999,999,999.00
    */
    //</snippet7>

    //<snippet8>      
    // Declare delegate -- defines required signature:
    delegate double MathAction(double num);

    class DelegateTest
    {
        // Regular method that matches signature:
        static double Double(double input)
        {
            return input * 2;
        }

        static void Main()
        {
            // Instantiate delegate with named method:
            MathAction ma = Double;

            // Invoke delegate ma:
            double multByTwo = ma(4.5);
            Console.WriteLine("multByTwo: {0}", multByTwo);

            // Instantiate delegate with anonymous method:
            MathAction ma2 = delegate(double input)
            {
                return input * input;
            };

            double square = ma2(5);
            Console.WriteLine("square: {0}", square);

            // Instantiate delegate with lambda expression
            MathAction ma3 = s => s * s * s;
            double cube = ma3(4.375);

            Console.WriteLine("cube: {0}", cube);
        }
        // Output:
        // multByTwo: 9
        // square: 25
        // cube: 83.740234375
    }
    //</snippet8>

    //<snippet9>
    // Mixing types in expressions
    class MixedTypes
    {
        static void Main()
        {
            int x = 3;
            float y = 4.5f;
            short z = 5;
            double w = 1.7E+3;
            // Result of the 2nd argument is a double:
            Console.WriteLine("The sum is {0}", x + y + z + w);
        }
    }
    // Output: The sum is 1712.5
    //</snippet9>

    //<snippet10>

    public class EnumTest
    {
        enum Days { Sun, Mon, Tue, Wed, Thu, Fri, Sat };

        static void Main()
        {
            int x = (int)Days.Sun;
            int y = (int)Days.Fri;
            Console.WriteLine("Sun = {0}", x);
            Console.WriteLine("Fri = {0}", y);
        }
    }
    /* Output:
       Sun = 0
       Fri = 5
    */
    //</snippet10>

    //<snippet11>
    public class EnumTest2
    {
        enum Range : long { Max = 2147483648L, Min = 255L };
        static void Main()
        {
            long x = (long)Range.Max;
            long y = (long)Range.Min;
            Console.WriteLine("Max = {0}", x);
            Console.WriteLine("Min = {0}", y);
        }
    }
    /* Output:
       Max = 2147483648
       Min = 255
    */
    //</snippet11>

    //<snippet12>
    // Add the attribute Flags or FlagsAttribute.
    [Flags]
    public enum CarOptions
    {
        // The flag for SunRoof is 0001.
        SunRoof = 0x01,
        // The flag for Spoiler is 0010.
        Spoiler = 0x02,
        // The flag for FogLights is 0100.
        FogLights = 0x04,
        // The flag for TintedWindows is 1000.
        TintedWindows = 0x08,
    }

    class FlagTest
    {
        static void Main()
        {
            // The bitwise OR of 0001 and 0100 is 0101.
            CarOptions options = CarOptions.SunRoof | CarOptions.FogLights;

            // Because the Flags attribute is specified, Console.WriteLine displays
            // the name of each enum element that corresponds to a flag that has
            // the value 1 in variable options.
            Console.WriteLine(options);
            // The integer value of 0101 is 5.
            Console.WriteLine((int)options);
        }
    }
    /* Output:
       SunRoof, FogLights
       5
    */
    //</snippet12>

    //<snippet13>
    class FloatTest 
    {
        static void Main() 
        {
            int x = 3;
            float y = 4.5f;
            short z = 5;
            var result = x * y / z;
            Console.WriteLine("The result is {0}", result);
            Type type = result.GetType();
            Console.WriteLine("result is of type {0}", type.ToString());
        }
    }
    /* Output: 
      The result is 2.7
      result is of type System.Single //'float' is alias for 'Single'
     */
    //</snippet13>

    //<snippet14>
    interface ISampleInterface
    {
        void SampleMethod();
    }

    class ImplementationClass : ISampleInterface
    {
        // Explicit interface member implementation: 
        void ISampleInterface.SampleMethod()
        {
            // Method implementation.
        }

        static void Main()
        {
            // Declare an interface instance.
            ISampleInterface obj = new ImplementationClass();

            // Call the member.
            obj.SampleMethod();
        }
    }
    //</snippet14>

    //<snippet15>
    interface IPoint
    {
       // Property signatures:
       int x
       {
          get;
          set;
       }

       int y
       {
          get;
          set;
       }
    }

    class Point : IPoint
    {
       // Fields:
       private int _x;
       private int _y;

       // Constructor:
       public Point(int x, int y)
       {
          _x = x;
          _y = y;
       }

       // Property implementation:
       public int x
       {
          get
          {
             return _x;
          }

          set
          {
             _x = value;
          }
       }

       public int y
       {
          get
          {
             return _y;
          }
          set
          {
             _y = value;
          }
       }
    }

    class MainClass
    {
       static void PrintPoint(IPoint p)
       {
          Console.WriteLine("x={0}, y={1}", p.x, p.y);
       }

       static void Main()
       {
          Point p = new Point(2, 3);
          Console.Write("My Point: ");
          PrintPoint(p);
       }
    }
    // Output: My Point: x=2, y=3
    //</snippet15>

   

//<snippet16>
class ObjectTest
{
   public int i = 10;
}

class MainClass2
{
   static void Main()
   {
      object a;
      a = 1;   // an example of boxing
      Console.WriteLine(a);
      Console.WriteLine(a.GetType());
      Console.WriteLine(a.ToString());

      a = new ObjectTest();
      ObjectTest classRef;
      classRef = (ObjectTest)a;
      Console.WriteLine(classRef.i);
   }
}
/* Output
    1
    System.Int32
    1
 * 10
*/
//</snippet16>

//<snippet17>
    class SimpleStringTest 
    {
       static void Main()
       {
          string a = "\u0068ello ";
          string b = "world";
          Console.WriteLine( a + b );
          Console.WriteLine( a + b == "Hello World" ); // == performs a case-sensitive comparison
       }
    }
    /* Output:
        hello world
        False
     */
//</snippet17>

    


    class VarTest
    {
        #region compilation only
        class Customer
        {
            public string City { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
        }

        #endregion
        static void Main()
        {


            List<Customer> customers = new List<Customer>();
            //<snippet18>
            // Example #1: var is optional because
            // the select clause specifies a string
            string[] words = { "apple", "strawberry", "grape", "peach", "banana" };
            var wordQuery = from word in words
                            where word[0] == 'g'
                            select word;

            // Because each element in the sequence is a string, 
            // not an anonymous type, var is optional here also.
            foreach (string s in wordQuery)
            {
                Console.WriteLine(s);
            }

            // Example #2: var is required because
            // the select clause specifies an anonymous type
            var custQuery = from cust in customers
                            where cust.City == "Phoenix"
                            select new { cust.Name, cust.Phone };

            // var must be used because each item 
            // in the sequence is an anonymous type
            foreach (var item in custQuery)
            {
                Console.WriteLine("Name={0}, Phone={1}", item.Name, item.Phone);
            }
            //</snippet18>
        }
    }



    
    class CharTest
    {
        static void Main()
        {
            //<snippet19>
            char[] chars = new char[4];

            chars[0] = 'X';        // Character literal
            chars[1] = '\x0058';   // Hexadecimal
            chars[2] = (char)88;   // Cast from integral type
            chars[3] = '\u0058';   // Unicode

            foreach (char c in chars)
            {
                Console.Write(c + " ");
            }
            // Output: X X X X
            //</snippet19>
        }
    }
    







}