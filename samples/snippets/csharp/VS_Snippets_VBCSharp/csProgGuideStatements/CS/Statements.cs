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

            int y = 0;

            //<Snippet5>
            y++;
            //</Snippet5>

            //<Snippet6>
            y = 2 + 3;
            //</Snippet6>
        }
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

    // This is no longer in docs, replaced by ~docs\docs\csharp\programming-guide\statements-expressions-operators\snippets\how-to-define-value-equality-for-a-type\ValueEqualityClass\Program.cs
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
                {
                    throw new System.ArgumentException("Point must be in range 1 - 2000");
                }
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
                {
                    return false;
                }

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
                {
                    throw new System.ArgumentException("Point must be in range 1 - 2000");
                }
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
                {
                    return false;
                }
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
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
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

    // This is no longer in docs, replaced by ~docs\docs\csharp\programming-guide\statements-expressions-operators\snippets\how-to-define-value-equality-for-a-type\ValueEqualityStruct\Program.cs
    namespace ValueEqualityValueTypes
    {
        //<Snippet20>
        using System;
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
                Console.WriteLine("object.Equals(pointA, pointB) = {0}", object.Equals(pointA, pointB));
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
                Console.WriteLine("pointA.Equals(list[0]): {0}", pointA.Equals(list[0]));

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
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
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
                {
                    return false;
                }
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
}
