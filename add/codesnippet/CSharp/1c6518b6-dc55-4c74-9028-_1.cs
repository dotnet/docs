         // Create the source, if it does not already exist.
         string myLogName = "myNewLog";
         if(!EventLog.SourceExists("MySource"))
         {
            // An event log source should not be created and immediately used.
            // There is a latency time to enable the source, it should be created
            // prior to executing the application that uses the source.
            // Execute this sample a second time to use the new source.
            EventLog.CreateEventSource("MySource", myLogName);
            Console.WriteLine("Created EventSource");
            Console.WriteLine("Exiting, execute the application a second time to use the source.");
            return;
         }
         else
            myLogName = EventLog.LogNameFromSourceName("MySource",".");
         // Create an EventLog and assign source.
         EventLog myEventLog = new EventLog();
         myEventLog.Source = "MySource";
         myEventLog.Log = myLogName;

         // Set the 'description' for the event.
         string myMessage = "This is my event.";
         EventLogEntryType myEventLogEntryType = EventLogEntryType.Warning;
         int myApplicatinEventId = 1100;
         short myApplicatinCategoryId = 1;

         // Set the 'data' for the event.
         byte[] myRawData = new byte[4];
         for(int i=0;i<4;i++)
         {
            myRawData[i]=1;
         }
         // Write the entry in the event log.
         Console.WriteLine("Writing to EventLog.. ");
         myEventLog.WriteEntry(myMessage,myEventLogEntryType, 
            myApplicatinEventId, myApplicatinCategoryId, myRawData);