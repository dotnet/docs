---
description: "Learn more about: ICorDebugChain::GetPrevious Method"
title: "ICorDebugChain::GetPrevious Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugChain.GetPrevious"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugChain::GetPrevious"
helpviewer_keywords:
  - "ICorDebugChain::GetPrevious method [.NET debugging]"
  - "GetPrevious method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugChain::GetPrevious Method

Gets the previous chain of frames for the thread.

## Syntax

```cpp
HRESULT GetPrevious (
    [out] ICorDebugChain     **ppChain
);
```

## Parameters

 `ppChain`
 [out] A pointer to the address of an ICorDebugChain object that represents the previous chain of frames for this thread. If this chain is the first chain, `ppChain` is null.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
