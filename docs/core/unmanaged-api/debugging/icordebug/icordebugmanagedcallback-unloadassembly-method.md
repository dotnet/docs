---
description: "Learn more about: ICorDebugManagedCallback::UnloadAssembly Method"
title: "ICorDebugManagedCallback::UnloadAssembly Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugManagedCallback.UnloadAssembly"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugManagedCallback::UnloadAssembly"
helpviewer_keywords:
  - "ICorDebugManagedCallback::UnloadAssembly method [.NET debugging]"
  - "UnloadAssembly method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugManagedCallback::UnloadAssembly Method

Notifies the debugger that a common language runtime assembly has been unloaded.

## Syntax

```cpp
HRESULT UnloadAssembly (
    [in] IcorDebugAppDomain  *pAppDomain,
    [in] ICorDebugAssembly   *pAssembly
);
```

## Parameters

 `pAppDomain`
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain that contained the assembly.

 `pAssembly`
 [in] A pointer to an ICorDebugAssembly object that represents the assembly.

## Remarks

 The assembly should not be used after this callback.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [LoadAssembly Method](icordebugmanagedcallback-loadassembly-method.md)
- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)
