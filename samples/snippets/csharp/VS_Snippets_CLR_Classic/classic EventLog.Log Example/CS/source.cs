// <Snippet1>
using System;
using System.Diagnostics;
              
class MySample{

    public static void Main(){

        EventLog myNewLog = new EventLog();
        myNewLog.Log = "NewEventLog";                      
        foreach(EventLogEntry entry in myNewLog.Entries){
            Console.WriteLine("\tEntry: " + entry.Message);
        }    
    }       
}
   
// </Snippet1>
