         string myLog = "myNewLog";
         if (EventLog.Exists(myLog))
         {
            Console.WriteLine("Log '"+myLog+"' exists.");
         }
         else
         {
            Console.WriteLine("Log '"+myLog+"' does not exist.");
         }