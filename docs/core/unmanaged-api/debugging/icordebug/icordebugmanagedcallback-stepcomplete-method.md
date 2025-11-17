---
description: "Learn more about: ICorDebugManagedCallback::StepComplete Method"
title: "ICorDebugManagedCallback::StepComplete Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugManagedCallback.StepComplete"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugManagedCallback::StepComplete"
helpviewer_keywords:
  - "StepComplete method [.NET debugging]"
  - "ICorDebugManagedCallback::StepComplete method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugManagedCallback::StepComplete Method

Notifies the debugger that a step has completed.

## Syntax

```cpp
HRESULT StepComplete (
    [in] ICorDebugAppDomain  *pAppDomain,
    [in] ICorDebugThread     *pThread,
    [in] ICorDebugStepper    *pStepper,
    [in] CorDebugStepReason   reason
);
```

## Parameters

 `pAppDomain`
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain containing the thread in which the step has completed.

 `pThread`
 [in] A pointer to an ICorDebugThread object that represents the thread in which the step has completed.

 `pStepper`
 [in] A pointer to an ICorDebugStepper object that represents the step in code execution.

 `reason`
 [in] A value of the CorDebugStepReason enumeration that indicates the outcome of an individual step.

## Remarks

The stepper may be used to continue stepping if desired, unless the debugging is terminated.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)
