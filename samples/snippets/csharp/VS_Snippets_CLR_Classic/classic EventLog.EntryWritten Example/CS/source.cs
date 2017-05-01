// <Snippet1>
using System;
using System.Diagnostics;
using System.Threading;
              
class MySample{

    // This member is used to wait for events.
    static AutoResetEvent signal;

    public static void Main(){

        signal = new AutoResetEvent(false);
        EventLog myNewLog = new EventLog("Application", ".", "testEventLogEvent");                 
        
        myNewLog.EntryWritten += new EntryWrittenEventHandler(MyOnEntryWritten);
        myNewLog.EnableRaisingEvents = true;
        myNewLog.WriteEntry("Test message", EventLogEntryType.Information);
	    signal.WaitOne();        

    }       

    public static void MyOnEntryWritten(object source, EntryWrittenEventArgs e){
        Console.WriteLine("In event handler");
        signal.Set();
    }
}
   
// </Snippet1>
