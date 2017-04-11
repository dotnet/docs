//Types:System.Threading.WaitHandle Vendor: Richter
//<snippet1>
using namespace System;
using namespace System::Threading;

public ref class WaitHandleExample
{
    // Define a random number generator for testing.
private:
    static Random^ random = gcnew Random();
public:
    static void DoTask(Object^ state)
    {
        AutoResetEvent^ autoReset = (AutoResetEvent^) state;
        int time = 1000 * random->Next(2, 10);
        Console::WriteLine("Performing a task for {0} milliseconds.", time);
        Thread::Sleep(time);
        autoReset->Set();
    }
};

//<snippet2>
int main()
{
    // Define an array with two AutoResetEvent WaitHandles.
    array<WaitHandle^>^ handles = gcnew array<WaitHandle^> {
        gcnew AutoResetEvent(false), gcnew AutoResetEvent(false)};

    // Queue up two tasks on two different threads;
    // wait until all tasks are completed.
    DateTime timeInstance = DateTime::Now;
    Console::WriteLine("Main thread is waiting for BOTH tasks to " +
        "complete.");
    ThreadPool::QueueUserWorkItem(
        gcnew WaitCallback(WaitHandleExample::DoTask), handles[0]);
    ThreadPool::QueueUserWorkItem(
        gcnew WaitCallback(WaitHandleExample::DoTask), handles[1]);
    WaitHandle::WaitAll(handles);
    // The time shown below should match the longest task.
    Console::WriteLine("Both tasks are completed (time waited={0})",
        (DateTime::Now - timeInstance).TotalMilliseconds);

    // Queue up two tasks on two different threads;
    // wait until any tasks are completed.
    timeInstance = DateTime::Now;
    Console::WriteLine();
    Console::WriteLine("The main thread is waiting for either task to " +
        "complete.");
    ThreadPool::QueueUserWorkItem(
        gcnew WaitCallback(WaitHandleExample::DoTask), handles[0]);
    ThreadPool::QueueUserWorkItem(
        gcnew WaitCallback(WaitHandleExample::DoTask), handles[1]);
    int index = WaitHandle::WaitAny(handles);
    // The time shown below should match the shortest task.
    Console::WriteLine("Task {0} finished first (time waited={1}).",
        index + 1, (DateTime::Now - timeInstance).TotalMilliseconds);
}
//</snippet2>

// This code produces the following sample output.
//
// Main thread is waiting for BOTH tasks to complete.
// Performing a task for 7000 milliseconds.
// Performing a task for 4000 milliseconds.
// Both tasks are completed (time waited=7064.8052)

// The main thread is waiting for either task to complete.
// Performing a task for 2000 milliseconds.
// Performing a task for 2000 milliseconds.
// Task 1 finished first (time waited=2000.6528).
//</snippet1>
