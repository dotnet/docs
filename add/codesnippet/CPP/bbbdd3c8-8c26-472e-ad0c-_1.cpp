   EventLogInstaller^ myEventLogInstaller = gcnew EventLogInstaller;
   // Create a source for the specified event log, on local computer.
   EventLog::CreateEventSource( "MyEventSource", "MyEventLog", "." );
   // Create an event log instance and associate it with the log .
   EventLog^ myEventLog = gcnew EventLog( "MyEventLog",".","MyEventSource" );
   // Copy the properties that are required at install time from
   // the event log component to the installer.
   myEventLogInstaller->CopyFromComponent( myEventLog );