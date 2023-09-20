---
description: "Learn more about: CLRCreateInstance for .NET Core Function"
title: "CLRCreateInstance for .NET Core Function"
ms.date: "03/25/2022"
api_name:
  - "CLRCreateInstance"
api_location:
  - "dbgshim.dll"
  - "libdbgshim.so"
  - "libdbgshim.dylib"
api_type:
  - "COM"
f1_keywords:
  - "CLRCreateInstance"
  - "CreateInterface"
helpviewer_keywords:
  - "CLRCreateInstance function [.NET Core Debugging]"
  - "CreateInterface function"
ms.assetid: 5de13327-96c6-4697-a89e-b8bf40717855
topic_type:
  - "apiref"
---
# CLRCreateInstance for .NET Core Function

Provides the [ICLRDebugging](../../../framework/unmanaged-api/debugging/iclrdebugging-interface.md) interface.

## Syntax

```cpp
HRESULT CLRCreateInstance (
    [in]  REFCLSID  clsid,
    [in]  REFIID     riid,
    [out] LPVOID  * ppInterface
);
```

## Parameters

 `clsid`
 [in] Supports only the CLSID_CLRDebugging class identifier.

 `riid`
 [in] Supports only the IID_ICLRDebugging interface identifiers.

 `ppInterface`
 [out] A [ICLRDebugging](../../../framework/unmanaged-api/debugging/iclrdebugging-interface.md) instance.

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
|CLSID_CLRDebugging|IID_ICLRDebugging|

 The following code shows how to use `CLRCreateInstance` to get to get the interface:

```cpp
#include <metahost.h>
#pragma comment(lib, "mscoree.lib")

ICLRDebugging      *pCLRDebugging   = NULL;
HRESULT hr;
hr = CLRCreateInstance (CLSID_CLRDebugging, IID_ICLRDebugging,
                    (LPVOID*)&pCLRDebugging);
```

## Requirements

 **Platforms:** See [.NET Core supported operating systems](../../../core/install/windows.md?pivots=os-windows).

 **Header:** dbgshim.h

 **Library:** dbgshim.dll, libdbgshim.so, libdbgshim.dylib

 **.NET Versions:** [!INCLUDE[net_core_21](../../../../includes/net-core-21-md.md)]
