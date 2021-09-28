// <snippet1>
// wrl-consume-events.cpp
// compile with: runtimeobject.lib
// <snippet2>
#include <Windows.Devices.Enumeration.h>
#include <wrl/event.h>
#include <stdio.h>

using namespace ABI::Windows::Devices::Enumeration;
using namespace ABI::Windows::Foundation;
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
    // Type define the event handler types to make the code more readable.
    typedef __FITypedEventHandler_2_Windows__CDevices__CEnumeration__CDeviceWatcher_Windows__CDevices__CEnumeration__CDeviceInformation AddedHandler;
    typedef __FITypedEventHandler_2_Windows__CDevices__CEnumeration__CDeviceWatcher_IInspectable EnumerationCompletedHandler;
    typedef __FITypedEventHandler_2_Windows__CDevices__CEnumeration__CDeviceWatcher_IInspectable StoppedHandler;

    // <snippet7>
    // Counts the number of enumerated devices.
    unsigned int deviceCount = 0;

    // Event registration tokens that enable us to later unsubscribe from events.
    EventRegistrationToken addedToken;
    EventRegistrationToken stoppedToken;
    EventRegistrationToken enumCompletedToken;
    // </snippet7>

    // <snippet3>
    // Initialize the Windows Runtime.
    RoInitializeWrapper initialize(RO_INIT_MULTITHREADED);
    if (FAILED(initialize))
    {
        return PrintError(__LINE__, initialize);
    }
    // </snippet3>

    // <snippet4>
    // Create an event that is set after device enumeration completes. We later use this event to wait for the timer to complete. 
    // This event is for demonstration only in a console app. In most apps, you typically don't wait for async operations to complete.
    Event enumerationCompleted(CreateEventEx(nullptr, nullptr, CREATE_EVENT_MANUAL_RESET, WRITE_OWNER | EVENT_ALL_ACCESS));
    HRESULT hr = enumerationCompleted.IsValid() ? S_OK : HRESULT_FROM_WIN32(GetLastError());
    if (FAILED(hr))
    {
        return PrintError(__LINE__, hr);
    }
    // </snippet4>

    // <snippet5>
    // Get the activation factory for the IDeviceWatcher interface.
    ComPtr<IDeviceInformationStatics> watcherFactory;
    hr = ABI::Windows::Foundation::GetActivationFactory(HStringReference(RuntimeClass_Windows_Devices_Enumeration_DeviceInformation).Get(), &watcherFactory);
    if (FAILED(hr))
    {
        return PrintError(__LINE__, hr);
    }
    // </snippet5>

    // <snippet6>
    // Create a IDeviceWatcher object from the factory.
    ComPtr<IDeviceWatcher> watcher;
    hr = watcherFactory->CreateWatcher(&watcher);
    if (FAILED(hr))
    {
        return PrintError(__LINE__, hr);
    }
    // </snippet6>

    // <snippet8>
    // Subscribe to the Added event.
    hr = watcher->add_Added(Callback<AddedHandler>([&deviceCount](IDeviceWatcher* watcher, IDeviceInformation*) -> HRESULT
    {
        // Print a message and increment the device count.
        // When we reach 10 devices, stop enumerating devices.
        wprintf_s(L"Added device...\n");
        deviceCount++;
        if (deviceCount == 10)
        {
            return watcher->Stop();
        }
        return S_OK;

    }).Get(), &addedToken);
    if (FAILED(hr))
    {
        return PrintError(__LINE__, hr);
    }

    hr = watcher->add_Stopped(Callback<StoppedHandler>([=, &enumerationCompleted](IDeviceWatcher* watcher, IInspectable*) -> HRESULT
    {
        wprintf_s(L"Device enumeration stopped.\nRemoving event handlers...");

        // Unsubscribe from the events. This is shown for demonstration.
        // The need to remove event handlers depends on the requirements of 
        // your app. For instance, if you only need to handle an event for 
        // a short period of time, you might remove the event handler when you
        // no longer need it. If you handle an event for the duration of the app,
        // you might not need to explicitly remove it.
        HRESULT hr1 = watcher->remove_Added(addedToken);
        HRESULT hr2 = watcher->remove_Stopped(stoppedToken);
        HRESULT hr3 = watcher->remove_EnumerationCompleted(enumCompletedToken);

        // Set the completion event and return.
        SetEvent(enumerationCompleted.Get());

        return FAILED(hr1) ? hr1 : FAILED(hr2) ? hr2 : hr3;

    }).Get(), &stoppedToken);
    if (FAILED(hr))
    {
        return PrintError(__LINE__, hr);
    }

    // Subscribe to the EnumerationCompleted event.
    hr = watcher->add_EnumerationCompleted(Callback<EnumerationCompletedHandler>([](IDeviceWatcher* watcher, IInspectable*) -> HRESULT
    {
        wprintf_s(L"Enumeration completed.\n");

        return watcher->Stop();

    }).Get(), &enumCompletedToken);
    if (FAILED(hr))
    {
        return PrintError(__LINE__, hr);
    }
    // </snippet8>

    // <snippet9>
    wprintf_s(L"Starting device enumeration...\n");
    hr = watcher->Start();
    if (FAILED(hr))
    {
        return PrintError(__LINE__, hr);
    }
    // </snippet9>

    // <snippet10>
    // Wait for the operation to complete.
    WaitForSingleObjectEx(enumerationCompleted.Get(), INFINITE, FALSE);

    wprintf_s(L"Enumerated %u devices.\n", deviceCount);

    // All smart pointers and RAII objects go out of scope here.
    // </snippet10>
}
/*
Sample output:
Starting device enumeration...
Added device...
Added device...
Added device...
Added device...
Added device...
Added device...
Added device...
Added device...
Added device...
Added device...
Device enumeration stopped.
Removing event handlers...
Enumerated 10 devices.
*/
// </snippet1>