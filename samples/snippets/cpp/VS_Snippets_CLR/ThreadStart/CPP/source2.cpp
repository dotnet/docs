// <snippet3>
using namespace System;
using namespace System::Threading;

// The ThreadWithState class contains the information needed for
// a task, and the method that executes the task.
//
public ref class ThreadWithState
{
private:
    // State information used in the task.
    String^ boilerplate;
    int value;

public:
    // The constructor obtains the state information.
    ThreadWithState(String^ text, int number)
    {
        boilerplate = text;
        value = number;
    }

    // The thread procedure performs the task, such as formatting
    // and printing a document.
    void ThreadProc()
    {
        Console::WriteLine(boilerplate, value);
    }
};

public ref class Example
{
public:
    // Entry point for the example.
    //
    static void Main()
    {
        // Supply the state information required by the task.
        ThreadWithState^ tws = gcnew ThreadWithState(
            "This report displays the number {0}.", 42);

        // Create a thread to execute the task, and then
        // start the thread.
        Thread^ t = gcnew Thread(
            gcnew ThreadStart(tws, &ThreadWithState::ThreadProc));
        t->Start();
        Console::WriteLine("Main thread does some work, then waits.");
        t->Join();
        Console::WriteLine(
            "Independent task has completed; main thread ends.");
    }
};

int main()
{
    Example::Main();
}
// </snippet3>
