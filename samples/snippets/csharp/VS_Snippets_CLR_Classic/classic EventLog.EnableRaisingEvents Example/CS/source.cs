// <Snippet1>
using System;
using System.Diagnostics;
using System.Threading;
              
class MySample{


    public static void Main(){
    
        EventLog myNewLog = new EventLog();
        myNewLog.Log = "MyCustomLog";                      
        
        myNewLog.EntryWritten += new EntryWrittenEventHandler(MyOnEntryWritten);
        myNewLog.EnableRaisingEvents = true;
        
        
        Console.WriteLine("Press \'q\' to quit.");
        // Wait for the EntryWrittenEvent or a quit command.
        while(Console.Read() != 'q'){
            // Wait.
        }                                                                                                                         
    }       

    public static void MyOnEntryWritten(Object source, EntryWrittenEventArgs e){
        Console.WriteLine("Written: " + e.Entry.Message);
    }
}

// </Snippet1>
