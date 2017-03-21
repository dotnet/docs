   // Ensure that the source has already been registered using
   // EventLogInstaller or EventLog.CreateEventSource.
   String^ sourceName = "SampleApplicationSource";
   if ( EventLog::SourceExists( sourceName ) )
   {
      // Define an informational event with no category.
      // The message identifier corresponds to the message text in the
      // message resource file defined for the source.
      EventInstance ^ myEvent = gcnew EventInstance( UpdateCycleCompleteMsgId,0 );

      // Write the event to the event log using the registered source.
      EventLog::WriteEvent( sourceName, myEvent, 0 );

      // Reuse the event data instance for another event entry.
      // Set the entry category and message identifiers for
      // the appropriate resource identifiers in the resource files
      // for the registered source.  Set the event type to Warning.
      myEvent->CategoryId = RefreshCategoryMsgId;
      myEvent->EntryType = EventLogEntryType::Warning;
      myEvent->InstanceId = ServerConnectionDownMsgId;

      // Write the event to the event log using the registered source.
      // Insert the machine name into the event message text.
      array<String^>^ss = {Environment::MachineName};
      EventLog::WriteEvent( sourceName, myEvent, ss );
   }
   else
   {
      Console::WriteLine( "Warning - event source {0} not registered", sourceName );
   }