

// <Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Diagnostics;
int main()
{
   EventLog^ myNewLog = gcnew EventLog;
   myNewLog->Log = "NewEventLog";
   System::Collections::IEnumerator^ myEnum = myNewLog->Entries->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      EventLogEntry^ entry = safe_cast<EventLogEntry^>(myEnum->Current);
      Console::WriteLine( "\tEntry: {0}", entry->Message );
   }
}

// </Snippet1>
