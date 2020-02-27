//<snippet1>
using namespace System;
using namespace System::Threading;
using namespace System::Runtime::Remoting::Contexts;

[Synchronization(true)]
public ref class SyncingClass : ContextBoundObject
{
private:
    EventWaitHandle^ waitHandle;

public:
    SyncingClass()
    {
         waitHandle =
            gcnew EventWaitHandle(false, EventResetMode::ManualReset);
    }

    void Signal()
    {
        Console::WriteLine("Thread[{0:d4}]: Signalling...", Thread::CurrentThread->GetHashCode());
        waitHandle->Set();
    }

    void DoWait(bool leaveContext)
    {
        bool signalled;

        waitHandle->Reset();
        Console::WriteLine("Thread[{0:d4}]: Waiting...", Thread::CurrentThread->GetHashCode());
        signalled = waitHandle->WaitOne(3000, leaveContext);
        if (signalled)
        {
            Console::WriteLine("Thread[{0:d4}]: Wait released!!!", Thread::CurrentThread->GetHashCode());
        }
        else
        {
            Console::WriteLine("Thread[{0:d4}]: Wait timeout!!!", Thread::CurrentThread->GetHashCode());
        }
    }
};

public ref class TestSyncDomainWait
{
public:
    static void Main()
    {
        SyncingClass^ syncClass = gcnew SyncingClass();

        Thread^ runWaiter;

        Console::WriteLine("\nWait and signal INSIDE synchronization domain:\n");
        runWaiter = gcnew Thread(gcnew ParameterizedThreadStart(&TestSyncDomainWait::RunWaitKeepContext));
        runWaiter->Start(syncClass);
        Thread::Sleep(1000);
        Console::WriteLine("Thread[{0:d4}]: Signal...", Thread::CurrentThread->GetHashCode());
        // This call to Signal will block until the timeout in DoWait expires.
        syncClass->Signal();
        runWaiter->Join();

        Console::WriteLine("\nWait and signal OUTSIDE synchronization domain:\n");
        runWaiter = gcnew Thread(gcnew ParameterizedThreadStart(&TestSyncDomainWait::RunWaitLeaveContext));
        runWaiter->Start(syncClass);
        Thread::Sleep(1000);
        Console::WriteLine("Thread[{0:d4}]: Signal...", Thread::CurrentThread->GetHashCode());
        // This call to Signal is unblocked and will set the wait handle to
        // release the waiting thread.
        syncClass->Signal();
        runWaiter->Join();
    }

    static void RunWaitKeepContext(Object^ parm)
    {
        ((SyncingClass^)parm)->DoWait(false);
    }

    static void RunWaitLeaveContext(Object^ parm)
    {
        ((SyncingClass^)parm)->DoWait(true);
    }
};

int main()
{
    TestSyncDomainWait::Main();
}
// The output for the example program will be similar to the following:
//
// Wait and signal INSIDE synchronization domain:
//
// Thread[0004]: Waiting...
// Thread[0001]: Signal...
// Thread[0004]: Wait timeout!!!
// Thread[0001]: Signalling...
//
// Wait and signal OUTSIDE synchronization domain:
//
// Thread[0006]: Waiting...
// Thread[0001]: Signal...
// Thread[0001]: Signalling...
// Thread[0006]: Wait released!!!
//</snippet1>
