// <snippet6>
#include "stdafx.h"

#include "..\CalculatorComponent\CalculatorComponent_h.h"

const IID IID_ICalculatorComponent = {0x0DBABB94,0xCE99,0x42F7,0xAC,0xBD,0xE6,0x98,0xB2,0x33,0x2C,0x60};
const CLSID CLSID_CalculatorComponent = {0xE68F5EDD,0x6257,0x4E72,0xA1,0x0B,0x40,0x67,0xED,0x8E,0x85,0xF2};

// Prints an error string for the provided source code line and HRESULT
// value and returns the HRESULT value as an int.
int PrintError(unsigned int line, HRESULT hr)
{
    wprintf_s(L"ERROR: Line:%d HRESULT: 0x%X\n", line, hr);
    return hr;
}

int wmain()
{
    HRESULT hr;

    // Initialize the COM library.
    hr = CoInitializeEx(nullptr, COINIT_APARTMENTTHREADED);
    if (FAILED(hr))
    {
        return PrintError(__LINE__, hr);
    }

    ICalculatorComponent* calc = nullptr; // Interface to COM component.

    // Create the CalculatorComponent object.
    hr = CoCreateInstance(CLSID_CalculatorComponent, nullptr, CLSCTX_INPROC_SERVER, IID_PPV_ARGS(&calc));
    if (SUCCEEDED(hr))
    {
        // Test the component by adding two numbers.
        int result;
        hr = calc->Add(4, 5, &result);
        if (FAILED(hr))
        {
            PrintError(__LINE__, hr);
        }
        else
        {
            wprintf_s(L"result = %d\n", result);
        }

        // Free the CalculatorComponent object.
        calc->Release();
    }
    else
    {
        // Object creation failed. Print a message.
        PrintError(__LINE__, hr);
    }

    // Free the COM library.
    CoUninitialize();

    return hr;
}
/* Output:
result = 9
*/
// </snippet6>
/*
// <snippet7>
#include "stdafx.h"
#include <wrl.h>

#include "..\CalculatorComponent\CalculatorComponent_h.h"

using namespace Microsoft::WRL;

const IID IID_ICalculatorComponent = {0x0DBABB94,0xCE99,0x42F7,0xAC,0xBD,0xE6,0x98,0xB2,0x33,0x2C,0x60};
const CLSID CLSID_CalculatorComponent = {0xE68F5EDD,0x6257,0x4E72,0xA1,0x0B,0x40,0x67,0xED,0x8E,0x85,0xF2};

// Prints an error string for the provided source code line and HRESULT
// value and returns the HRESULT value as an int.
int PrintError(unsigned int line, HRESULT hr)
{
    wprintf_s(L"ERROR: Line:%d HRESULT: 0x%X\n", line, hr);
    return hr;
}

int wmain()
{
    HRESULT hr;

    // RAII wrapper for managing the lifetime of the COM library.
    class CoInitializeWrapper
    {
        HRESULT _hr;
    public:
        CoInitializeWrapper(DWORD flags)
        {
            _hr = CoInitializeEx(nullptr, flags);
        }
        ~CoInitializeWrapper()
        {
            if (SUCCEEDED(_hr))
            {
                CoUninitialize();
            }
        }
        operator HRESULT()
        {
            return _hr;
        }

    };

    // Initialize the COM library.
    CoInitializeWrapper initialize(COINIT_APARTMENTTHREADED);
    if (FAILED(initialize))
    {
        return PrintError(__LINE__, initialize);
    }

    ComPtr<ICalculatorComponent> calc; // Interface to COM component.

    // Create the CalculatorComponent object.
    hr = CoCreateInstance(CLSID_CalculatorComponent, nullptr, CLSCTX_INPROC_SERVER, IID_PPV_ARGS(calc.GetAddressOf()));
    if (SUCCEEDED(hr))
    {
        // Test the component by adding two numbers.
        int result;
        hr = calc->Add(4, 5, &result);
        if (FAILED(hr))
        {
            return PrintError(__LINE__, hr);
        }
        wprintf_s(L"result = %d\n", result);
    }
    else
    {
        // Object creation failed. Print a message.
        return PrintError(__LINE__, hr);
    }

    return 0;
}
// </snippet7>
*/