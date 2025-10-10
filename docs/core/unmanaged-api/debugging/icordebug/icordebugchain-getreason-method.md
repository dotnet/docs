---
description: "Learn more about: ICorDebugChain::GetReason Method"
title: "ICorDebugChain::GetReason Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugChain.GetReason"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "GetReason"
helpviewer_keywords:
  - "GetReason method [.NET debugging]"
  - "ICorDebugChain::GetReason method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugChain::GetReason Method

Gets the reason for the genesis of this calling chain.

## Syntax

```cpp
HRESULT GetReason (
    [out] CorDebugChainReason *pReason
);
```

## Parameters

 `pReason`
 [out] A pointer to a value (a bitwise combination) of the CorDebugChainReason enumeration that indicates the reason for the genesis of this calling chain.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
