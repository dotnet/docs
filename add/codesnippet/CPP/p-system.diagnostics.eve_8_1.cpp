      // Create a new EventLog object.
      EventLog^ myEventLog1 = gcnew EventLog;
      myEventLog1->Log = myLogName;
      
      // Obtain the Log Entries of the Event Log
      EventLogEntryCollection^ myEventLogEntryCollection = myEventLog1->Entries;
      Console::WriteLine( "The number of entries in 'MyNewLog' = {0}", myEventLogEntryCollection->Count );
      
      // Display the 'Message' property of EventLogEntry.
      for ( int i = 0; i < myEventLogEntryCollection->Count; i++ )
      {
         Console::WriteLine( "The Message of the EventLog is : {0}", myEventLogEntryCollection[ i ]->Message );
      }