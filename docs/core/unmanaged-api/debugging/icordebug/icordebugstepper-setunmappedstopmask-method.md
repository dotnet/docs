---
description: "Learn more about: ICorDebugStepper::SetUnmappedStopMask Method"
title: "ICorDebugStepper::SetUnmappedStopMask Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugStepper.SetUnmappedStopMask"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugStepper::SetUnmappedStopMask"
helpviewer_keywords:
  - "ICorDebugStepper::SetUnmappedStopMask method [.NET debugging]"
  - "SetUnmappedStopMask method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugStepper::SetUnmappedStopMask Method

Sets a value that specifies the type of unmapped code in which execution will halt.

## Syntax

```cpp
HRESULT SetUnmappedStopMask (
    [in] CorDebugUnmappedStop   mask
);
```

## Parameters

 `mask`
 [in] A value of the CorDebugUnmappedStop enumeration that specifies the type of unmapped code in which the debugger will halt execution.

The default value is STOP_OTHER_UNMAPPED. The value STOP_UNMANAGED is only valid with interop debugging.

## Remarks

When the debugger finds a just-in-time (JIT) compilation that has no corresponding mapping to common intermediate language (CIL), it halts execution if the flag specifying that type of unmapped code has been set; otherwise, stepping transparently continues.

If the debugger doesn't use a stepper to enter a method, then it won't necessarily step over unmapped code.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
