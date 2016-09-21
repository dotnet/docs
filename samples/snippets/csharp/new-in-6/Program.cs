using System;
using System.Runtime.CompilerServices;
using static NewStyle.ExceptionExtensions;

namespace NewInCSharp6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var t = new OldStyle.Student();
            t.Grades.Add(4.5);

            var person = new NewStyle.Student("first", "last");

            var first = person?.FirstName; 

            first = person?.FirstName ?? "Unspecified";

            var test = new NewStyle.Student("first", "last");
            test.Grades.Add(1.0);
            test.Grades.Add(1.5);
            test.Grades.Add(2.0);
            test.Grades.Add(3.5);
            test.Grades.Add(2.0);
            test.Grades.Add(4.0);
            test.Grades.Add(1.50);
            test.Grades.Add(2.25);
            test.Grades.Add(3.5);
            test.Grades.Add(1.0);
            test.Grades.Add(1.0);
            
            Console.WriteLine(test.GetAllGrades());
        }

        public void MethodThatFailsSometimes()
        {
            try {
                PerformFailingOperation();
            } catch (Exception e) when (e.LogException())
            {
                // This is never reached!
            }
        } 
        
        public void MethodThatFailsButHasRecoveryPath()
        {
            try {
                PerformFailingOperation();
            } catch (Exception e) when (e.LogException())
            {
                // This is never reached!
            }
            catch (RecoverableException ex)
            {
                Console.WriteLine(ex.ToString());
                // This can still catch the more specific
                // exception because the exception filter
                // above always returns false.
                // perform recovery here 
            }
        }

        public void MethodThatFailsWhenDebuggerIsNotAttached()
        {
            try {
                PerformFailingOperation();
            } catch (Exception e) when (e.LogException())
            {
                // This is never reached!
            }
            catch (RecoverableException ex) when (!System.Diagnostics.Debugger.IsAttached)
            {
                Console.WriteLine(ex.ToString());
                // Only catch exceptions when a debugger is not attached.
                // Otherwise, this should stop in the debugger. 
            }
        } 


        private void PerformFailingOperation() {}
    }

    public class RecoverableException : Exception
    {

    }
}
