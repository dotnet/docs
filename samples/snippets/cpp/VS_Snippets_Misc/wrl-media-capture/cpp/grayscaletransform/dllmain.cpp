// <snippet6>
#include "pch.h"
#include <initguid.h>
#include <wrl\module.h>

using namespace Microsoft::WRL;

STDAPI_(BOOL) DllMain(_In_ HINSTANCE hInstance, _In_ DWORD reason, _In_opt_ void *reserved)
{
    if (DLL_PROCESS_ATTACH == reason)
    {
        DisableThreadLibraryCalls(hInstance);
    }
    return TRUE;
}

STDAPI DllGetActivationFactory(_In_ HSTRING activatibleClassId, _COM_Outptr_ IActivationFactory **factory)
{
    return Module<InProc>::GetModule().GetActivationFactory(activatibleClassId, factory);
}

STDAPI DllCanUnloadNow()
{
    return Module<InProc>::GetModule().Terminate() ? S_OK : S_FALSE;
}

STDAPI DllGetClassObject(_In_ REFCLSID rclsid, _In_ REFIID riid, _COM_Outptr_ void **ppv)
{
    return Module<InProc>::GetModule().GetClassObject(rclsid, riid, ppv);
}
// </snippet6>