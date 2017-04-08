

// <Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Diagnostics;
using namespace System::Threading;
int main()
{
   array<EventLog^>^remoteEventLogs;
   remoteEventLogs = EventLog::GetEventLogs( "myServer" );
   Console::WriteLine( "Number of logs on computer: {0}", remoteEventLogs->Length );
   System::Collections::IEnumerator^ myEnum = remoteEventLogs->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      EventLog^ log = safe_cast<EventLog^>(myEnum->Current);
      Console::WriteLine( "Log: {0}", log->Log );
   }
}

// </Snippet1>
