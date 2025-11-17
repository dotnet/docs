---
description: "Learn more about: ICorDebugChainEnum::Next Method"
title: "ICorDebugChainEnum::Next Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugChainEnum.Next"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugChainEnum::Next"
helpviewer_keywords:
  - "ICorDebugChainEnum::Next method [.NET debugging]"
  - "Next method, ICorDebugChainEnum interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugChainEnum::Next Method

Gets the specified number of ICorDebugChain instances from the enumeration, starting at the current position.

## Syntax

```cpp
HRESULT Next (
    [in] ULONG  celt,
    [out, size_is(celt), length_is(*pceltFetched)]
        ICorDebugChain *chains[],
    [out] ULONG *pceltFetched
);
```

## Parameters

 `celt`
 [in] The number of `ICorDebugChain` instances to be retrieved.

 `chains`
 [out] An array of pointers, each of which points to an `ICorDebugChain` object that represents a chain.

 `pceltFetched`
 [out] A pointer to the number of `ICorDebugChain` instances actually returned. This value may be null if `celt` is one.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
