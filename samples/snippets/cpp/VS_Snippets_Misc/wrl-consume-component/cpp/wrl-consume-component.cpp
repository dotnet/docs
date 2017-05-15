// <snippet1>
// wrl-consume-component.cpp
// compile with: runtimeobject.lib
// <snippet2>
#include <Windows.Foundation.h>
#include <wrl\wrappers\corewrappers.h>
#include <wrl\client.h>
#include <stdio.h>

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
    // <snippet3>
    // Initialize the Windows Runtime.
    RoInitializeWrapper initialize(RO_INIT_MULTITHREADED);
    if (FAILED(initialize))
    {
        return PrintError(__LINE__, initialize);
    }
    // </snippet3>

    // <snippet4>
    // Get the activation factory for the IUriRuntimeClass interface.
    ComPtr<IUriRuntimeClassFactory> uriFactory;
    HRESULT hr = GetActivationFactory(HStringReference(RuntimeClass_Windows_Foundation_Uri).Get(), &uriFactory);
    if (FAILED(hr))
    {
        return PrintError(__LINE__, hr);
    }
    // </snippet4>

    // <snippet6>
    // Create a string that represents a URI.
    HString uriHString;
    hr = uriHString.Set(L"http://www.microsoft.com");
    if (FAILED(hr))
    {
        return PrintError(__LINE__, hr);
    }
    // </snippet6>

    // <snippet7>
    // Create the IUriRuntimeClass object.
    ComPtr<IUriRuntimeClass> uri;
    hr = uriFactory->CreateUri(uriHString.Get(), &uri);
    if (FAILED(hr))
    {
        return PrintError(__LINE__, hr);
    }
    // </snippet7>

    // <snippet8>
    // Get the domain part of the URI.
    HString domainName;
    hr = uri->get_Domain(domainName.GetAddressOf());
    if (FAILED(hr))
    {
        return PrintError(__LINE__, hr);
    }
    // </snippet8>

    // <snippet9>
    // Print the domain name and return.
    wprintf_s(L"Domain name: %s\n", domainName.GetRawBuffer(nullptr));

    // All smart pointers and RAII objects go out of scope here.
    // </snippet9>
}
/*
Output:
Domain name: microsoft.com
*/
// </snippet1>