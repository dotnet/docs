---
description: "Learn more about: ICorDebugModule::IsDynamic Method"
title: "ICorDebugModule::IsDynamic Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugModule.IsDynamic"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugModule::IsDynamic"
helpviewer_keywords:
  - "IsDynamic method [.NET debugging]"
  - "ICorDebugModule::IsDynamic method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugModule::IsDynamic Method

Gets a value that indicates whether this module is dynamic.

## Syntax

```cpp
HRESULT IsDynamic(
    [out] BOOL *pDynamic
);
```

## Parameters

 `pDynamic`
 [out] `true` if this module is dynamic; otherwise, `false`.

## Remarks

 A dynamic module can add new classes and delete existing classes even after the module has been loaded. The [ICorDebugManagedCallback::LoadClass](icordebugmanagedcallback-loadclass-method.md) and [ICorDebugManagedCallback::UnloadClass](icordebugmanagedcallback-unloadclass-method.md) callbacks inform the debugger when a class has been added or deleted.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
