void DisplayEventLogProperties()
{
   
   // Iterate through the current set of event log files,
   // displaying the property settings for each file.
   array<EventLog^>^eventLogs = EventLog::GetEventLogs();
   System::Collections::IEnumerator^ myEnum = eventLogs->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      EventLog^ e = safe_cast<EventLog^>(myEnum->Current);
      Int64 sizeKB = 0;
      Console::WriteLine();
      Console::WriteLine( "{0}:", e->LogDisplayName );
      Console::WriteLine( "  Log name = \t\t {0}", e->Log );
      Console::WriteLine( "  Number of event log entries = {0}", e->Entries->Count );
      
      // Determine if there is a file for this event log.
      RegistryKey ^ regEventLog = Registry::LocalMachine->OpenSubKey( String::Format( "System\\CurrentControlSet\\Services\\EventLog\\{0}", e->Log ) );
      if ( regEventLog )
      {
         Object^ temp = regEventLog->GetValue( "File" );
         if ( temp != nullptr )
         {
            Console::WriteLine( "  Log file path = \t {0}", temp );
            FileInfo^ file = gcnew FileInfo( temp->ToString() );
            
            // Get the current size of the event log file.
            if ( file->Exists )
            {
               sizeKB = file->Length / 1024;
               if ( (file->Length % 1024) != 0 )
               {
                  sizeKB++;
               }
               Console::WriteLine( "  Current size = \t {0} kilobytes", sizeKB );
            }
         }
         else
         {
            Console::WriteLine( "  Log file path = \t <not set>" );
         }
      }
      
      // Display the maximum size and overflow settings.
      sizeKB = e->MaximumKilobytes;
      Console::WriteLine( "  Maximum size = \t {0} kilobytes", sizeKB );
      Console::WriteLine( "  Overflow setting = \t {0}", e->OverflowAction );
      switch ( e->OverflowAction )
      {
         case OverflowAction::OverwriteOlder:
            Console::WriteLine( "\t Entries are retained a minimum of {0} days.", e->MinimumRetentionDays );
            break;

         case OverflowAction::DoNotOverwrite:
            Console::WriteLine( "\t Older entries are not overwritten." );
            break;

         case OverflowAction::OverwriteAsNeeded:
            Console::WriteLine( "\t If number of entries equals max size limit, a new event log entry overwrites the oldest entry." );
            break;

         default:
            break;
      }
   }
}

