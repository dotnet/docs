

//<Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Diagnostics;
void CleanUp();
void CreateEventSourceSample1( String^ messageFile );
void WriteEventSample1();
void WriteEventSample2();
void EventInstanceSamples();

//<Snippet2>
// The following constants match the message definitions
// in the message resource file. They are used to specify
// the resource identifier for a localized string in the 
// message resource file.
// The message resource file is an .mc file built into a 
// Win32 resource file using the message compiler (MC) tool.
//<Snippet3>
const short InstallCategoryMsgId = 1;
const short QueryCategoryMsgId = 2;
const short RefreshCategoryMsgId = 3;
const short CategoryCount = 3;

//</Snippet3>
//<Snippet4>
// Define the resource identifiers for the event messages.
// Resource identifiers combine the message ID and the severity field.
const long AuditSuccessMsgId = 1000;
const long AuditFailedMsgId = 1001 + 0x80000000;
const long InformationMsgId = 1002;
const long WarningMsgId = 1003 + 0x80000000;
const long UpdateCycleCompleteMsgId = 1004;
const long ServerConnectionDownMsgId = 1005 + 0x80000000;

//</Snippet4>
//<Snippet5>
const long DisplayNameMsgId = 5001;
const long ServiceNameMsgId = 5002;

//</Snippet5>
//</Snippet2>

[STAThread]
int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   String^ messageFile;
   if ( args->Length > 1 )
   {
      
      // Use the input argument as the message resource file.
      messageFile = args[ 1 ];
   }
   else
   {
      
      // Use the default message dll.
      messageFile = String::Format( "{0}\\{1}", System::Environment::CurrentDirectory, "EventLogMsgs.dll" );
   }

   CleanUp();
   CreateEventSourceSample1( messageFile );
   WriteEventSample1();
   WriteEventSample2();
   EventInstanceSamples();
}

void CleanUp()
{
   String^ sourceName = "SampleApplicationSource";
   
   // Delete the event source in order to re-register
   // the source with the latest configuration properties.
   if ( EventLog::SourceExists( sourceName ) )
   {
      Console::WriteLine( "Deleting event source {0}.", sourceName );
      EventLog::DeleteEventSource( sourceName );
   }
}
//<Snippet6>
void CreateEventSourceSample1( String^ messageFile )
{
   String^ myLogName;
   String^ sourceName = "SampleApplicationSource";
   
   // Create the event source if it does not exist.
   if (  !EventLog::SourceExists( sourceName ) )
   {
      
      // Create a new event source for the custom event log
      // named "myNewLog."  
      myLogName = "myNewLog";
      EventSourceCreationData ^ mySourceData = gcnew EventSourceCreationData( sourceName,myLogName );
      
      // Set the message resource file that the event source references.
      // All event resource identifiers correspond to text in this file.
      if (  !System::IO::File::Exists( messageFile ) )
      {
         Console::WriteLine( "Input message resource file does not exist - {0}", messageFile );
         messageFile = "";
      }
      else
      {
         
         // Set the specified file as the resource
         // file for message text, category text, and 
         // message parameter strings.  
         mySourceData->MessageResourceFile = messageFile;
         mySourceData->CategoryResourceFile = messageFile;
         mySourceData->CategoryCount = CategoryCount;
         mySourceData->ParameterResourceFile = messageFile;
         Console::WriteLine( "Event source message resource file set to {0}", messageFile );
      }

      Console::WriteLine( "Registering new source for event log." );
      EventLog::CreateEventSource( mySourceData );
   }
   else
   {
      
      // Get the event log corresponding to the existing source.
      myLogName = EventLog::LogNameFromSourceName( sourceName, "." );
   }

   
   // Register the localized name of the event log.
   // For example, the actual name of the event log is "myNewLog," but
   // the event log name displayed in the Event Viewer might be
   // "Sample Application Log" or some other application-specific
   // text.
   EventLog^ myEventLog = gcnew EventLog( myLogName,".",sourceName );
   if ( messageFile->Length > 0 )
   {
      myEventLog->RegisterDisplayName( messageFile, DisplayNameMsgId );
   }   
}
//</Snippet6>

void WriteEventSample1()
{
   //<Snippet7>
   // Create the event source if it does not exist.
   String^ sourceName = "SampleApplicationSource";
   if (  !EventLog::SourceExists( sourceName ) )
   {
      
      // Call a local method to register the event log source
      // for the event log "myNewLog."  Use the resource file
      // EventLogMsgs.dll in the current directory for message text.
      String^ messageFile = String::Format( "{0}\\{1}", System::Environment::CurrentDirectory, "EventLogMsgs.dll" );
      CreateEventSourceSample1( messageFile );
   }

   // Get the event log corresponding to the existing source.
   String^ myLogName = EventLog::LogNameFromSourceName( sourceName, "." );
   EventLog^ myEventLog = gcnew EventLog( myLogName,".",sourceName );
   
   // Define two audit events.
   // The message identifiers correspond to the message text in the
   // message resource file defined for the source.
   EventInstance ^ myAuditSuccessEvent = gcnew EventInstance( AuditSuccessMsgId,0,EventLogEntryType::SuccessAudit );
   EventInstance ^ myAuditFailEvent = gcnew EventInstance( AuditFailedMsgId,0,EventLogEntryType::FailureAudit );
   
   // Insert the method name into the event log message.
   array<String^>^insertStrings = {"EventLogSamples.WriteEventSample1"};
   
   // Write the events to the event log.
   myEventLog->WriteEvent( myAuditSuccessEvent, insertStrings );
   
   // Append binary data to the audit failure event entry.
   array<Byte>^binaryData = {3,4,5,6};
   myEventLog->WriteEvent( myAuditFailEvent, binaryData, insertStrings );
   
   //</Snippet7>
}

void WriteEventSample2()
{
   //<Snippet8>
   String^ sourceName = "SampleApplicationSource";
   if ( EventLog::SourceExists( sourceName ) )
   {
      
      // Define an informational event and a warning event.
      // The message identifiers correspond to the message text in the
      // message resource file defined for the source.
      EventInstance ^ myInfoEvent = gcnew EventInstance( InformationMsgId,0,EventLogEntryType::Information );
      EventInstance ^ myWarningEvent = gcnew EventInstance( WarningMsgId,0,EventLogEntryType::Warning );
      
      // Insert the method name into the event log message.
      array<String^>^insertStrings = {"EventLogSamples.WriteEventSample2"};
      
      // Write the events to the event log.
      EventLog::WriteEvent( sourceName, myInfoEvent, 0 );
      
      // Append binary data to the warning event entry.
      array<Byte>^binaryData = {7,8,9,10};
      EventLog::WriteEvent( sourceName, myWarningEvent, binaryData, insertStrings );
   }
   else
   {
      Console::WriteLine( "Warning - event source {0} not registered", sourceName );
   }
   //</Snippet8>
}

void EventInstanceSamples()
{
   
   //<Snippet9>
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
   //</Snippet9>
   //<Snippet10>

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
   //</Snippet10>
}
//</Snippet1>
