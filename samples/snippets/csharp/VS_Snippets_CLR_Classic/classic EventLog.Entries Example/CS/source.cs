// <Snippet1>
using System;
using System.Diagnostics;
              
class MySample{

    public static void Main(){

        EventLog myLog = new EventLog();
        myLog.Log = "MyNewLog";                      
        foreach(EventLogEntry entry in myLog.Entries){
            Console.WriteLine("\tEntry: " + entry.Message);
        }    
    }       
}
   
// </Snippet1>
