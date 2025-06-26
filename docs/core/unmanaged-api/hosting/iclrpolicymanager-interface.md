---
description: "Learn more about: ICLRPolicyManager Interface"
title: "ICLRPolicyManager Interface"
ms.date: "03/30/2017"
api_name:
  - "ICLRPolicyManager"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLRPolicyManager"
helpviewer_keywords:
  - "ICLRPolicyManager interface [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICLRPolicyManager Interface

Provides methods that allow the host to specify policy actions to be taken in the event of failures and timeouts.

## Methods

|Method|Description|
|------------|-----------------|
|[SetActionOnFailure Method](iclrpolicymanager-setactiononfailure-method.md)|Specifies the policy action the common language runtime (CLR) should take when the specified failure occurs.|
|[SetActionOnTimeout Method](iclrpolicymanager-setactionontimeout-method.md)|Specifies the policy action the CLR should take when the specified operation times out.|
|[SetDefaultAction Method](iclrpolicymanager-setdefaultaction-method.md)|Specifies the policy action the CLR should take when the specified operation occurs.|
|[SetTimeout Method](iclrpolicymanager-settimeout-method.md)|Sets a timeout value for the specified operation.|
|[SetTimeoutAndAction Method](iclrpolicymanager-settimeoutandaction-method.md)|Sets a timeout value for the specified operation, and specifies the policy action the CLR should take when the operation occurs.|
|[SetUnhandledExceptionPolicy Method](iclrpolicymanager-setunhandledexceptionpolicy-method.md)|Specifies the behavior of the CLR when an unhandled exception occurs.|

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [EClrFailure Enumeration](eclrfailure-enumeration.md)
- [EClrOperation Enumeration](eclroperation-enumeration.md)
- [EPolicyAction Enumeration](epolicyaction-enumeration.md)
- [ICLRControl Interface](iclrcontrol-interface.md)
