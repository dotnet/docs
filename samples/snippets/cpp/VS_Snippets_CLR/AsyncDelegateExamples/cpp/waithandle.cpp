//<Snippet3>
#using <TestMethod.dll>

using namespace System;
using namespace System::Threading;
using namespace Examples::AdvancedProgramming::AsynchronousOperations;

void main() 
{
    // The asynchronous method puts the thread id here.
    int threadId;

    // Create an instance of the test class.
    AsyncDemo^ ad = gcnew AsyncDemo();

    // Create the delegate.
    AsyncMethodCaller^ caller = gcnew AsyncMethodCaller(ad, &AsyncDemo::TestMethod);
       
    // Initiate the asynchronous call.
    IAsyncResult^ result = caller->BeginInvoke(3000, 
        threadId, nullptr, nullptr);

    Thread::Sleep(0);
    Console::WriteLine("Main thread {0} does some work.",
        Thread::CurrentThread->ManagedThreadId);

    // Wait for the WaitHandle to become signaled.
    result->AsyncWaitHandle->WaitOne();

    // Perform additional processing here.
    // Call EndInvoke to retrieve the results.
    String^ returnValue = caller->EndInvoke(threadId, result);

    // Close the wait handle.
    result->AsyncWaitHandle->Close();

    Console::WriteLine("The call executed on thread {0}, with return value \"{1}\".",
        threadId, returnValue);
}

/* This example produces output similar to the following:

Main thread 1 does some work.
Test method begins.
The call executed on thread 3, with return value "My call time was 3000.".
 */
//</Snippet3>
