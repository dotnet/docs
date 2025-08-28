---
description: "Learn more about: ICorDebugFrame::CreateStepper Method"
title: "ICorDebugFrame::CreateStepper Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugFrame.CreateStepper"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugFrame::CreateStepper"
helpviewer_keywords:
  - "ICorDebugFrame::CreateStepper method [.NET debugging]"
  - "CreateStepper method, ICorDebugFrame interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugFrame::CreateStepper Method

Gets a stepper that allows the debugger to perform stepping operations relative to this ICorDebugFrame.

## Syntax

```cpp
HRESULT CreateStepper (
    [out] ICorDebugStepper   **ppStepper
);
```

## Parameters

 `ppStepper`
 [out] A pointer to the address of an ICorDebugStepper object that allows the debugger to perform stepping operations relative to the current frame.

## Remarks

 If the frame is not active, the stepper object will typically have to return to the frame before the step is completed.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
