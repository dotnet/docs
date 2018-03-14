
//<Snippet1>
// This example shows how to create an Object* containing task
// information, and pass that Object* to a task queued for
// execution by the thread pool.
using namespace System;
using namespace System::Threading;

// TaskInfo holds state information for a task that will be
// executed by a ThreadPool thread.
public ref class TaskInfo
{
public:

   // State information for the task.  These members
   // can be implemented as read-only properties, read/write
   // properties with validation, and so on, as required.
   String^ Boilerplate;
   int Value;

   // Public constructor provides an easy way to supply all
   // the information needed for the task.
   TaskInfo( String^ text, int number )
   {
      Boilerplate = text;
      Value = number;
   }

};

public ref struct Example
{
public:

   // The thread procedure performs the independent task, in this case
   // formatting and printing a very simple report.
   //
   static void ThreadProc( Object^ stateInfo )
   {
      TaskInfo^ ti = dynamic_cast<TaskInfo^>(stateInfo);
      Console::WriteLine( ti->Boilerplate, ti->Value );
   }

};

void main()
{
   
   // Create an object containing the information needed
   // for the task.
   TaskInfo^ ti = gcnew TaskInfo( "This report displays the number {0}.",42 );
   
   // Queue the task and data.
   ThreadPool::QueueUserWorkItem( gcnew WaitCallback( Example::ThreadProc ), ti );

   Console::WriteLine( "Main thread does some work, then sleeps." );
      
   // If you comment out the Sleep, the main thread exits before
   // the ThreadPool task has a chance to run.  ThreadPool uses 
   // background threads, which do not keep the application 
   // running.  (This is a simple example of a race condition.)
   Thread::Sleep( 1000 );
   Console::WriteLine( "Main thread exits." );
}
// The example displays output like the following:
//       Main thread does some work, then sleeps.
//       This report displays the number 42.
//       Main thread exits.
//</Snippet1>
