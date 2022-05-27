using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace keywords
{
    public class RefKeywordsExceptions
    {
        //<snippet1>
        public class EHClass
        {
            void ReadFile(int index)
            {
                // To run this code, substitute a valid path from your local machine
                string path = @"c:\users\public\test.txt";
                System.IO.StreamReader file = new System.IO.StreamReader(path);
                char[] buffer = new char[10];
                try
                {
                    file.ReadBlock(buffer, index, buffer.Length);
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine("Error reading from {0}. Message = {1}", path, e.Message);
                }
                finally
                {
                    if (file != null)
                    {
                        file.Close();
                    }
                }
                // Do something with buffer...
            }
        }

        //</snippet1>

        //<snippet2>
        class TryFinallyTest
        {
            static void ProcessString(string s)
            {
                if (s == null)
                {
                    throw new ArgumentNullException(paramName: nameof(s), message: "parameter can't be null.");
                }
            }

            public static void Main()
            {
                string s = null; // For demonstration purposes.

                try
                {
                    ProcessString(s);
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }
            }
        }
        /*
        Output:
        System.ArgumentNullException: Value cannot be null.
           at TryFinallyTest.Main() Exception caught.
         * */
        //</snippet2>

        //<snippet3>
        class ThrowTest3
        {
            static void ProcessString(string s)
            {
                if (s == null)
                {
                    throw new ArgumentNullException(paramName: nameof(s), message: "Parameter can't be null");
                }
            }

            public static void Main()
            {
                try
                {
                    string s = null;
                    ProcessString(s);
                }
                // Most specific:
                catch (ArgumentNullException e)
                {
                    Console.WriteLine("{0} First exception caught.", e);
                }
                // Least specific:
                catch (Exception e)
                {
                    Console.WriteLine("{0} Second exception caught.", e);
                }
            }
        }
        /*
         Output:
         System.ArgumentNullException: Value cannot be null.
         at Test.ThrowTest3.ProcessString(String s) ... First exception caught.
        */
        //</snippet3>

        //<snippet4>
        public class ThrowTestA
        {
            public static void Main()
            {
                int i = 123;
                string s = "Some string";
                object obj = s;

                try
                {
                    // Invalid conversion; obj contains a string, not a numeric type.
                    i = (int)obj;

                    // The following statement is not run.
                    Console.WriteLine("WriteLine at the end of the try block.");
                }
                finally
                {
                    // To run the program in Visual Studio, type CTRL+F5. Then
                    // click Cancel in the error dialog.
                    Console.WriteLine("\nExecution of the finally block after an unhandled\n" +
                        "error depends on how the exception unwind operation is triggered.");
                    Console.WriteLine("i = {0}", i);
                }
            }
            // Output:
            // Unhandled Exception: System.InvalidCastException: Specified cast is not valid.
            //
            // Execution of the finally block after an unhandled
            // error depends on how the exception unwind operation is triggered.
            // i = 123
        }
        //</snippet4>

        //<snippet5>
        public class ThrowTest2
        {

            static int GetNumber(int index)
            {
                int[] nums = { 300, 600, 900 };
                if (index > nums.Length)
                {
                    throw new IndexOutOfRangeException();
                }
                return nums[index];
            }
            public static void Main()
            {
                int result = GetNumber(3);
            }
        }
        /*
            Output:
            The System.IndexOutOfRangeException exception occurs.
        */

        //</snippet5>

        //<snippet6>
        public class ThrowTestB
        {
            public static void Main()
            {
                try
                {
                    // TryCast produces an unhandled exception.
                    TryCast();
                }
                catch (Exception ex)
                {
                    // Catch the exception that is unhandled in TryCast.
                    Console.WriteLine
                        ("Catching the {0} exception triggers the finally block.",
                        ex.GetType());

                    // Restore the original unhandled exception. You might not
                    // know what exception to expect, or how to handle it, so pass
                    // it on.
                    throw;
                }
            }

            static void TryCast()
            {
                int i = 123;
                string s = "Some string";
                object obj = s;

                try
                {
                    // Invalid conversion; obj contains a string, not a numeric type.
                    i = (int)obj;

                    // The following statement is not run.
                    Console.WriteLine("WriteLine at the end of the try block.");
                }
                finally
                {
                    // Report that the finally block is run, and show that the value of
                    // i has not been changed.
                    Console.WriteLine("\nIn the finally block in TryCast, i = {0}.\n", i);
                }
            }
            // Output:
            // In the finally block in TryCast, i = 123.

            // Catching the System.InvalidCastException exception triggers the finally block.

            // Unhandled Exception: System.InvalidCastException: Specified cast is not valid.
        }
        //</snippet6>
    }
}
