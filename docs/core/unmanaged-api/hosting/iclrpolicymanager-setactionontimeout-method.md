---
description: "Learn more about: ICLRPolicyManager::SetActionOnTimeout Method"
title: "ICLRPolicyManager::SetActionOnTimeout Method"
ms.date: "03/30/2017"
api_name:
  - "ICLRPolicyManager.SetActionOnTimeout"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLRPolicyManager::SetActionOnTimeout"
helpviewer_keywords:
  - "SetActionOnTimeout method [.NET Framework hosting]"
  - "ICLRPolicyManager::SetActionOnTimeout method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICLRPolicyManager::SetActionOnTimeout Method

Specifies the policy action the common language runtime (CLR) should take when the specified operation times out.

## Syntax

```cpp
HRESULT SetActionOnTimeout (
    [in] EClrOperation operation,
    [in] EPolicyAction action
);
```

## Parameters

 `operation`
 [in] One of the [EClrOperation](eclroperation-enumeration.md) values, indicating the operation for which to specify the timeout action. The following values are supported:

- OPR_AppDomainUnload

- OPR_ProcessExit

- OPR_ThreadRudeAbortInCriticalRegion

- OPR_ThreadRudeAbortInNonCriticalRegion

 `action`
 [in] One of the [EPolicyAction](epolicyaction-enumeration.md) values, indicating the policy action to be taken when the operation times out.

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|S_OK|`SetActionOnTimeout` returned successfully.|
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|
|HOST_E_TIMEOUT|The call timed out.|
|HOST_E_NOT_OWNER|The caller does not own the lock.|
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|
|E_FAIL|An unknown catastrophic failure occurred. After a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|
|E_INVALIDARG|A timeout cannot be set for the specified `operation`, or an invalid value was supplied for `operation`.|

## Remarks

 The timeout value can be either the default timeout set by the CLR, or a value specified by the host in a call to the [ICLRPolicyManager::SetTimeout](iclrpolicymanager-settimeout-method.md) method.

 Not all policy action values can be specified as the timeout behavior for CLR operations. `SetActionOnTimeout` is typically used only to escalate behavior. For example, a host can specify that thread aborts be turned into rude thread aborts, but cannot specify the opposite. The table below describes the valid `action` values for valid `operation` values.

|Value for `operation`|Valid values for `action`|
|---------------------------|-------------------------------|
|OPR_ThreadRudeAbortInNonCriticalRegion<br /><br /> OPR_ThreadRudeAbortInCriticalRegion|-   eRudeAbortThread<br />-   eUnloadAppDomain<br />-   eRudeUnloadAppDomain<br />-   eExitProcess<br />-   eFastExitProcess<br />-   eRudeExitProcess<br />-   eDisableRuntime|
|OPR_AppDomainUnload|-   eUnloadAppDomain<br />-   eRudeUnloadAppDomain<br />-   eExitProcess<br />-   eFastExitProcess<br />-   eRudeExitProcess<br />-   eDisableRuntime|
|OPR_ProcessExit|-   eExitProcess<br />-   eFastExitProcess<br />-   eRudeExitProcess<br />-   eDisableRuntime|

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [EClrOperation Enumeration](eclroperation-enumeration.md)
- [EPolicyAction Enumeration](epolicyaction-enumeration.md)
- [ICLRControl Interface](iclrcontrol-interface.md)
- [ICLRPolicyManager Interface](iclrpolicymanager-interface.md)
