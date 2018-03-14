

// <Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Diagnostics;
using namespace System::Threading;
ref class MySample
{
public:
   static void MyOnEntryWritten( Object^ /*source*/, EntryWrittenEventArgs^ e )
   {
      Console::WriteLine( "Written: {0}", e->Entry->Message );
   }

};

int main()
{
   EventLog^ myNewLog = gcnew EventLog;
   myNewLog->Log = "MyCustomLog";
   myNewLog->EntryWritten += gcnew EntryWrittenEventHandler( MySample::MyOnEntryWritten );
   myNewLog->EnableRaisingEvents = true;
   Console::WriteLine( "Press \'q\' to quit." );
   
   // Wait for the EntryWrittenEvent or a quit command.
   while ( Console::Read() != 'q' )
   {
      
      // Wait.
   }
}

// </Snippet1>
