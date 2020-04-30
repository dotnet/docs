// <snippet1>
// wrl-consume-async.cpp
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
    // Get the activation factory for the IThreadPoolTimer interface.
    ComPtr<IThreadPoolTimerStatics> timerFactory;
    HRESULT hr = GetActivationFactory(HStringReference(RuntimeClass_Windows_System_Threading_ThreadPoolTimer).Get(), &timerFactory);
    if (FAILED(hr))
    {
        return PrintError(__LINE__, hr);
    }
    // </snippet4>

    // <snippet5>
    // Create an event that is set after the timer callback completes. We later use this event to wait for the timer to complete. 
    // This event is for demonstration only in a console app. In most apps, you typically don't wait for async operations to complete.
    Event timerCompleted(CreateEventEx(nullptr, nullptr, CREATE_EVENT_MANUAL_RESET, WRITE_OWNER | EVENT_ALL_ACCESS));
    hr = timerCompleted.IsValid() ? S_OK : HRESULT_FROM_WIN32(GetLastError());
    if (FAILED(hr))
    {
        return PrintError(__LINE__, hr);
    }
    // </snippet5>

    // <snippet6>
    // Create a timer that prints a message after 2 seconds.

    TimeSpan delay;
    delay.Duration = 20000000; // 2 seconds.

    auto callback = Callback<ITimerElapsedHandler>([&timerCompleted](IThreadPoolTimer* timer) -> HRESULT
    {
        wprintf_s(L"Timer fired.\n");

        TimeSpan delay;
        HRESULT hr = timer->get_Delay(&delay);
        if (SUCCEEDED(hr))
        {
            wprintf_s(L"Timer duration: %2.2f seconds.\n", delay.Duration / 10000000.0);
        }

        // Set the completion event and return.
        SetEvent(timerCompleted.Get());
        return hr;
    });
    hr = callback ? S_OK : E_OUTOFMEMORY;
    if (FAILED(hr))
    {
        return PrintError(__LINE__, hr);
    }

    ComPtr<IThreadPoolTimer> timer;
    hr = timerFactory->CreateTimer(callback.Get(), delay, &timer);
    if (FAILED(hr))
    {
        return PrintError(__LINE__, hr);
    }
    // </snippet6>

    // <snippet7>
    // Print a message and wait for the timer callback to complete.
    wprintf_s(L"Timer started.\nWaiting for timer...\n");

    // Wait for the timer to complete.
    WaitForSingleObjectEx(timerCompleted.Get(), INFINITE, FALSE);
    // All smart pointers and RAII objects go out of scope here.
    // </snippet7>
}
/*
Output:
Timer started.
Waiting for timer...
Timer fired.
Timer duration: 2.00 seconds.
*/
// </snippet1>