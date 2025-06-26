---
description: "Learn more about: IHostPolicyManager::OnDefaultAction Method"
title: "IHostPolicyManager::OnDefaultAction Method"
ms.date: "03/30/2017"
api_name:
  - "IHostPolicyManager.OnDefaultAction"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IHostPolicyManager::OnDefaultAction"
helpviewer_keywords:
  - "OnDefaultAction method [.NET Framework hosting]"
  - "IHostPolicyManager::OnDefaultAction method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# IHostPolicyManager::OnDefaultAction Method

Notifies the host that the common language runtime (CLR) is about to take the default action that was set by a call to the [ICLRPolicyManager::SetDefaultAction](iclrpolicymanager-setdefaultaction-method.md) method in response to a thread abort or <xref:System.AppDomain> unload.

## Syntax

```cpp
HRESULT OnDefaultAction (
    [in] EClrOperation  operation,
    [in] EPolicyAction  action
);
```

## Parameters

 `operation`
 [in] One of the [EClrOperation](eclroperation-enumeration.md) values, indicating the kind of event to which the CLR is responding.

 `action`
 [in] One of the [EPolicyAction](epolicyaction-enumeration.md) values, indicating the action that the CLR is taking in response to the event.

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|S_OK|`OnDefaultAction` returned successfully.|
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call. successfully|
|HOST_E_TIMEOUT|The call timed out.|
|HOST_E_NOT_OWNER|The caller does not own the lock.|
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [EClrOperation Enumeration](eclroperation-enumeration.md)
- [EPolicyAction Enumeration](epolicyaction-enumeration.md)
- [ICLRPolicyManager Interface](iclrpolicymanager-interface.md)
- [IHostPolicyManager Interface](ihostpolicymanager-interface.md)
