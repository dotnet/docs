//<snippet4>
using namespace System;
using namespace System::Threading;

// Delegate that defines the signature for the callback method.
//
public delegate void ExampleCallback(int lineCount);

// The ThreadWithState class contains the information needed for
// a task, the method that executes the task, and a delegate
// to call when the task is complete.
//
public ref class ThreadWithState
{
private:
    // State information used in the task.
    String^ boilerplate;
    int numberValue;

    // Delegate used to execute the callback method when the
    // task is complete.
    ExampleCallback^ callback;

public:
    // The constructor obtains the state information and the
    // callback delegate.
    ThreadWithState(String^ text, int number,
        ExampleCallback^ callbackDelegate)
    {
        boilerplate = text;
        numberValue = number;
        callback = callbackDelegate;
    }

    // The thread procedure performs the task, such as
    // formatting and printing a document, and then invokes
    // the callback delegate with the number of lines printed.
    void ThreadProc()
    {
        Console::WriteLine(boilerplate, numberValue);
        if (callback != nullptr)
        {
            callback(1);
        }
    }
};

// Entry point for the example.
//
public ref class Example
{
public:
    static void Main()
    {
        // Supply the state information required by the task.
        ThreadWithState^ tws = gcnew ThreadWithState(
            "This report displays the number {0}.",
            42,
            gcnew ExampleCallback(&Example::ResultCallback)
        );

        Thread^ t = gcnew Thread(gcnew ThreadStart(tws, &ThreadWithState::ThreadProc));
        t->Start();
        Console::WriteLine("Main thread does some work, then waits.");
        t->Join();
        Console::WriteLine(
            "Independent task has completed; main thread ends.");
    }

    // The callback method must match the signature of the
    // callback delegate.
    //
    static void ResultCallback(int lineCount)
    {
        Console::WriteLine(
            "Independent task printed {0} lines.", lineCount);
    }
};

int main()
{
    Example::Main();
}
// The example displays the following output:
//       Main thread does some work, then waits.
//       This report displays the number 42.
//       Independent task printed 1 lines.
//       Independent task has completed; main thread ends.
//</snippet4>
