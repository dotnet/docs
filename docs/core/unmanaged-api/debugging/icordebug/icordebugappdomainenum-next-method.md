---
description: "Learn more about: ICorDebugAppDomainEnum::Next Method"
title: "ICorDebugAppDomainEnum::Next Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugAppDomainEnum.Next"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugAppDomainEnum::Next method"
helpviewer_keywords:
  - "ICorDebugAppDomainEnum::Next method [.NET debugging]"
  - "Next method, ICorDebugAppDomainEnum interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugAppDomainEnum::Next Method

Gets the specified number of application domains from the collection, starting at the current cursor position.

## Syntax

```cpp
HRESULT Next (
    [in] ULONG celt,
    [out, size_is(celt), length_is(*pceltFetched)]
                           ICorDebugAppDomain *values[],
    [out] ULONG *pceltFetched
);
```

## Parameters

 `celt`
 [in] The number of application domains to be retrieved.

 `values`
 [out] An array of pointers, each of which points to an ICorDebugAppDomain object that represents an application domain.

 `pceltFetched`
 [out] A pointer to the number of application domains actually returned. This value may be null if `celt` is one.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
