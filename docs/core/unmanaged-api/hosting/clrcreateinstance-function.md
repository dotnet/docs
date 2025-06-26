---
description: "Learn more about: CLRCreateInstance Function (.NET Framework)"
title: "CLRCreateInstance Function for .NET Framework"
ms.date: "03/30/2017"
api_name:
  - "CLRCreateInstance"
  - "CreateInterface"
api_location:
  - "mscoree.dll"
  - "mscoreei.dll"
api_type:
  - "COM"
f1_keywords:
  - "CLRCreateInstance"
  - "CreateInterface"
helpviewer_keywords:
  - "CLRCreateInstance function [.NET Framework hosting]"
  - "CreateInterface function"
topic_type:
  - "apiref"
---
# CLRCreateInstance Function (.NET Framework)

Provides one of three interfaces: [ICLRMetaHost](iclrmetahost-interface.md), [ICLRMetaHostPolicy](iclrmetahostpolicy-interface.md), or [ICLRDebugging](../../../framework/unmanaged-api/debugging/iclrdebugging-interface.md).

## Syntax

```cpp
HRESULT CLRCreateInstance(
    [in]  REFCLSID  clsid,
    [in]  REFIID     riid,
    [out] LPVOID  * ppInterface
);
```

## Parameters

 `clsid`\
 [in] One of three class identifiers: CLSID_CLRMetaHost, CLSID_CLRMetaHostPolicy, or CLSID_CLRDebugging.

 `riid`\
 [in] One of three interface identifiers (IIDs): IID_ICLRMetaHost, IID_ICLRMetaHostPolicy, or IID_ICLRDebugging.

 `ppInterface`\
 [out] One of three interfaces: [ICLRMetaHost](iclrmetahost-interface.md), [ICLRMetaHostPolicy](iclrmetahostpolicy-interface.md), or [ICLRDebugging](../../../framework/unmanaged-api/debugging/iclrdebugging-interface.md).

## Return Value

 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.

|HRESULT|Description|
|-------------|-----------------|
|S_OK|The method completed successfully.|
|E_POINTER|`ppInterface` is null.|

## Remarks

 The following table shows the supported combinations for `clsid` and `riid`.

|`clsid`|`riid`|
|--------------|------------|
|CLSID_CLRMetaHost|IID_ICLRMetaHost|
|CLSID_CLRMetaHostPolicy|IID_ICLRMetaHostPolicy|
|CLSID_CLRDebugging|IID_ICLRDebugging|

 The following code shows how to use `CLRCreateInstance` to get all three interfaces:

```cpp
#include <metahost.h>
#pragma comment(lib, "mscoree.lib")

ICLRMetaHost       *pMetaHost       = NULL;
ICLRMetaHostPolicy *pMetaHostPolicy = NULL;
ICLRDebugging      *pCLRDebugging   = NULL;
HRESULT hr;
hr = CLRCreateInstance(CLSID_CLRMetaHost, IID_ICLRMetaHost,
                    (LPVOID*)&pMetaHost);
hr = CLRCreateInstance (CLSID_CLRMetaHostPolicy, IID_ICLRMetaHostPolicy,
                    (LPVOID*)&pMetaHostPolicy);
hr = CLRCreateInstance (CLSID_CLRDebugging, IID_ICLRDebugging,
                    (LPVOID*)&pCLRDebugging);
```

The `CreateInterface` function is aliased to `CLRCreateInstance`.  Both `CLRCreateInstance` and `CreateInterface` functions can be used interchangeably. For example:

```cpp
HMODULE hModule = LoadLibrary(L"mscoree.dll");
CreateInterfaceFnPtr createInterface = (CreateInterfaceFnPtr)GetProcAddress(hModule, "CreateInterface");
HRESULT hr;
hr = createInterface(CLSID_CLRMetaHost, IID_ICLRMetaHost, (LPVOID*)&pMetaHost);
hr = createInterface (CLSID_CLRMetaHostPolicy, IID_ICLRMetaHostPolicy,  (LPVOID*)&pMetaHostPolicy);
hr = createInterface (CLSID_CLRDebugging, IID_ICLRDebugging,  (LPVOID*)&pCLRDebugging);
```

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MetaHost.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]

## See also

- [Hosting](index.md)
