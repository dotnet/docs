//<snippet2>
using namespace System;
using namespace System::Threading;

public ref class ServerClass
{
public:
    // The method that will be called when the thread is started.
    void InstanceMethod()
    {
        Console::WriteLine(
            "ServerClass.InstanceMethod is running on another thread.");

        // Pause for a moment to provide a delay to make
        // threads more apparent.
        Thread::Sleep(3000);
        Console::WriteLine(
            "The instance method called by the worker thread has ended.");
    }

    static void StaticMethod()
    {
        Console::WriteLine(
            "ServerClass.StaticMethod is running on another thread.");

        // Pause for a moment to provide a delay to make
        // threads more apparent.
        Thread::Sleep(5000);
        Console::WriteLine(
            "The static method called by the worker thread has ended.");
    }
};

public ref class Simple
{
public:
    static void Main()
    {
        ServerClass^ serverObject = gcnew ServerClass();

        // Create the thread object, passing in the
        // serverObject.InstanceMethod method using a
        // ThreadStart delegate.
        Thread^ InstanceCaller = gcnew Thread(
            gcnew ThreadStart(serverObject, &ServerClass::InstanceMethod));

        // Start the thread.
        InstanceCaller->Start();

        Console::WriteLine("The Main() thread calls this after "
            + "starting the new InstanceCaller thread.");

        // Create the thread object, passing in the
        // serverObject.StaticMethod method using a
        // ThreadStart delegate.
        Thread^ StaticCaller = gcnew Thread(
            gcnew ThreadStart(&ServerClass::StaticMethod));

        // Start the thread.
        StaticCaller->Start();

        Console::WriteLine("The Main() thread calls this after "
            + "starting the new StaticCaller thread.");
    }
};

int main()
{
    Simple::Main();
}
// The example displays output like the following:
//       The Main() thread calls this after starting the new InstanceCaller thread.
//       The Main() thread calls this after starting the new StaticCaller thread.
//       ServerClass.StaticMethod is running on another thread.
//       ServerClass.InstanceMethod is running on another thread.
//       The instance method called by the worker thread has ended.
//       The static method called by the worker thread has ended.
//</snippet2>
