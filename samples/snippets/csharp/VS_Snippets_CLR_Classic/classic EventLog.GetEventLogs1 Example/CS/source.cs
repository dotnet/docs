// <Snippet1>
using System;
using System.Diagnostics;
using System.Threading;
              
class MySample{

    public static void Main(){
    
        EventLog[] remoteEventLogs;
    
        remoteEventLogs = EventLog.GetEventLogs("myServer");
        
        Console.WriteLine("Number of logs on computer: " + remoteEventLogs.Length);
        
        foreach(EventLog log in remoteEventLogs){
            Console.WriteLine("Log: " + log.Log);
        }                                                                      
    }       
}
   
// </Snippet1>
