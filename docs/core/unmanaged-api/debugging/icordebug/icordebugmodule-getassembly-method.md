---
description: "Learn more about: ICorDebugModule::GetAssembly Method"
title: "ICorDebugModule::GetAssembly Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugModule.GetAssembly"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugModule::GetAssembly"
helpviewer_keywords:
  - "ICorDebugModule::GetAssembly method [.NET debugging]"
  - "GetAssembly method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugModule::GetAssembly Method

Gets the containing assembly for this module.

## Syntax

```cpp
HRESULT GetAssembly(
    [out] ICorDebugAssembly **ppAssembly
);
```

## Parameters

 `ppAssembly`
 [out] A pointer to an ICorDebugAssembly object that represents the assembly containing this module.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
