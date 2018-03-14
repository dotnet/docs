using System;

namespace SingleSnippet
{
    class SingleSample {
        public SingleSample()
        {
            //<snippet1> 
            Single s = 4.55F;
            //</snippet1>

            //<snippet2> 
            Console.WriteLine("A Single is of type {0}.", s.GetType().ToString());
            //</snippet2>

            //<snippet3> 
            bool done = false;
            string inp;
            do
            {
                Console.Write("Enter a real number: ");
                inp = Console.ReadLine();
                try
                {
                    s = Single.Parse(inp);
                    Console.WriteLine("You entered {0}.", s.ToString());
                    done = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("You did not enter a number.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("An exception occurred while parsing your response: {0}", e.ToString());
                }
            } while (!done);
            //</snippet3>

            //<snippet4> 
            if (s > Single.MaxValue)
            {
                Console.WriteLine("Your number is larger than a Single.");
            }
            //</snippet4>

            //<snippet5> 
            if (s < Single.MinValue)
            {
                Console.WriteLine("Your number is smaller than a Single.");
            }
            //</snippet5>

            //<snippet6> 
            Console.WriteLine("Epsilon, or the permittivity of a vacuum, has value {0}", Single.Epsilon.ToString());
            //</snippet6>

            //<snippet7> 
            Single zero = 0;

            // This condition will return false.
            if ((0 / zero) == Single.NaN)
            {
                Console.WriteLine("0 / 0 can be tested with Single.NaN.");
            }
            else
            {
                Console.WriteLine("0 / 0 cannot be tested with Single.NaN; use Single.IsNan() instead.");
            }
            //</snippet7>

            //<snippet8> 
            // This will return true.
            if (Single.IsNaN(0 / zero))
            {
                Console.WriteLine("Single.IsNan() can determine whether a value is not-a-number.");
            }
            //</snippet8>

            //<snippet9> 
            // This will equal Infinity.
            Console.WriteLine("10.0 minus NegativeInfinity equals {0}.", (10.0 - Single.NegativeInfinity).ToString());
            //</snippet9>

            //<snippet10> 
            // This will equal Infinity.
            Console.WriteLine("PositiveInfinity plus 10.0 equals {0}.", (Single.PositiveInfinity + 10.0).ToString());
            //</snippet10>

            //<snippet11> 
            // This will return "true".
            Console.WriteLine("IsInfinity(3.0F / 0) == {0}.", Single.IsInfinity(3.0F / 0) ? "true" : "false");
            //</snippet11>

            //<snippet12> 
            // This will return true.
            Console.WriteLine("IsPositiveInfinity(4.0F / 0) == {0}.", Single.IsPositiveInfinity(4.0F / 0) ? "true" : "false");
            //</snippet12>

            //<snippet13> 
            // This will return true.
            Console.WriteLine("IsNegativeInfinity(-5.0F / 0) == {0}.", Single.IsNegativeInfinity(-5.0F / 0) ? "true" : "false");
            //</snippet13>

            //<snippet14>
            Single a;
            a = 500;

            Object obj1;
            //</snippet14>

            //<snippet15> 
            // The variables point to the same objects.
            Object obj2;
            obj1 = a;
            obj2 = obj1;

            if (Single.ReferenceEquals(obj1, obj2))
            {
                Console.WriteLine("The variables point to the same Single object.");
            }
            else
            {
                Console.WriteLine("The variables point to different Single objects.");
            }
            //</snippet15>

            //<snippet16> 
            obj1 = (Single)450;

            if (a.CompareTo(obj1) < 0)
            {
                Console.WriteLine("{0} is less than {1}.", a.ToString(), obj1.ToString());
            }

            if (a.CompareTo(obj1) > 0)
            {
                Console.WriteLine("{0} is greater than {1}.", a.ToString(), obj1.ToString());
            }

            if (a.CompareTo(obj1) == 0)
            {
                Console.WriteLine("{0} equals {1}.", a.ToString(), obj1.ToString());
            }
            //</snippet16>

            //<snippet17> 
            obj1 = (Single)500;
            if (a.Equals(obj1)) {
                Console.WriteLine("The value type and reference type values are equal.");
            }
            //</snippet17>
        }
    }
}

class EntryPoint
{
    static void Main(string[] args)
    {
        new SingleSnippet.SingleSample();
    }

}