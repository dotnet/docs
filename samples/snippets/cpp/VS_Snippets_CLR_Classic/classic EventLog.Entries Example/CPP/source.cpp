

// <Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Diagnostics;
int main()
{
   EventLog^ myLog = gcnew EventLog;
   myLog->Log = "MyNewLog";
   System::Collections::IEnumerator^ myEnum = myLog->Entries->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      EventLogEntry^ entry = safe_cast<EventLogEntry^>(myEnum->Current);
      Console::WriteLine( "\tEntry: {0}", entry->Message );
   }
}

// </Snippet1>
