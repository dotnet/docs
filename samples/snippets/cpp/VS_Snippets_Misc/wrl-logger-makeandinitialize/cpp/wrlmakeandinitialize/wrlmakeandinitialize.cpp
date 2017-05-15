// WRLMakeAndInitialize.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <wrl\implements.h>
#include <comutil.h>
#include <Shlwapi.h>

#include "ILogger_h.h"

using namespace Microsoft::WRL;

// <snippet1>
// Writes logging messages to the console.
class CConsoleWriter : public RuntimeClass<RuntimeClassFlags<ClassicCom>, ILogger>
{
public:
    // Initializes the CConsoleWriter object.
    // Failure here causes your object to fail construction with the HRESULT you choose.
    HRESULT RuntimeClassInitialize(_In_ PCWSTR category)
    {
        return SHStrDup(category, &m_category);
    }

    STDMETHODIMP Log(_In_ PCWSTR text)
    {
        wprintf_s(L"%s: %s\n", m_category, text);
        return S_OK;
    }

private:
    PWSTR m_category;

    // Make destroyable only through Release.
    ~CConsoleWriter()
    {
        CoTaskMemFree(m_category);
    }
};
// </snippet1>

// <snippet2>
int wmain()
{
    ComPtr<CConsoleWriter> writer;
    HRESULT hr = MakeAndInitialize<CConsoleWriter>(&writer, L"INFO");
    if (FAILED(hr))
    {
        wprintf_s(L"Object creation failed. Result = 0x%x", hr);
        return hr;
    }
    hr = writer->Log(L"Logger ready.");
    return hr;
}

/* Output:
INFO: Logger ready.
*/
// </snippet2>