//<Snippet2>
#using <TestMethod.dll>

using namespace System;
using namespace System::Threading;
using namespace Examples::AdvancedProgramming::AsynchronousOperations;

void main() 
{
    // The asynchronous method puts the thread id here.
    int threadId = 2546;

    // Create an instance of the test class.
    AsyncDemo^ ad = gcnew AsyncDemo();

    // Create the delegate.
    AsyncMethodCaller^ caller = gcnew AsyncMethodCaller(ad, &AsyncDemo::TestMethod);
       
    // Initiate the asynchronous call.
    IAsyncResult^ result = caller->BeginInvoke(3000, 
        threadId, nullptr, nullptr);

    Thread::Sleep(1);
    Console::WriteLine("Main thread {0} does some work.",
        Thread::CurrentThread->ManagedThreadId);

    // Call EndInvoke to wait for the asynchronous call to complete,
    // and to retrieve the results.
    String^ returnValue = caller->EndInvoke(threadId, result);

    Console::WriteLine("The call executed on thread {0}, with return value \"{1}\".",
        threadId, returnValue);
}

/* This example produces output similar to the following:

Main thread 1 does some work.
Test method begins.
The call executed on thread 3, with return value "My call time was 3000.".
 */
//</Snippet2>
