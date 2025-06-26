---
description: "Learn more about: ICLRRuntimeInfo::IsLoaded Method"
title: "ICLRRuntimeInfo::IsLoaded Method"
ms.date: "03/30/2017"
api_name:
  - "ICLRRuntimeInfo.IsLoaded"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLRRuntimeInfo::IsLoaded"
helpviewer_keywords:
  - "IsLoaded method [.NET Framework hosting]"
  - "ICLRRuntimeInfo::IsLoaded method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICLRRuntimeInfo::IsLoaded Method

Indicates whether the common language runtime (CLR) associated with the [ICLRRuntimeInfo](iclrruntimeinfo-interface.md) interface is loaded into a process. A runtime can be loaded without also being started.

## Syntax

```cpp
HRESULT IsLoaded(
[in]  HANDLE hndProcess,
[out, retval] BOOL *pbLoaded);
```

## Parameters

 `hndProcess`
 [in] A handle to the process.

 `pbLoaded`
 [out] `true` if the CLR is loaded into the process; otherwise, `false`.

## Return Value

 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.

|HRESULT|Description|
|-------------|-----------------|
|S_OK|The method completed successfully.|
|E_POINTER|`pbLoaded` is null.|

## Remarks

 This method is backward-compatible with the following functions and interfaces:

- [ICorRuntimeHost](icorruntimehost-interface.md) interface (in the .NET Framework version 1 hosting API).

- [ICLRRuntimeHost](iclrruntimehost-interface.md) interface (in the .NET Framework 2.0 hosting API).

- Deprecated `CorBindTo*` functions (see [Deprecated CLR Hosting Functions](deprecated-clr-hosting-functions.md) in the .NET Framework 2.0 hosting API).

 A host may call one of the deprecated `CorBindTo*` functions, such as the [CorBindToRuntime](corbindtoruntime-function.md) function, to instantiate a specific version of the CLR. The host could then call the [ICLRMetaHost::GetRuntime](iclrmetahost-getruntime-method.md) method and specify the same version number to obtain a [ICLRRuntimeInfo](iclrruntimeinfo-interface.md) interface.

 If the host then calls the `IsLoaded` method on the returned [ICLRRuntimeInfo](iclrruntimeinfo-interface.md) interface, `pbLoaded` returns `true`; otherwise, it returns `false`.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MetaHost.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]

## See also

- [ICLRRuntimeInfo Interface](iclrruntimeinfo-interface.md)
- [Hosting Interfaces](hosting-interfaces.md)
- [Hosting](index.md)
