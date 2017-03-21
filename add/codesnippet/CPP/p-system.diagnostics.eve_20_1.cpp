
   // Get the event log corresponding to the existing source.
   String^ myLogName = EventLog::LogNameFromSourceName( sourceName, "." );
   
   // Find each instance of a specific event log entry in a
   // particular event log.
   EventLog^ myEventLog = gcnew EventLog( myLogName,"." );
   int count = 0;
   Console::WriteLine( "Searching event log entries for the event ID {0}...", ServerConnectionDownMsgId );
   
   // Search for the resource ID, display the event text,
   // and display the number of matching entries.
   System::Collections::IEnumerator^ myEnum = myEventLog->Entries->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      EventLogEntry^ entry = safe_cast<EventLogEntry^>(myEnum->Current);
      if ( entry->InstanceId == ServerConnectionDownMsgId )
      {
         count++;
         Console::WriteLine();
         Console::WriteLine( "Entry ID    = {0}", entry->InstanceId );
         Console::WriteLine( "Reported at {0}", entry->TimeWritten );
         Console::WriteLine( "Message text:" );
         Console::WriteLine( "\t{0}", entry->Message );
      }
   }

   Console::WriteLine();
   Console::WriteLine( "Found {0} events with ID {1} in event log {2}.", count, ServerConnectionDownMsgId, myLogName );