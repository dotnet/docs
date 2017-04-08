

// System::Diagnostics::Process::WorkingSet
// System::Diagnostics::Process::BasePriority
// System::Diagnostics::Process::UserProcessorTime
// System::Diagnostics::Process::PrivilegedProcessorTime
// System::Diagnostics::Process::TotalProcessorTime
// System::Diagnostics::Process::ToString
// System::Diagnostics::Process::Responding
// System::Diagnostics::Process::PriorityClass
// System::Diagnostics::Process::ExitCode
// The following example starts an instance of Notepad. The example 
// then retrieves and displays various properties of the associated
// process.  The example detects when the process exits, and displays the process's exit code.
// <Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Diagnostics;
using namespace System::Threading;
int main()
{
   try
   {
      Process^ myProcess;
      myProcess = Process::Start( "NotePad.exe" );
      while (  !myProcess->HasExited )
      {
         Console::WriteLine();
         
         // Get physical memory usage of the associated process.
         Console::WriteLine( "Process's physical memory usage: {0}", myProcess->WorkingSet.ToString() );
         
         // Get base priority of the associated process.
         Console::WriteLine( "Base priority of the associated process: {0}", myProcess->BasePriority.ToString() );
         
         // Get priority class of the associated process.
         Console::WriteLine(  "Priority class of the associated process: {0}", myProcess->PriorityClass );
         
         // Get user processor time for this process.
         Console::WriteLine( "User Processor Time: {0}", myProcess->UserProcessorTime.ToString() );
         
         // Get privileged processor time for this process.
         Console::WriteLine( "Privileged Processor Time: {0}", myProcess->PrivilegedProcessorTime.ToString() );
         
         // Get total processor time for this process.
         Console::WriteLine( "Total Processor Time: {0}", myProcess->TotalProcessorTime.ToString() );
         
         // Invoke overloaded ToString function.
         Console::WriteLine( "Process's Name: {0}", myProcess->ToString() );
         Console::WriteLine( "-------------------------------------" );
         if ( myProcess->Responding )
         {
            Console::WriteLine( "Status:  Responding to user interface" );
            myProcess->Refresh();
         }
         else
         {
            Console::WriteLine( "Status:  Not Responding" );
         }
         Thread::Sleep( 1000 );
      }
      Console::WriteLine();
      Console::WriteLine(  "Process exit code: {0}", myProcess->ExitCode.ToString() );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "The following exception was raised:  {0}", e->Message );
   }

}

// </Snippet1>
