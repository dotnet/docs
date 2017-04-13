// <Snippet1>
using System;
using System.Diagnostics;
using System.Threading;
              
class MySample{

    public static void Main(){
                 
        
        // Create an EventLog instance and assign its log name.
        EventLog myLog = new EventLog();
        myLog.Log = "myNewLog";

        myLog.Clear();                                                                    
    }       
}
   
// </Snippet1>
