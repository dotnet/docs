      // Create the source, if it does not already exist.
      String^ myLogName = "myNewLog";
      if (  !EventLog::SourceExists( "MySource" ) )
      {
         EventLog::CreateEventSource( "MySource", myLogName );
         Console::WriteLine( "Creating EventSource" );
      }
      else
         myLogName = EventLog::LogNameFromSourceName( "MySource", "." );
      
      // Create an EventLog and assign source.
      EventLog^ myEventLog = gcnew EventLog;
      myEventLog->Source = "MySource";
      myEventLog->Log = myLogName;
      
      // Set the 'description' for the event.
      String^ myMessage = "This is my event.";
      EventLogEntryType myEventLogEntryType = EventLogEntryType::Warning;
      int myApplicatinEventId = 1100;
      short myApplicatinCategoryId = 1;
      
      // Set the 'data' for the event.
      array<Byte>^ myRawData = gcnew array<Byte>(4);
      for ( int i = 0; i < 4; i++ )
      {
         myRawData[ i ] = 1;
      }
      Console::WriteLine( "Writing to EventLog.. " );
      myEventLog->WriteEntry( myMessage, myEventLogEntryType, myApplicatinEventId, myApplicatinCategoryId, myRawData );