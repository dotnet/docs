// <snippet1>
// wrl-consume-asyncOp.cpp
// compile with: runtimeobject.lib 
// <snippet2>
#include <Windows.Foundation.h>
#include <Windows.System.Threading.h>
#include <wrl/event.h>
#include <stdio.h>
#include <Objbase.h>

using namespace ABI::Windows::Foundation;
using namespace ABI::Windows::System::Threading;
using namespace Microsoft::WRL;
using namespace Microsoft::WRL::Wrappers;
// </snippet2>

// Prints an error string for the provided source code line and HRESULT
// value and returns the HRESULT value as an int.
int PrintError(unsigned int line, HRESULT hr)
{
    wprintf_s(L"ERROR: Line:%d HRESULT: 0x%X\n", line, hr);
    return hr;
}

// Determines whether the input value is prime.
bool IsPrime(int n)
{
    if (n < 2)
    {
        return false;
    }
    for (int i = 2; i < n; ++i)
    {
        if ((n % i) == 0)
        {
            return false;
        }
    }
    return true;
}

int wmain()
{
    // <snippet3>
    // Initialize the Windows Runtime.
    RoInitializeWrapper initialize(RO_INIT_MULTITHREADED);
    if (FAILED(initialize))
    {
        return PrintError(__LINE__, initialize);
    }
    // </snippet3>

    // <snippet4>
    // Get the activation factory for the IThreadPoolStatics interface.
    ComPtr<IThreadPoolStatics> threadPool;
    HRESULT hr = GetActivationFactory(HStringReference(RuntimeClass_Windows_System_Threading_ThreadPool).Get(), &threadPool);
    if (FAILED(hr))
    {
        return PrintError(__LINE__, hr);
    }
    // </snippet4>

    // <snippet5>
    // Create an event that is set after the timer callback completes. We later use this event to wait for the timer to complete. 
    // This event is for demonstration only in a console app. In most apps, you typically don't wait for async operations to complete.
    Event threadCompleted(CreateEventEx(nullptr, nullptr, CREATE_EVENT_MANUAL_RESET, WRITE_OWNER | EVENT_ALL_ACCESS));
    hr = threadCompleted.IsValid() ? S_OK : HRESULT_FROM_WIN32(GetLastError());
    if (FAILED(hr))
    {
        return PrintError(__LINE__, hr);
    }

    // </snippet5>

    // <snippet6>
    wprintf_s(L"Starting thread...\n");

    // Create a thread that computes prime numbers.
    ComPtr<IAsyncAction> asyncAction;
    hr = threadPool->RunAsync(Callback<IWorkItemHandler>([&threadCompleted](IAsyncAction* asyncAction) -> HRESULT
    {
        // Print a message.
        const unsigned int start = 0;
        const unsigned int end = 100000;
        unsigned int primeCount = 0;
        for (int n = start; n < end; n++)
        {
            if (IsPrime(n))
            {
                primeCount++;
            }
        }

        wprintf_s(L"There are %u prime numbers from %u to %u.\n", primeCount, start, end);

        // Set the completion event and return.
        SetEvent(threadCompleted.Get());
        return S_OK;

    }).Get(), &asyncAction);
    if (FAILED(hr))
    {
        return PrintError(__LINE__, hr);
    }
    // </snippet6>

    // <snippet7>
    // Print a message and wait for the thread to complete.
    wprintf_s(L"Waiting for thread...\n");

    // Wait for the thread to complete.
    WaitForSingleObjectEx(threadCompleted.Get(), INFINITE, FALSE);

    wprintf_s(L"Finished.\n");

    // All smart pointers and RAII objects go out of scope here.
    // </snippet7>
}
/*
Output:
Starting thread...
Waiting for thread...
There are 9592 prime numbers from 0 to 100000.
Finished.
*/
// </snippet1>
