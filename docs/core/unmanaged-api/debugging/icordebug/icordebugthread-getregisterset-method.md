---
description: "Learn more about: ICorDebugThread::GetRegisterSet Method"
title: "ICorDebugThread::GetRegisterSet Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugThread.GetRegisterSet"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugThread::GetRegisterSet"
helpviewer_keywords:
  - "ICorDebugThread::GetRegisterSet method [.NET debugging]"
  - "GetRegisterSet method, ICorDebugThread interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugThread::GetRegisterSet Method

Gets an interface pointer to the register set that is associated with the active part of this ICorDebugThread object.

## Syntax

```cpp
HRESULT GetRegisterSet (
    [out] ICorDebugRegisterSet **ppRegisters
);
```

## Parameters

 `ppRegisters`
 [out] A pointer to the address of an [ICorDebugRegisterSet](icordebugregisterset-interface.md) interface object that represents the register set for the active part of this thread.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
