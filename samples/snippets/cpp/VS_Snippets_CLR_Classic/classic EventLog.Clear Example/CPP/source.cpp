

// <Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Diagnostics;
using namespace System::Threading;
int main()
{
   
   // Create an EventLog instance and assign its log name.
   EventLog^ myLog = gcnew EventLog;
   myLog->Log = "myNewLog";
   myLog->Clear();
}

// </Snippet1>
