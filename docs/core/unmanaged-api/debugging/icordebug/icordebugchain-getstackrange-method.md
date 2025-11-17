---
description: "Learn more about: ICorDebugChain::GetStackRange Method"
title: "ICorDebugChain::GetStackRange Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugChain.GetStackRange"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugChain::GetStackRange"
helpviewer_keywords:
  - "ICorDebugChain::GetStackRange method [.NET debugging]"
  - "GetStackRange method, ICorDebugChain interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugChain::GetStackRange Method

Gets the address range of the stack segment for this chain.

## Syntax

```cpp
HRESULT GetStackRange (
    [out] CORDB_ADDRESS      *pStart,
    [out] CORDB_ADDRESS      *pEnd
);
```

## Parameters

 `pStart`
 [out] A pointer to a `CORDB_ADDRESS` value that is the starting address of the stack segment.

 `pEnd`
 [out] A pointer to a `CORDB_ADDRESS` value that is the ending address of the stack segment.

## Remarks

The numeric range is meaningful only for comparison of stack frame locations. You cannot make any assumptions about what is actually stored on the stack.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
