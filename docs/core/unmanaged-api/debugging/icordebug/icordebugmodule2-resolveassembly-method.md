---
description: "Learn more about: ICorDebugModule2::ResolveAssembly Method"
title: "ICorDebugModule2::ResolveAssembly Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugModule2.ResolveAssembly"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugModule2::ResolveAssembly"
helpviewer_keywords:
  - "ICorDebugModule2::ResolveAssembly method [.NET debugging]"
  - "ResolveAssembly method [.NET debugging]"
topic_type:
  - "apiref"
---

# ICorDebugModule2::ResolveAssembly Method

Resolves the assembly referenced by the specified metadata token.

## Syntax

```cpp
HRESULT ResolveAssembly (
    [in]  mdToken             tkAssemblyRef,
    [out] ICorDebugAssembly   **ppAssembly
);
```

## Parameters

`tkAssemblyRef`\
[in] An `mdToken` value that references the assembly.

`ppAssembly`\
[out] A pointer to the address of an ICorDebugAssembly object that represents the assembly.

## Remarks

If the assembly is not already loaded when `ResolveAssembly` is called, an HRESULT value of CORDBG_E_CANNOT_RESOLVE_ASSEMBLY is returned.

## Requirements

**Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

**Header:** CorDebug.idl, CorDebug.h

**Library:** CorGuids.lib

**.NET versions:** Available since .NET Framework 2.0
