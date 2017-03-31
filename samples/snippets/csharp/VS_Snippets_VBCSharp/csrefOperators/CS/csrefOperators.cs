
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;



namespace ConsoleApplication1
{

    class ParensOperator
    {
        static void Main()
        {
            // () operator
            //<snippet1>
            double x = 1234.7;
            int a;
            a = (int)x; // Cast double to int    
            //</snippet1>

            //<snippet2>
            TestMethod();
            //</snippet2>
        }

        static void TestMethod() { }
    }

    //<snippet3> 
    //++ operator
    class MainClass
    {
        static void Main()
        {
            double x;
            x = 1.5;
            Console.WriteLine(++x);
            x = 1.5;
            Console.WriteLine(x++);
            Console.WriteLine(x);
        }
    }
    /*
    Output
    2.5
    1.5
    2.5
    */
    //</snippet3>

    // %= operator
    //<snippet4> 

    class Test2
    {
        static void Main()
        {
            int a = 5;
            a %= 3;
            Console.WriteLine(a);
        }
    }
    // Output: 2
    //</snippet4>

    //<snippet5>
    class MainClass2
    {
        static void Main()
        {
            int a = 5;
            a /= 6;
            Console.WriteLine(a);
            double b = 5;
            b /= 6;
            Console.WriteLine(b);
        }
    }
    /*
    Output:
    0
    0.833333333333333
    */
    //</snippet5>

    //<snippet6>
    class MainClass3
    {
        static void Main()
        {
            int a = 5;
            a -= 6;
            Console.WriteLine(a);
        }
    }
    /*
    Output:
    -1
    */

    //</snippet6>

    // !
    //<snippet7>
    class MainClass4
    {
        static void Main()
        {
            Console.WriteLine(!true);
            Console.WriteLine(!false);
        }
    }
    /*
    Output:
    False
    True
    */
    //</snippet7>

    // --
    //<snippet8>
    class MainClass5
    {
        static void Main()
        {
            double x;
            x = 1.5;
            Console.WriteLine(--x);
            x = 1.5;
            Console.WriteLine(x--);
            Console.WriteLine(x);
        }
    }
    /*
    Output:
    0.5
    1.5
    0.5
    */
    //</snippet8>

    // %
    //<snippet9>
    class MainClass6
    {
        static void Main()
        {
            Console.WriteLine(5 % 2);       // int
            Console.WriteLine(-5 % 2);      // int
            Console.WriteLine(5.0 % 2.2);   // double
            Console.WriteLine(5.0m % 2.2m); // decimal
            Console.WriteLine(-5.2 % 2.0);  // double
        }
    }
    /*
    Output:
    1
    -1
    0.6
    0.6
    -1.2
    */

    //</snippet9>

    // |=
    //<snippet10>
    class MainClass7
    {
        static void Main()
        {
            int a = 0x0c;
            a |= 0x06;
            Console.WriteLine("0x{0:x8}", a);
            bool b = true;
            b |= false;
            Console.WriteLine(b);
        }
    }
    /*
    Output:
    0x0000000e
    True
    */

    //</snippet10>

    //<snippet11>
    class MainClass8
    {
        static void Main()
        {
            int a = 1000;
            a >>= 4;
            Console.WriteLine(a);
        }
    }
    /*
    Output:
    62
    */
    //</snippet11>

    //<snippet12>
    class MainClass9
    {
        static void Main()
        {
            int a = 1000;
            a <<= 4;
            Console.WriteLine(a);
        }
    }
    /*
    Output:
    16000
    */
    //</snippet12>

    //<snippet13>
    class MainClass10
    {
        static void Main()
        {
            int a = 5;
            a *= 6;
            Console.WriteLine(a);
        }
    }
    /*
    Output:
    30
    */
    //</snippet13>

    //<snippet14>
    class MainClass11
    {
        static void Main()
        {
            int i = 1;
            long lg = 1;
            // Shift i one bit to the left. The result is 2.
            Console.WriteLine("0x{0:x}", i << 1);
            // In binary, 33 is 100001. Because the value of the five low-order
            // bits is 1, the result of the shift is again 2. 
            Console.WriteLine("0x{0:x}", i << 33);
            // Because the type of lg is long, the shift is the value of the six
            // low-order bits. In this example, the shift is 33, and the value of
            // lg is shifted 33 bits to the left.
            //     In binary:     10 0000 0000 0000 0000 0000 0000 0000 0000 
            //     In hexadecimal: 2    0    0    0    0    0    0    0    0
            Console.WriteLine("0x{0:x}", lg << 33);
        }
    }
    /*
    Output:
    0x2
    0x2
    0x200000000
    */
    //</snippet14>

    //<snippet15>
    // compile with: /unsafe

    struct Point
    {
        public int x, y;
    }

    class MainClass12
    {
        unsafe static void Main()
        {
            Point pt = new Point();
            Point* pp = &pt;
            pp->x = 123;
            pp->y = 456;
            Console.WriteLine("{0} {1}", pt.x, pt.y);
        }
    }
    /*
    Output:
    123 456
    */
    //</snippet15>


    class Test3
    {

        void TestMethod()
        {
            //<snippet16>
            // The class Console in namespace System:
            System.Console.WriteLine("hello");
            //</snippet16>
        }

        //<snippet17>
        class Simple
        {
            public int a;
            public void b()
            {
            }
        }
        //</snippet17>

        void M()
        {
            //<snippet18>     
            Simple s = new Simple();
            //</snippet18>

            //<snippet19>
            s.a = 6;   // assign to field a;
            s.b();     // invoke member function b;
            //</snippet19>

            //<snippet20>
            // The class Console in namespace System:
            System.Console.WriteLine("hello");
            //</snippet20>
        }

    }

    //<snippet21>
    
    namespace ExampleNS
    {
        using System;
        class C
        {
            void M()
            {
                System.Console.WriteLine("hello");
                Console.WriteLine("hello");   // Same as previous line.
            }
        }
    }
    //</snippet21>

    //<snippet22>
    namespace Example2
    {
        class Console
        {
            public static void WriteLine(string s){}
        }
    }
    namespace Example1
    {
        using System;
        using Example2;
        class C
        {
            void M()
            {                
                // Console.WriteLine("hello");   // Compiler error. Ambiguous reference.
                System.Console.WriteLine("hello"); //OK
                Example2.Console.WriteLine("hello"); //OK
            }
        }
    }
    //</snippet22>

    //<snippet23>
    class XORAssignment
    {
        static void Main()
        {
            int a = 0x0c;
            a ^= 0x06;
            Console.WriteLine("0x{0:x8}", a);
            bool b = true;
            b ^= false;
            Console.WriteLine(b);
        }
    }
    /*
    Output:
    0x0000000a
    True
    */
    //</snippet23>

    //<snippet24>
    class LT
    {
        static void Main()
        {
            Console.WriteLine(1 < 1.1);
            Console.WriteLine(1.1 < 1.1);
        }
    }
    /*
    Output:
    True
    False
    */
    //</snippet24>

    //<snippet25>
    class BWC
    {
        static void Main()
        {
            int[] values = { 0, 0x111, 0xfffff, 0x8888, 0x22000022 };
            foreach (int v in values)
            {
                Console.WriteLine("~0x{0:x8} = 0x{1:x8}", v, ~v);
            }
        }
    }
    /*
    Output:
    ~0x00000000 = 0xffffffff
    ~0x00000111 = 0xfffffeee
    ~0x000fffff = 0xfff00000
    ~0x00008888 = 0xffff7777
    ~0x22000022 = 0xddffffdd
    */
    //</snippet25>

    //<snippet26>
    class RightShift
    {
        static void Main()
        {
            int i = -1000;
            Console.WriteLine(i >> 3);
        }
    }
    /*
    Output:
    -125
    */
    //</snippet26>

    class Global
    {
        void M()
        {
            //<snippet27>
            global::System.Console.WriteLine("Hello World");
            //</snippet27>
        }
    }

    //<snippet28>

    class Plus
    {
        static void Main()
        {
            Console.WriteLine(+5);        // unary plus
            Console.WriteLine(5 + 5);     // addition
            Console.WriteLine(5 + .5);    // addition
            Console.WriteLine("5" + "5"); // string concatenation
            Console.WriteLine(5.0 + "5"); // string concatenation
            // note automatic conversion from double to string
        }
    }
    /*
    Output:
    5
    10
    5.5
    55
    55
    */
    //</snippet28>

    //<snippet29>
    class GT
    {
        static void Main()
        {
            Console.WriteLine(1.1 > 1);
            Console.WriteLine(1.1 > 1.1);
        }
    }
    /*
    Output:
    True
    False
    */
    //</snippet29>

    //<snippet30>
    class XOR
    {
        static void Main()
        {
            // Logical exclusive-OR

            // When one operand is true and the other is false, exclusive-OR 
            // returns True.
            Console.WriteLine(true ^ false);
            // When both operands are false, exclusive-OR returns False.
            Console.WriteLine(false ^ false);
            // When both operands are true, exclusive-OR returns False.
            Console.WriteLine(true ^ true);


            // Bitwise exclusive-OR

            // Bitwise exclusive-OR of 0 and 1 returns 1.
            Console.WriteLine("Bitwise result: {0}", Convert.ToString(0x0 ^ 0x1, 2));
            // Bitwise exclusive-OR of 0 and 0 returns 0.
            Console.WriteLine("Bitwise result: {0}", Convert.ToString(0x0 ^ 0x0, 2));
            // Bitwise exclusive-OR of 1 and 1 returns 0.
            Console.WriteLine("Bitwise result: {0}", Convert.ToString(0x1 ^ 0x1, 2));

            // With more than one digit, perform the exclusive-OR column by column.
            //    10
            //    11
            //    --
            //    01
            // Bitwise exclusive-OR of 10 (2) and 11 (3) returns 01 (1).
            Console.WriteLine("Bitwise result: {0}", Convert.ToString(0x2 ^ 0x3, 2));

            // Bitwise exclusive-OR of 101 (5) and 011 (3) returns 110 (6).
            Console.WriteLine("Bitwise result: {0}", Convert.ToString(0x5 ^ 0x3, 2));

            // Bitwise exclusive-OR of 1111 (decimal 15, hexadecimal F) and 0101 (5)
            // returns 1010 (decimal 10, hexadecimal A).
            Console.WriteLine("Bitwise result: {0}", Convert.ToString(0xf ^ 0x5, 2));

            // Finally, bitwise exclusive-OR of 11111000 (decimal 248, hexadecimal F8)
            // and 00111111 (decimal 63, hexadecimal 3F) returns 11000111, which is 
            // 199 in decimal, C7 in hexadecimal.
            Console.WriteLine("Bitwise result: {0}", Convert.ToString(0xf8 ^ 0x3f, 2));
        }
    }
    /*
    Output:
    True
    False
    False
    Bitwise result: 1
    Bitwise result: 0
    Bitwise result: 0
    Bitwise result: 1
    Bitwise result: 110
    Bitwise result: 1010
    Bitwise result: 11000111
    */

    //</snippet30>


    //<snippet31>
    class OR
    {
        static void Main()
        {
            Console.WriteLine(true | false);  // logical or
            Console.WriteLine(false | false); // logical or
            Console.WriteLine("0x{0:x}", 0xf8 | 0x3f);   // bitwise or
        }
    }
    /*
    Output:
    True
    False
    0xff
    */
    //</snippet31>

    //<snippet32>
    class LTE
    {
        static void Main()
        {
            Console.WriteLine(1 <= 1.1);
            Console.WriteLine(1.1 <= 1.1);
        }
    }
    /*
    Output:
    True
    True
    */
    //</snippet32>
    //<snippet33>

    class InequalityTest
    {
        static void Main()
        {
            // Numeric inequality:
            Console.WriteLine((2 + 2) != 4);

            // Reference equality: two objects, same boxed value
            object s = 1;
            object t = 1;
            Console.WriteLine(s != t);

            // String equality: same string value, same string objects
            string a = "hello";
            string b = "hello";

            // compare string values
            Console.WriteLine(a != b);

            // compare string references
            Console.WriteLine((object)a != (object)b);
        }
    }
    /*
    Output:
    False
    True
    False
    False
    */
    //</snippet33>

    //<snippet34>
    class AndAssignment
    {
        static void Main()
        {
            int a = 0x0c;
            a &= 0x06;
            Console.WriteLine("0x{0:x8}", a);
            bool b = true;
            b &= false;
            Console.WriteLine(b);
        }
    }
    /*
    Output:
    0x00000004
    False
    */
    //</snippet34>

    //<snippet35>
    class AddAssigment
    {
        static void Main()
        {
            //addition
            int a = 5;
            a += 6;
            Console.WriteLine(a);

            //string concatenation
            string s = "Hello";
            s += " world.";
            Console.WriteLine(s);
        }
    }
    /*
    Output:
    11
    Hello world
    */
    //</snippet35>

    //<snippet36>
    class Equality
    {
        static void Main()
        {
            // Numeric equality: True
            Console.WriteLine((2 + 2) == 4);

            // Reference equality: different objects, 
            // same boxed value: False.
            object s = 1;
            object t = 1;
            Console.WriteLine(s == t);

            // Define some strings:
            string a = "hello";
            string b = String.Copy(a);
            string c = "hello";

            // Compare string values of a constant and an instance: True
            Console.WriteLine(a == b);

            // Compare string references; 
            // a is a constant but b is an instance: False.
            Console.WriteLine((object)a == (object)b);

            // Compare string references, both constants 
            // have the same value, so string interning
            // points to same reference: True.
            Console.WriteLine((object)a == (object)c);
        }
    }
    /*
    Output:
    True
    False
    True
    False
    True
    */
    //</snippet36>

    class AndTest
    {
        void M()
        {
            //<snippet37>
            int i = 0;
            if (false & ++i == 1)
            {
                // i is incremented, but the conditional
                // expression evaluates to false, so
                // this block does not execute.
            }
            //</snippet37>
        }        
    }

    //<snippet38>
    class BitwiseAnd
    {
        static void Main()
        {
            // The following two statements perform logical ANDs.
            Console.WriteLine(true & false); 
            Console.WriteLine(true & true);  

            // The following line performs a bitwise AND of F8 (1111 1000) and
            // 3F (0011 1111).
            //    1111 1000
            //    0011 1111
            //    ---------
            //    0011 1000 or 38
            Console.WriteLine("0x{0:x}", 0xf8 & 0x3f); 
        }
    }
    // Output:
    // False
    // True
    // 0x38
    //</snippet38>

    //<snippet39>
    class GTE
    {
        static void Main()
        {
            Console.WriteLine(1.1 >= 1);
            Console.WriteLine(1.1 >= 1.1);
        }
    }
    /*
    Output:
    True
    True
    */
    //</snippet39>

    //<snippet40>
    class MinusLinus
    {
        static void Main()
        {
            int a = 5;
            Console.WriteLine(-a);
            Console.WriteLine(a - 1);
            Console.WriteLine(a - .5);
        }
    }
    /*
    Output:
    -5
    4
    4.5
    */
    //</snippet40>

    //<snippet41>
    class ConditionalOp
    {
        static double sinc(double x)
        {
            return x != 0.0 ? Math.Sin(x) / x : 1.0;
        }

        static void Main()
        {
            Console.WriteLine(sinc(0.2));
            Console.WriteLine(sinc(0.1));
            Console.WriteLine(sinc(0.0));
        }
    }
    /*
    Output:
    0.993346653975306
    0.998334166468282
    1
    */
    //</snippet41>

    //<snippet42>
    class Division
    {
        static void Main()
        {        
            Console.WriteLine("\nDividing 7 by 3.");
            // Integer quotient is 2, remainder is 1.
            Console.WriteLine("Integer quotient:           {0}", 7 / 3);
            Console.WriteLine("Negative integer quotient:  {0}", -7 / 3);
            Console.WriteLine("Remainder:                  {0}", 7 % 3);
            // Force a floating point quotient.
            float dividend = 7;
            Console.WriteLine("Floating point quotient:    {0}", dividend / 3);

            Console.WriteLine("\nDividing 8 by 5.");
            // Integer quotient is 1, remainder is 3.
            Console.WriteLine("Integer quotient:           {0}", 8 / 5);
            Console.WriteLine("Negative integer quotient:  {0}", 8 / -5);
            Console.WriteLine("Remainder:                  {0}", 8 % 5);
            // Force a floating point quotient.
            Console.WriteLine("Floating point quotient:    {0}", 8 / 5.0);
        }
    }
    // Output:
    //Dividing 7 by 3.
    //Integer quotient:           2
    //Negative integer quotient:  -2
    //Remainder:                  1
    //Floating point quotient:    2.33333333333333

    //Dividing 8 by 5.
    //Integer quotient:           1
    //Negative integer quotient:  -1
    //Remainder:                  3
    //Floating point quotient:    1.6
    //</snippet42>

    class BracketOperator
    {
        void M()
        {
            //<snippet43>
            int[] fib; // fib is of type int[], "array of int".
            fib = new int[100]; // Create a 100-element int array.
            //</snippet43>

            //<snippet44>
            fib[0] = fib[1] = 1;
            for (int i = 2; i < 100; ++i) fib[i] = fib[i - 1] + fib[i - 2];
            //</snippet44>

            //<snippet45>
            System.Collections.Hashtable h = new System.Collections.Hashtable();
            h["a"] = 123; // Note: using a string as the index.
            //</snippet45>


        }
    }

    public class Attr
    {
        //<snippet46>
        // using System.Diagnostics;
        [Conditional("DEBUG")] 
        void TraceMethod() {}
        //</snippet46>

        //<snippet47>
        unsafe void M()
        {
            int[] nums = {0,1,2,3,4,5};
            fixed ( int* p = nums )
            {
                p[0] = p[1] = 1;
                for( int i=2; i<100; ++i ) p[i] = p[i-1] + p[i-2];
            }
        }
        //</snippet47>
    }

    //<snippet48>
    class LogicalAnd
    {
        static void Main()
        {
            // Each method displays a message and returns a Boolean value. 
            // Method1 returns false and Method2 returns true. When & is used,
            // both methods are called. 
            Console.WriteLine("Regular AND:");
            if (Method1() & Method2())
                Console.WriteLine("Both methods returned true.");
            else
                Console.WriteLine("At least one of the methods returned false.");

            // When && is used, after Method1 returns false, Method2 is 
            // not called.
            Console.WriteLine("\nShort-circuit AND:");
            if (Method1() && Method2())
                Console.WriteLine("Both methods returned true.");
            else
                Console.WriteLine("At least one of the methods returned false.");
        }

        static bool Method1()
        {
            Console.WriteLine("Method1 called.");
            return false;
        }

        static bool Method2()
        {
            Console.WriteLine("Method2 called.");
            return true;
        }
    }
    // Output:
    // Regular AND:
    // Method1 called.
    // Method2 called.
    // At least one of the methods returned false.

    // Short-circuit AND:
    // Method1 called.
    // At least one of the methods returned false.
    //</snippet48>

    //<snippet49>
    class Assignment
    {
        static void Main()
        {
            double x;
            int i;
            i = 5; // int to int assignment
            x = i; // implicit conversion from int to double
            i = (int)x; // needs cast
            Console.WriteLine("i is {0}, x is {1}", i, x);
            object obj = i;
            Console.WriteLine("boxed value = {0}, type is {1}",
                      obj, obj.GetType());
            i = (int)obj;
            Console.WriteLine("unboxed: {0}", i);
        }
    }
    /*
    Output:
    i is 5, x is 5
    boxed value = 5, type is System.Int32
    unboxed: 5
     */
     //</snippet49>


    //<snippet50>
    class Multiply
    {
        static void Main() 
        {
            Console.WriteLine(5 * 2);
            Console.WriteLine(-.5 * .2);
            Console.WriteLine(-.5m * .2m); // decimal type
        }
    }
        /*
    Output
        10
        -0.1
        -0.10
    */
    //</snippet50>

    //<snippet51>
    public class Pointer
    {
        unsafe static void Main()
        {
            int i = 5;
            int* j = &i;
            System.Console.WriteLine(*j);
        }
    }
    /*
    Output:
    5
    */
    //</snippet51>   

    //<snippet52>
    class ConditionalOr
    {
        // Method1 returns true.
        static bool Method1()
        {
            Console.WriteLine("Method1 called.");
            return true;
        }

        // Method2 returns false.
        static bool Method2()
        {
            Console.WriteLine("Method2 called.");
            return false;
        }


        static bool Divisible(int number, int divisor)
        {
            // If the OR expression uses ||, the division is not attempted
            // when the divisor equals 0.
            return !(divisor == 0 || number % divisor != 0);

            // If the OR expression uses |, the division is attempted when
            // the divisor equals 0, and causes a divide-by-zero exception.
            // Replace the return statement with the following line to
            // see the exception.
            //return !(divisor == 0 | number % divisor != 0);
        }

        static void Main()
        {
            // Example #1 uses Method1 and Method2 to demonstrate 
            // short-circuit evaluation.

            Console.WriteLine("Regular OR:");
            // The | operator evaluates both operands, even though after 
            // Method1 returns true, you know that the OR expression is
            // true.
            Console.WriteLine("Result is {0}.\n", Method1() | Method2());

            Console.WriteLine("Short-circuit OR:");
            // Method2 is not called, because Method1 returns true.
            Console.WriteLine("Result is {0}.\n", Method1() || Method2());


            // In Example #2, method Divisible returns True if the
            // first argument is evenly divisible by the second, and False
            // otherwise. Using the | operator instead of the || operator
            // causes a divide-by-zero exception.

            // The following line displays True, because 42 is evenly 
            // divisible by 7.
            Console.WriteLine("Divisible returns {0}.", Divisible(42, 7));

            // The following line displays False, because 42 is not evenly
            // divisible by 5.
            Console.WriteLine("Divisible returns {0}.", Divisible(42, 5));

            // The following line displays False when method Divisible 
            // uses ||, because you cannot divide by 0.
            // If method Divisible uses | instead of ||, this line
            // causes an exception.
            Console.WriteLine("Divisible returns {0}.", Divisible(42, 0));
        }
    }
    /*
    Output:
    Regular OR:
    Method1 called.
    Method2 called.
    Result is True.

    Short-circuit OR:
    Method1 called.
    Result is True.
 
    Divisible returns True.
    Divisible returns False.
    Divisible returns False.
    */
    //</snippet52>   

    //<snippet53>
    class NullCoalesce
    {
        static int? GetNullableInt()
        {
            return null;
        }

        static string GetStringValue()
        {
            return null;
        }

        static void Main()
        {
            int? x = null;

            // Set y to the value of x if x is NOT null; otherwise,
            // if x = null, set y to -1.
            int y = x ?? -1;

            // Assign i to return value of the method if the method's result
            // is NOT null; otherwise, if the result is null, set i to the
            // default value of int.
            int i = GetNullableInt() ?? default(int);

            string s = GetStringValue();
            // Display the value of s if s is NOT null; otherwise, 
            // display the string "Unspecified".
            Console.WriteLine(s ?? "Unspecified");
        }
    }
    //</snippet53>

}
