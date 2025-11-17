---
description: "Learn more about: ICorDebugAppDomain::EnumerateAssemblies Method"
title: "ICorDebugAppDomain::EnumerateAssemblies Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugAppDomain.EnumerateAssemblies"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugAppDomain::EnumerateAssemblies"
helpviewer_keywords:
  - "ICorDebugAppDomain::EnumerateAssemblies method [.NET debugging]"
  - "EnumerateAssemblies method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugAppDomain::EnumerateAssemblies Method

Gets an enumerator for the assemblies in the application domain.

## Syntax

```cpp
HRESULT EnumerateAssemblies (
    [out] ICorDebugAssemblyEnum  **ppAssemblies
);
```

## Parameters

 `ppAssemblies`
 [out] A pointer to the address of an ICorDebugAssemblyEnum object that is the enumerator for the assemblies in the application domain.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
