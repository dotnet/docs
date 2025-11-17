---
description: "Learn more about: ICorDebugAssemblyEnum::Next Method"
title: "ICorDebugAssemblyEnum::Next Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugAssemblyEnum.Next"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugAssemblyEnum::Next method"
helpviewer_keywords:
  - "ICorDebugAssemblyEnum::Next method [.NET debugging]"
  - "Next method, ICorDebugAssemblyEnum interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugAssemblyEnum::Next Method

Gets the specified number of assemblies from the collection, starting at the current cursor position.

## Syntax

```cpp
HRESULT Next (
    [in] ULONG celt,
    [out, size_is(celt), length_is(*pceltFetched)]
        ICorDebugAssembly *values[],
    [out] ULONG *pceltFetched
);
```

## Parameters

 `celt`
 [in] The number of assemblies to be retrieved.

 `values`
 [out] An array of pointers, each of which points to an ICorDebugAssembly object that represents an assembly.

 `pceltFetched`
 [out] A pointer to the number of assemblies actually returned. This value may be null if `celt` is one.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
