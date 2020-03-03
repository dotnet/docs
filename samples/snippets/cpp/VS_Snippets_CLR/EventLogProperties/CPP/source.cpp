

//<Snippet1>
#using <System.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Globalization;
using namespace System::IO;
using namespace System::Data;
using namespace System::Diagnostics;
using namespace Microsoft::Win32;
void GetNewOverflowSetting( OverflowAction * newOverflow, interior_ptr<Int32> numDays );
void DisplayEventLogProperties();
void ChangeEventLogOverflowAction( String^ logName );

/// The main entry point for the sample application.

[STAThread]
int main()
{
   DisplayEventLogProperties();
   Console::WriteLine();
   Console::WriteLine( "Enter the name of an event log to change the" );
   Console::WriteLine( "overflow policy (or press Enter to exit): " );
   String^ input = Console::ReadLine();
   if (  !String::IsNullOrEmpty( input ) )
   {
      ChangeEventLogOverflowAction( input );
   }
}


// Prompt the user for the overflow policy setting.
void GetNewOverflowSetting( OverflowAction * newOverflow, interior_ptr<Int32> numDays )
{
   Console::Write( "Enter the new overflow policy setting [" );
   Console::Write( " OverwriteOlder," );
   Console::Write( " DoNotOverwrite," );
   Console::Write( " OverwriteAsNeeded" );
   Console::WriteLine( "] : " );
   String^ input = Console::ReadLine();
   if (  !String::IsNullOrEmpty( input ) )
   {
      String^ INPUT = input->Trim()->ToUpper( CultureInfo::InvariantCulture );
      if ( INPUT->Equals( "OVERWRITEOLDER" ) )
      {
          *newOverflow = OverflowAction::OverwriteOlder;
         Console::WriteLine( "Enter the number of days to retain events: " );
         input = Console::ReadLine();

         if ( ( !Int32::TryParse( input, *numDays )) || ( *numDays == 0) )
         {
            Console::WriteLine( "  Invalid input, defaulting to 7 days." );
             *numDays = 7;
         }
      }
      else
      if ( INPUT->Equals( "DONOTOVERWRITE" ) )
      {
          *newOverflow = OverflowAction::DoNotOverwrite;
      }
      else
      if ( INPUT->Equals( "OVERWRITEASNEEDED" ) )
      {
          *newOverflow = OverflowAction::OverwriteAsNeeded;
      }
      else
            Console::WriteLine( "Unrecognized overflow policy." );
   }

   Console::WriteLine();
}


// <Snippet2>
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


// </Snippet2>
// <Snippet3>
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

// </Snippet3>
//</Snippet1>
