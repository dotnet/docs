using System;
using System.Diagnostics;

class MyConsoleApp
{
    [STAThread]
    static void Main(string[] args)
    {
        MyConsoleApp myApp = new MyConsoleApp();
        myApp.MyPublicMethod();
    }

    public void MyPublicMethod()
    {
        MyInnerClass helperClass = new MyInnerClass();
        helperClass.ThrowsException();
    }
//<snippet5>
    class MyInnerClass
    {
        public void ThrowsException()
        {
            try
            {
                throw new Exception("A problem was encountered.");
            }
            catch (Exception)
            {
                // Log the Exception. This example avoids revealing
                // the inner workings of the class and simplifies the
                // exception output by limiting the trace to the
                // frame of the calling method.
                //<snippet6>
                StackFrame fr = new StackFrame(1,true);
                StackTrace st = new StackTrace(fr);
                EventLog.WriteEntry(fr.GetMethod().Name,
                                    st.ToString(),
                                    EventLogEntryType.Warning);
                //</snippet6>
                // Note that whenever this application is run, the EventLog
                // contains an Event similar to the following Event.
                //
                //     Event Type: Warning
                //     Event Source:   MyPublicMethod
                //     Event Category: None
                //     Event ID:   0
                //     Date:       6/17/2001
                //     Time:       6:39:56 PM
                //     User:       N/A
                //     Computer:   MYCOMPUTER
                //     Description:
                //
                //        at MyConsoleApp.MyPublicMethod()
                //
                //     For more information, see Help and Support Center at
                //     http://go.microsoft.com/fwlink/events.asp.
            }
        }
    }
//</snippet5>
}