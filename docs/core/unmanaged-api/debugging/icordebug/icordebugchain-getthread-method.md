---
description: "Learn more about: ICorDebugChain::GetThread Method"
title: "ICorDebugChain::GetThread Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugChain.GetThread"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugChain::GetThread"
helpviewer_keywords:
  - "GetThread method, ICorDebugChain interface [.NET debugging]"
  - "ICorDebugChain::GetThread method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugChain::GetThread Method

Gets the physical thread this call chain is part of.

## Syntax

```cpp
HRESULT GetThread (
    [out] ICorDebugThread    **ppThread
);
```

## Parameters

 `ppThread`
 [out] A pointer to an ICorDebugThread object that represents the physical thread this call chain is part of.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
