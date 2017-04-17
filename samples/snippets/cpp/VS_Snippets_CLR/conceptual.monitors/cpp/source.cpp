#using <System.dll>

using namespace System;
using namespace System::Threading;

// Note: The class whose internal public member is the synchronizing
// method is not public; none of the client code takes a lock on the
// Resource object.The member of the nonpublic class takes the lock on
// itself. Written this way, malicious code cannot take a lock on
// a public object.
ref class SyncResource
{
public:
    void Access(Int32 threadNum)
    {
        // Uses Monitor class to enforce synchronization.
        Monitor::Enter(this);
        try
        {
            // Synchronized: Despite the next conditional, each thread
            // waits on its predecessor.
            if (threadNum % 2 == 0)
            {
                Thread::Sleep(2000);
            }
            Console::WriteLine("Start Synched Resource access (Thread={0})", threadNum);
            Thread::Sleep(200);
            Console::WriteLine("Stop Synched Resource access  (Thread={0})", threadNum);
        }
        finally
        {
            Monitor::Exit(this);
        }
    }
};

// Without the lock, the method is called in the order in which threads reach it.
ref class UnSyncResource
{
public:
    void Access(Int32 threadNum)
    {
        // Does not use Monitor class to enforce synchronization.
        // The next call throws the thread order.
        if (threadNum % 2 == 0)
        {
            Thread::Sleep(2000);
        }
        Console::WriteLine("Start UnSynched Resource access (Thread={0})", threadNum);
        Thread::Sleep(200);
        Console::WriteLine("Stop UnSynched Resource access  (Thread={0})", threadNum);
    }
};

public ref class App
{
private:
    static Int32 numAsyncOps = 5;
    static AutoResetEvent^ asyncOpsAreDone = gcnew AutoResetEvent(false);
    static SyncResource^ SyncRes = gcnew SyncResource();
    static UnSyncResource^ UnSyncRes = gcnew UnSyncResource();

public:
    static void Main()
    {
        for (Int32 threadNum = 0; threadNum < 5; threadNum++)
        {
            ThreadPool::QueueUserWorkItem(gcnew WaitCallback(SyncUpdateResource), threadNum);
        }

        // Wait until this WaitHandle is signaled.
        asyncOpsAreDone->WaitOne();
        Console::WriteLine("\t\nAll synchronized operations have completed.\t\n");

        // Reset the thread count for unsynchronized calls.
        numAsyncOps = 5;

        for (Int32 threadNum = 0; threadNum < 5; threadNum++)
        {
            ThreadPool::QueueUserWorkItem(gcnew WaitCallback(UnSyncUpdateResource), threadNum);
        }

        // Wait until this WaitHandle is signaled.
        asyncOpsAreDone->WaitOne();
        Console::WriteLine("\t\nAll unsynchronized thread operations have completed.");
    }

    // The callback method's signature MUST match that of a
    // System.Threading.TimerCallback delegate (it takes an Object
    // parameter and returns void).
    static void SyncUpdateResource(Object^ state)
    {
        // This calls the internal synchronized method, passing
        // a thread number.
        SyncRes->Access((Int32) state);

        // Count down the number of methods that the threads have called.
        // This must be synchronized, however; you cannot know which thread
        // will access the value **before** another thread's incremented
        // value has been stored into the variable.
        if (Interlocked::Decrement(numAsyncOps) == 0)
        {
            // Announce to Main that in fact all thread calls are done.
            asyncOpsAreDone->Set();
        }
    }

    // The callback method's signature MUST match that of a
    // System.Threading.TimerCallback delegate (it takes an Object
    // parameter and returns void).
    static void UnSyncUpdateResource(Object^ state)
    {
        // This calls the unsynchronized method, passing a thread number.
        UnSyncRes->Access((Int32) state);

        // Count down the number of methods that the threads have called.
        // This must be synchronized, however; you cannot know which thread
        // will access the value **before** another thread's incremented
        // value has been stored into the variable.
        if (Interlocked::Decrement(numAsyncOps) == 0)
        {
            // Announce to Main that in fact all thread calls are done.
            asyncOpsAreDone->Set();
        }
    }
};

int main()
{
    App::Main();
}

public ref class MonitorSnippets
{
public:
    static void MonitorBlock1()
    {
        try
        {
            int x = 1;
            // The call to Enter() creates a generic synchronizing object for the value
            // of x each time the code is executed, so that Enter never blocks.
            Monitor::Enter(x);
            try
            {
                // Code that needs to be protected by the monitor.
            }
            finally
            {
                // Always use Finally to ensure that you exit the Monitor.

                // The call to Exit() will FAIL!!!
                // The synchronizing object created for x in Exit() will be different
                // than the object used in Enter(). SynchronizationLockException
                // will be thrown.
                Monitor::Exit(x);
            }
        }
        catch (SynchronizationLockException^ SyncEx)
        {
            Console::WriteLine("A SynchronizationLockException occurred. Message:");
            Console::WriteLine(SyncEx->Message);
        }
    }

    static void MonitorBlock2()
    {
        int x = 1;
        Object^ o = x;

        Monitor::Enter(o);
        try
        {
            // Code that needs to be protected by the monitor.
        }
        finally
        {
            // Always use Finally to ensure that you exit the Monitor.
            Monitor::Exit(o);
        }
    }
};
