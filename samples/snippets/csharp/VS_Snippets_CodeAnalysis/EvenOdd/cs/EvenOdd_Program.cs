// <snippet1>

using System;
using System.Globalization;
using System.IO;

namespace EvenOdd
{
    class TestSecondsOrNumbersOrFiles
    {
        /* Purpose: Wrap this sample app to create a generic test that passes or fails.  
           
           When you run the EvenOdd app, it exhibits the following Pass/Fail behavior: 
           * Pass zero arguments: EvenOdd randomly returns 1 (Fail) or 0 (Pass).  
           * Pass one (integer) argument: EvenOdd returns 1 if the argument is odd, 0 if even. 
           * Pass two arguments: EvenOdd ignores the first argument and uses only the second one, a string.  
             If the file named by that string has been deployed, EvenOdd returns 0 (Pass); otherwise 1 (Fail). 
        */ 

        [STAThread]
        public static int Main(string[] args)
        {
            // If no argument was supplied, test whether the value of Second is even.
            if (args.Length == 0)
                return TestNumber(DateTime.Now.Second);

            // If only a single numeric (integer) argument was supplied, 
            // test whether the argument is even.
            if (args.Length == 1)
            {
                try
                {               
                    int num = Int32.Parse(args[0], CultureInfo.InvariantCulture);                     
                    return TestNumber(num);
                }
                // catch non-integer argument for args[0]
                catch (FormatException)
                {
                    Console.WriteLine("Please type an integer.");
                    return 1;
                }
                // catch too-large integer argument for args[0]
                catch (OverflowException)
                {                    
                    Console.WriteLine("Type an integer whose value is between {0} and {1}.", int.MinValue, int.MaxValue);
                    return 1;
                }

            }
            // If two arguments are supplied, the test passes if the second
            // argument is the name of a file that has been deployed. 
            if (args.Length == 2)
            {
                if (File.Exists(args[1]))
                    return 0;              
            }
            // Test fails for all other cases
            return 1;                        
        }

        public static int TestNumber(int arg)
        {
            return arg % 2;
        }
    }
}

// </snippet1>
