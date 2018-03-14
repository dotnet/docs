//<snippet1>
using System;
using System.Diagnostics;

class StackTraceSample
{
    [STAThread]
    static void Main(string[] args)
    {
        StackTraceSample sample = new StackTraceSample();
        try
        {
            sample.MyPublicMethod();
        }
        catch (Exception)
        {
            // Create a StackTrace that captures
            // filename, line number, and column
            // information for the current thread.
            StackTrace st = new StackTrace(true);
            for(int i =0; i< st.FrameCount; i++ )
            {
                // Note that high up the call stack, there is only
                // one stack frame.
                StackFrame sf = st.GetFrame(i);
                Console.WriteLine();
                Console.WriteLine("High up the call stack, Method: {0}",
                    sf.GetMethod());

                Console.WriteLine("High up the call stack, Line Number: {0}",
                    sf.GetFileLineNumber());
            }
        }
    }

    public void MyPublicMethod () 
    { 
        MyProtectedMethod(); 
    }

    protected void MyProtectedMethod ()
    {
        MyInternalClass mic = new MyInternalClass();
        mic.ThrowsException();
    }

    class MyInternalClass
    {
        public void ThrowsException()
        {
            try
            {
                throw new Exception("A problem was encountered.");
            }
            catch (Exception e)
            {
                // Create a StackTrace that captures filename,
                // line number and column information.
                StackTrace st = new StackTrace(true);
                string stackIndent = "";
                for(int i =0; i< st.FrameCount; i++ )
                {
                    // Note that at this level, there are four
                    // stack frames, one for each method invocation.
                    StackFrame sf = st.GetFrame(i);
                    Console.WriteLine();
                    Console.WriteLine(stackIndent + " Method: {0}",
                        sf.GetMethod() );
                    Console.WriteLine(  stackIndent + " File: {0}", 
                        sf.GetFileName());
                    Console.WriteLine(  stackIndent + " Line Number: {0}",
                        sf.GetFileLineNumber());
                    stackIndent += "  ";
                }
                throw e;
            }
        }
    }
}

/*
This console application produces the following output when
compiled with the Debug configuration.
  
   Method: Void ThrowsException()
   File: c:\samples\stacktraceframe\myclass.cs
   Line Number: 59

     Method: Void MyProtectedMethod()
     File: c:\samples\stacktraceframe\myclass.cs
     Line Number: 45

       Method: Void MyPublicMethod()
       File: c:\samples\stacktraceframe\myclass.cs
       Line Number: 39

         Method: Void Main(System.String[])
         File: c:\samples\stacktraceframe\myclass.cs
         Line Number: 13

  High up the call stack, Method: Void Main(System.String[])
  High up the call stack, Line Number: 20


This console application produces the following output when
compiled with the Release configuration.

   Method: Void ThrowsException()
   File:
   Line Number: 0

     Method: Void Main(System.String[])
     File:
     Line Number: 0

  High up the call stack, Method: Void Main(System.String[])
  High up the call stack, Line Number: 0

*/
//</snippet1>