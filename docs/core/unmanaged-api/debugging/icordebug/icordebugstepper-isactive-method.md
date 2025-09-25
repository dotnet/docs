---
description: "Learn more about: ICorDebugStepper::IsActive Method"
title: "ICorDebugStepper::IsActive Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugStepper.IsActive"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugStepper::IsActive"
helpviewer_keywords:
  - "IsActive method, ICorDebugStepper interface [.NET debugging]"
  - "ICorDebugStepper::IsActive method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugStepper::IsActive Method

Gets a value that indicates whether this ICorDebugStepper is currently executing a step.

## Syntax

```cpp
HRESULT IsActive (
    [out] BOOL   *pbActive
);
```

## Parameters

 `pbActive`
 [out] Returns `true` if the stepper is currently executing a step; otherwise, returns `false`.

## Remarks

Any step action remains active until the debugger receives a [ICorDebugManagedCallback::StepComplete](icordebugmanagedcallback-stepcomplete-method.md) call, which automatically deactivates the stepper. A stepper may also be deactivated prematurely by calling [ICorDebugStepper::Deactivate](icordebugstepper-deactivate-method.md) before the callback condition is reached.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
