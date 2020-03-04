using namespace System;
using namespace System::Threading;
using namespace System::Security::Permissions;

public ref class ThreadWork
{
public:
    static void DoWork()
    {
        //<Snippet2>
        try
        {
            // Code that is executing when the thread is aborted.
            // Simulated thread work...
            Thread::Sleep(2000);
        }
        catch (ThreadAbortException^ ex)
        {
            // Clean-up code can go here.
            // If there is no Finally clause, ThreadAbortException is
            // re-thrown by the system at the end of the Catch clause.
            if (ex->ExceptionState != nullptr)
            {
                Console::WriteLine("Exception State: {0}", ex->ExceptionState);
            }
        }
        finally
        {
            // Clean-up code can go here.
        }
        // Do not put clean-up code here, because the exception
        // is rethrown at the end of the Finally clause.
        //</Snippet2>
    }
};

public ref class ThreadAbortTest
{
public:
    static void Main()
    {
        ThreadStart^ myThreadDelegate = gcnew ThreadStart(&ThreadWork::DoWork);
        Thread^ myThread = gcnew Thread(myThreadDelegate);
        myThread->Start();
        Thread::Sleep(1000);
        myThread->Abort("You are finished!");
        myThread->Join();
    }
};

int main()
{
    ThreadAbortTest::Main();
}