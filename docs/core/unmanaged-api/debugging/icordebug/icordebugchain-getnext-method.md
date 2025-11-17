---
description: "Learn more about: ICorDebugChain::GetNext Method"
title: "ICorDebugChain::GetNext Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugChain.GetNext"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugChain::GetNext"
helpviewer_keywords:
  - "GetNext method [.NET debugging]"
  - "ICorDebugChain::GetNext method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugChain::GetNext Method

Gets the next chain of frames for the thread.

## Syntax

```cpp
HRESULT GetNext (
    [out] ICorDebugChain     **ppChain
);
```

## Parameters

 `ppChain`
 [out] A pointer to the address of an ICorDebugChain object that represents the next chain of frames for the thread. If this chain is the last chain, `ppChain` is null.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
