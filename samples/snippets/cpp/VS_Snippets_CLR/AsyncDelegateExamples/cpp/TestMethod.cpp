//<Snippet1>
using namespace System;
using namespace System::Threading;
using namespace System::Runtime::InteropServices; 

namespace Examples {
namespace AdvancedProgramming {
namespace AsynchronousOperations
{
    public ref class AsyncDemo 
    {
    public:
        // The method to be executed asynchronously.
        String^ TestMethod(int callDuration, [OutAttribute] int% threadId) 
        {
            Console::WriteLine("Test method begins.");
            Thread::Sleep(callDuration);
            threadId = Thread::CurrentThread->ManagedThreadId;
            return String::Format("My call time was {0}.", callDuration);
        }
    };

    // The delegate must have the same signature as the method
    // it will call asynchronously.
    public delegate String^ AsyncMethodCaller(int callDuration, [OutAttribute] int% threadId);
}}}
//</Snippet1>
