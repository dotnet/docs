using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csrefKeywordsConversion
{
    //<snippet1>
    
    class Celsius
    {
        public Celsius(float temp)
        {
            degrees = temp;
        }
        public static explicit operator Fahrenheit(Celsius c)
        {
            return new Fahrenheit((9.0f / 5.0f) * c.degrees + 32);
        }
        public float Degrees
        {
            get { return degrees; }
        }
        private float degrees;
    }

    class Fahrenheit
    {
        public Fahrenheit(float temp)
        {
            degrees = temp;
        }
        //<snippet2>
        // Must be defined inside a class called Fahrenheit:
        public static explicit operator Celsius(Fahrenheit fahr)
        {
            return new Celsius((5.0f / 9.0f) * (fahr.degrees - 32));
        }
        //</snippet2>
        public float Degrees
        {
            get { return degrees; }
        }
        private float degrees;
    }

    class MainClass
    {
        static void Main()
        {
            //<snippet3>            
            Fahrenheit fahr = new Fahrenheit(100.0f);
            Console.Write("{0} Fahrenheit", fahr.Degrees);
            Celsius c = (Celsius)fahr;
            //</snippet3>

            Console.Write(" = {0} Celsius", c.Degrees);
            Fahrenheit fahr2 = (Fahrenheit)c;
            Console.WriteLine(" = {0} Fahrenheit", fahr2.Degrees);
        }
    }
    // Output:
    // 100 Fahrenheit = 37.77778 Celsius = 100 Fahrenheit
    //</snippet1>

    //<snippet4>    
    struct Digit
    {
        byte value;
        public Digit(byte value)
        {
            if (value > 9)
            {
                throw new ArgumentException();
            }
            this.value = value;
        }

        // Define explicit byte-to-Digit conversion operator:
        public static explicit operator Digit(byte b)
        {
            Digit d = new Digit(b);
            Console.WriteLine("conversion occurred");
            return d;
        }
    }

    class ExplicitTest
    {
        static void Main()
        {
            try
            {
                byte b = 3;
                Digit d = (Digit)b; // explicit conversion
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
    }
    /*
    Output:
    conversion occurred
    */
    //</snippet4>

    namespace implicitExample
    {
        //<snippet5>
        class Digit
        {
            public Digit(double d) { val = d; }
            public double val;
            // ...other members

            // User-defined conversion from Digit to double
            public static implicit operator double(Digit d)
            {
                return d.val;
            }
            //  User-defined conversion from double to Digit
            public static implicit operator Digit(double d)
            {
                return new Digit(d);
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Digit dig = new Digit(7);
                //This call invokes the implicit "double" operator
                double num = dig;
                //This call invokes the implicit "Digit" operator
                Digit dig2 = 12;
                Console.WriteLine("num = {0} dig2 = {1}", num, dig2.val);
                Console.ReadLine();
            }
        }
        //</snippet5>
    }



    //<snippet6>
    class Fraction
    {
        int num, den;
        public Fraction(int num, int den)
        {
            this.num = num;
            this.den = den;
        }

        // overload operator +
        public static Fraction operator +(Fraction a, Fraction b)
        {
            return new Fraction(a.num * b.den + b.num * a.den,
               a.den * b.den);
        }

        // overload operator *
        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(a.num * b.num, a.den * b.den);
        }

        // user-defined conversion from Fraction to double
        public static implicit operator double(Fraction f)
        {
            return (double)f.num / f.den;
        }
    }

    class Test
    {
        static void Main()
        {
            Fraction a = new Fraction(1, 2);
            Fraction b = new Fraction(3, 7);
            Fraction c = new Fraction(2, 3);
            Console.WriteLine((double)(a * b + c));
        }
    }
    /*
    Output
    0.880952380952381
    */

    //</snippet6>




}