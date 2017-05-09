using System;
using System.IO;
namespace CsCsrefProgrammingExceptions
{
    
    //-------------------------------------------------------------------------
    class UsingExceptions
    {
        //<Snippet1>

        class CustomException : Exception
        {
            public CustomException(string message)
            {
               
            }
 
        }
        private static void TestThrow()
        {
            CustomException ex =
                new CustomException("Custom exception in TestThrow()");

            throw ex;
        }
        //</Snippet1>

        

        //<Snippet2>
        static void TestCatch()
        {
            try
            {
                TestThrow();
            }
            catch (CustomException ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
        }
        //</Snippet2>


        //<Snippet3>
        static void TestCatch2()
        {
            System.IO.StreamWriter sw = null;
            try
            {
                sw = new System.IO.StreamWriter(@"C:\test\test.txt");
                sw.WriteLine("Hello");
            }

            catch (System.IO.FileNotFoundException ex)
            {
                // Put the more specific exception first.
                System.Console.WriteLine(ex.ToString());  
            }

            catch (System.IO.IOException ex)
            {
                // Put the less specific exception last.
                System.Console.WriteLine(ex.ToString());  
            }
            finally 
            {
                sw.Close();
            }

            System.Console.WriteLine("Done"); 
        }
        //</Snippet3>


        //<Snippet4>
        static void TestFinally()
        {
            System.IO.FileStream file = null;
            //Change the path to something that works on your machine.
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(@"C:\file.txt");

            try
            {
                file = fileInfo.OpenWrite();
                file.WriteByte(0xF);
            }
            finally
            {
                // Closing the file allows you to reopen it immediately - otherwise IOException is thrown.
                if (file != null)
                {
                    file.Close();
                }
            }

            try
            {
                file = fileInfo.OpenWrite();
                System.Console.WriteLine("OpenWrite() succeeded");
            }
            catch (System.IO.IOException)
            {
                System.Console.WriteLine("OpenWrite() failed");
            }
        }
        //</Snippet4>

        public static void Main()
        {
            TestFinally();
            Console.WriteLine("Done. Press a key to exit.");
            Console.ReadKey();
        }
    }


    //-------------------------------------------------------------------------
    //<Snippet5>
    class TestTryCatch
    {
        static int GetInt(int[] array, int index)
        {
            try
            {
                return array[index];
            }
            catch (System.IndexOutOfRangeException e)  // CS0168
            {
                System.Console.WriteLine(e.Message);
                // Set IndexOutOfRangeException to the new exception's InnerException.
                throw new System.ArgumentOutOfRangeException("index parameter is out of range.", e);
            }
        }
    }
    //</Snippet5>
    
    // TODO MOVE THIS EXAMPLE INTO EXCEPTIONS AND EXCEPTION HANDLING TOPIC AFTER JAN CPUB
    //-------------------------------------------------------------------------
    class Exceptions
    {
        static double SafeDivision(double x, double y)
        {
            if (y == 0)
                throw new System.DivideByZeroException();
            return x / y;
        }
        static void Main()
        {
            // Input for test purposes. Change values
            // to see exception handling behavior.
            double a = 98, b = 0;
            double result = 0;
            
            try
            {
                result = SafeDivision(a, b);
                Console.WriteLine("{0} divided by {1} = {2}", a, b, result);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Attempted divide by zero.");
            }
        }
    }


    //-------------------------------------------------------------------------
    class ExceptionHandling
    {
        class SomeSpecificException : Exception { }
        static void Main()
        {
            //<Snippet6>
            try
            {
                // Code to try goes here.
            }
            catch (SomeSpecificException ex)
            {
                // Code to handle the exception goes here.
                // Only catch exceptions that you know how to handle.
                // Never catch base class System.Exception without
                // rethrowing it at the end of the catch block.
            }
            //</Snippet6>


            //<Snippet7>
            try
            {
                // Code to try goes here.
            }
            finally
            {
                // Code to execute after the try block goes here.
            }
            //</Snippet7>


            //<Snippet8>
            try
            {
                // Code to try goes here.
            }
            catch (SomeSpecificException ex)
            {
                // Code to handle the exception goes here.
            }
            finally
            {
                // Code to execute after the try (and possibly catch) blocks 
                // goes here.
            }
            //</Snippet8>


            //<Snippet10>
            try
            {
                // Try to access a resource.
            }
            catch (System.UnauthorizedAccessException e)
            {
                // Call a custom error logging procedure.
                LogError(e);
                // Re-throw the error.
                throw;     
            }
            //</Snippet10>


            //<Snippet11>
            System.IO.FileStream file = null;
            System.IO.FileInfo fileinfo = new System.IO.FileInfo("C:\\file.txt");
            try
            {
                file = fileinfo.OpenWrite();
                file.WriteByte(0xF);
            }
            finally
            {
                // Check for null because OpenWrite might have failed.
                if (file != null)
                {
                    file.Close();
                }
            }
            //</Snippet11>
        }


        static void LogError(System.Exception ex){}


        //<Snippet9>
        int GetInt(int[] array, int index)
        {
            try
            {
                return array[index];
            }
            catch(System.IndexOutOfRangeException e)
            {
                throw new System.ArgumentOutOfRangeException(
                    "Parameter index is out of range.", e);
            }
        }
        //</Snippet9>

    }


    //-------------------------------------------------------------------------
    
    class CreatingAndThrowing 
    {
        class SampleClass
        {
            //<Snippet12>
            static void CopyObject(SampleClass original)
            {
                if (original == null)
                {
                    throw new System.ArgumentException("Parameter cannot be null", "original");
                }

            }
            //</Snippet12>
        }

            
        //<Snippet13>
        class ProgramLog
        {
            System.IO.FileStream logFile = null;
            void OpenLog(System.IO.FileInfo fileName, System.IO.FileMode mode) {}

            void WriteLog()
            {
                if (!this.logFile.CanWrite)
                {
                    throw new System.InvalidOperationException("Logfile cannot be read-only");
                }
                // Else write data to the log and return.
            }
        }
        //</Snippet13>


        //<Snippet14>
        static int GetValueFromArray(int[] array, int index)
        {
            try
            {
                return array[index];
            }
            catch (System.IndexOutOfRangeException ex)
            {
                System.ArgumentException argEx = new System.ArgumentException("Index is out of range", "index", ex);
                throw argEx;
            }
        }
        //</Snippet14>


        
    }

    //<Snippet15>
    [Serializable()]
    public class InvalidDepartmentException : System.Exception
    {
        public InvalidDepartmentException() : base() { }
        public InvalidDepartmentException(string message) : base(message) { }
        public InvalidDepartmentException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected InvalidDepartmentException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) { }
    }
    //</Snippet15>


    //-------------------------------------------------------------------------
    class UsingTryFinally
    {
        //<Snippet16>
        static void CodeWithoutCleanup()
        {
            System.IO.FileStream file = null;
            System.IO.FileInfo fileInfo = new System.IO.FileInfo("C:\\file.txt");

            file = fileInfo.OpenWrite();
            file.WriteByte(0xF);

            file.Close();
        }
        //</Snippet16>


        //<Snippet17>
        static void CodeWithCleanup()
        {
            System.IO.FileStream file = null;
            System.IO.FileInfo fileInfo = null;

            try
            {
                fileInfo = new System.IO.FileInfo("C:\\file.txt");

                file = fileInfo.OpenWrite();
                file.WriteByte(0xF);
            }
            catch(System.UnauthorizedAccessException e)
            {
                System.Console.WriteLine(e.Message);
            }
            finally
            {
                if (file != null)
                {
                    file.Close();
                }
            }
        }
        //</Snippet17>

        static void Main()
        {
            CodeWithoutCleanup();
            Console.ReadKey();
        }

    }

    //<snippet18>   
    class ExceptionTest
    {
        static double SafeDivision(double x, double y)
        {
            if (y == 0)
                throw new System.DivideByZeroException();
            return x / y;
        }
        static void Main()
        {
            // Input for test purposes. Change the values to see
            // exception handling behavior.
            double a = 98, b = 0;
            double result = 0;

            try
            {
                result = SafeDivision(a, b);
                Console.WriteLine("{0} divided by {1} = {2}", a, b, result);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Attempted divide by zero.");
            }
        }
    }
    //</snippet18>


}
