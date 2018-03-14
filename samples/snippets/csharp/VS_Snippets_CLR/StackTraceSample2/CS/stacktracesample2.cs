//<snippet2>
using System;
using System.Diagnostics;

class MyConsoleApp
{
    [STAThread]
    static void Main()
    {
        MyConsoleApp myApp = new MyConsoleApp();
        myApp.MyPublicMethod();
    }

    public void MyPublicMethod()
    {
        MyInnerClass helperClass = new MyInnerClass();
        helperClass.ThrowsException();
    }

    class MyInnerClass
    {
        public void ThrowsException()
        {
            try {
                throw new Exception("A problem was encountered.");
            }
            catch (Exception) {

                // Create a StackTrace starting at the next level
                // stack frame.  Skip the first frame, the frame of
                // this level, which hides the internal implementation
                // of the ThrowsException method.  Include the line
                // number, file name, and column number information
                // for each frame.
//<snippet3>
                StackTrace st = new StackTrace(1, true);
                StackFrame [] stFrames = st.GetFrames();

                foreach(StackFrame sf in stFrames )
                {
                   Console.WriteLine("Method: {0}", sf.GetMethod() );
                }
//</snippet3>
            }
        }
    }
}
/*
This console application produces the following output
when compiled with optimization off.

Note that the ThrowsException() method is not identified in
this stack trace.

  Method: Void MyPublicMethod()
  Method: Void Main()

*/
//</snippet2>
