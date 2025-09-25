---
description: "Learn more about: ICorDebugStepper::SetRangeIL Method"
title: "ICorDebugStepper::SetRangeIL Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugStepper.SetRangeIL"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugStepper::SetRangeIL"
helpviewer_keywords:
  - "SetRangeIL method [.NET debugging]"
  - "ICorDebugStepper::SetRangeIL method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugStepper::SetRangeIL Method

Sets a value that specifies whether calls to [ICorDebugStepper::StepRange](icordebugstepper-steprange-method.md) pass argument values that are relative to the native code or relative to common intermediate language (CIL) code of the method that is being stepped through.

## Syntax

```cpp
HRESULT SetRangeIL (
    [in] BOOL    bIL
);
```

## Parameters

 `bIL`
 [in] Set to `true` to specify that the ranges are relative to the CIL code. Set to `false` to specify that the ranges are relative to the native code. The default value is `true`.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
