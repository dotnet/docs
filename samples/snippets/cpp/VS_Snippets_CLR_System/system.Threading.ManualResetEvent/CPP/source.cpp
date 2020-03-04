// <Snippet1>
using namespace System;
using namespace System::Threading;

ref class Example
{
private:
    // mre is used to block and release threads manually. It is
    // created in the unsignaled state.
    static ManualResetEvent^ mre = gcnew ManualResetEvent(false);

    static void ThreadProc()
    {
        String^ name = Thread::CurrentThread->Name;

        Console::WriteLine(name + " starts and calls mre->WaitOne()");

        mre->WaitOne();

        Console::WriteLine(name + " ends.");
    }

public:
    static void Demo()
    {
        Console::WriteLine("\nStart 3 named threads that block on a ManualResetEvent:\n");

        for(int i = 0; i <=2 ; i++)
        {
            Thread^ t = gcnew Thread(gcnew ThreadStart(ThreadProc));
            t->Name = "Thread_" + i;
            t->Start();
        }

        Thread::Sleep(500);
        Console::WriteLine("\nWhen all three threads have started, press Enter to call Set()" +
                           "\nto release all the threads.\n");
        Console::ReadLine();

        mre->Set();

        Thread::Sleep(500);
        Console::WriteLine("\nWhen a ManualResetEvent is signaled, threads that call WaitOne()" +
                           "\ndo not block. Press Enter to show this.\n");
        Console::ReadLine();

        for(int i = 3; i <= 4; i++)
        {
            Thread^ t = gcnew Thread(gcnew ThreadStart(ThreadProc));
            t->Name = "Thread_" + i;
            t->Start();
        }

        Thread::Sleep(500);
        Console::WriteLine("\nPress Enter to call Reset(), so that threads once again block" +
                           "\nwhen they call WaitOne().\n");
        Console::ReadLine();

        mre->Reset();

        // Start a thread that waits on the ManualResetEvent.
        Thread^ t5 = gcnew Thread(gcnew ThreadStart(ThreadProc));
        t5->Name = "Thread_5";
        t5->Start();

        Thread::Sleep(500);
        Console::WriteLine("\nPress Enter to call Set() and conclude the demo.");
        Console::ReadLine();

        mre->Set();

        // If you run this example in Visual Studio, uncomment the following line:
        //Console::ReadLine();
    }
};

int main()
{
   Example::Demo();
}

/* This example produces output similar to the following:

Start 3 named threads that block on a ManualResetEvent:

Thread_0 starts and calls mre->WaitOne()
Thread_1 starts and calls mre->WaitOne()
Thread_2 starts and calls mre->WaitOne()

When all three threads have started, press Enter to call Set()
to release all the threads.


Thread_2 ends.
Thread_1 ends.
Thread_0 ends.

When a ManualResetEvent is signaled, threads that call WaitOne()
do not block. Press Enter to show this.


Thread_3 starts and calls mre->WaitOne()
Thread_3 ends.
Thread_4 starts and calls mre->WaitOne()
Thread_4 ends.

Press Enter to call Reset(), so that threads once again block
when they call WaitOne().


Thread_5 starts and calls mre->WaitOne()

Press Enter to call Set() and conclude the demo.

Thread_5 ends.
 */
// </Snippet1>
