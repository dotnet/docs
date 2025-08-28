---
description: "Learn more about: ICorDebugAssembly::EnumerateModules Method"
title: "ICorDebugAssembly::EnumerateModules Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugAssembly.EnumerateModules"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugAssembly::EnumerateModules"
helpviewer_keywords:
  - "ICorDebugAssembly::EnumerateModules method [.NET debugging]"
  - "EnumerateModules method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugAssembly::EnumerateModules Method

Gets an enumerator for the modules contained in the `ICorDebugAssembly`.

## Syntax

```cpp
HRESULT EnumerateModules (
    [out] ICorDebugModuleEnum **ppModules
);
```

## Parameters

 `ppModules`
 [out] A pointer to the address of the ICorDebugModuleEnum interface that is the enumerator.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
