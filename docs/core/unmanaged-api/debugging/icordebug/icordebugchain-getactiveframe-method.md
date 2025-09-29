---
description: "Learn more about: ICorDebugChain::GetActiveFrame Method"
title: "ICorDebugChain::GetActiveFrame Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugChain.GetActiveFrame"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugChain::GetActiveFrame"
helpviewer_keywords:
  - "ICorDebugChain::GetActiveFrame method [.NET debugging]"
  - "GetActiveFrame method, ICorDebugChain interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugChain::GetActiveFrame Method

Gets the active (that is, most recent) frame on the chain.

## Syntax

```cpp
HRESULT GetActiveFrame (
    [out] ICorDebugFrame   **ppFrame
);
```

## Parameters

 `ppFrame`
 [out] A pointer to the address of an ICorDebugFrame object that represents the active (that is, most recent) frame on the chain.

## Remarks

If no managed stack frame is available, `ppFrame` is set to null.

If the active frame is not available, the call will succeed and `ppFrame` will be null. Active frames will not be available for chains initiated due to CHAIN_ENTER_UNMANAGED, and for some chains initiated due to CHAIN_CLASS_INIT. See the CorDebugChainReason enumeration.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
