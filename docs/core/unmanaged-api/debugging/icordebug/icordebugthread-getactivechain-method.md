---
description: "Learn more about: ICorDebugThread::GetActiveChain Method"
title: "ICorDebugThread::GetActiveChain Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugThread.GetActiveChain"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugThread::GetActiveChain"
helpviewer_keywords:
  - "ICorDebugThread::GetActiveChain method [.NET debugging]"
  - "GetActiveChain method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugThread::GetActiveChain Method

Gets an interface pointer to the active (most recent) stack chain on this ICorDebugThread object.

## Syntax

```cpp
HRESULT GetActiveChain (
    [out] ICorDebugChain **ppChain
);
```

## Parameters

 `ppChain`
 [out] A pointer to the address of an ICorDebugChain object that represents the stack chain.

## Remarks

The `ppChain` parameter is null if no stack chain is currently active.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
