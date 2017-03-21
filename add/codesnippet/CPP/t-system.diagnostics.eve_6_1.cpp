      // Check whether source exist in event log.
      if (  !EventLog::SourceExists( mySource ) )
      {
         
         // Create a new source in a specified log on a system.
         EventLog::CreateEventSource( mySource, myLog );
      }
      
      // Create an event log instance.* myEventLog = new EventLog(myLog);
      // Initialize source property of obtained instance.
      myEventLog->Source = mySource;
      switch ( myIntLog )
      {
         case 1:
            
            // Write an 'Error' entry in specified log of event log.
            myEventLog->WriteEntry( myMessage, EventLogEntryType::Error, myID );
            break;

         case 2:
            
            // Write a 'Warning' entry in specified log of event log.
            myEventLog->WriteEntry( myMessage, EventLogEntryType::Warning, myID );
            break;

         case 3:
            
            // Write an 'Information' entry in specified log of event log.
            myEventLog->WriteEntry( myMessage, EventLogEntryType::Information, myID );
            break;

         case 4:
            
            // Write a 'FailureAudit' entry in specified log of event log.
            myEventLog->WriteEntry( myMessage, EventLogEntryType::FailureAudit, myID );
            break;

         case 5:
            
            // Write a 'SuccessAudit' entry in specified log of event log.
            myEventLog->WriteEntry( myMessage, EventLogEntryType::SuccessAudit, myID );
            break;

         default:
            Console::WriteLine( "Error: Failed to create an event in event log." );
            break;
      }
      Console::WriteLine( "A new event in log '{0}' with ID '{1}' is successfully written into event log.", myEventLog->Log, myID );
      