// <snippet2>
using namespace System;
using namespace System::Threading;

public ref class ServerClass
{
public:
    // The method that will be called when the thread is started.
    void InstanceMethod()
    {
        Console::WriteLine(
            "ServerClass->InstanceMethod is running on another thread.");

        // Pause for a moment to provide a delay to make
        // threads more apparent.
        Thread::Sleep(3000);
        Console::WriteLine(
            "The instance method called by the worker thread has ended.");
    }

    static void StaticMethod()
    {
        Console::WriteLine(
            "ServerClass::StaticMethod is running on another thread.");

        // Pause for a moment to provide a delay to make
        // threads more apparent.
        Thread::Sleep(5000);
        Console::WriteLine(
            "The static method called by the worker thread has ended.");
    }
};

public class Simple
{
public:
    static void Main()
    {
        Console::WriteLine("Thread Simple Sample");

        ServerClass^ serverObject = gcnew ServerClass();

        // Create the thread object, passing in a ThreadStart delegate
        // representing an instance of ServerClass and the
        // ServerClass::InstanceMethod method.
        Thread^ InstanceCaller = gcnew Thread(
        gcnew ThreadStart(serverObject, &ServerClass::InstanceMethod));

        // Start the thread.
        InstanceCaller->Start();

        Console::WriteLine("The main thread has "
            + "started the new InstanceMethod thread.");

        // Create the thread object, passing in a ThreadStart delegate
        // representing the static ServerClass::StaticMethod method.
        Thread^ StaticCaller = gcnew Thread(
            gcnew ThreadStart(&ServerClass::StaticMethod));

        // Start the thread.
        StaticCaller->Start();

        Console::WriteLine("The main thread has called "
            + "the new StaticMethod thread.");
    }        
};

int main()
{
    Simple::Main();
}
// </snippet2>
