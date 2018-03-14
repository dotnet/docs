// <Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Diagnostics;
using namespace System::Threading;
ref class MySample
{
private:

   // This member is used to wait for events.
   static AutoResetEvent^ signal;

public:
   static void main()
   {
	  signal = gcnew AutoResetEvent( false );
      EventLog^ myNewLog = gcnew EventLog;
      myNewLog->Source = "testEventLogEvent";
      myNewLog->EntryWritten += gcnew EntryWrittenEventHandler( MyOnEntryWritten );
      myNewLog->EnableRaisingEvents = true;
	  myNewLog->WriteEntry("Test message", EventLogEntryType::Information);
      signal->WaitOne();
   }

   static void MyOnEntryWritten( Object^ /*source*/, EntryWrittenEventArgs^ /*e*/ )
   {
	  Console::WriteLine("In event handler");
      signal->Set();
   }

};

int main()
{
   MySample::main();
}

// </Snippet1>