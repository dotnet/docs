    public class ThrowTestA
    {
        static void Main()
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