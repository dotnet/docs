---
description: "Learn more about: IHostPolicyManager Interface"
title: "IHostPolicyManager Interface"
ms.date: "03/30/2017"
api_name:
  - "IHostPolicyManager"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IHostPolicyManager"
helpviewer_keywords:
  - "IHostPolicyManager interface [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# IHostPolicyManager Interface

Provides methods that notify the host of the actions the common language runtime (CLR) performs in case of aborts, timeouts, or failures.

## Methods

|Method|Description|
|------------|-----------------|
|[OnDefaultAction Method](ihostpolicymanager-ondefaultaction-method.md)|Notifies the host that the CLR is about to take the default action specified by a call to [ICLRPolicyManager::SetDefaultAction](iclrpolicymanager-setdefaultaction-method.md) in response to a thread abort or <xref:System.AppDomain> unload.|
|[OnFailure Method](ihostpolicymanager-onfailure-method.md)|Notifies the host that the CLR is about to take the action specified by a call to [ICLRPolicyManager::SetActionOnFailure](iclrpolicymanager-setactiononfailure-method.md) in response to a resource allocation or reclamation failure.|
|[OnTimeout Method](ihostpolicymanager-ontimeout-method.md)|Notifies the host that the CLR is about to take the action specified by a call to [ICLRPolicyManager::SetActionOnTimeout](iclrpolicymanager-setactionontimeout-method.md) in response to a timeout.|

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [EClrFailure Enumeration](eclrfailure-enumeration.md)
- [EClrOperation Enumeration](eclroperation-enumeration.md)
- [EPolicyAction Enumeration](epolicyaction-enumeration.md)
- [ICLRPolicyManager Interface](iclrpolicymanager-interface.md)
- [Hosting Interfaces](hosting-interfaces.md)
