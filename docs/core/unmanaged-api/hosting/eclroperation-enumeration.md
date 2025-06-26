---
description: "Learn more about: EClrOperation Enumeration"
title: "EClrOperation Enumeration"
ms.date: "03/30/2017"
api_name:
  - "EClrOperation"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "EClrOperation"
helpviewer_keywords:
  - "EClrOperation enumeration [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# EClrOperation Enumeration

Describes the set of operations for which a host can apply policy actions.

## Syntax

```cpp
typedef enum {
    OPR_ThreadAbort,
    OPR_ThreadRudeAbortInNonCriticalRegion,
    OPR_ThreadRudeAbortInCriticalRegion,
    OPR_AppDomainUnload,
    OPR_AppDomainRudeUnload,
    OPR_ProcessExit,
    OPR_FinalizerRun
} EClrOperation;
```

## Members

|Member|Description|
|------------|-----------------|
|`OPR_AppDomainRudeUnload`|The host can specify policy actions to be taken when an <xref:System.AppDomain> is unloaded in a non-graceful (rude) manner.|
|`OPR_AppDomainUnload`|The host can specify policy actions to be taken when an <xref:System.AppDomain> is unloaded.|
|`OPR_FinalizerRun`|The host can specify policy actions to be taken when finalizers run.|
|`OPR_ProcessExit`|The host can specify policy actions to be taken when the process exits.|
|`OPR_ThreadAbort`|The host can specify policy actions to be taken when a thread is aborted.|
|`OPR_ThreadRudeAbortInCriticalRegion`|The host can specify policy actions to be taken when a rude thread abort occurs in a critical region of code.|
|`OPR_ThreadRudeAbortInNonCriticalRegion`|The host can specify policy actions to be take when a rude thread abort occurs in a non-critical region of code.|

## Remarks

 The common language runtime (CLR) reliability infrastructure distinguishes between aborts and resource allocation failures that occur in critical regions of code and those that occur in non-critical regions of code. This distinction is designed to allow hosts to set different policies depending on where a failure occurs in the code.

 A *critical region of code* is any space where the CLR cannot guarantee that aborting a task or failing to complete a request for resources will affect only the current task. For example, if a task is holding a lock and receives an HRESULT that indicates failure upon making a memory allocation request, it is insufficient simply to abort that task to ensure the stability of the <xref:System.AppDomain>, because the <xref:System.AppDomain> might contain other tasks waiting for the same lock. To abandon the current task might cause those other tasks to stop responding. In such a case, the host needs the ability to unload the entire <xref:System.AppDomain> rather than risk potential instability.

 A *non-critical region of code*, on the other hand, is a region where the CLR can guarantee that an abort or a failure will affect only the task upon which the error occurs.

 The CLR also distinguishes between graceful and non-graceful (rude) aborts. In general, a normal or graceful abort makes every effort to run exception-handling routines and finalizers before aborting a task, while a rude abort makes no such guarantees.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [EClrFailure Enumeration](eclrfailure-enumeration.md)
- [EPolicyAction Enumeration](epolicyaction-enumeration.md)
- [ICLRPolicyManager Interface](iclrpolicymanager-interface.md)
- [IHostPolicyManager Interface](ihostpolicymanager-interface.md)
- [Hosting Enumerations](hosting-enumerations.md)
