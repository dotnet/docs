---
description: "Learn more about: IDENTITY_ATTRIBUTE_BLOB Structure"
title: "IDENTITY_ATTRIBUTE_BLOB Structure"
ms.date: "03/30/2017"
dev_langs: 
  - "cpp"
api_name: 
  - "IDENTITY_ATTRIBUTE_BLOB"
api_location: 
  - "fusion.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IDENTITY_ATTRIBUTE_BLOB"
helpviewer_keywords: 
  - "IDENTITY_ATTRIBUTE_BLOB structure [.NET Framework fusion]"
ms.assetid: af14ae5f-d226-47dd-ba90-8fc6e6605d4d
topic_type: 
  - "apiref"
---
# IDENTITY_ATTRIBUTE_BLOB Structure

Contains information about a single attribute in an assembly, and consists of three `DWORD`s. Each `DWORD` is an offset into a character buffer produced by the `CurrentIntoBuffer` method of the [IEnumIDENTITY_ATTRIBUTE](ienumidentity-attribute-interface.md) interface  
  
## Syntax  
  
```cpp  
typedef struct _IDENTITY_ATTRIBUTE_BLOB {  
    DWORD  ofsNamespace;  
    DWORD  ofsName;  
    DWORD  ofsValue;  
}   IDENTITY_ATTRIBUTE_BLOB;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`ofsNamespace`|The first offset into the character buffer. This offset is not followed by the attribute's namespace, but by a series of null characters. Therefore, it is not used.|  
|`ofsName`|The second offset into the character buffer. This location marks the start of the attribute's name.|  
|`ofsValue`|The third offset into the character buffer. This location marks the start of the attribute's value.|  
  
## Sample  

 The following example illustrates several basic steps, which eventually result in a populated `IDENTITY_ATTRIBUTE_BLOB` structure:  
  
1. Obtain an [IReferenceIdentity](ireferenceidentity-interface.md) for the assembly.  
  
2. Call the `IReferenceIdentity::EnumAttributes` method, and obtain an [IEnumIDENTITY_ATTRIBUTE](ienumidentity-attribute-interface.md).  
  
3. Create a character buffer, and cast it as an `IDENTITY_ATTRIBUTE_BLOB` structure.  
  
4. Call the `CurrentIntoBuffer` method of the `IEnumIDENTITY_ATTRIBUTE` interface. This method copies the attributes `Namespace`, `Name`, and `Value` into the character buffer. The three offsets to those strings will become available in the `IDENTITY_ATTRIBUTE_BLOB` structure.  
  
```cpp  
// EnumAssemblyAttributes.cpp : main project file.  
  
#include "stdafx.h"  
  
#include "fusion.h"  
#include "windows.h"  
#include "stdio.h"  
#include "mscoree.h"  
#include "isolation.h"  
  
typedef HRESULT (__stdcall *PFNGETREF)(LPCWSTR pwzFile, REFIID riid, IUnknown **ppUnk);  
typedef HRESULT (__stdcall *PFNGETAUTH)(IIdentityAuthority **ppIIdentityAuthority);  
  
PFNGETREF                   g_pfnGetAssemblyIdentityFromFile = NULL;  
PFNGETAUTH                  g_pfnGetIdentityAuthority = NULL;  
IUnknown                    *g_pUnk = NULL;  
  
bool Init()  
{  
    HRESULT     hr = S_OK;  
    DWORD       dwSize = 0;  
    bool        bRC = false;  
  
    hr = CorBindToRuntimeEx(NULL, L"wks", 0, CLSID_CorRuntimeHost,  
                           IID_ICorRuntimeHost, (void **)&g_pUnk);  
    if(FAILED(hr)) {  
        printf("Error: Failed to initialize CLR runtime! hr = 0x%0x\n",  
                hr);  
        goto Exit;  
    }  
  
    if (SUCCEEDED(hr)) {  
        hr = GetRealProcAddress("GetAssemblyIdentityFromFile",  
                         (VOID **)&g_pfnGetAssemblyIdentityFromFile);  
    }  
  
    if (SUCCEEDED(hr)) {  
        hr = GetRealProcAddress("GetIdentityAuthority",  
                                (VOID **)&g_pfnGetIdentityAuthority);  
    }  
  
    if (!g_pfnGetAssemblyIdentityFromFile ||
        !g_pfnGetIdentityAuthority)  
    {  
        printf("Error: Cannot get required APIs from fusion.dll!\n");  
        goto Exit;  
    }  
  
    bRC = true;  
  
Exit:  
    return bRC;  
}  
  
void Shutdown()  
{  
    if(g_pUnk) {  
        g_pUnk->Release();  
        g_pUnk = NULL;  
    }  
}  
  
void Usage()  
{  
    printf("EnumAssemblyAttributes: A tool to enumerate the identity
            attributes of a given assembly.\n\n");  
    printf("Usage: EnumAssemblyAttributes AssemblyFilePath\n");  
    printf("\n");  
}  
  
int _cdecl wmain(int argc, LPCWSTR argv[])  
{  
    int     iResult = 1;  
    IUnknown                    *pUnk  = NULL;  
    IReferenceIdentity          *pRef  = NULL;  
    HRESULT                     hr     = S_OK;
    IEnumIDENTITY_ATTRIBUTE     *pEnum = NULL;  
    BYTE                        abData[1024];  
    DWORD                       cbAvailable;  
    DWORD                       cbUsed;  
    IDENTITY_ATTRIBUTE_BLOB     *pBlob;  
  
    if(argc != 2) {  
        Usage();  
        goto Exit;  
    }  
  
    if(!Init()) {  
        printf("Failure initializing EnumIdAttr.\n");  
        goto Exit;  
    }  
  
    hr = g_pfnGetAssemblyIdentityFromFile(argv[1],
                            __uuidof(IReferenceIdentity), &pUnk);  
  
    if (FAILED(hr)) {  
        printf("GetAssemblyIdentityFromFile failed with hr = 0x%x",
                hr);  
        goto Exit;  
    }  
  
    hr = pUnk->QueryInterface(__uuidof(IReferenceIdentity),
                              (void**)&pRef);  
    if (FAILED(hr)) {  
        goto Exit;  
    }  
  
    hr = pRef->EnumAttributes(&pEnum);  
    if (FAILED(hr)) {  
        printf("IReferenceIdentity::EnumAttributes failed with hr =
                0x%x", hr);  
        goto Exit;  
    }  
  
    pBlob = (IDENTITY_ATTRIBUTE_BLOB *)(abData);  
    while (1) {  
        cbAvailable = sizeof(abData);  
        hr = pEnum->CurrentIntoBuffer(cbAvailable, abData, &cbUsed);  
        if (FAILED(hr)) {  
            printf("IEnumIDENTITY_ATTRIBUTE::CurrentIntoBuffer failed
                    with hr = 0x%x", hr);  
            goto Exit;  
        }  
  
        if (! cbUsed) {  
            break;  
        }  
  
        LPWSTR pwzNameSpace = (LPWSTR)(abData + pBlob->ofsNamespace);  
        LPWSTR pwzName      = (LPWSTR)(abData + pBlob->ofsName);  
        LPWSTR pwzValue     = (LPWSTR)(abData + pBlob->ofsValue);  
        printf("%ws: %ws = %ws\n", pwzNameSpace, pwzName, pwzValue);  
  
        hr = pEnum->Skip(1);  
        if (FAILED(hr)) {  
            printf("IEnumIDENTITY_ATTRIBUTE::Skip failed with hr =
                    0x%x", hr);  
            goto Exit;  
        }  
    }  
  
    iResult = 0;  
  
Exit:  
  
    Shutdown();  
  
    if (pUnk) {  
        pUnk->Release();  
    }  
  
    if (pRef) {  
        pRef->Release();  
    }  
  
    if (pEnum) {  
        pEnum->Release();  
    }  
  
    return iResult;  
}  
```  
  
### To run the sample  

 C:\\> EnumAssemblyAttributes.exe C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\System.dll  
  
### Sample output  

 Culture = neutral  
  
 name = System  
  
 processorArchitecture = MSIL  
  
 PublicKeyToken = b77a5c561934e089  
  
 Version = 2.0.0.0  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Isolation.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IReferenceIdentity Interface](ireferenceidentity-interface.md)
- [IEnumIDENTITY_ATTRIBUTE Interface](ienumidentity-attribute-interface.md)
- [IDENTITY_ATTRIBUTE Structure](identity-attribute-structure.md)
- [Fusion Structures](fusion-structures.md)
