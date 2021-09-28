// module.cpp : Defines the module that contains the com classes
//
#include "pch.h"

#include <wrl\module.h>

extern "C" BOOL WINAPI DllMain(_In_opt_ HINSTANCE, DWORD, _In_opt_ LPVOID);
extern "C" HRESULT WINAPI DllCanUnloadNow();

#if !defined(__WRL_CLASSIC_COM__)
extern "C" HRESULT WINAPI DllGetActivationFactory(_In_ HSTRING, _Deref_out_ IActivationFactory**);

extern "C" HRESULT WINAPI DllGetActivationFactory(_In_ HSTRING activatibleClassId, _Deref_out_ IActivationFactory** factory)
{
    auto &module = Microsoft::WRL::Module<Microsoft::WRL::InProc>::GetModule();
    return module.GetActivationFactory(activatibleClassId, factory);
}
#endif

#if !defined(__WRL_WINRT_STRICT__)
extern "C" HRESULT WINAPI DllGetClassObject(REFCLSID, REFIID, _Deref_out_ LPVOID*);

extern "C" HRESULT WINAPI DllGetClassObject(REFCLSID rclsid, REFIID riid, _Deref_out_ LPVOID *ppv)
{
    auto &module = Microsoft::WRL::Module<Microsoft::WRL::InProc>::GetModule();
    return module.GetClassObject(rclsid, riid, ppv);
}
#endif

extern "C" BOOL WINAPI DllMain(_In_opt_ HINSTANCE, DWORD, _In_opt_ LPVOID)
{
    return TRUE;
}

extern "C" HRESULT WINAPI DllCanUnloadNow()
{
    const auto &module = Microsoft::WRL::Module<Microsoft::WRL::InProc>::GetModule();    
    return module.GetObjectCount() == 0 ? S_OK : S_FALSE;
}

#if defined(_M_IX86)
#if !defined(__WRL_CLASSIC_COM__)
#pragma comment(linker, "/EXPORT:DllGetActivationFactory=_DllGetActivationFactory@8,PRIVATE")
#endif
#if !defined(__WRL_WINRT_STRICT__)
#pragma comment(linker, "/EXPORT:DllGetClassObject=_DllGetClassObject@12,PRIVATE")
#endif
#pragma comment(linker, "/EXPORT:DllCanUnloadNow=_DllCanUnloadNow@0,PRIVATE")
#elif defined(_M_ARM) || defined(_M_AMD64)
#if !defined(__WRL_CLASSIC_COM__)
#pragma comment(linker, "/EXPORT:DllGetActivationFactory,PRIVATE")
#endif
#if !defined(__WRL_WINRT_STRICT__)
#pragma comment(linker, "/EXPORT:DllGetClassObject,PRIVATE")
#endif
#pragma comment(linker, "/EXPORT:DllCanUnloadNow,PRIVATE")
#endif