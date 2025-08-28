---
description: "Learn more about: ICorDebugProcess::IsTransitionStub Method"
title: "ICorDebugProcess::IsTransitionStub Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugProcess.IsTransitionStub"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugProcess::IsTransitionStub"
helpviewer_keywords:
  - "ICorDebugProcess::IsTransitionStub method [.NET debugging]"
  - "IsTransitionStub method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugProcess::IsTransitionStub Method

Gets a value that indicates whether an address is inside a stub that will cause a transition to managed code.

## Syntax

```cpp
HRESULT IsTransitionStub(
    [in]  CORDB_ADDRESS address,
    [out] BOOL *pbTransitionStub);
```

## Parameters

 `address`
 [in] A `CORDB_ADDRESS` value that specifies the address in question.

 `pbTransitionStub`
 [out] A pointer to a Boolean value that is `true` if the specified address is inside a stub that will cause a transition to managed code; otherwise *`pbTransitionStub` is `false`.

## Remarks

 The `IsTransitionStub` method can be used by unmanaged stepping code to decide when to return stepping control to the managed stepper.

 You can also identity transition stubs by looking at information in the portable executable (PE) file.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0
