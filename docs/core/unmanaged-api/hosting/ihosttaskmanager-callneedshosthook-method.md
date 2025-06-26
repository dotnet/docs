---
description: "Learn more about: IHostTaskManager::CallNeedsHostHook Method"
title: "IHostTaskManager::CallNeedsHostHook Method"
ms.date: "03/30/2017"
api_name:
  - "IHostTaskManager.CallNeedsHostHook"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IHostTaskManager::CallNeedsHostHook"
helpviewer_keywords:
  - "CallNeedsHostHook method [.NET Framework hosting]"
  - "IHostTaskManager::CallNeedsHostHook method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# IHostTaskManager::CallNeedsHostHook Method

Enables the host to specify whether the common language runtime (CLR) can inline the specified call to an unmanaged function.

## Syntax

```cpp
HRESULT CallNeedsHostHook (
    [in]  SIZE_T target,
    [out] BOOL   *pbCallNeedsHostHook
);
```

## Parameters

 `target`
 [in] The address within the mapped portable executable (PE) file of the unmanaged function that is to be called.

 `pbCallNeedsHostHook`
 [out] A pointer to a Boolean value that indicates whether the host requires the call to be hooked.

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|S_OK|`CallNeedsHostHook` returned successfully.|
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|
|HOST_E_TIMEOUT|The call timed out.|
|HOST_E_NOT_OWNER|The caller does not own the lock.|
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|
|E_FAIL|An unknown catastrophic failure has occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|

## Remarks

 To help optimize code execution, the CLR performs an analysis of each platform invoke call during compilation to determine whether the call can be inlined. `CallNeedsHostHook` enables the host to override that decision by requiring that a call to an unmanaged function be hooked. If the host requires a hook, the runtime does not inline the call.

 The host typically would require a hook where it must adjust a floating-point state, or upon receiving notification that a call is entering a state where the host cannot track the runtime's requests for memory or any locks taken. When the host requires that the call be hooked, the runtime notifies the host of transitions to and from managed code by using calls to [EnterRuntime](ihosttaskmanager-enterruntime-method.md), [LeaveRuntime](ihosttaskmanager-leaveruntime-method.md), [ReverseEnterRuntime](ihosttaskmanager-reverseenterruntime-method.md), and [ReverseLeaveRuntime](ihosttaskmanager-reverseleaveruntime-method.md).

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICLRTask Interface](iclrtask-interface.md)
- [ICLRTaskManager Interface](iclrtaskmanager-interface.md)
- [IHostTask Interface](ihosttask-interface.md)
- [IHostTaskManager Interface](ihosttaskmanager-interface.md)
