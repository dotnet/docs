---
description: "Learn more about: ICLRDebugManager::IsDebuggerAttached Method"
title: "ICLRDebugManager::IsDebuggerAttached Method"
ms.date: "03/30/2017"
api_name:
  - "ICLRDebugManager.IsDebuggerAttached"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLRDebugManager::IsDebuggerAttached"
helpviewer_keywords:
  - "IsDebuggerAttached method, ICLRDebugManager interface [.NET Framework hosting]"
  - "ICLRDebugManager::IsDebuggerAttached method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICLRDebugManager::IsDebuggerAttached Method

Gets a value that indicates whether a debugger is attached to the process.

## Syntax

```cpp
HRESULT IsDebuggerAttached (
    [out] BOOL *pbAttached
);
```

## Parameters

 `pbAttached`
 [out] `true` if a debugger is attached to the process; otherwise, `false`.

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|S_OK|`IsDebuggerAttached` returned successfully.|
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|
|HOST_E_TIMEOUT|The call timed out.|
|HOST_E_NOT_OWNER|The caller does not own the lock.|
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|
|E_FAIL|An unknown catastrophic failure occurred. After a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|

## Remarks

 `IsDebuggerAttached` allows the host to query the CLR to determine whether a debugger is attached to the process.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICLRControl Interface](iclrcontrol-interface.md)
- [ICLRDebugManager Interface](iclrdebugmanager-interface.md)
- [IHostControl Interface](ihostcontrol-interface.md)
