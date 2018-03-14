// CorrelationManager.cpp : main project file.


//<Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Collections::Generic;
using namespace System::Text;
using namespace System::Diagnostics;
using namespace System::Threading;

void ThreadProc()
{
    TraceSource^ ts = gcnew TraceSource("MyApp");
    int i = ts->Listeners->Add(gcnew ConsoleTraceListener());
    ts->Listeners[i]->TraceOutputOptions = TraceOptions::LogicalOperationStack;
    ts->Switch = gcnew SourceSwitch("MyAPP", "Verbose");
    // Add another logical operation.
    Trace::CorrelationManager->StartLogicalOperation("WorkerThread");

    ts->TraceEvent(TraceEventType::Error, 1, "Trace an error event.");
    Trace::CorrelationManager->StopLogicalOperation();
}

void main()
{
    TraceSource^ ts = gcnew TraceSource("MyApp");
    int i = ts->Listeners->Add(gcnew ConsoleTraceListener());
    ts->Listeners[i]->TraceOutputOptions = TraceOptions::LogicalOperationStack;
    ts->Switch = gcnew SourceSwitch("MyAPP", "Verbose");
    // Start the logical operation on the Main thread.
    Trace::CorrelationManager->StartLogicalOperation("MainThread");

    ts->TraceEvent(TraceEventType::Error, 1, "Trace an error event.");
    Thread^ t = gcnew Thread(gcnew ThreadStart(ThreadProc));
//   Start the worker thread.
    t->Start();
//  Give the worker thread a chance to execute.
    Thread::Sleep(1000);
    Trace::CorrelationManager->StopLogicalOperation();}



// This sample generates the following output:
//MyApp Error: 1 : Trace an error event.
//    LogicalOperationStack=MainThread
//MyApp Error: 1 : Trace an error event.
//    LogicalOperationStack=WorkerThread, MainThread
//</Snippet1>

