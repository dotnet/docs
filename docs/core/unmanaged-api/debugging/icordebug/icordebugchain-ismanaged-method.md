---
description: "Learn more about: ICorDebugChain::IsManaged Method"
title: "ICorDebugChain::IsManaged Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugChain.IsManaged"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugChain::IsManaged"
helpviewer_keywords:
  - "ICorDebugChain::IsManaged method [.NET debugging]"
  - "IsManaged method, ICorDebugChain interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugChain::IsManaged Method

Gets a value that indicates whether this chain is running managed code.

## Syntax

```cpp
HRESULT IsManaged (
    [out] BOOL               *pManaged
);
```

## Parameters

 `pManaged`
 [out] `true` if this chain is running managed code; otherwise, `false`.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
