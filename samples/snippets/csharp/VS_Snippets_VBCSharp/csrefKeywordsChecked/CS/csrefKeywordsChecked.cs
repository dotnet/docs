using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csrefKeywordsChecked
{
    //<snippet1>
    class OverFlowTest
    {
        // Set maxIntValue to the maximum value for integers.
        static int maxIntValue = 2147483647;

        // Using a checked expression.
        static int CheckedMethod()
        {
            int z = 0;
            try
            {
                // The following line raises an exception because it is checked.
                z = checked(maxIntValue + 10);
            }
            catch (System.OverflowException e)
            {
                // The following line displays information about the error.
                Console.WriteLine("CHECKED and CAUGHT:  " + e.ToString());
            }
            // The value of z is still 0.
            return z;
        }

        // Using an unchecked expression.
        static int UncheckedMethod()
        {
            int z = 0;
            try
            {
                // The following calculation is unchecked and will not
                // raise an exception.
                z = maxIntValue + 10;
            }
            catch (System.OverflowException e)
            {
                // The following line will not be executed.
                Console.WriteLine("UNCHECKED and CAUGHT:  " + e.ToString());
            }
            // Because of the undetected overflow, the sum of 2147483647 + 10 is
            // returned as -2147483639.
            return z;
        }

        static void Main()
        {
            Console.WriteLine("\nCHECKED output value is: {0}",
                              CheckedMethod());
            Console.WriteLine("UNCHECKED output value is: {0}",
                              UncheckedMethod());
        }
        /*
       Output:
       CHECKED and CAUGHT:  System.OverflowException: Arithmetic operation resulted
       in an overflow.
          at ConsoleApplication1.OverFlowTest.CheckedMethod()

       CHECKED output value is: 0
       UNCHECKED output value is: -2147483639
     */
    }
    //</snippet1>

    // <Snippet2>
    class UncheckedDemo
    {
        static void Main(string[] args)
        {
            // int.MaxValue is 2,147,483,647.
            const int ConstantMax = int.MaxValue;
            int int1;
            int int2;
            int variableMax = 2147483647;

            // The following statements are checked by default at compile time. They do not
            // compile.
            //int1 = 2147483647 + 10;
            //int1 = ConstantMax + 10;

            // To enable the assignments to int1 to compile and run, place them inside
            // an unchecked block or expression. The following statements compile and
            // run.
            // <Snippet5>
            unchecked
            {
                int1 = 2147483647 + 10;
            }
            int1 = unchecked(ConstantMax + 10);
            // </Snippet5>

            // The sum of 2,147,483,647 and 10 is displayed as -2,147,483,639.
            Console.WriteLine(int1);

            // The following statement is unchecked by default at compile time and run
            // time because the expression contains the variable variableMax. It causes
            // overflow but the overflow is not detected. The statement compiles and runs.
            int2 = variableMax + 10;

            // Again, the sum of 2,147,483,647 and 10 is displayed as -2,147,483,639.
            Console.WriteLine(int2);

            // To catch the overflow in the assignment to int2 at run time, put the
            // declaration in a checked block or expression. The following
            // statements compile but raise an overflow exception at run time.
            checked
            {
                //int2 = variableMax + 10;
            }
            //int2 = checked(variableMax + 10);

            // Unchecked sections frequently are used to break out of a checked
            // environment in order to improve performance in a portion of code
            // that is not expected to raise overflow exceptions.
            checked
            {
                // Code that might cause overflow should be executed in a checked
                // environment.
                unchecked
                {
                    // This section is appropriate for code that you are confident
                    // will not result in overflow, and for which performance is
                    // a priority.
                }
                // Additional checked code here.
            }
        }
    }
    // </Snippet2>

    class CheckedAndUnchecked
    {
        static void Main()
        {
            tests();
        }

        static void tests()
        {
            //<snippet3>
            // The following example causes compiler error CS0220 because 2147483647
            // is the maximum value for integers.
            //int i1 = 2147483647 + 10;

            // The following example, which includes variable ten, does not cause
            // a compiler error.
            int ten = 10;
            int i2 = 2147483647 + ten;

            // By default, the overflow in the previous statement also does
            // not cause a run-time exception. The following line displays
            // -2,147,483,639 as the sum of 2,147,483,647 and 10.
            Console.WriteLine(i2);
            //</snippet3>

            //<Snippet4>
            // If the previous sum is attempted in a checked environment, an
            // OverflowException error is raised.

            // Checked expression.
            Console.WriteLine(checked(2147483647 + ten));

            // Checked block.
            checked
            {
                int i3 = 2147483647 + ten;
                Console.WriteLine(i3);
            }
            //</Snippet4>
        }
    }
}
