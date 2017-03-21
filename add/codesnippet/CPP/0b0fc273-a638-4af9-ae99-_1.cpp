// Display the current event log overflow settings, and 
// prompt the user to input a new overflow setting.
void ChangeEventLogOverflowAction( String^ logName )
{
   if ( EventLog::Exists( logName ) )
   {
      
      // Display the current overflow setting of the 
      // specified event log.
      EventLog^ inputLog = gcnew EventLog( logName );
      Console::WriteLine( "  Event log {0}", inputLog->Log );
      OverflowAction logOverflow = inputLog->OverflowAction;
      Int32 numDays = inputLog->MinimumRetentionDays;
      Console::WriteLine( "  Current overflow setting = {0}", logOverflow );
      if ( logOverflow == OverflowAction::OverwriteOlder )
      {
         Console::WriteLine( "\t Entries are retained a minimum of {0} days.", numDays );
      }
      
      // Prompt user for a new overflow setting.
      GetNewOverflowSetting(  &logOverflow,  &numDays );
      
      // Change the overflow setting on the event log.
      if ( logOverflow != inputLog->OverflowAction )
      {
         inputLog->ModifyOverflowPolicy( logOverflow, numDays );
         Console::WriteLine( "Event log overflow policy was modified successfully!" );
      }
      else
      {
         Console::WriteLine( "Event log overflow policy was not modified." );
      }
   }
   else
   {
      Console::WriteLine( "Event log {0} was not found.", logName );
   }
}
