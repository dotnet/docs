//<Snippet1>
using namespace System;
using namespace System::Threading;

namespace SystemThreadingExample
{
    public ref class Example
    {
    private:
        static ManualResetEvent^ dummyEvent = 
            gcnew ManualResetEvent(false);
            
        static Mutex^ orphanMutex1 = gcnew Mutex;
        static Mutex^ orphanMutex2 = gcnew Mutex;
        static Mutex^ orphanMutex3 = gcnew Mutex;
        static Mutex^ orphanMutex4 = gcnew Mutex;
        static Mutex^ orphanMutex5 = gcnew Mutex;
        
    public:
        static void ProduceAbandonMutexException(void)
        {
            
            // Start a thread that grabs all five mutexes, and then
            // abandons them.
            Thread^ abandonThread = 
                gcnew Thread(gcnew ThreadStart(AbandonMutex));

            abandonThread->Start();
            
            // Make sure the thread is finished.
            abandonThread->Join();
            
            // Wait on one of the abandoned mutexes. The WaitOne
            // throws an AbandonedMutexException.
            try
            {
                orphanMutex1->WaitOne();
                Console::WriteLine("WaitOne succeeded.");
            }
            catch (AbandonedMutexException^ ex) 
            {
                Console::WriteLine("Exception in WaitOne: {0}", 
                    ex->Message);
            }
            finally
            {
                
                // Whether or not the exception was thrown, 
                // the current thread owns the mutex, and 
                // must release it.
                orphanMutex1->ReleaseMutex();
            }

            
            // Create an array of wait handles, consisting of one
            // ManualResetEvent and two mutexes, using two more of
            // the abandoned mutexes.
    	    array <WaitHandle^>^ waitFor = {dummyEvent, 
                orphanMutex2, orphanMutex3};
            
            // WaitAny returns when any of the wait handles in the 
            // array is signaled. Either of the two abandoned mutexes
            // satisfy the wait, but lower of the two index values is
            // returned by MutexIndex. Note that the Try block and
            // the Catch block obtain the index in different ways.
            try
            {
                int index = WaitHandle::WaitAny(waitFor);
                Console::WriteLine("WaitAny succeeded.");
                (safe_cast<Mutex^>(waitFor[index]))->ReleaseMutex();
            }
            catch (AbandonedMutexException^ ex) 
            {
                Console::WriteLine("Exception in WaitAny at index {0}"
                    "\r\n\tMessage: {1}", ex->MutexIndex, 
                    ex->Message);
                (safe_cast<Mutex^>(waitFor[ex->MutexIndex]))->
                    ReleaseMutex();
            }

            orphanMutex3->ReleaseMutex();
            
            // Use two more of the abandoned mutexes for the WaitAll 
            // call. WaitAll doesn't return until all wait handles 
            // are signaled, so the ManualResetEvent must be signaled 
            // by calling Set().
            dummyEvent->Set();
            waitFor[1] = orphanMutex4;
            waitFor[2] = orphanMutex5;
            
            // Because WaitAll requires all the wait handles to be
            // signaled, both mutexes must be released even if the
            // exception is thrown. Thus, the ReleaseMutex calls are 
            // placed in the Finally block. Again, MutexIndex returns
            // the lower of the two index values for the abandoned
            // mutexes.
            //  
            try
            {
                WaitHandle::WaitAll(waitFor);
                Console::WriteLine("WaitAll succeeded.");
            }
            catch (AbandonedMutexException^ ex) 
            {
                Console::WriteLine("Exception in WaitAny at index {0}"
                    "\r\n\tMessage: {1}", ex->MutexIndex, 
                    ex->Message);
            }
            finally
            {
                orphanMutex4->ReleaseMutex();
                orphanMutex5->ReleaseMutex();
            }

        }


    private:
        [MTAThread]
        static void AbandonMutex()
        {
            orphanMutex1->WaitOne();
            orphanMutex2->WaitOne();
            orphanMutex3->WaitOne();
            orphanMutex4->WaitOne();
            orphanMutex5->WaitOne();
            Console::WriteLine(
                "Thread exits without releasing the mutexes.");
        }
    };   
}

//Entry point of example application
[MTAThread]
int main(void)
{
    SystemThreadingExample::Example::ProduceAbandonMutexException();
}

// This code example produces the following output:
// Thread exits without releasing the mutexes.
// Exception in WaitOne: The wait completed due to an abandoned mutex.
// Exception in WaitAny at index 1
//         Message: The wait completed due to an abandoned mutex.
// Exception in WaitAll at index -1
//         Message: The wait completed due to an abandoned mutex.

//</Snippet1>
