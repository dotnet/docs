---
description: "Learn more about: ICorDebugChain::GetCallee Method"
title: "ICorDebugChain::GetCallee Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugChain.GetCallee"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugChain::GetCallee method"
helpviewer_keywords:
  - "ICorDebugChain::GetCallee method [.NET debugging]"
  - "GetCallee method, ICorDebugChain interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugChain::GetCallee Method

Gets the chain that was called by this chain.

## Syntax

```cpp
HRESULT GetCallee (
    [out] ICorDebugChain     **ppChain
);
```

## Parameters

 `ppChain`
 [out] A pointer to the address of an ICorDebugChain object that represents the called chain. If this chain is currently executing (that is, if this chain is not waiting for a called chain to return), `ppChain` will be null.

## Remarks

 This chain will wait for the called chain to return before it resumes execution. The called chain may be on another thread in the case of cross-thread marshalled calls.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
