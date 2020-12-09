using System;

namespace exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            ExceptionTest.Main();
            TestThrowCatch();
            CatchOrder.Main();
            TestFinally();

        }

        private static void TestThrowCatch()
        {
            // <CatchException>
            try
            {
                TestThrow();
            }
            catch (CustomException ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
            // </CatchException>
        }

        // <ThrowException>
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
        // </ThrowException>

        // <TestFinally>
        static void TestFinally()
        {
            System.IO.FileStream file = null;
            //Change the path to something that works on your machine.
            System.IO.FileInfo fileInfo = new System.IO.FileInfo("./file.txt");

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
        // </TestFinally>

        class SomeSpecificException : Exception { }


        private static void Structure()
        {
            //<TryCatchStructure>
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
            //</TryCatchStructure>

            // <TryFinallyStructure>
            try
            {
                // Code to try goes here.
            }
            finally
            {
                // Code to execute after the try block goes here.
            }
            // </TryFinallyStructure>

            // <TryCatchFinallyStructure>
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
            // </TryCatchFinallyStructure>
        }

        // <ThrowMoreSpecificException>
        int GetInt(int[] array, int index)
        {
            try
            {
                return array[index];
            }
            catch (System.IndexOutOfRangeException e)
            {
                throw new System.ArgumentOutOfRangeException(
                    "Parameter index is out of range.", e);
            }
        }
        // </ThrowMoreSpecificException>

        private static void ReThrow()
        {
            // <RethrowError>
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
            // </RethrowError>
        }
        static void LogError(System.Exception ex) { }


        static void CloseOptionally()
        {
            //<CleanupIfNotNull>
            System.IO.FileStream file = null;
            System.IO.FileInfo fileinfo = new System.IO.FileInfo("./file.txt");
            try
            {
                file = fileinfo.OpenWrite();
                file.WriteByte(0xF);
            }
            finally
            {
                // Check for null because OpenWrite might have failed.
                file?.Close();
            }
            //</CleanupIfNotNull>
        }

        // <CantComplete>
        static void CopyObject(SampleClass original)
        {
            if (original is null)
            {
                throw new System.ArgumentException("Parameter cannot be null", "original");
            }
        }
        // </CantComplete>

        // <InvalidArg>
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
        // </InvalidArg>

        // <NoCleanup>
        static void CodeWithoutCleanup()
        {
            System.IO.FileStream file = null;
            System.IO.FileInfo fileInfo = new System.IO.FileInfo("C:\\file.txt");

            file = fileInfo.OpenWrite();
            file.WriteByte(0xF);

            file.Close();
        }
        // </NoCleanup>

        // <WithCleanup>
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
            catch (System.UnauthorizedAccessException e)
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
        // </WithCleanup>
    }

    public class SampleClass { }
}
