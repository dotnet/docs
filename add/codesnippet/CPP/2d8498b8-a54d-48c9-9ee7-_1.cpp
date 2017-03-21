      // Create the source, if it does not already exist.
      if (  !EventLog::SourceExists( "MySource" ) )
      {
         EventLog::CreateEventSource( "MySource", "myNewLog" );
         Console::WriteLine( "Creating EventSource" );
      }
      
      // Set the 'description' for the event.
      String^ myMessage = "This is my event.";
      EventLogEntryType myEventLogEntryType = EventLogEntryType::Warning;
      int myApplicationEventId = 100;
      
      // Write the entry in the event log.
      Console::WriteLine( "Writing to EventLog.. " );
      EventLog::WriteEntry( "MySource", myMessage,
         myEventLogEntryType, myApplicationEventId );