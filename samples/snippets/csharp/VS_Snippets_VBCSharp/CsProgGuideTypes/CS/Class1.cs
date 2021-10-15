//<snippet5555>
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
//</snippet5555>
namespace CsProgGuideTypes
{
    //-------------------------------------------------------------------------
    class WrapCasting
    {
        //<Snippet1>
        static void TestCasting()
        {
            int i = 10;
            float f = 0;
            f = i;  // An implicit conversion, no data will be lost.
            f = 0.5F;
            i = (int)f;  // An explicit conversion. Information will be lost.
        }
        //</Snippet1>

        //<Snippet2>
        class Test
        {
            static void Main()
            {
                double x = 1234.7;
                int a;
                // Cast double to int.
                a = (int)x;
                System.Console.WriteLine(a);
            }
        }
        // Output: 1234
        //</Snippet2>
    }

    //-------------------------------------------------------------------------
    //<Snippet3>
    class NullableExample
    {
        static void Main()
        {
            int? num = null;

            // Is the HasValue property true?
            if (num.HasValue)
            {
                System.Console.WriteLine("num = " + num.Value);
            }
            else
            {
                System.Console.WriteLine("num = Null");
            }

            // y is set to zero
            int y = num.GetValueOrDefault();

            // num.Value throws an InvalidOperationException if num.HasValue is false
            try
            {
                y = num.Value;
            }
            catch (System.InvalidOperationException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
    }
    //</Snippet3>

    //-------------------------------------------------------------------------
    class UsingNullable
    {
        static void Main()
        {
            //<Snippet4>
            int? i = 10;
            double? d1 = 3.14;
            bool? flag = null;
            char? letter = 'a';
            int?[] arr = new int?[10];
            //</Snippet4>

            // Clear compiler warnings:
            System.Console.WriteLine(i);
            System.Console.WriteLine(d1);
            System.Console.WriteLine(flag);
            System.Console.WriteLine(letter);

            //<Snippet5>
            int? x = 10;
            if (x.HasValue)
            {
                System.Console.WriteLine(x.Value);
            }
            else
            {
                System.Console.WriteLine("Undefined");
            }
            //</Snippet5>

            //<Snippet6>
            int? y = 10;
            if (y != null)
            {
                System.Console.WriteLine(y.Value);
            }
            else
            {
                System.Console.WriteLine("Undefined");
            }
            //</Snippet6>

            //<Snippet7>
            int? n = null;

            //int m1 = n;      // Will not compile.
            int m2 = (int)n;   // Compiles, but will create an exception if n is null.
            int m3 = n.Value;  // Compiles, but will create an exception if n is null.
            //</Snippet7>

            //<Snippet8>
            int? n1 = null;
            //</Snippet8>
            System.Console.WriteLine(n1);

            //<Snippet9>
            int? n2;
            n2 = 10;  // Implicit conversion.
            //</Snippet9>
            System.Console.WriteLine(n2);

            //<Snippet10>
            int? a = 10;
            int? b = null;

            a++;         // Increment by 1, now a is 11.
            a = a * 10;  // Multiply by 10, now a is 110.
            a = a + b;   // Add b, now a is null.
            //</Snippet10>

            //<Snippet11>
            int? num1 = 10;
            int? num2 = null;
            if (num1 >= num2)
            {
                Console.WriteLine("num1 is greater than or equal to num2");
            }
            else
            {
                // This clause is selected, but num1 is not less than num2.
                Console.WriteLine("num1 >= num2 returned false (but num1 < num2 also is false)");
            }

            if (num1 < num2)
            {
                Console.WriteLine("num1 is less than num2");
            }
            else
            {
                // The else clause is selected again, but num1 is not greater than
                // or equal to num2.
                Console.WriteLine("num1 < num2 returned false (but num1 >= num2 also is false)");
            }

            if (num1 != num2)
            {
                // This comparison is true, num1 and num2 are not equal.
                Console.WriteLine("Finally, num1 != num2 returns true!");
            }

            // Change the value of num1, so that both num1 and num2 are null.
            num1 = null;
            if (num1 == num2)
            {
                // The equality comparison returns true when both operands are null.
                Console.WriteLine("num1 == num2 returns true when the value of each is null");
            }

            /* Output:
             * num1 >= num2 returned false (but num1 < num2 also is false)
             * num1 < num2 returned false (but num1 >= num2 also is false)
             * Finally, num1 != num2 returns true!
             * num1 == num2 returns true when the value of each is null
             */
            //</Snippet11>

            //<Snippet12>
            int? c = null;

            // d = c, unless c is null, in which case d = -1.
            int d = c ?? -1;
            //</Snippet12>

            //<Snippet13>
            int? e = null;
            int? f = null;

            // g = e or f, unless e and f are both null, in which case g = -1.
            int g = e ?? f ?? -1;
            //</Snippet13>
        }
    }

    //-------------------------------------------------------------------------
    class BoxingAndUnboxing
    {
        static void Main()
        {
            //<Snippet14>
            int i = 123;
            // The following line boxes i.
            object o = i;
            //</Snippet14>

            //<Snippet15>
            o = 123;
            i = (int)o;  // unboxing
            //</Snippet15>

            //<Snippet47>
            // String.Concat example.
            // String.Concat has many versions. Rest the mouse pointer on
            // Concat in the following statement to verify that the version
            // that is used here takes three object arguments. Both 42 and
            // true must be boxed.
            Console.WriteLine(String.Concat("Answer", 42, true));

            // List example.
            // Create a list of objects to hold a heterogeneous collection
            // of elements.
            List<object> mixedList = new List<object>();

            // Add a string element to the list.
            mixedList.Add("First Group:");

            // Add some integers to the list.
            for (int j = 1; j < 5; j++)
            {
                // Rest the mouse pointer over j to verify that you are adding
                // an int to a list of objects. Each element j is boxed when
                // you add j to mixedList.
                mixedList.Add(j);
            }

            // Add another string and more integers.
            mixedList.Add("Second Group:");
            for (int j = 5; j < 10; j++)
            {
                mixedList.Add(j);
            }

            // Display the elements in the list. Declare the loop variable by
            // using var, so that the compiler assigns its type.
            foreach (var item in mixedList)
            {
                // Rest the mouse pointer over item to verify that the elements
                // of mixedList are objects.
                Console.WriteLine(item);
            }

            // The following loop sums the squares of the first group of boxed
            // integers in mixedList. The list elements are objects, and cannot
            // be multiplied or added to the sum until they are unboxed. The
            // unboxing must be done explicitly.
            var sum = 0;
            for (var j = 1; j < 5; j++)
            {
                // The following statement causes a compiler error: Operator
                // '*' cannot be applied to operands of type 'object' and
                // 'object'.
                //sum += mixedList[j] * mixedList[j]);

                // After the list elements are unboxed, the computation does
                // not cause a compiler error.
                sum += (int)mixedList[j] * (int)mixedList[j];
            }

            // The sum displayed is 30, the sum of 1 + 4 + 9 + 16.
            Console.WriteLine("Sum: " + sum);

            // Output:
            // Answer42True
            // First Group:
            // 1
            // 2
            // 3
            // 4
            // Second Group:
            // 5
            // 6
            // 7
            // 8
            // 9
            // Sum: 30
            //</Snippet47>
        }

        static void Wrap()
        {
            //<Snippet21>
            int i = 123;      // a value type
            object o = i;     // boxing
            int j = (int)o;   // unboxing
            //</Snippet21>
        }
    }

    //-------------------------------------------------------------------------
    //<Snippet16>
    class TestBoxing
    {
        static void Main()
        {
            //<Snippet17>
            int i = 123;
            //</Snippet17>

            //<Snippet18>
            // Boxing copies the value of i into object o.
            object o = i;
            //</Snippet18>

            // Change the value of i.
            i = 456;

            // The change in i doesn't affect the value stored in o.
            System.Console.WriteLine("The value-type value = {0}", i);
            System.Console.WriteLine("The object-type value = {0}", o);
        }
    }
    /* Output:
        The value-type value = 456
        The object-type value = 123
    */
    //</Snippet16>

    //-------------------------------------------------------------------------
    class WrapExplicitBoxing
    {
        static void Main()
        {
            //<Snippet19>
            int i = 123;
            object o = (object)i;  // explicit boxing
            //</Snippet19>
        }
    }

    //-------------------------------------------------------------------------
    //<Snippet20>
    class TestUnboxing
    {
        static void Main()
        {
            int i = 123;
            object o = i;  // implicit boxing

            try
            {
                int j = (short)o;  // attempt to unbox

                System.Console.WriteLine("Unboxing OK.");
            }
            catch (System.InvalidCastException e)
            {
                System.Console.WriteLine("{0} Error: Incorrect unboxing.", e.Message);
            }
        }
    }
    //</Snippet20>

    //-------------------------------------------------------------------------
    public class ConvertByteArrayExample
    {
        static void Main(string[] args)
        {
            //<Snippet22>
            byte[] bytes = { 0, 0, 0, 25 };

            // If the system architecture is little-endian (that is, little end first),
            // reverse the byte array.
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);

            int i = BitConverter.ToInt32(bytes, 0);
            Console.WriteLine("int: {0}", i);
            // Output: int: 25
            //</Snippet22>
        }
    }

    //-------------------------------------------------------------------------
    public class ConvertByteArrayExample2
    {
        static void Main(string[] args)
        {
            //<Snippet23>
            byte[] bytes = BitConverter.GetBytes(201805978);
            Console.WriteLine("byte array: " + BitConverter.ToString(bytes));
            // Output: byte array: 9A-50-07-0C
            //</Snippet23>
        }
    }

    public class ConvertStringExample4
    {
        static void Main(string[] args)
        {
            //<Snippet29>
            string notNumber = "abc";
            int numVal;
            bool parsed = Int32.TryParse(notNumber, out numVal);

            if (!parsed)
                Console.WriteLine("Cannot parse '{0}' to an int.", notNumber);
            //</Snippet29>
        }
    }

    //-------------------------------------------------------------------------
    public class ConvertHexadecimalStrings
    {
        static void Main(string[] args)
        {
            //<Snippet30>
            string input = "Hello World!";
            char[] values = input.ToCharArray();
            foreach (char letter in values)
            {
                // Get the integral value of the character.
                int value = Convert.ToInt32(letter);
                // Convert the integer value to a hexadecimal value in string form.
                Console.WriteLine($"Hexadecimal value of {letter} is {value:X}");
            }
            /* Output:
                Hexadecimal value of H is 48
                Hexadecimal value of e is 65
                Hexadecimal value of l is 6C
                Hexadecimal value of l is 6C
                Hexadecimal value of o is 6F
                Hexadecimal value of   is 20
                Hexadecimal value of W is 57
                Hexadecimal value of o is 6F
                Hexadecimal value of r is 72
                Hexadecimal value of l is 6C
                Hexadecimal value of d is 64
                Hexadecimal value of ! is 21
             */
            //</Snippet30>

            //<Snippet31>
            string hexValues = "48 65 6C 6C 6F 20 57 6F 72 6C 64 21";
            string[] hexValuesSplit = hexValues.Split(' ');
            foreach (string hex in hexValuesSplit)
            {
                // Convert the number expressed in base-16 to an integer.
                int value = Convert.ToInt32(hex, 16);
                // Get the character corresponding to the integral value.
                string stringValue = Char.ConvertFromUtf32(value);
                char charValue = (char)value;
                Console.WriteLine("hexadecimal value = {0}, int value = {1}, char value = {2} or {3}",
                                    hex, value, stringValue, charValue);
            }
            /* Output:
                hexadecimal value = 48, int value = 72, char value = H or H
                hexadecimal value = 65, int value = 101, char value = e or e
                hexadecimal value = 6C, int value = 108, char value = l or l
                hexadecimal value = 6C, int value = 108, char value = l or l
                hexadecimal value = 6F, int value = 111, char value = o or o
                hexadecimal value = 20, int value = 32, char value =   or
                hexadecimal value = 57, int value = 87, char value = W or W
                hexadecimal value = 6F, int value = 111, char value = o or o
                hexadecimal value = 72, int value = 114, char value = r or r
                hexadecimal value = 6C, int value = 108, char value = l or l
                hexadecimal value = 64, int value = 100, char value = d or d
                hexadecimal value = 21, int value = 33, char value = ! or !
            */
            //</Snippet31>

            //<Snippet32>
            string hexString = "8E2";
            int num = Int32.Parse(hexString, System.Globalization.NumberStyles.HexNumber);
            Console.WriteLine(num);
            //Output: 2274
            //</Snippet32>

            //see also snippet38 below
        }
    }

    //Types and Type Conversions f782d7cc-035e-4500-b1b1-36a9881130ad
    //<snippet33>
    class MyType
    {
        // An integer variable.
        int num = 5;

        // num string constant.
        const string name = "Rocky";

        // num System.DateTime variable.
        System.DateTime startDate = new System.DateTime(2008, 2, 27);

        // Method that takes a DateTime and returns a bool.
        bool IsValidDate(System.DateTime dt)
        {
            return dt < System.DateTime.Today ? true : false;
        }
    }
    //</snippet33>

    class ValueTypeConversion
    {
        static void Main()
        {
            //<snippet34>
            // Implicit conversion. A long can
            // hold any value an int can hold, and more!
            int num = 2147483647;
            long bigNum = num;
            //</snippet34>
        }
    }

    class ConvertHexStrings2
    {
        static void Main()
        {
            //<snippet38>
            byte[] vals = { 0x01, 0xAA, 0xB1, 0xDC, 0x10, 0xDD };

            string str = BitConverter.ToString(vals);
            Console.WriteLine(str);

            str = BitConverter.ToString(vals).Replace("-", "");
            Console.WriteLine(str);

            /*Output:
              01-AA-B1-DC-10-DD
              01AAB1DC10DD
             */
            //</snippet38>

            //<snippet39>

            string hexString = "43480170";
            uint num = uint.Parse(hexString, System.Globalization.NumberStyles.AllowHexSpecifier);

            byte[] floatVals = BitConverter.GetBytes(num);
            float f = BitConverter.ToSingle(floatVals, 0);
            Console.WriteLine("float convert = {0}", f);

            // Output: 200.0056
            //</snippet39>

            //<snippet48>
            byte[] array = { 0x64, 0x6f, 0x74, 0x63, 0x65, 0x74 };

            string hexValue = Convert.ToHexString(array);
            Console.WriteLine(hexValue);

            /*Output:
              646F74636574
             */
            //</snippet48>
            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }

    //<snippet40>
    class SafeCasting
    {
        class Animal
        {
            public void Eat() { Console.WriteLine("Eating."); }
            public override string ToString()
            {
                return "I am an animal.";
            }
        }
        class Mammal : Animal { }
        class Giraffe : Mammal { }

        class SuperNova { }

        static void Main()
        {
            SafeCasting app = new SafeCasting();

            // Use the is operator to verify the type.
            // before performing a cast.
            Giraffe g = new Giraffe();
            app.UseIsOperator(g);

            // Use the as operator and test for null
            // before referencing the variable.
            app.UseAsOperator(g);

            // Use the as operator to test
            // an incompatible type.
            SuperNova sn = new SuperNova();
            app.UseAsOperator(sn);

            // Use the as operator with a value type.
            // Note the implicit conversion to int? in
            // the method body.
            int i = 5;
            app.UseAsWithNullable(i);

            double d = 9.78654;
            app.UseAsWithNullable(d);

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }

        void UseIsOperator(Animal a)
        {
            if (a is Mammal)
            {
                Mammal m = (Mammal)a;
                m.Eat();
            }
        }

        void UseAsOperator(object o)
        {
            Mammal m = o as Mammal;
            if (m != null)
            {
                Console.WriteLine(m.ToString());
            }
            else
            {
                Console.WriteLine("{0} is not a Mammal", o.GetType().Name);
            }
        }

        void UseAsWithNullable(System.ValueType val)
        {
            int? j = val as int?;
            if (j != null)
            {
                Console.WriteLine(j);
            }
            else
            {
                Console.WriteLine("Could not convert " + val.ToString());
            }
        }
    }
    //</snippet40>

    //<snippet41>
    class Animal
    {
        public void Eat() => System.Console.WriteLine("Eating.");

        public override string ToString() => "I am an animal.";
    }

    class Reptile : Animal { }
    class Mammal : Animal { }

    class UnSafeCast
    {
        static void Main()
        {
            Test(new Mammal());

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }

        static void Test(Animal a)
        {
            // System.InvalidCastException at run time
            // Unable to cast object of type 'Mammal' to type 'Reptile'
            Reptile r = (Reptile)a;
        }
    }
    //</snippet41>

    //<snippet43>
    class ValueTypeDemo
    {
        static void PassByValue(int i)
        {

            i = 5;
            Console.WriteLine("PassByValue: local copy = {0}", i);
        }

        static void PassByReference(ref int i)
        {

            i = 5;
            Console.WriteLine("PassByReference: local copy = {0}", i);
        }

        static void Main()
        {
            int num = 1;

            // Pass num by value (default behavior for value types).
            PassByValue(num);
            Console.WriteLine("After calling PassByValue, num = {0}", num);

            //Pass num by reference.
            PassByReference(ref num);
            Console.WriteLine("After calling PassByReference, num = {0}", num);

            // Keep the console open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    /*
       Output:
        PassByValue: local copy = 5
        After calling PassByValue, num = 1
        PassByReference: local copy = 5
        After calling PassByReference, num = 5
    */
    //</snippet43>

    //<Snippet46>
    class Base { }
    class Derived : Base { }

    class GetTypeInfo
    {

        static void Main()
        {
            Derived derived = new Derived();

            // The 'is' keyword is polymorphic.

            Console.WriteLine("derived is Derived = {0}", derived is Derived);
            // true:
            Console.WriteLine("derived is Base = {0}", derived is Base);

            // GetType returns the exact run-time type.
            object o = derived;
            Console.WriteLine("The run-time type of o is {0}", o.GetType().Name);
        }
    }
    /* Output:
        derived is Derived = True
        derived is Base = True
        The run-time type of o is Derived
     */

    //</Snippet46>
}
