//<Snippet1>
using System;
using System.Diagnostics;

namespace StackFrameExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Method1();
            }
            catch (Exception e)
            {
                StackTrace st = new StackTrace();
                StackTrace st1 = new StackTrace(new StackFrame(true));
                Console.WriteLine(" Stack trace for Main: {0}",
                   st1.ToString());
                Console.WriteLine(st.ToString());
            }
            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
        }
        private static void Method1()
        {
            try
            {
                Method2(4);
            }
            catch (Exception e)
            {
                StackTrace st = new StackTrace();
                StackTrace st1 = new StackTrace(new StackFrame(true));
                Console.WriteLine(" Stack trace for Method1: {0}",
                   st1.ToString());
                Console.WriteLine(st.ToString());
                // Build a stack trace for the next frame.
                StackTrace st2 = new StackTrace(new StackFrame(1, true));
                Console.WriteLine(" Stack trace for next level frame: {0}",
                   st2.ToString());
                throw e;
            }

        }
        private static void Method2( int count)
        {
            try
            {
                if (count < 5)
                    throw new ArgumentException("count too large", "count");
            }
            catch (Exception e)
            {
                StackTrace st = new StackTrace();              
                StackTrace st1 = new StackTrace(new StackFrame(2,true));
                Console.WriteLine(" Stack trace for Method2: {0}",
                   st1.ToString());
                Console.WriteLine(st.ToString());
                throw e;
            }
        }
    }
}
//</Snippet1>
