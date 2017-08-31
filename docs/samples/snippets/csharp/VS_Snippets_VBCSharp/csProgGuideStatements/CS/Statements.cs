
namespace CsCsrefProgrammingStatements
{
    //---------------------------------------------------------------------------
    public class SimpleStatements
    {
        //<Snippet1>
        static void Main()
        {
            // Declaration statement.
            int counter;

            // Assignment statement.
            counter = 1;

            // Error! This is an expression, not an expression statement.
            // counter + 1; 

            // Declaration statements with initializers are functionally
            // equivalent to  declaration statement followed by assignment statement:         
            int[] radii = { 15, 32, 108, 74, 9 }; // Declare and initialize an array.
            const double pi = 3.14159; // Declare and initialize  constant.          

            // foreach statement block that contains multiple statements.
            foreach (int radius in radii)
            {
                // Declaration statement with initializer.
                double circumference = pi * (2 * radius);

                // Expression statement (method invocation). A single-line
                // statement can span multiple text lines because line breaks
                // are treated as white space, which is ignored by the compiler.
                System.Console.WriteLine("Radius of circle #{0} is {1}. Circumference = {2:N2}",
                                        counter, radius, circumference);

                // Expression statement (postfix increment).
                counter++;

            } // End of foreach statement block
        } // End of Main method body.
    } // End of SimpleStatements class.
    /*
       Output:
        Radius of circle #1 = 15. Circumference = 94.25
        Radius of circle #2 = 32. Circumference = 201.06
        Radius of circle #3 = 108. Circumference = 678.58
        Radius of circle #4 = 74. Circumference = 464.96
        Radius of circle #5 = 9. Circumference = 56.55
    */
    //</Snippet1>
    public class WrapStatements
    {

        static void Main()
        {
            int x = 4;
            bool b = ((x < 10) && (x > 5)) || ((x > 20) && (x < 25));
            bool b2 = 35 == System.Convert.ToInt32("35");


        }

        static void DoWork(int i) { }

        public static void test()
        {
            //<Snippet2>
            // Expression statements.
            int i = 5;
            string s = "Hello World";
            //</Snippet2>

            System.Console.WriteLine(i.ToString());
            System.Console.WriteLine(s);

            //<Snippet3>
            int num = 5;
            System.Console.WriteLine(num); // Output: 5
            num = 6;
            System.Console.WriteLine(num); // Output: 6            
            //</Snippet3>

            //<Snippet4>
            DoWork(num);
            //</Snippet4>
            int y = 0;

            //<Snippet5>
            y++;
            //</Snippet5>

            //<Snippet6>
            y = 2 + 3;
            //</Snippet6>

            //<Snippet7>
            int num1 = 5;
            num1++;
            System.Console.WriteLine(num1);
            //</Snippet7>

            //<Snippet8>
            int num2 = 5;
            num2 = num2++;  //not recommended
            System.Console.WriteLine(num2);
            //</Snippet8>
        }

        class Complex
        {
            //<Snippet9>
            public static Complex operator +(Complex c1, Complex c2)
            //</Snippet9>
            {
                Complex temp = new Complex();
                // code to do the addition...

                return temp;
            }
        }

        //<Snippet10>
        class SampleClass
        {
            public static explicit operator SampleClass(int i)
            {
                SampleClass temp = new SampleClass();
                // code to convert from int to SampleClass...

                return temp;
            }
        }
        //</Snippet10>
    }

    //---------------------------------------------------------------------------
    namespace WrapUsing1
    {
        //<Snippet11>
        struct Digit
        {
            byte value;

            public Digit(byte value)  //constructor
            {
                if (value > 9)
                {
                    throw new System.ArgumentException();
                }
                this.value = value;
            }

            public static explicit operator Digit(byte b)  // explicit byte to digit conversion operator
            {
                Digit d = new Digit(b);  // explicit conversion

                System.Console.WriteLine("Conversion occurred.");
                return d;
            }
        }

        class TestExplicitConversion
        {
            static void Main()
            {
                try
                {
                    byte b = 3;
                    Digit d = (Digit)b;  // explicit conversion
                }
                catch (System.Exception e)
                {
                    System.Console.WriteLine("{0} Exception caught.", e);
                }
            }
        }
        // Output: Conversion occurred.
        //</Snippet11>
    }

    //---------------------------------------------------------------------------
    namespace WrapUsing2
    {
        //<Snippet12>
        struct Digit
        {
            byte value;

            public Digit(byte value)  //constructor
            {
                if (value > 9)
                {
                    throw new System.ArgumentException();
                }
                this.value = value;
            }

            public static implicit operator byte(Digit d)  // implicit digit to byte conversion operator
            {
                System.Console.WriteLine("conversion occurred");
                return d.value;  // implicit conversion
            }
        }

        class TestImplicitConversion
        {
            static void Main()
            {
                Digit d = new Digit(3);
                byte b = d;  // implicit conversion -- no cast needed
            }
        }
        // Output: Conversion occurred.
        //</Snippet12>
    }


    //---------------------------------------------------------------------------
    namespace WrapStructConversions
    {
        //<Snippet13>
        struct RomanNumeral
        {
            private int value;

            public RomanNumeral(int value)  //constructor
            {
                this.value = value;
            }

            static public implicit operator RomanNumeral(int value)
            {
                return new RomanNumeral(value);
            }

            static public implicit operator RomanNumeral(BinaryNumeral binary)
            {
                return new RomanNumeral((int)binary);
            }

            static public explicit operator int(RomanNumeral roman)
            {
                return roman.value;
            }

            static public implicit operator string(RomanNumeral roman)
            {
                return ("Conversion to string is not implemented");
            }
        }

        struct BinaryNumeral
        {
            private int value;

            public BinaryNumeral(int value)  //constructor
            {
                this.value = value;
            }

            static public implicit operator BinaryNumeral(int value)
            {
                return new BinaryNumeral(value);
            }

            static public explicit operator int(BinaryNumeral binary)
            {
                return (binary.value);
            }

            static public implicit operator string(BinaryNumeral binary)
            {
                return ("Conversion to string is not implemented");
            }
        }

        class TestConversions
        {
            static void Main()
            {
                RomanNumeral roman;
                BinaryNumeral binary;

                roman = 10;

                // Perform a conversion from a RomanNumeral to a BinaryNumeral:
                //<Snippet14>
                binary = (BinaryNumeral)(int)roman;
                //</Snippet14>

                // Perform a conversion from a BinaryNumeral to a RomanNumeral:
                // No cast is required:
                //<Snippet15>
                roman = binary;
                //</Snippet15>

                System.Console.WriteLine((int)binary);
                System.Console.WriteLine(binary);

                // Keep the console window open in debug mode.
                System.Console.WriteLine("Press any key to exit.");
                System.Console.ReadKey();
            }
        }
        /* Output:
            10
            Conversion not yet implemented
        */
        //</Snippet13>
    }


    //---------------------------------------------------------------------------
    namespace WrapComplexClass
    {
        //<Snippet16>
        public struct Complex
        {
            public int real;
            public int imaginary;

            // Constructor.
            public Complex(int real, int imaginary)  
            {
                this.real = real;
                this.imaginary = imaginary;
            }

            // Specify which operator to overload (+), 
            // the types that can be added (two Complex objects),
            // and the return type (Complex).
            public static Complex operator +(Complex c1, Complex c2)
            {
                return new Complex(c1.real + c2.real, c1.imaginary + c2.imaginary);
            }

            // Override the ToString() method to display a complex number 
            // in the traditional format:
            public override string ToString()
            {
                return (System.String.Format("{0} + {1}i", real, imaginary));
            }
        }

        class TestComplex
        {
            static void Main()
            {
                Complex num1 = new Complex(2, 3);
                Complex num2 = new Complex(3, 4);

                // Add two Complex objects by using the overloaded + operator.
                Complex sum = num1 + num2;

                // Print the numbers and the sum by using the overridden 
                // ToString method.
                System.Console.WriteLine("First complex number:  {0}", num1);
                System.Console.WriteLine("Second complex number: {0}", num2);
                System.Console.WriteLine("The sum of the two numbers: {0}", sum);

                // Keep the console window open in debug mode.
                System.Console.WriteLine("Press any key to exit.");
                System.Console.ReadKey();
            }
        }
        /* Output:
            First complex number:  2 + 3i
            Second complex number: 3 + 4i
            The sum of the two numbers: 5 + 7i
        */
        //</Snippet16>
    }


    //---------------------------------------------------------------------------
    namespace WrapThreValuedLogic
    {
        //<Snippet17>
        public struct DBBool
        {
            // The three possible DBBool values:
            public static readonly DBBool dbFalse = new DBBool(-1);
            public static readonly DBBool dbNull = new DBBool(0);
            public static readonly DBBool dbTrue = new DBBool(1);

            // Private field that stores 
            // -1, 0, 1 for dbFalse, dbNull, dbTrue:
            int value;

            // Private constructor. 
            // The value parameter must be -1, 0, or 1:
            DBBool(int value)
            {
                this.value = value;
            }

            // Implicit conversion from bool to DBBool.
            // Maps true to DBBool.dbTrue and false to DBBool.dbFalse:
            public static implicit operator DBBool(bool x)
            {
                return x ? dbTrue : dbFalse;
            }

            // Explicit conversion from DBBool to bool.
            // Throws an exception if the given DBBool is dbNull; 
            // otherwise, returns true or false:
            public static explicit operator bool(DBBool x)
            {
                if (x.value == 0) throw new System.InvalidOperationException();
                return x.value > 0;
            }

            // Equality operator.
            // Returns dbNull if either operand is dbNull; 
            // otherwise, returns dbTrue or dbFalse:
            public static DBBool operator ==(DBBool x, DBBool y)
            {
                if (x.value == 0 || y.value == 0) return dbNull;
                return x.value == y.value ? dbTrue : dbFalse;
            }

            // Inequality operator.
            // Returns dbNull if either operand is dbNull; 
            // otherwise, returns dbTrue or dbFalse:
            public static DBBool operator !=(DBBool x, DBBool y)
            {
                if (x.value == 0 || y.value == 0) return dbNull;
                return x.value != y.value ? dbTrue : dbFalse;
            }

            // Logical negation operator. Returns dbTrue if the 
            // operand is dbFalse, dbNull if the operand is dbNull, 
            // or dbFalse if the operand is dbTrue:
            public static DBBool operator !(DBBool x)
            {
                return new DBBool(-x.value);
            }

            // Logical AND operator. Returns dbFalse if either 
            // operand is dbFalse, dbNull if either operand is 
            // dbNull; otherwise, dbTrue:
            public static DBBool operator &(DBBool x, DBBool y)
            {
                return new DBBool(x.value < y.value ? x.value : y.value);
            }

            // Logical OR operator.
            // Returns dbTrue if either operand is dbTrue, dbNull if 
            // either operand is dbNull; otherwise, dbFalse:
            public static DBBool operator |(DBBool x, DBBool y)
            {
                return new DBBool(x.value > y.value ? x.value : y.value);
            }

            // Definitely true operator.
            // Returns true if the operand is dbTrue, false otherwise:
            public static bool operator true(DBBool x)
            {
                return x.value > 0;
            }

            // Definitely false operator.
            // Returns true if the operand is dbFalse, false otherwise:
            public static bool operator false(DBBool x)
            {
                return x.value < 0;
            }

            // Overload the conversion from DBBool to string:
            public static implicit operator string(DBBool x)
            {
                return x.value > 0 ? "dbTrue"
                                   : x.value < 0 ? "dbFalse"
                                                 : "dbNull";
            }

            // Override the Object.Equals(object o) method:
            public override bool Equals(object o)
            {
                try
                {
                    return (bool)(this == (DBBool)o);
                }
                catch
                {
                    return false;
                }
            }

            // Override the Object.GetHashCode() method:
            public override int GetHashCode()
            {
                return value;
            }

            // Override the ToString method to convert DBBool to  string:
            public override string ToString()
            {
                switch (value)
                {
                    case -1:
                        return "DBBool.False";
                    case 0:
                        return "DBBool.Null";
                    case 1:
                        return "DBBool.True";
                    default:
                        throw new System.InvalidOperationException();
                }
            }
        }

        class TestDBBool
        {
            static void Main()
            {
                DBBool a = DBBool.dbTrue;
                DBBool b = DBBool.dbNull;

                System.Console.WriteLine("!{0} = {1}", a, !a);
                System.Console.WriteLine("!{0} = {1}", b, !b);
                System.Console.WriteLine("{0} & {1} = {2}", a, b, a & b);
                System.Console.WriteLine("{0} | {1} = {2}", a, b, a | b);

                // Invoke the true operator to determine the Boolean 
                // value of the DBBool variable:
                if (b)
                {
                    System.Console.WriteLine("{0} is definitely true", b);
                }
                else
                {
                    System.Console.WriteLine("{0} is not definitely true", b);
                }
            }
        }
        //</Snippet17>
    }


    //---------------------------------------------------------------------------
    namespace WrapGuidelines
    {
        //<Snippet18>
        using System;
        class Test
        {
            public int Num { get; set; }
            public string Str { get; set; }

            static void Main()
            {
                Test a = new Test() { Num = 1, Str = "Hi" };
                Test b = new Test() { Num = 1, Str = "Hi" };

                bool areEqual = System.Object.ReferenceEquals(a, b);
                // False:
                System.Console.WriteLine("ReferenceEquals(a, b) = {0}", areEqual);

                // Assign b to a.
                b = a;

                // Repeat calls with different results.
                areEqual = System.Object.ReferenceEquals(a, b);
                // True:
                System.Console.WriteLine("ReferenceEquals(a, b) = {0}", areEqual);

                // Keep the console open in debug mode.
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
        //</Snippet18>
    }

    // Replaced on 10-13-08 with new correct version.
    // This goes into new topic "how to: implement value equality in a type"
    //<Snippet19>


    namespace ValueEquality
    {
        using System;
        class TwoDPoint : IEquatable<TwoDPoint>
        {
            // Readonly auto-implemented properties.
            public int X { get; private set; }
            public int Y { get; private set; }

            // Set the properties in the constructor.
            public TwoDPoint(int x, int y)
            {
                if ((x < 1) || (x > 2000) || (y < 1) || (y > 2000))
                    throw new System.ArgumentException("Point must be in range 1 - 2000");
                this.X = x;
                this.Y = y;
            }

            public override bool Equals(object obj)
            {
                return this.Equals(obj as TwoDPoint);
            }

            public bool Equals(TwoDPoint p)
            {
                // If parameter is null, return false.
                if (Object.ReferenceEquals(p, null))
                {
                    return false;
                }

                // Optimization for a common success case.
                if (Object.ReferenceEquals(this, p))
                {
                    return true;
                }

                // If run-time types are not exactly the same, return false.
                if (this.GetType() != p.GetType())
                    return false;

                // Return true if the fields match.
                // Note that the base class is not invoked because it is
                // System.Object, which defines Equals as reference equality.
                return (X == p.X) && (Y == p.Y);
            }

            public override int GetHashCode()
            {
                return X * 0x00010000 + Y;
            }

            public static bool operator ==(TwoDPoint lhs, TwoDPoint rhs)
            {
                // Check for null on left side.
                if (Object.ReferenceEquals(lhs, null))
                {
                    if (Object.ReferenceEquals(rhs, null))
                    {
                        // null == null = true.
                        return true;
                    }

                    // Only the left side is null.
                    return false;
                }
                // Equals handles case of null on right side.
                return lhs.Equals(rhs);
            }

            public static bool operator !=(TwoDPoint lhs, TwoDPoint rhs)
            {
                return !(lhs == rhs);
            }
        }

        // For the sake of simplicity, assume a ThreeDPoint IS a TwoDPoint.
        class ThreeDPoint : TwoDPoint, IEquatable<ThreeDPoint>
        {
            public int Z { get; private set; }

            public ThreeDPoint(int x, int y, int z)
                : base(x, y)
            {
                if ((z < 1) || (z > 2000))
                    throw new System.ArgumentException("Point must be in range 1 - 2000");
                this.Z = z;
            }

            public override bool Equals(object obj)
            {
                return this.Equals(obj as ThreeDPoint);
            }

            public bool Equals(ThreeDPoint p)
            {
                // If parameter is null, return false.
                if (Object.ReferenceEquals(p, null))
                {
                    return false;
                }

                // Optimization for a common success case.
                if (Object.ReferenceEquals(this, p))
                {
                    return true;
                }

                // Check properties that this class declares.
                if (Z == p.Z)
                {
                    // Let base class check its own fields 
                    // and do the run-time type comparison.
                    return base.Equals((TwoDPoint)p);
                }
                else
                    return false;
            }

            public override int GetHashCode()
            {
                return (X * 0x100000) + (Y * 0x1000) + Z;
            }

            public static bool operator ==(ThreeDPoint lhs, ThreeDPoint rhs)
            {
                // Check for null.
                if (Object.ReferenceEquals(lhs, null))
                {
                    if (Object.ReferenceEquals(rhs, null))
                    {
                        // null == null = true.
                        return true;
                    }

                    // Only the left side is null.
                    return false;
                }
                // Equals handles the case of null on right side.
                return lhs.Equals(rhs);
            }

            public static bool operator !=(ThreeDPoint lhs, ThreeDPoint rhs)
            {
                return !(lhs == rhs);
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                ThreeDPoint pointA = new ThreeDPoint(3, 4, 5);
                ThreeDPoint pointB = new ThreeDPoint(3, 4, 5);
                ThreeDPoint pointC = null;
                int i = 5;

                Console.WriteLine("pointA.Equals(pointB) = {0}", pointA.Equals(pointB));
                Console.WriteLine("pointA == pointB = {0}", pointA == pointB);
                Console.WriteLine("null comparison = {0}", pointA.Equals(pointC));
                Console.WriteLine("Compare to some other type = {0}", pointA.Equals(i));

                TwoDPoint pointD = null;
                TwoDPoint pointE = null;



                Console.WriteLine("Two null TwoDPoints are equal: {0}", pointD == pointE);

                pointE = new TwoDPoint(3, 4);
                Console.WriteLine("(pointE == pointA) = {0}", pointE == pointA);
                Console.WriteLine("(pointA == pointE) = {0}", pointA == pointE);
                Console.WriteLine("(pointA != pointE) = {0}", pointA != pointE);

                System.Collections.ArrayList list = new System.Collections.ArrayList();
                list.Add(new ThreeDPoint(3, 4, 5));
                Console.WriteLine("pointE.Equals(list[0]): {0}", pointE.Equals(list[0]));

                // Keep the console window open in debug mode.
                System.Console.WriteLine("Press any key to exit.");
                System.Console.ReadKey();
            }
        }

        /* Output:
            pointA.Equals(pointB) = True
            pointA == pointB = True
            null comparison = False
            Compare to some other type = False
            Two null TwoDPoints are equal: True
            (pointE == pointA) = False
            (pointA == pointE) = False
            (pointA != pointE) = True
            pointE.Equals(list[0]): False
        */
    }

    //</Snippet19>

    // Test the Hash Code -- this is not in docs
    namespace ValueEquality
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;
        class Hash
        {
            public static void Main()
            {
                Random rand = new Random();
                List<ThreeDPoint> list = new List<ThreeDPoint>();
                for (int x = 0; x < 100000; x++)
                {
                    list.Add(new ThreeDPoint(rand.Next(1, 2000), rand.Next(1, 2000), rand.Next(1, 2000)));
                }

                list = (from item in list
                        select item)
                        .Distinct()
                        .ToList();

                int uniqueObjects = list.Count();

                Console.WriteLine("there are {0} unique objects", uniqueObjects);

                var uniqueHashCodes = (from item in list
                                       select item.GetHashCode())
                                         .Distinct();

                var hashCodeCount = uniqueHashCodes.Count();

                // This only shows the number of unique values, not the evenness
                // of their distribution. For that there is a LINQ query example in the docs
                // how to group by a range.
                Console.WriteLine("there are {0} unique hash codes", hashCodeCount);

                Console.WriteLine("Distribution:");

                GroupByRange(uniqueHashCodes);

                // Keep the console open in debug mode.
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }


            static int GetRange(int hash, int granularity)
            {
                if (hash <= 0)
                    throw new System.ArgumentException();
                return hash / (System.Int32.MaxValue / granularity);
            }




            private static void GroupByRange(IEnumerable<int> list)
            {
                Console.WriteLine("\r\nGroup by numeric range and project into a new anonymous type:");

                var queryNumericRange =
                    from item in list
                    group item by GetRange(item, 100) into percentGroup
                    orderby percentGroup.Key
                    select percentGroup;

                // Nested foreach required to iterate over groups and group items.
                foreach (var hashGroup in queryNumericRange)
                {
                    Console.WriteLine("Key: {0} Count: {1}", (hashGroup.Key), hashGroup.Count());
                }
            }



        }
    }

    namespace ValueEqualityValueTypes
    {
        using System;
        //<Snippet20>
        struct TwoDPoint : IEquatable<TwoDPoint>
        {
            // Read/write auto-implemented properties.
            public int X { get; private set; }
            public int Y { get; private set; }

            public TwoDPoint(int x, int y)
                : this()
            {
                X = x;
                Y = x;
            }

            public override bool Equals(object obj)
            {
                if (obj is TwoDPoint)
                {
                    return this.Equals((TwoDPoint)obj);
                }
                return false;
            }

            public bool Equals(TwoDPoint p)
            {
                return (X == p.X) && (Y == p.Y);
            }

            public override int GetHashCode()
            {
                return X ^ Y;
            }

            public static bool operator ==(TwoDPoint lhs, TwoDPoint rhs)
            {
                return lhs.Equals(rhs);
            }

            public static bool operator !=(TwoDPoint lhs, TwoDPoint rhs)
            {
                return !(lhs.Equals(rhs));
            }
        }


        class Program
        {
            static void Main(string[] args)
            {
                TwoDPoint pointA = new TwoDPoint(3, 4);
                TwoDPoint pointB = new TwoDPoint(3, 4);
                int i = 5;

                // Compare using virtual Equals, static Equals, and == and != operators.
                // True:
                Console.WriteLine("pointA.Equals(pointB) = {0}", pointA.Equals(pointB));
                // True:
                Console.WriteLine("pointA == pointB = {0}", pointA == pointB);
                // True:
                Console.WriteLine("Object.Equals(pointA, pointB) = {0}", Object.Equals(pointA, pointB));
                // False:
                Console.WriteLine("pointA.Equals(null) = {0}", pointA.Equals(null));
                // False:
                Console.WriteLine("(pointA == null) = {0}", pointA == null);
                // True:
                Console.WriteLine("(pointA != null) = {0}", pointA != null);
                // False:
                Console.WriteLine("pointA.Equals(i) = {0}", pointA.Equals(i));
                // CS0019:
                // Console.WriteLine("pointA == i = {0}", pointA == i); 

                // Compare unboxed to boxed.
                System.Collections.ArrayList list = new System.Collections.ArrayList();
                list.Add(new TwoDPoint(3, 4));
                // True:
                Console.WriteLine("pointE.Equals(list[0]): {0}", pointA.Equals(list[0]));


                // Compare nullable to nullable and to non-nullable.
                TwoDPoint? pointC = null;
                TwoDPoint? pointD = null;
                // False:
                Console.WriteLine("pointA == (pointC = null) = {0}", pointA == pointC);
                // True:
                Console.WriteLine("pointC == pointD = {0}", pointC == pointD);

                TwoDPoint temp = new TwoDPoint(3, 4);
                pointC = temp;
                // True:
                Console.WriteLine("pointA == (pointC = 3,4) = {0}", pointA == pointC);

                pointD = temp;
                // True:
                Console.WriteLine("pointD == (pointC = 3,4) = {0}", pointD == pointC);

                // Keep the console window open in debug mode.
                System.Console.WriteLine("Press any key to exit.");
                System.Console.ReadKey();
            }
        }

        /* Output:
            pointA.Equals(pointB) = True
            pointA == pointB = True
            Object.Equals(pointA, pointB) = True
            pointA.Equals(null) = False
            (pointA == null) = False
            (pointA != null) = True
            pointA.Equals(i) = False
            pointE.Equals(list[0]): True
            pointA == (pointC = null) = False
            pointC == pointD = True
            pointA == (pointC = 3,4) = True
            pointD == (pointC = 3,4) = True
        */
    }
    //</Snippet20>



    namespace WrapGuidelines2
    {
        class Program
        {
            static void Test5()
            {
                /* Commented out to remove deliberate compile warning
                //<Snippet22>
                // An over-simplified example of unreachable code.
                const int val = 5;
                if (val < 4)
                {
                    System.Console.WriteLine("I'll never write anything."); //CS0162
                }
                //</Snippet22>  
                */
            }


            void TestMethod(string s)
            {
                //<Snippet23>
                // Variable declaration statements.
                double area;
                double radius = 2;

                // Constant declaration statement.
                const double pi = 3.14159;
                //</Snippet23> 


                //<Snippet24>    
                // Expression statement (assignment).
                area = 3.14 * (radius * radius);

                // Error. Not  statement because no assignment:
                //circ * 2;

                // Expression statement (method invocation).
                System.Console.WriteLine();

                // Expression statement (new object creation).
                System.Collections.Generic.List<string> strings =
                    new System.Collections.Generic.List<string>();
                //</Snippet24> 

                System.Console.WriteLine(pi.ToString());
            }

            bool GetNextMessage() { return true; }

            bool ProcessMessage()
            {
                if (GetNextMessage())
                {
                    // Code to process message...
                    return true;
                }
                else
                    return false;
            }
            bool done = false;
            //<Snippet25>
            void ProcessMessages()
            {
                while (ProcessMessage())
                    ; // Statement needed here.
            }

            void F()
            {
                //...
                if (done) goto exit;
            //...
            exit:
                ; // Statement needed here.
            }
            //</Snippet25> 

            void G()
            {
                bool b = true;
                //<Snippet26>
                // Recommended style. Embedded statement in  block.
                foreach (string s in System.IO.Directory.GetDirectories(
                                        System.Environment.CurrentDirectory))
                {
                    System.Console.WriteLine(s);
                }

                // Not recommended.
                foreach (string s in System.IO.Directory.GetDirectories(
                                        System.Environment.CurrentDirectory))
                    System.Console.WriteLine(s);
                //</Snippet26>

                /*
                //<Snippet27>
                if(pointB == true)
                    //Error CS1023:
                    int radius = 5; 
                //</Snippet27>
                 */

                //<Snippet28>
                if (b == true)
                {
                    // OK:
                    System.DateTime d = System.DateTime.Now;
                    System.Console.WriteLine(d.ToLongDateString());
                }
                //</Snippet28> 
            }
            string S()
            {
                //<Snippet29>
                foreach (string s in System.IO.Directory.GetDirectories(
                    System.Environment.CurrentDirectory))
                {
                    if (s.StartsWith("CSharp"))
                    {
                        if (s.EndsWith("TempFolder"))
                        {
                            return s;
                        }
                    }

                }
                return "Not found.";
                //</Snippet29>  
            }
        }
    }

    namespace ObjectsTopic
    {
        using System;

        //<Snippet30>
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }
            //Other properties, methods, events...
        }

        class Program
        {
            static void Main()
            {
                Person person1 = new Person("Leopold", 6);
                Console.WriteLine("person1 Name = {0} Age = {1}", person1.Name, person1.Age);

                // Declare  new person, assign person1 to it.
                Person person2 = person1;

                //Change the name of person2, and person1 also changes.
                person2.Name = "Molly";
                person2.Age = 16;

                Console.WriteLine("person2 Name = {0} Age = {1}", person2.Name, person2.Age);
                Console.WriteLine("person1 Name = {0} Age = {1}", person1.Name, person1.Age);

                // Keep the console open in debug mode.
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();

            }
        }
        /*
            Output:
            person1 Name = Leopold Age = 6
            person2 Name = Molly Age = 16
            person1 Name = Molly Age = 16
        */
        //</Snippet30> 


    }


    // Separate namespace to have  struct and class by same name in code examples
    // for comparison in Objects (C# PRogramming Guide)
    namespace ObjectsTopic2
    {
        using System;

        //<Snippet31>    
        public struct Person
        {
            public string Name;
            public int Age;
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }
        }

        public class Application
        {
            static void Main()
            {
                // Create  struct instance and initialize by using "new".
                // Memory is allocated on thread stack.
                Person p1 = new Person("Alex", 9);
                Console.WriteLine("p1 Name = {0} Age = {1}", p1.Name, p1.Age);

                // Create  new struct object. Note that  struct can be initialized
                // without using "new".
                Person p2 = p1;

                // Assign values to p2 members.
                p2.Name = "Spencer";
                p2.Age = 7;
                Console.WriteLine("p2 Name = {0} Age = {1}", p2.Name, p2.Age);

                // p1 values remain unchanged because p2 is  copy.
                Console.WriteLine("p1 Name = {0} Age = {1}", p1.Name, p1.Age);

                // Keep the console open in debug mode.
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
        /*
          Output:
            p1 Name = Alex Age = 9
            p2 Name = Spencer Age = 7
            p1 Name = Alex Age = 9
        */
        //</Snippet31> 

        class Equality
        {
            static void Main()
            {
            //<Snippet32>  
            // Person is defined in the previous example.

            //public struct Person
            //{
            //    public string Name;
            //    public int Age;
            //    public Person(string name, int age)
            //    {
            //        Name = name;
            //        Age = age;
            //    }
            //}

            Person p1 = new Person("Wallace", 75);
            Person p2;
            p2.Name = "Wallace";
            p2.Age = 75;

            if (p2.Equals(p1))
                Console.WriteLine("p2 and p1 have the same values.");

            // Output: p2 and p1 have the same values.
            //</Snippet32> 
            }
        }
    }
    namespace RainyDay
    {
        using System;
        class JustInCase
        {
            static void Main()
            {


                //<Snippet33>    
                Console.WriteLine("Saving for  rainy day.");
                //</Snippet33> 
                //<Snippet34>    
                Console.WriteLine("Saving for  rainy day.");
                //</Snippet34> 
            }

        }
    }
}
