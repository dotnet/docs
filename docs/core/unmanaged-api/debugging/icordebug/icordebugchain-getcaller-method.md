---
description: "Learn more about: ICorDebugChain::GetCaller Method"
title: "ICorDebugChain::GetCaller Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugChain.GetCaller"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugChain::GetCaller"
helpviewer_keywords:
  - "ICorDebugChain::GetCaller method [.NET debugging]"
  - "GetCaller method, ICorDebugChain interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugChain::GetCaller Method

Gets the chain that called this chain.

## Syntax

```cpp
HRESULT GetCaller (
    [out] ICorDebugChain      **ppChain
);
```

## Parameters

 `ppChain`
 [out] A pointer to the address of an ICorDebugChain object that represents the calling chain.

If this chain was spontaneously called (as would be the case if this chain or the debugger initialized the call stack), `ppChain` will be null.

## Remarks

The calling chain may be on a different thread, if the call was marshalled across threads.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
