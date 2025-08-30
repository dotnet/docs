---
description: "Learn more about: ICorDebugThread::CreateStepper Method"
title: "ICorDebugThread::CreateStepper Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugThread.CreateStepper"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugThread::CreateStepper"
helpviewer_keywords:
  - "ICorDebugThread::CreateStepper method [.NET debugging]"
  - "CreateStepper method, ICorDebugThread interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugThread::CreateStepper Method

Creates an ICorDebugStepper object that allows stepping through the active frame of this ICorDebugThread.

## Syntax

```cpp
HRESULT CreateStepper (
    [out] ICorDebugStepper **ppStepper
);
```

## Parameters

 `ppStepper`
 [out] A pointer to the address of an `ICorDebugStepper` object that allows stepping through the active frame of this thread.

## Remarks

The active frame may be unmanaged code.

The `ICorDebugStepper` interface must be used to perform the actual stepping.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
